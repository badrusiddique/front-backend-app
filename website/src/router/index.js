import Vue from 'vue';
import VueRouter from 'vue-router';

import routes from './routes';
import { deepProp } from '../shared/rambda-extension';
import { redirectToUrl } from '../shared/http-extension';

Vue.use(VueRouter);

const failurePattern = /\bLoading chunk (\D)+failed./g;

const beforeEachRoute = async (_to, _from, next) => {
  next();
};

const router = new VueRouter({
  routes,
  mode: 'history',
  base: process.env.BASE_URL || '/',
});

router.onError( async ({ message = '' }) => {
  const isChunkLoadFailed = message.match(failurePattern);
  const url = deepProp(['history', 'pending', 'fullPath'], router) || '/';
  if (isChunkLoadFailed){
    console.error(`Chunk_Loading_Failed: ${message}. Trying to reloaded ${url} `);
    await redirectToUrl(url);
  }
});

router.beforeEach(beforeEachRoute);

export default router;
