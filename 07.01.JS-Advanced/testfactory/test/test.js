//////////////////////////////////  T   E   S   T   ////////////////////////////////////

// var assert = require('assert');

// describe('Array', () => {
//     describe('#indexOf()',() => {

//     it('should return -1 when the value is not present', function() {
//       assert.equal([1, 2, 3].indexOf(4), -1);
//     });

//   });
// });


const chai = require('chai');

// const sum = require('../demo');

// describe('sum', () => {
//   it('should return 8', () => {
//     chai.expect(sum(3, 5)).to.be.equal(8,'OK!');
//   });
// });

////////////////////////////////////////////////////////////////////////////////////////

const isOddOrEven  = require('../../9. Unit testing and exceptions/tasks.js').isOddOrEven;

describe('2.check odd or even - invalid input', () => {
  it('return undefined if input is null', () => {
    let input = null;
    chai.expect(isOddOrEven(input)).to.be.equal(undefined);
  });

  it('return undefined if input is int', () => {
    let input = 5;
    chai.expect(isOddOrEven(input)).to.be.equal(undefined);
  });

  it('return undefined if input is [g,o,s,h,o]', () => {
    let input = ['g','o','s','h','o'];
    chai.expect(isOddOrEven(input)).to.be.equal(undefined);
  });
});

describe('2.check odd or even - valid input', () => {
  it('return odd if length of the input is odd number', () => {
    chai.expect(isOddOrEven('gosho')).to.be.equal('odd');
  });

  it('return even if length of the input is even number', () => {
    chai.expect(isOddOrEven('gosho123')).to.be.equal('even');
  });
});


/////////////////////////////////////////////////////////////////////////////////////////
const lookupChar = require('../../9. Unit testing and exceptions/tasks.js').lookupChar;

describe('3.lookupChar', () => {
    it('check if input is not a string', () => {
        chai.expect(lookupChar([1, 2, 3], 2)).to.be.equal(undefined);
    });

    it('check if index is not a number', () => {
        chai.expect(lookupChar('gosho', '2')).to.be.equal(undefined);
    });

    it('check if the correct input', () => {
        chai.expect(lookupChar('gosho', 2)).to.be.equal('s');
    });

    it('check if the invalid input', () => {
        chai.expect(lookupChar(5, 2)).to.be.equal(undefined);
    });

    it('check if index is a less then 0', () => {
        chai.expect(lookupChar('gosho', -2)).to.be.equal('Incorrect index');
    });

    it('check if index is out of range', () => {
        chai.expect(lookupChar('gosho', 10)).to.be.equal('Incorrect index');
    });

    it('check if index is a floating number which couldnt be index', () => {
        chai.expect(lookupChar('gosho', 2.2)).to.be.equal(undefined);
    });
});
/////////////////////////////////////////////////////////////////////////////////////////

let mathEnforcer  = require('../../9. Unit testing and exceptions/tasks.js').mathEnforcer;

describe('4. Math Enforcer', () => {

    describe('addFive', () => {
        it('pass negative value', () => {
            chai.expect(mathEnforcer.addFive(-1)).to.be.equal(4);
        });

        it('pass invalid data', () => {
            chai.expect(mathEnforcer.addFive('gosho')).to.be.equal(undefined);
        });

        it('pass float number and add 5', () => {
            chai.expect(mathEnforcer.addFive(5.5)).to.be.equal(10.5);
        });

        it('pass float number closeto', () => {
            chai.expect(mathEnforcer.addFive(5.5)).closeTo(10, 6);
        });
    });

    describe('subtractTen', () => {
        it('pass negative value', () => {
            chai.expect(mathEnforcer.subtractTen(-5.5)).to.be.equal(-15.5);
        });

        it('invalid data', () => {
            chai.expect(mathEnforcer.subtractTen('gosho')).to.be.equal(undefined);
        });

        it('pass number and subtract 10 from it', () => {
            chai.expect(mathEnforcer.subtractTen(5.5)).to.be.equal(-4.5);
        });

        it('pass float number closeto', () => {
            chai.expect(mathEnforcer.subtractTen(5.5)).closeTo(-4.5, 0.01);
        });
    });

    describe('sum', () => {
        it('pass invalid data', () => {
            chai.expect(mathEnforcer.sum('gosho', 'pesho')).to.be.equal(undefined);
        });

        it('pass negative value num1', () => {
            chai.expect(mathEnforcer.sum(-1, 5)).to.be.equal(4);
        });

        it('pass negative value num2', () => {
            chai.expect(mathEnforcer.sum(5, -1)).to.be.equal(4);
        });

        it('pass valid data', () => {
            chai.expect(mathEnforcer.sum(1, 5)).to.be.equal(6);
        });

        it('pass float numbers', () => {
            chai.expect(mathEnforcer.sum(1.2, 5.3)).to.be.equal(6.5);
        });

        it('pass float number closeto', () => {
            chai.expect(mathEnforcer.sum(5.5, 4.5)).to.be.equal(10).closeTo(10.01, 0.01);
        });
    });
});
