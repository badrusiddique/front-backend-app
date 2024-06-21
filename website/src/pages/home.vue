<template>
  <div class="home-page">
    <page-header
      data-test="home-page-header"
      text="Welcome to Sample Website"
    />
  </div>
</template>

<script>
import PageHeader from '../components/extensions/page-header.vue';

export default {
  name: 'home-page',

  components: {
    'page-header': PageHeader,
  },
};
</script>
