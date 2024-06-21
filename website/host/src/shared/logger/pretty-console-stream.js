const PrettyStream = require('bunyan-prettystream');

const createConsoleStream = (config) => {
  const stream = new PrettyStream();
  stream.pipe(process.stdout);

  return {
    ...config,
    stream,
  };
};

module.exports = createConsoleStream;
