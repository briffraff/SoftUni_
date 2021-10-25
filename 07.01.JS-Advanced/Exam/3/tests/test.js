const chai = require('chai');
const library = require('../library');

describe('library', () => {
    describe('calcPriceOfBook', () => {
        it('throw error if invalid input', () => {
            chai.expect(() => library.calcPriceOfBook(1, 'gosho')).to.throw('Invalid input');
        });
        it('throw error if first input is invalid', () => {
            chai.expect(() => library.calcPriceOfBook(1, 1)).to.throw('Invalid input');
        });
        it('throw error if second input is invalid', () => {
            chai.expect(() => library.calcPriceOfBook('gosho', '1970')).to.throw('Invalid input');
        });
        it('return price with discount if year is less or equal 1980', () => {
            chai.expect(library.calcPriceOfBook('gosho', 1970)).to.equal('Price of gosho is 10.00');
        });
        it('return current price', () => {
            chai.expect(library.calcPriceOfBook('gosho', 1981)).to.equal('Price of gosho is 20.00');
        });
        it('minus number', () => {
            chai.expect(library.calcPriceOfBook('gosho', -1981)).to.equal('Price of gosho is 10.00');
        });
        it('just one argument', () => {
            chai.expect(() => library.calcPriceOfBook('gosho')).to.throw('Invalid input');
        });
    });

    describe('findBook', () => {
        it('throw error if arr is zero', () => {
            let books = [];
            chai.expect(() => library.findBook(books, 'gosho')).to.throw('No books currently available');
        });
        it('return message if book is found in the arr', () => {
            let books = ['Troy', 'Life Style', 'Torronto'];
            chai.expect(library.findBook(books, 'Torronto')).equal('We found the book you want.');
        });
        it('return message if book is not found in the arr', () => {
            let books = ['Troy', 'Life Style', 'Torronto'];
            chai.expect(library.findBook(books, 'Torronto Life')).equal('The book you are looking for is not here!');
        });
        it('return ', () => {
            let books = ['Troy', 'Life Style', 'Torronto'];
            chai.expect(library.findBook(books, 1)).equal('The book you are looking for is not here!');
        });
        
    });

    describe('arrangeTheBooks', () => {
        it('invalid input error if input is not a number', () => {
            chai.expect(() => library.arrangeTheBooks('gosho')).to.throw('Invalid input');
        });
        it('invalid input error if input string number', () => {
            chai.expect(() => library.arrangeTheBooks('10')).to.throw('Invalid input');
        });
        it('invalid input error if input is less then zero', () => {
            chai.expect(() => library.arrangeTheBooks('-10')).to.throw('Invalid input');
        });
        it('invalid input error if input is less then zero number', () => {
            chai.expect(() => library.arrangeTheBooks(-10)).to.throw('Invalid input');
        });
        it('return message if books to arrange are less then space', () => {
            chai.expect(library.arrangeTheBooks(10)).equal('Great job, the books are arranged.');
        });
        it('return error message if opposite', () => {
            chai.expect(library.arrangeTheBooks(41)).equal('Insufficient space, more shelves need to be purchased.');
        });
        it('return error message if 40', () => {
            chai.expect(library.arrangeTheBooks(40)).equal('Great job, the books are arranged.');
        });
    });
});
