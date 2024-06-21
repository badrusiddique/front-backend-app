<template>
  <div class="measurement-create">
    <page-header
      text="Measurement Details"
      data-test="measurement-create-page-header"
    />
    <create-measurement
      data-test="measurement-create-create-measurement"
    />
  </div>
</template>

<script>
import PageHeader from '../../components/extensions/page-header.vue';
import CreateMeasurement from '../../components/measurements/create-measurement.vue';

export default {
  name: 'measurement-create-view',

  components: {
    'page-header': PageHeader,
    'create-measurement': CreateMeasurement,
  },
};
</script>
