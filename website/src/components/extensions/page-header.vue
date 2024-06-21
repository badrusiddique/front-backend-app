<template>
  <div class="pageHeader">
    <h1>{{ text }}</h1>
  </div>
</template>

<script>
export default {
  name: 'page-header',

  props: {
    text: { type: String, required: true },
  },
};
</script>
