<template>
  <fragment name="delete-measurement">
    <ui-spinner
      v-if="isLoading"
      overlay
      size="small"
      position-y="middle"
    />
    <delete-combo
      :show-alert="hasError"
      @handleDelete="handleDelete"
      @handleCancel="handleCancel"
    />
  </fragment>
</template>

<script>
import { mapActions } from 'vuex';
import { UISpinner } from 'ui-framework';
import { hasValue } from '../../shared/rambda-extension';
import DeleteCombo from '../extensions/delete-combo.vue';
import { expandableTypes } from '../../shared/constant';

const { measurementDetails } = expandableTypes;

export default {
  name: 'delete-measurement',

  components: {
    'ui-spinner': UISpinner,
    'delete-combo': DeleteCombo,
  },

  props: {
    id: { type: String, required: true },
  },

  data() {
    return {
      schema: {},
      hasError: false,
      isLoading: false,
    };
  },

  methods: {
    ...mapActions('measurements', ['deleteMeasurement']),

    constructOptions: (id) => ({
      params: { id },
      query: { expand: measurementDetails },
    }),

    changeRoute(name, options = {}) {
      this.$router.push({ name, ...options});
    },

    handleCancel() {
      const options = this.constructOptions(this.id);
      this.changeRoute('view-measurement', options);
    },

    async handleDelete() {
      this.isLoading = true;
      const { error } = (await this.deleteMeasurement(this.id)) || {};
      this.handleNavigation(error);
      this.isLoading = false;
    },

    handleNavigation(error) {
      this.hasError = hasValue(error);
      if (!this.hasError) {
        this.changeRoute('measurements');
      }
    },
  },
};
</script>
