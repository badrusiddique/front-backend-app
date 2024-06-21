import Vue from 'vue';
import Vuex from 'vuex';
import createLogger from 'vuex/dist/logger';

import modules from './modules';

Vue.use(Vuex);
const strict = process.env.NODE_ENV !== 'production';

export default new Vuex.Store({
  strict,
  modules,
  plugins: strict ? [createLogger()] : [],
});
