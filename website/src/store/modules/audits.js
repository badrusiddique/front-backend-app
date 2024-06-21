import { getAudits} from '../../repository/audit';

const mutations = {};

const actions = {
  getAudits:  async () =>  getAudits(),
};

const getters = {};

const state = () => ({});

const audits = {
  namespaced: true,
  state,
  mutations,
  actions,
  getters,
};

export default audits;
