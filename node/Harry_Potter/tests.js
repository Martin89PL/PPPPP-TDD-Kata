import test from 'tape';
import BookStore from './BookStore';

const bookStore = new BookStore();

test('Test creating instance of BookStore', assert => {
  assert.equals(bookStore instanceof BookStore, true)
  assert.end();
});

test('Test return price of one book', assert => {
  let bookPrice = bookStore.countPrice([1]);
  assert.equals(bookPrice, 8);
  assert.end();
});

test('Test return price of two different books', assert => {
  let bookPrice = bookStore.countPrice([1, 2]);
  assert.equals(bookPrice, 8 * 0.95);
  assert.end();
});


