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
      text="Audit Log List"
    />
    <ui-data-table
      id="auditLogsListDataTable"
      sortable
      pagination
      expandable-row
      :rows="rows"
      :columns="columns"
      :pagination-display="paginationDisplay"
    >
      <template #expandable="{ row }">
        <audit-view :audit="getById(row.id)" />
      </template>
    </ui-data-table>
  </ui-card>
</template>

<script>
import { mapActions } from 'vuex';
import {
  UICard,
  UISpinner,
  UIDatatable,
} from 'ui-framework';
import AuditView from './audit-view.vue';
import CardHeader from '../extensions/card-header.vue';
import { constructDataTableRows } from '../../utility/datatable-util';
import { transformAuditsList } from '../../utility/transformations/audits';
import { datatableSchema } from '../../ui-metadata/audit-schema';
import { find, deepPropEq } from '../../shared/rambda-extension';

export default {
  name: 'audits-list',

  components: {
    'ui-card': UICard,
    'audit-view': AuditView,
    'ui-spinner': UISpinner,
    'card-header': CardHeader,
    'ui-data-table': UIDatatable,
  },

  data() {
    return {
      rows: [],
      audits: {},
      columns: [],
      isLoading: true,
      paginationDisplay: [10, 25, 50, 100],
    };
  },

  async beforeMount() {
    await this.loadDatatable();
  },

  methods: {
    ...mapActions('audits', ['getAudits']),

    getById(id) {
      return find(deepPropEq(['id'], id), this.audits);
    },

    async transformRows(data, columns) {
      const transformedAudits = await transformAuditsList(data);
      return await constructDataTableRows(columns, transformedAudits);
    },

    async loadDatatable() {
      this.isLoading = true;
      this.columns = await datatableSchema();
      const { data } = await this.getAudits() || {};
      this.audits = data || [];
      this.rows = await this.transformRows(this.audits, this.columns);
      this.isLoading = false;
    },
  },
};
</script>
