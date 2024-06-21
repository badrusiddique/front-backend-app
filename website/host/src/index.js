const app = require('./app');
const router = require('./router');
const logger = require('./shared/logger');
const { port, apiBaseUrl } = require('./config');

require('./routes');

app.use(router);

app.listen(port, () => {
  logger.info(`Sample Website running on port: ${port} with Sample WebApi on: ${apiBaseUrl}`);
});
