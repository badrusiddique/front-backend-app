import {
  createMeasurement,
  deleteMeasurement,
  updateMeasurement,
  getAllMeasurements,
  getMeasurementById,
} from '../../repository/measurement';

const mutations = {};

const actions = {
  createMeasurement: async (_context, payload) => createMeasurement(payload),

  deleteMeasurement: async (_context, id) => deleteMeasurement(id),

  updateMeasurement: async (_context, payload) =>  updateMeasurement(payload),

  getMeasurements: async () =>  getAllMeasurements(),

  getMeasurementById: async (_context, id) => getMeasurementById(id),
};

const getters = {};

const state = () => ({});

const measurements = {
  namespaced: true,
  state,
  mutations,
  actions,
  getters,
};

export default measurements;
