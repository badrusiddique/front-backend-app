const {
  it,
  expect,
  forEach,
  describe,
} = require('../bootstrap');
const rambda = require('../../src/shared/rambda-extension');

describe('shared/rambda-extension', () => {
  describe('#isBlank', () => {
    const { isBlank: subject } = rambda;

    forEach([
      ['', true],
      [null, true],
      ['dummy', false],
      [undefined, true],
    ])
      .it('should handle input "%s" and return "%s"', async (input, expected) => {
        const result = await subject(input);
        expect(result).to.be.equals(expected);
      });
  });

  describe('#deepProp', () => {
    const { deepProp: subject } = rambda;

    forEach([
      [{ some: 'some-thing' }, undefined],
      [{ some: { first: 'some-thing' } }, 'some-thing'],
    ])
      .it('should handle input %j and return %j', async (input, expected) => {
        const result = await subject(['some', 'first'])(input);
        expect(result).to.be.equals(expected);
      });

    it('should work in a non-curried way (with 2 arguments)', async () => {
      const data = { input: 'some-other-thing' };
      const result = await subject(['input'], data);
      expect(result).to.be.equals('some-other-thing');
    });
  });
});
