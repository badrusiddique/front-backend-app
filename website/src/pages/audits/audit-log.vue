<template>
  <div className="audit-log-view">
    <page-header
      text="Audit Log"
      data-test="audit-log-page-header"
    />
    <audits-list data-test="audit-log-audit-list"/>
  </div>
</template>

<script>
import AuditsList from '../../components/audits/audits-list.vue';
import PageHeader from '../../components/extensions/page-header.vue';

export default {
  name: 'audit-log-view',

  components: {
    'audits-list': AuditsList,
    'page-header': PageHeader,
  },
};
</script>
