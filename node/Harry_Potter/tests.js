import test from 'tape';
import BookStore from './BookStore';
import BooksDiscounts from './BooksDiscounts';

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

test('Test return price of four different books', assert => {
  let bookPrice = bookStore.countPrice([1, 2, 3, 4]);
  assert.equals(bookPrice, 8 * 0.80);
  assert.end();
});

test('Check number of difference books for 2 positions', assert => {
  let differentBooksCount = bookStore.countDifferenceTitles([1, 2]);
  assert.equals(differentBooksCount, 2);
  assert.end();
});


test('Check number of difference books for 3 positions', assert => {
  let differentBooksCount = bookStore.countDifferenceTitles([1, 2, 3]);
  assert.equals(differentBooksCount, 3);
  assert.end();
});

test('get percentage Discount for 3 difference books', assert => {
  assert.equals(BooksDiscounts[3], bookStore.getDiscount(3));
  assert.end();
});

test('combination basket of Harry Potter books', assert => {
  // 2 copies of the first book
	// 2 copies of the second book
	// 2 copies of the third book
	// 1 copy of the fourth book
	// 1 copy of the fifth book

  // Answer: 51.60 EUR
  let different = 8 * 5 * 0.75;
  let theSame = 3 * 8;
  assert.comment(different);

});

