// urls
const apiBaseUrl = process.env.SAMPLE_API_URL || 'https://localhost:8086';

const port = process.env.PORT || 8080;

const httpOptionsTimeout = 10 * 1000; // 10 seconds

// logger
const loggerLevel = process.env.LOG_LEVEL || 'info';
const loggerStreams = process.env.LOG_STREAMS || ['console'];

module.exports = {
  port,
  apiBaseUrl,
  loggerLevel,
  loggerStreams,
  httpOptionsTimeout,
};
