<template>
  <div class="measurements-view">
    <page-header
      text="Measurements"
      data-test="measurements-page-header"
    />
    <measurements-list data-test="measurements-measurements-list" />
  </div>
</template>

<script>
import PageHeader from '../../components/extensions/page-header.vue';
import MeasurementsList from '../../components/measurements/measurements-list.vue';

export default {
  name: 'measurements-view',

  components: {
    'page-header': PageHeader,
    'measurements-list': MeasurementsList,
  },
};
</script>
