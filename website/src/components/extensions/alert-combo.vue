<template>
  <fragment name="alert-combo">
    <ui-alert
      v-if="error"
      ref="error"
      type="danger"
      class="alert"
      @alertclosed="handleErrorAlert"
    >
      {{ error }}
    </ui-alert>
    <ui-alert
      v-if="success"
      ref="success"
      type="success"
      class="alert"
      @alertclosed="handleSuccessAlert"
    >
      {{ success }}
    </ui-alert>
  </fragment>
</template>

<script>
import { UIAlert } from 'ui-framework';

export default {
  name: 'alert-combo',

  components: {
    'ui-alert': UIAlert,
  },

  props: {
    error: { type: [String, Boolean], default: false },
    success: { type: [String, Boolean], default: false },
  },

  methods: {
    handleErrorAlert() {
      this.$emit('handleErrorAlert');
    },

    handleSuccessAlert() {
      this.$emit('handleSuccessAlert');
    },
  },
};
</script>

<style scoped>
.alert {
  margin-top: 15px;
}
</style>
