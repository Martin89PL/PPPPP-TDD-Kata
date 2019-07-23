import BooksDiscounts from './BooksDiscounts';
import DiscountCalculator from './DiscountsCalculator';

export default class BookStore {

    constructor() {
        this.defaultBookPrice = 8;
        this.BooksDiscounts = BooksDiscounts;
    }

    /**
     * array with ordered books ids
     * @param {array} orderedBooks 
     */
    countPrice(orderedBooks) {
        let differentTitlesCount = this.countDifferenceTitles(orderedBooks);

        let discount = DiscountCalculator.calculate(differentTitlesCount.length);

        return this.calculate(discount, orderedBooks.length);
    }

    /**
     * Array of ids books
     * @param {array} orderedBooks 
     */
    countDifferenceTitles(orderedBooks) {
        let differentTitles = orderedBooks.filter((value, index) => {
            return orderedBooks.indexOf(value) == index;
        });

    
        return differentTitles;
    }

    /**
     * Calculate summary cost
     * @param {*} discount 
     */
    calculate(discount, booksNumber) {
       return this.defaultBookPrice * booksNumber * ((100 - discount) / 100);
    }
};
