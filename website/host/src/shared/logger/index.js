const { createLogger } = require('bunyan');

const consoleStream = require('./console-stream');
const prettyConsole = require('./pretty-console-stream');
const { loggerLevel, loggerStreams } = require('../../config');
const {
  tail,
  map,
  head,
  forEach,
} = require('../rambda-extension');

const options = {
  level: loggerLevel,
  name: 'Sample Website',
};
const availableStreams = { prettyConsole, console: consoleStream };
const enabledStreams = map((s) => availableStreams[s](options), loggerStreams);

const baseLogger = createLogger(head(enabledStreams));
forEach((s) => baseLogger.addStream(s), tail(enabledStreams));

module.exports = baseLogger;
