const createConsoleStream = (config) => ({
  ...config,
  stream: process.stdout,
});

module.exports = createConsoleStream;
