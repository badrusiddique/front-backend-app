const router = require('../../router');
const apiProxyHandler = require('../../middlewares/api-proxy-handler');

router.use('/api', apiProxyHandler);
