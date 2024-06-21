<template>
  <div id="app">
    <ui-spinner
      v-if="isLoading"
      overlay
      size="small"
      position-y="middle"
    />
    <ui-layout
      v-else
      toggle
      full-width
      logo-router
      :logo="logo"
      logo-link="/"
      toggle-type="full"
      :current-page="$route"
      :side-nav="$router.options.routes"
    >
      <div
        slot="content"
        class="pageContent"
      >
        <div
          class="container-fluid"
          style="margin-left: 0;"
        >
          <transition name="navigate-page">
            <router-view class="mt-2" />
          </transition>
        </div>
      </div>

      <div slot="search">
        <div class="row">
          <div
            style="font-weight: bold; padding-top: 5px; font-size: 1.2rem; color: #003168;"
          >
            Sample Website
            <ui-button
              size="small"
              title="Help"
              color="transparent"
              icon="fas fa-question-circle"
            />
          </div>
          <div style="padding-left: 5px; padding-right: 5px; border-left: 2px dotted #003168;">
            <div class="row col">
              Version: {{ version }}
            </div>
          </div>
        </div>
      </div>
    </ui-layout>
  </div>
</template>

<script>
import {
  UIButton,
  UILayout,
  UISpinner,
} from 'ui-framework';

export default {
  name: 'app',

  components: {
    'ui-layout': UILayout,
    'ui-button': UIButton,
    'ui-spinner': UISpinner,
  },

  data() {
    return {
      isLoading: false,
      version: '1.0.0',
      modalIsOpen: false,
      logo: 'https://raw.githubusercontent.com/fluent-vue/docs/HEAD/src/public/assets/logo.svg',
    };
  },

  errorCaptured(err, vm) {
    console.error(`Unknown error occurred at ${vm.$options.name} component: ${err}`);
  },
};
</script>

<style lang="scss">
@import 'styles/global.css';
@import url('https://maxcdn.bootstrapcdn.com/bootstrap/latest/css/bootstrap-grid.min.css');
@import url('https://fonts.googleapis.com/css?family=Fira+Sans:300,400,400i,500,700%7CRoboto:300,400,400i,500,700');
</style>
