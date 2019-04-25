import test from 'tape';

import thing from './index';

test('A passing test', (assert) => {

  assert.pass('This test will pass.');

  assert.end();
});

test('Assertions with tape.', (assert) => {
  const expected = 'something to test';
  const actual = thing.thong;

  assert.equal(actual, expected, 'message when assertion fails');

  assert.end();
});
