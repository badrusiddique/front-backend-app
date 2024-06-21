const proxy = require('express-http-proxy');

const { apiBaseUrl } = require('../config');

const options = {
  limit: '5mb',
  proxyReqPathResolver(req) {
    const { logger } = req;
    const url = `${apiBaseUrl}${req.originalUrl}`;
    logger.info(`proxyPathRequest redirecting to: ${url}`);

    return url;
  },
  proxyReqOptDecorator(proxyReqOpts) {
    return {
      ...proxyReqOpts,
      rejectUnauthorized: false,
    };
  },
  proxyErrorHandler(err, { req }) {
    const { logger } = req;
    logger.error(`proxyRequest an error occurred: ${JSON.stringify(err)}`);

    return err;
  },
};

module.exports = proxy(apiBaseUrl, options);
