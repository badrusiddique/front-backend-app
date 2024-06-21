<template>
  <div class="card-header">
    <div class="row card-header-row">
      <div class="col-md-4">
        <h3 :style="textStyle">
          {{ text }}
        </h3>
      </div>
      <div class="card-header-buttons">
        <slot />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'card-header',

  props: {
    text: { type: String, required: true },
  },

  computed: {
    textStyle() {
      return {
        color: this.text.endsWith(' *') ? '#808080' : '#003168',
      };
    },
  },
};
</script>

<style scoped>
.card-header {
  width: 100%;
}

.card-header-row {
  justify-content: space-between;
}

.card-header-buttons {
  padding-right: 15px;
}
</style>
