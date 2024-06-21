const { mockRequest: req, mockResponse: res } = require('mock-req-res');

const session = {
  idToken: 'some token',
  session: {
    metadata: {
      appBaseUrl: 'app-base-url',
    },
  },
};

const app = {
  locals: {
    originalUrl: 'original-url',
  },
};

const logger = {
  info: () => {},
  warn: () => {},
  error: () => {},
};

const mockRequest = () => ({
  ...req(),
  app,
  logger,
  session,
});

const mockResponse = () => res();

module.exports = {
  mockRequest,
  mockResponse,
};
