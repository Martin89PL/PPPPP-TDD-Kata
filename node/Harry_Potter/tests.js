import test from 'tape';
import BookStore from './BookStore';
import BooksDiscounts from './BooksDiscounts';
import DiscountCalculator from './DiscountsCalculator';

const bookStore = new BookStore();

test('Test creating instance of BookStore', assert => {
  assert.equals(bookStore instanceof BookStore, true)
  assert.end();
});


test('Test return price of any books', assert => {
  let bookPrice = bookStore.countPrice([]);
  assert.equals(bookPrice, 0);
  assert.end();
});

test('Test return price of one book', assert => {
  let bookPrice = bookStore.countPrice([1]);
  assert.equals(bookPrice, 8);
  assert.end();
});

test('Test return price of two different books', assert => {
  let bookPrice = bookStore.countPrice([1, 2]);
  assert.equals(bookPrice, 2 * 8 * 0.95);
  assert.end();
});

test('Test return price of four different books', assert => {
  let bookPrice = bookStore.countPrice([1, 2, 3, 4]);
  assert.equals(bookPrice, 4 * 8 * 0.80);
  assert.end();
});

test('Check number of difference books for 2 positions', assert => {
  let differentBooksCount = bookStore.countDifferenceTitles([1, 2]);
  assert.equals(differentBooksCount.length, 2);
  assert.deepEqual(differentBooksCount, [1, 2])
  assert.end();
});


test('Check number of difference books for 3 positions', assert => {
  let differentBooksCount = bookStore.countDifferenceTitles([1, 2, 3]);
  assert.equals(differentBooksCount.length, 3);
  assert.deepEqual(differentBooksCount, [1, 2, 3])
  assert.end();
});


test('Get percentage discounts for two unique Books in basket', assert => {
  let actual = DiscountCalculator.calculate(2)
  assert.equals(actual, BooksDiscounts[2]);
  assert.end();
});

test('Get percentage discount for 0 unique Books in basket', assert => {
  let actual = DiscountCalculator.calculate(0)
  assert.equals(actual, 0);
  assert.end();
});

test('Get percentage discount for 6 unique Books in basket', assert => {
  let actual = DiscountCalculator.calculate(6)
  assert.equals(actual, 0);
  assert.end();
});



// test('combination basket of Harry Potter books', assert => {
//   // 2 copies of the first book
// 	// 2 copies of the second book
// 	// 2 copies of the third book
// 	// 1 copy of the fourth book
// 	// 1 copy of the fifth book

//   // Answer: 51.60 EUR
//   let different = 8 * 5 * 0.75;
//   let theSame = 3 * 8;
//   assert.comment(different);

// });

