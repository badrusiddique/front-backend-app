const onHeaders = require('on-headers');
const convertHrtime = require('convert-hrtime');

const baseLogger = require('../shared/logger');

const level = process.env.LOG_LEVEL || 'info';

const buildLogger = (req) => (baseLogger.child({
  Body: req.body,
  level: level || 'info',
  Params: req.params,
  Method: req.method,
  'Correlation-ID': req.correlationId,
  url: `${req.protocol}://${req.get('host')}${req.originalUrl}`,
}));

const logger = (req, res, next) => {
  const log = buildLogger(req);

  log.info('Request starting');
  req.logger = log;
  const start = process.hrtime();

  onHeaders(res, () => {
    const duration = convertHrtime(process.hrtime(start)).milliseconds;
    log.info({ ElapsedMilliseconds: duration, StatusCode: res.statusCode }, 'Request finished');
  });

  next();
};

module.exports = logger;
