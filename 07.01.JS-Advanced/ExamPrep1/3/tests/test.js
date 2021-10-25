const chai = require('chai');
const testNumbers = require('../testNumbers');

describe('testNumbers', () => {
    describe('sumNumbers', () => {
        it('returns undefined', () => {
            chai.expect(testNumbers.sumNumbers('gosho', 'pesho')).to.undefined;
        });
        it('returns undefined if one of the first param is not a number', () => {
            chai.expect(testNumbers.sumNumbers(1, '2')).to.undefined;
        });
        it('returns undefined if one of the second param is not a number', () => {
            chai.expect(testNumbers.sumNumbers('1', 2)).to.undefined;
        });
        it('returns sum if valid numbers input', () => {
            chai.expect(testNumbers.sumNumbers(1, 2)).equal('3.00');
        });
        it('returns sum fixed to second digit if floating numbers as input', () => {
            chai.expect(testNumbers.sumNumbers(1.5, 2.5)).equal('4.00');
        });
    });

    describe('numberChecker', () => {
        it('returns even', () => {
            chai.expect(testNumbers.numberChecker(4)).contains('even');
        });
        it('returns odd', () => {
            chai.expect(testNumbers.numberChecker(3)).contains('odd');
        });
        it('works with even value as string', () => {
            chai.expect(testNumbers.numberChecker('4')).contains('even');
        });
        it('works with odd value as string', () => {
            chai.expect(testNumbers.numberChecker('3')).contains('odd');
        });
        it('returns not a number error', () => {
            chai.expect(() => testNumbers.numberChecker('gosho')).to.throw('The input is not a number!');
        });
    });

    describe('averageSumArray', () => {
        it('returns average sum if valid input', () => {
            let arr = [1, 2, 3];
            chai.expect(testNumbers.averageSumArray(arr)).equal(6 / arr.length);
        });
        it('returns average sum if input is arr of floats', () => {
            let arr = [1.5, 2.5, 3.5];
            chai.expect(testNumbers.averageSumArray(arr)).equal(2.5);
        });
        it('returns average number of their ascii codes/len', () => {
            let arr = ['1', '2', '3'];
            chai.expect(testNumbers.averageSumArray(arr)).equal(41);
        });
    });
});
