const tunnel = require('tunnel');

const {
  port,
  httpOptionsTimeout,
} = require('../../config');
const { deepProp } = require('../../shared/rambda-extension');

const httpsAgentOption = {
  https: tunnel.httpsOverHttp({
    proxy: {
      port,
    },
  }),
};

const agentOptions = () => httpsAgentOption;

const httpOptions = {
  timeout: httpOptionsTimeout,
  agent: agentOptions() || null,
};

const httpsAgentOptions = deepProp(['https'], agentOptions());

module.exports = {
  httpOptions,
  httpsAgentOptions,
};
