<template>
  <card-expandable
    :is-loading="isLoading"
    header-text="View Measurement Information"
    :expanded="isCardExpanded"
  >
    <ui-button
      v-if="isCardExpanded"
      slot="headerContent"
      class="edit-button-icon"
      title="Edit"
      icon="edit"
      color="white"
      data-test="edit"
      @click="handleEdit"
    />
    <form-group
      slot="contentBody"
      :schema="schema"
    />
  </card-expandable>
</template>

<script>
import { mapActions } from 'vuex';
import { UIButton } from 'ui-framework';
import FormGroup from '../extensions/form-group.vue';
import { expandableTypes } from '../../shared/constant';
import { formatFormData } from '../../utility/form-util';
import { hasValue } from '../../shared/rambda-extension';
import CardExpandable from '../extensions/card-expandable.vue';
import { viewFormSchema} from '../../ui-metadata/measurement-schema';

const { measurementDetails } = expandableTypes;

export default {
  name: 'view-measurement',

  components: {
    'ui-button': UIButton,
    'form-group': FormGroup,
    'card-expandable': CardExpandable,
  },

  props: {
    id: { type: String, required: true },
    expand: { type: String, default: null },
  },

  data() {
    return {
      schema: {},
      isLoading: false,
      isDataLoaded: false,
      isCardExpanded: false,
    };
  },

  async beforeMount() {
    this.isLoading = true;
    await this.loadData();
    this.isCardExpanded = this.expand === measurementDetails;
    this.isLoading = false;
  },

  methods: {
    ...mapActions('measurements', ['getMeasurementById']),

    changeRoute(name, options) {
      this.$router.push({ name, ...options });
    },

    constructOptions: (id) => ({
      params: { id },
      query: { expand: measurementDetails },
    }),

    async handleResponseData(data) {
      this.$emit('handleDataCallback', data);
      this.schema = await formatFormData(data, viewFormSchema);
      this.isDataLoaded = true;
    },

    async loadData() {
      if (this.isDataLoaded) { return; }

      const { data, code } = (await this.getMeasurementById(this.id)) || {};
      hasValue(data)
        ? await this.handleResponseData(data)
        : code === 404 && this.changeRoute('page-not-found');
    },

    handleEdit() {
      const options = this.constructOptions(this.id);
      this.changeRoute('edit-measurement', options);
    },
  },
};
</script>

<style scoped>
.edit-button-icon {
  padding-top: 0;
  font-size: 20px;
  padding-bottom: 0;
}
</style>
<template>
  <card-expandable
    :is-loading="isLoading"
    header-text="View Measurement Information"
    :expanded="isCardExpanded"
  >
    <ui-button
      v-if="isCardExpanded"
      slot="headerContent"
      class="edit-button-icon"
      title="Edit"
      icon="edit"
      color="white"
      data-test="edit"
      @click="handleEdit"
    />
    <form-group
      slot="contentBody"
      :schema="schema"
    />
  </card-expandable>
</template>

<script>
import { mapActions } from 'vuex';
import { UIButton } from 'ui-framework';
import FormGroup from '../extensions/form-group.vue';
import { expandableTypes } from '../../shared/constant';
import { formatFormData } from '../../utility/form-util';
import { hasValue } from '../../shared/rambda-extension';
import CardExpandable from '../extensions/card-expandable.vue';
import { viewFormSchema} from '../../ui-metadata/measurement-schema';

const { measurementDetails } = expandableTypes;

export default {
  name: 'view-measurement',

  components: {
    'ui-button': UIButton,
    'form-group': FormGroup,
    'card-expandable': CardExpandable,
  },

  props: {
    id: { type: String, required: true },
    expand: { type: String, default: null },
  },

  data() {
    return {
      schema: {},
      isLoading: false,
      isDataLoaded: false,
      isCardExpanded: false,
    };
  },

  async beforeMount() {
    this.isLoading = true;
    await this.loadData();
    this.isCardExpanded = this.expand === measurementDetails;
    this.isLoading = false;
  },

  methods: {
    ...mapActions('measurements', ['getMeasurementById']),

    changeRoute(name, options) {
      this.$router.push({ name, ...options });
    },

    constructOptions: (id) => ({
      params: { id },
      query: { expand: measurementDetails },
    }),

    async handleResponseData(data) {
      this.$emit('handleDataCallback', data);
      this.schema = await formatFormData(data, viewFormSchema);
      this.isDataLoaded = true;
    },

    async loadData() {
      if (this.isDataLoaded) { return; }

      const { data, code } = (await this.getMeasurementById(this.id)) || {};
      hasValue(data)
        ? await this.handleResponseData(data)
        : code === 404 && this.changeRoute('page-not-found');
    },

    handleEdit() {
      const options = this.constructOptions(this.id);
      this.changeRoute('edit-measurement', options);
    },
  },
};
</script>

<style scoped>
.edit-button-icon {
  padding-top: 0;
  font-size: 20px;
  padding-bottom: 0;
}
</style>
