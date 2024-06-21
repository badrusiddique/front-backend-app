<template>
  <ui-card>
    <ui-spinner
      v-if="isLoading"
      overlay
      size="small"
      position-y="middle"
    />
    <card-header
      class="card-header-container"
      text="Create Measurement"
    />
    <form-group
      :schema="schema"
      :validators="$v.schema"
      :error-messages="validationMessages"
      @handleChange="handleChange"
    />
    <submit-combo
      :enable-submit="true"
      :error-message="errorMessage"
      @handleCancel="handleCancel"
      @handleSubmit="handleSubmit"
      @handleErrorAlert="handleErrorAlert"
    />
  </ui-card>
</template>

<script>
import { mapActions } from 'vuex';
import { UICard, UISpinner } from 'ui-framework';
import FormGroup from '../extensions/form-group.vue';
import CardHeader from '../extensions/card-header.vue';
import { expandableTypes } from '../../shared/constant';
import SubmitCombo from '../extensions/submit-combo.vue';
import { createFormSchema } from '../../ui-metadata/measurement-schema';
import { formatRequestData, formatValidationData } from '../../utility/form-util';
import {
  trim,
  clone,
  isBlank,
  deepProp,
} from '../../shared/rambda-extension';

const { measurementDetails } = expandableTypes;

export default {
  name: 'create-measurement',

  components: {
    'ui-card': UICard,
    'form-group': FormGroup,
    'ui-spinner': UISpinner,
    'card-header': CardHeader,
    'submit-combo': SubmitCombo,
  },

  data() {
    return {
      validators: {},
      isLoading: false,
      errorMessage: null,
      validationMessages: {},
      schema: clone(createFormSchema),
    };
  },

  async beforeMount() {
    const { rules, messages } = (await formatValidationData(this.schema)) || {};
    this.validators = rules || {};
    this.validationMessages = messages || {};
  },

  methods: {
    ...mapActions('measurements', ['createMeasurement']),

    handleErrorAlert() {
      this.errorMessage = null;
    },

    constructOptions: (id) => ({
      params: { id },
      query: { expand: measurementDetails },
    }),

    changeRoute(name, options = {}) {
      this.$router.push({ name, ...options });
    },

    handleChange({ key, value }) {
      this.$v.schema[key].$touch();
      this.schema[key].value = trim(value || '');
    },

    handleCancel() {
      this.changeRoute('measurements');
    },

    async handleSubmit() {
      this.$v.$touch();
      if (this.$v.$error) { return; }

      this.isLoading = true;
      const requestData = await formatRequestData(this.schema);
      const response = (await this.createMeasurement(requestData)) || {};
      this.handleSubmitCallback(response);
    },

    handleSubmitCallback({ data, error }) {
      this.isLoading = false;
      this.errorMessage = error;
      if (isBlank(error)) {
        const options = this.constructOptions(deepProp(['id'], data));
        this.changeRoute('view-measurement', options);
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
