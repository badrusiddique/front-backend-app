const errorResponse = {
  response: {
    data: {
      Error: 'some-error',
      StatusCode: 'some-status-code',
    },
    statusText: 'some-status-text',
    status: 'some-status',
  },
};

const healthChecksResponse = {
  status: 'Healthy',
  azureAd: {
    status: 'Healthy',
    ur: 'http://azure-health-url',
    isRequired: true,
  },
  webapi: {
    status: 'Healthy',
    url: 'http://webapi-health-url',
    isRequired: true,
  },
  redis: {
    status: 'Healthy',
    url: 'http://redis-health-url',
    isRequired: true,
  },
};

const config = {
  loggerLevel: 'info',
  issuer: 'sample-issuer',
  loggerStreams: ['console'],
  clientId: 'sample-client-id',
  jwksUri: 'http://sample-jwks-uri',
  clientSecret: 'sample-client-secret',
  tokenEndpoint: 'http://sample-endpoint',
  userinfoEndpoint: 'http://sample-user-info',
  authorizationEndpoint: 'http://sample-auth-url',
  azureLogoutEndpoint: 'http://sample-logout-url',
};

module.exports = {
  config,
  errorResponse,
  healthChecksResponse,
};
