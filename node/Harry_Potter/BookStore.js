export default class BookStore {

    constructor() {
        this.defaultBookPrice = 8;
    }


    countPrice(orderedBooks) {
        if (orderedBooks.length === 1) {
            return this.defaultBookPrice;
        }

        if (orderedBooks.length === 2) {
            return this.defaultBookPrice * 0.95;
        }
    }
};