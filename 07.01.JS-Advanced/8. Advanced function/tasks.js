//  1
function sortArray(arrayOfNumbers, command) {

    let sortedArr = [];

    if (command == 'asc') {
        sortedArr = sortAscending(arrayOfNumbers);
    }

    if (command == 'desc') {
        sortedArr = sortDescending(arrayOfNumbers);
    }

    function sortAscending(arrayOfNumbers) {
        let sortedArray = arrayOfNumbers.sort((a, b) => a - b);
        return sortedArray;
    }

    function sortDescending(arrayOfNumbers) {
        let sortedArray = arrayOfNumbers.sort((a, b) => b - a);
        return sortedArray;
    }

    console.log(sortedArr);
    return sortedArr;
}

// sortArray([14, 7, 17, 6, 8], 'asc');
// sortArray([14, 7, 17, 6, 8], 'desc');


//  2
function ArgumentInfo() {

    let summary = {};

    let args = [].slice.call(arguments);

    function getTypes() {
        for (let argument of args) {
            let argumentType = typeof (argument);

            if (summary.hasOwnProperty(argumentType)) {
                summary[argumentType]++;
            }
            else {
                summary[argumentType] = 1;
            }

            console.log(`${argumentType}: ${argument}`);
        }
    }

    function printSummary() {
        Object.keys(summary).sort((a, b) => summary[b] - summary[a]).forEach(t => {
            console.log(`${t} = ${summary[t]}`);
        });
    }

    getTypes.apply(summary);
    printSummary.apply(summary);
}

// ArgumentInfo({ name: 'bob' }, 3.333, 9.999);
// ArgumentInfo('cat', 42, function () { console.log('Hello world!'); });



//  3. Fibonacci
function letFibonacci() {
    let number1 = 0;
    let number2 = 1;
    let isStart = true;

    function getNext() {
        if (isStart) {
            isStart = false;
            return 1;
        }

        let nextNumber = number1 + number2;
        number1 = number2;
        number2 = nextNumber;
        return nextNumber;
    }

    return getNext;
}

// let fibonacci = letFibonacci();
// console.log(fibonacci());
// console.log(fibonacci());
// console.log(fibonacci());
// console.log(fibonacci());
// console.log(fibonacci());
// console.log(fibonacci());
// console.log(fibonacci());
// console.log(fibonacci());

//  4. Breakfast Robot
function solution() {

    let supplies = { protein: 0, carbohydrate: 0, fat: 0, flavour: 0 };

    let foodRecipes = {
        apple: { protein: 0, carbohydrate: 1, fat: 0, flavour: 2 },
        lemonade: { protein: 0, carbohydrate: 10, fat: 0, flavour: 20 },
        burger: { protein: 0, carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, carbohydrate: 0, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
        cookRecipe(recipe, quantity) {

            let deductedQuantity = {};

            for (const value in this[recipe]) {
                if (this[recipe][value] * quantity > supplies[value]) {
                    return `Error: not enough ${value} in stock`;
                }
                deductedQuantity[value] = supplies[value] - this[recipe][value] * quantity;
            }

            Object.assign(supplies, deductedQuantity);
            return 'Success';

        }
    };

    // eslint-disable-next-line no-undef
    return controller = (str) => {

        if (str.includes('restock')) {
            let [, nutrient, quantity] = str.split(' ');
            supplies[nutrient] += Number(quantity);
            return 'Success';
        }

        if (str.includes('prepare')) {
            let [, recipe, quantity] = str.split(' ');
            return foodRecipes.cookRecipe(recipe, Number(quantity));
        }

        return `protein=${supplies.protein} carbohydrate=${supplies.carbohydrate} fat=${supplies.fat} flavour=${supplies.flavour}`;
    };
}

// let manager = solution();
// console.log(manager('restock flavour 50')); // Success
// console.log(manager('prepare lemonade 4')); // Error: not enough carbohydrate in stock
// console.log(manager('restock flavour 10'));
// console.log(manager('prepare apple 1'));
// console.log(manager('restock fat 10'));
// console.log(manager('prepare burger 1'));
// console.log(manager('report'));


//  5.	Functional Sum
function add(num) {

    let total = num;

    function Sum(num2) {
        total += num2;
        return Sum;
    }

    Sum.toString = () => {
        return (total);
    };

    return Sum;
}

// console.log(add(1)(6)(-3).toString());

//  6. Monkey Patcher 
