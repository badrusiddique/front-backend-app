const path = require('path');
const express = require('express');
const history = require('connect-history-api-fallback');

const router = require('../router');

require('./api-proxy');

const dir = path.join(path.dirname(__dirname), '../..', 'dist');

router.use(history({ verbose: true }));

router.use('/js', express.static(`${dir}/js`));
router.use('/fonts', express.static(`${dir}/fonts`));
router.use('/favicon.ico', express.static(`${dir}/favicon.svg`));

router.use('/', express.static(dir));
