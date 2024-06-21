<template>
  <ui-modal
    v-if="modalIsOpen"
    :active="modalIsOpen"
    size="medium"
    title="Confirm Delete"
    disable-background-click
    @toggle="handleToggle"
  >
    <p>
      Are you sure you want to permanently delete this item and all its dependent content?
    </p>
    <ui-button
      slot="buttons"
      data-test="delete-modal"
      type="danger"
      size="small"
      @click="handleNavigation"
    >
      Delete
    </ui-button>
  </ui-modal>
</template>

<script>
import { UIButton, UIModal } from 'ui-framework';

export default {
  name: 'delete-modal',

  components: {
    'ui-modal': UIModal,
    'ui-button': UIButton,
  },

  props: {
    modalIsOpen: { type: Boolean, default: false },
  },

  methods: {
    handleToggle() {
      this.$emit('toggleModal', false);
    },

    handleNavigation() {
      this.$emit('allowNavigation');
    },
  },
};
</script>
