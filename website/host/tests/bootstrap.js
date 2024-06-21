const {
  it,
  after,
  before,
  describe,
  afterEach,
  beforeEach,
} = require('mocha');
const chai = require('chai');
const forEach = require('mocha-each');
const chaiAsPromised = require('chai-as-promised');

chai.use(chaiAsPromised);

module.exports = {
  it,
  after,
  before,
  forEach,
  describe,
  afterEach,
  beforeEach,
  afterAll: after,
  beforeAll: before,
  expect: chai.expect,
};
