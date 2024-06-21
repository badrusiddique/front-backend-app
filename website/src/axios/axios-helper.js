import * as ax from 'axios';
import axiosHelpers from 'axios-helpers';

const axios = axiosHelpers(ax);

axios.defaults.timeout = 17500;
axios.setHeader('Accept', 'application/json');
axios.setHeader('Content-Type', 'application/json');

export default axios;
