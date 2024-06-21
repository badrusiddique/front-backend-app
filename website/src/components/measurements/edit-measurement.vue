<template>
  <card-expandable
    :is-loading="isLoading"
    header-text="View Measurement Information"
    :expanded="isCardExpanded"
  >
    <fragment
      slot="contentBody"
      name="card-content-body"
    >
      <form-group
        :schema="schema"
        :validators="$v.schema"
        :error-messages="validationMessages"
        @handleChange="handleChange"
      />
      <submit-combo
        :show-cancel="false"
        :enable-submit="true"
        :error-message="errorMsg"
        :success-message="successMsg"
        @handleSubmit="handleSubmit"
        @handleErrorAlert="handleErrorAlert"
        @handleSuccessAlert="handleSuccessAlert"
      />
    </fragment>
  </card-expandable>
</template>

<script>
import { mapActions } from 'vuex';
import FormGroup from '../extensions/form-group.vue';
import { expandableTypes } from '../../shared/constant';
import SubmitCombo from '../extensions/submit-combo.vue';
import CardExpandable from '../extensions/card-expandable.vue';
import { editFormSchema } from '../../ui-metadata/measurement-schema';
import { trim, isBlank, hasValue } from '../../shared/rambda-extension';
import {
  formatFormData,
  formatRequestData,
  formatValidationData,
} from '../../utility/form-util';

const { measurementDetails } = expandableTypes;

export default {
  name: 'edit-measurement',

  components: {
    'form-group': FormGroup,
    'submit-combo': SubmitCombo,
    'card-expandable': CardExpandable,
  },

  props: {
    id: { type: String, required: true },
    expand: { type: String, default: null },
  },

  data() {
    return {
      schema: {},
      validators: {},
      errorMsg: null,
      isLoading: false,
      successMsg: null,
      isDataLoaded: false,
      isCardExpanded: false,
      validationMessages: {},
    };
  },

  async beforeMount() {
    this.isLoading = true;
    await this.loadData();
    this.isCardExpanded = this.expand === measurementDetails;
    this.isLoading = false;
  },

  methods: {
    ...mapActions('measurements', [
      'updateMeasurement',
      'getMeasurementById',
    ]),

    changeRoute(name) {
      this.$router.push({ name });
    },

    async handleResponseData(data) {
      this.schema = await formatFormData(data, editFormSchema);
      await this.populateFormData(this.schema);
      this.isDataLoaded = true;
    },

    async loadData() {
      if (this.isDataLoaded) { return; }

      const { data, code } = (await this.getMeasurementById(this.id)) || {};
      hasValue(data)
        ? await this.handleResponseData(data)
        : code === 404 && this.changeRoute('page-not-found');
    },

    async populateFormData(schema) {
      const { rules, messages } = (await formatValidationData(schema)) || {};
      this.validators = rules || {};
      this.validationMessages = messages || {};
    },

    handleErrorAlert() {
      this.errorMsg = null;
    },

    handleSuccessAlert() {
      this.successMsg = null;
    },

    handleChange({ key, value }) {
      this.$v.schema[key].$touch();
      this.schema[key].value = isNaN(value) ? trim(value || '') : value;
    },

    async handleSubmit() {
      this.$v.$touch();
      if (this.$v.$error) { return; }

      const id = this.id;
      this.isLoading = true;
      const data = await formatRequestData(this.schema);
      const result = (await this.updateMeasurement({ id, data })) || {};
      this.handleSubmitCallback(result);
    },

    handleSubmitCallback({ error }) {
      this.isLoading = false;
      this.errorMsg = error;
      if (isBlank(error)) {
        this.successMsg = 'Save was successful.';
        this.changeRoute('measurements');
      }
    },
  },

  validations() {
    return {
      schema: this.validators,
    };
  },
};
</script>
