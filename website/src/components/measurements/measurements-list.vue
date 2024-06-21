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
      text="Measurements List"
    />
    <ui-data-table
      id="measurementsListDataTable"
      sortable
      pagination
      global-search
      :rows="rows"
      :columns="columns"
      :pagination-display="paginationDisplay"
      :components-to-register="{ 'ui-button': UIButton }"
    />
  </ui-card>
</template>

<script>
import { mapActions } from 'vuex';
import {
  UICard,
  UIButton,
  UISpinner,
  UIDatatable,
} from 'ui-framework';
import { expandableTypes } from '../../shared/constant';
import CardHeader from '../extensions/card-header.vue';
import { constructDataTableRows } from '../../utility/datatable-util';
import { datatableSchema } from '../../ui-metadata/measurement-schema';
import { transformMeasurementsList } from '../../utility/transformations/measurements';

const { measurementDetails } = expandableTypes;

export default {
  name: 'measurements-list',

  components: {
    'ui-card': UICard,
    'ui-spinner': UISpinner,
    'card-header': CardHeader,
    'ui-data-table': UIDatatable,
  },

  data() {
    return {
      rows: [],
      columns: [],
      UIButton,
      isLoading: true,
      paginationDisplay: [10, 25, 50, 100],
      handlers: {
        handleEdit: this.handleEditClicked,
        handleView: this.handleViewClicked,
      },
    };
  },

  async beforeMount() {
    const { data } = (await this.getMeasurements()) || {};
    const measurements = await transformMeasurementsList(data);
    this.columns = await datatableSchema(this.handlers);
    this.rows = await constructDataTableRows(this.columns, measurements);
    this.isLoading = false;
  },

  methods: {
    ...mapActions('measurements', ['getMeasurements']),

    constructOptions: (id) => ({ params: { id }, query: { expand: measurementDetails } }),

    changeRoute(name, options) {
      this.$router.push({ name, ...options });
    },

    handleViewClicked(id) {
      const options = this.constructOptions(id);
      this.changeRoute('view-measurement', options);
    },

    handleEditClicked(id) {
      const options = this.constructOptions(id);
      this.changeRoute('edit-measurement', options);
    },
  },
};
</script>
