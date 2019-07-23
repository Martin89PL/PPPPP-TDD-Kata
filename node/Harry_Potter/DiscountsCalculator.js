import BooksDiscounts from './BooksDiscounts';

/**
 * Get discount for unique Books
 */
export default class DiscountCalculator {

    /**
     * 
     * @param {integer} uniqueOrdersCount 
     */
    static calculate(uniqueOrdersCount) {

        if (uniqueOrdersCount < 1 || uniqueOrdersCount > 5) {
            return 0;
        }

        return BooksDiscounts[uniqueOrdersCount];
    }
}