<template>
  <div
    id="deleteCombo"
    class="delete-combobox"
  >
    <delete-modal
      :modal-is-open="modalIsOpen"
      @toggleModal="toggleModal"
      @allowNavigation="handleContinue"
    />
    <ui-button
      v-if="showDelete"
      :ref="deleteLabel"
      data-test="delete"
      type="danger"
      size="small"
      @click="onDelete"
    >
      {{ deleteLabel }}
    </ui-button>
    <ui-button
      :ref="cancelLabel"
      outline
      size="small"
      @click="onCancel"
    >
      {{ cancelLabel }}
    </ui-button>
    <ui-alert
      v-if="showAlert"
      type="danger"
      class="error-alert"
    >
      {{ errorMessage }}
    </ui-alert>
  </div>
</template>

<script>
import { UIAlert, UIButton } from 'ui-framework';
import DeleteModal from '../extensions/delete-modal.vue';

export default {
  name: 'delete-combo',

  components: {
    'ui-alert': UIAlert,
    'ui-button': UIButton,
    'delete-modal': DeleteModal,
  },

  props: {
    showAlert: Boolean,
    showDelete: { type: Boolean, default: true },
    cancelLabel: { type: String, default: 'Cancel' },
    deleteLabel: { type: String, default: 'Delete' },
  },

  data() {
    return {
      modalIsOpen: false,
      errorMessage:  'Delete failed due to a server issue. Please report the issue to support centre and try again later.',
    };
  },

  methods: {
    toggleModal() {
      this.modalIsOpen = false;
    },

    onDelete() {
      this.modalIsOpen = true;
    },

    onCancel() {
      this.$emit('handleCancel');
    },

    handleContinue() {
      this.modalIsOpen = false;
      this.$emit('handleDelete');
    },
  },
};
</script>

<style scoped>
.delete-combobox {
  margin-top: 30px;
}

.delete-combobox > button {
  margin-left: 15px;
}

.error-alert {
  margin-top: 15px;
}
</style>
