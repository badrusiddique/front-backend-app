<template>
  <div
    id="submitCombo"
    class="submit-combobox"
  >
    <submit-modal
      :message="modalMessage"
      :modal-is-open="modalIsOpen"
      @toggleModal="toggleModal"
      @allowSubmit="handleSubmit"
    />
    <ui-button
      ref="Save"
      :disabled="!enableSubmit"
      type="submit"
      size="small"
      data-test="submit"
      @click="onSubmit"
    >
      Save
    </ui-button>
    <ui-button
      v-if="showCancel"
      ref="Cancel"
      outline
      size="small"
      @click="onCancel"
    >
      Cancel
    </ui-button>
    <alert-combo
      :error="errorMessage"
      :success="successMessage"
      @handleErrorAlert="handleErrorAlert"
      @handleSuccessAlert="handleSuccessAlert"
    />
  </div>
</template>

<script>
import { UIButton } from 'ui-framework';
import AlertCombo from '../extensions/alert-combo.vue';
import SubmitModal from '../extensions/submit-modal.vue';

export default {
  name: 'submit-combo',

  components: {
    'ui-button': UIButton,
    'alert-combo': AlertCombo,
    'submit-modal': SubmitModal,
  },

  props: {
    showCancel: { type: Boolean, default: true },
    showModal: { type: Boolean, default: false },
    modalMessage: { type: String, default: null },
    enableSubmit: { type: Boolean, default: true },
    errorMessage: { type: [String, Boolean], default: false },
    successMessage: { type: [String, Boolean], default: false },
  },

  data() {
    return {
      modalIsOpen: false,
    };
  },

  methods: {
    toggleModal() {
      this.modalIsOpen = false;
    },

    onSubmit() {
      if (this.showModal) {
        this.modalIsOpen = true;
      } else {
        this.handleSubmit();
      }
    },

    onCancel() {
      this.$emit('handleCancel');
    },

    handleSubmit() {
      this.modalIsOpen = false;
      this.$emit('handleSubmit');
    },

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
.submit-combobox {
  margin-top: 25px;
}

.submit-combobox > button {
  margin-left: 15px;
}
</style>
