import Vue from 'vue';
import Vuelidate from 'vuelidate';
import { Plugin } from 'vue-fragment';
import VuelidateErrorExtractor from 'vuelidate-error-extractor';

import App from './app.vue';
import router from './router';
import store from './store';
import { nodeEnv } from './shared/config';

Vue.use(Plugin);
Vue.use(Vuelidate);
Vue.config.productionTip = false;
Vue.use(VuelidateErrorExtractor, { i18n: false });

console.log(`Running Sample-Website under ${nodeEnv} environment`);

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
