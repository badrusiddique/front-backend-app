<template>
  <div class="row justify-content-center">
    <json-pretty
      ref="oldValues"
      class="col-6"
      show-length
      :path="'res'"
      :data="oldValues"
      highlight-mouseover-node
      :show-double-quotes="false"
    />
    <json-pretty
      ref="newValues"
      class="col-6"
      show-length
      :path="'res'"
      :data="newValues"
      highlight-mouseover-node
      :show-double-quotes="false"
    />
  </div>
</template>

<script>
import VueJsonPretty from 'vue-json-pretty';
import { deepProp } from '../../shared/rambda-extension';

export default {
  name: 'audit-view',

  components: {
    'json-pretty': VueJsonPretty,
  },

  props: {
    audit: { type: Object, default: () => ({}) },
  },

  computed: {
    oldValues() {
      return this.parseData('oldValues');
    },

    newValues() {
      return this.parseData('newValues');
    },
  },

  methods: {
    parseData(value) {
      const data = deepProp([value], this.audit) || null;
      return JSON.parse(data) || {};
    },
  },
};
</script>

<style scoped>
@import '../../styles/json-pretty.css';
</style>
