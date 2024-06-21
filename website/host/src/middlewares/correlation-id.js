const dig = require('object-dig');
const { v4: uuid } = require('uuid');

const headerKey = 'X-Correlation-ID';

const correlationId = (req, res, next) => {
  const id = dig(req, 'headers', headerKey)
    || dig(req, 'headers', headerKey.toLowerCase())
    || uuid();

  req.correlationId = id;
  res.set(headerKey, id);
  req.headers[headerKey] = id;

  next();
};

module.exports = correlationId;
