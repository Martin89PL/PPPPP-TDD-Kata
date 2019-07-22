import BooksDiscounts from './BooksDiscounts';

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

        if (differentTitlesCount < 6) {
            return this.defaultBookPrice * ((100 - this.getDiscount(orderedBooks.length)) / 100);
        }
    }

    /**
     * Array of ids books
     * @param {array} orderedBooks 
     */
    countDifferenceTitles(orderedBooks) {
        let differenceTitles = orderedBooks.filter((value, index) => {
            return orderedBooks.indexOf(value) == index;
        });
        return differenceTitles.length;
    }

    /**
     * Get value of discount
     * @param {number} differenceTitles 
     */
    getDiscount(differenceTitles = 0) {
        return this.BooksDiscounts[differenceTitles];
    }
};
