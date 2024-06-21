<template>
  <div class="measurement-detail-view">
    <page-header
      text="Measurement Details"
      data-test="measurement-detail-page-header"
    />
    <view-measurement
      :id="id"
      :expand="expand"
      data-test="measurement-detail-view-measurement"
    />
  </div>
</template>

<script>
import PageHeader from '../../components/extensions/page-header.vue';
import ViewMeasurement from '../../components/measurements/view-measurement.vue';

export default {
  name: 'measurement-detail-view',

  components: {
    'page-header': PageHeader,
    'view-measurement': ViewMeasurement,
  },

  props: {
    id: { type: String, required: true },
    expand: { type: String, default: null },
  },
};
</script>
