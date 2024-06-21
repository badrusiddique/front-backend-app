const dig = require('object-dig');

const getNameMessageCode = async (error) => {
  if (error.isBoom) {
    const {
      error: name,
      message,
      statusCode: status,
    } = dig(error, 'output', 'payload');

    return {
      name,
      message,
      status: status || 500,
    };
  }

  return error;
};

const errorAsJson = async (error, _req, res, next) => {
  if (error) {
    const {
      name,
      status,
      message,
    } = await getNameMessageCode(error);

    res.status(status).json({ error: { name, code: status, message } });
  }

  next();
};

module.exports = errorAsJson;
