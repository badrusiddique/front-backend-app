require('dotenv').config();
const cors = require('cors');
const express = require('express');
const bodyParser = require('body-parser');

const logger = require('./middlewares/logger');
const disableNagle = require('./middlewares/nagle');
const corsHandler = require('./middlewares/cors-handler');
const formatError = require('./middlewares/error-as-json');
const correlationId = require('./middlewares/correlation-id');

const app = express();

app.use(bodyParser.json({ limit: '5mb' }));
app.use(bodyParser.urlencoded({ extended: true }));
app.use(disableNagle);
app.use(correlationId);
app.use(logger);
app.use(formatError);
app.use(cors());
app.use(corsHandler);

module.exports = app;
