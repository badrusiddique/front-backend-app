const axios = require('axios');

const { httpsAgentOptions } = require('./options');
const { parseError } = require('../shared/error-handler');
const { deepProp } = require('../shared/rambda-extension');

const fetch = async (options, context) => {
  const { logger } = context || {};
  try {
    const { route } = options;
    const result = await axios.get(route, options);

    return deepProp(['data'], result);
  } catch (error) {
    logger.error(`fetchRequest: ${JSON.stringify(error)}`);
    throw parseError(error);
  }
};

const fetchRequest = async (options, context) => {
  const requestOptions = { ...options, httpsAgent: httpsAgentOptions };

  return fetch(requestOptions, context);
};

module.exports = {
  fetchRequest,
};
