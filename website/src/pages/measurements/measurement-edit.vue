<template>
  <div class="measurement-edit-view">
    <page-header
      text="Measurement Details"
      data-test="measurement-edit-page-header"
    />
    <edit-measurement
      :id="id"
      :expand="expand"
      data-test="measurement-edit-edit-measurement"
    />
    <delete-measurement
      :id="id"
    />
  </div>
</template>

<script>
import PageHeader from '../../components/extensions/page-header.vue';
import EditMeasurement from '../../components/measurements/edit-measurement.vue';
import DeleteMeasurement from '../../components/measurements/delete-measurement.vue';

export default {
  name: 'measurement-edit-view',

  components: {
    'page-header': PageHeader,
    'edit-measurement': EditMeasurement,
    'delete-measurement': DeleteMeasurement,
  },

  props: {
    id: { type: String, required: true },
    expand: { type: String, default: null },
  },
};
</script>
