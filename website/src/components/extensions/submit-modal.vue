<template>
  <ui-modal
    v-if="modalIsOpen"
    :active="modalIsOpen"
    size="medium"
    title="Confirm Save"
    disable-background-click
    @toggle="handleToggle"
  >
    <p>
      {{ message }}
    </p>
    <ui-button
      slot="buttons"
      data-test="delete-modal"
      size="small"
      @click="handleSubmit"
    >
      Save Changes
    </ui-button>
  </ui-modal>
</template>

<script>
import { UIButton, UIModal } from 'ui-framework';

export default {
  name: 'submit-modal',

  components: {
    'ui-modal': UIModal,
    'ui-button': UIButton,
  },

  props: {
    modalIsOpen: { type: Boolean, default: false },
    message: { type: String, default: 'Are you sure you want save this item?' },
  },

  methods: {
    handleToggle() {
      this.$emit('toggleModal', false);
    },

    handleSubmit() {
      this.$emit('allowSubmit');
    },
  },
};
</script>
