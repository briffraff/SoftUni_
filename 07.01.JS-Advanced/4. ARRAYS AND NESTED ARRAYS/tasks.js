//// 1
function printArray(arr, delimiter) {
    console.log(arr.join(delimiter));
}

// printArray(['One', 'Two', 'Three', 'Four', 'Five'], '-');

// 2
function prinNthElement(arr, step) {
    let targetnum = 0;
    let counter = 0;
    let newarr = [];

    for (const element of arr) {

        if (targetnum === counter) {
            newarr.push(element);
            targetnum += step;
        }

        counter++;
    }

    console.log(newarr);
    return newarr;
}

// prinNthElement(['1', '2', '3', '4', '5', '6'], 2);

// 3
function addRemoveElement(arr) {
    let initNum = 1;
    let collection = [];

    arr.forEach(command => {
        command === 'add' ? collection.push(initNum) : collection.pop(initNum);
        initNum++;
    });

    console.log(collection.length !== 0 ? collection.join('\n') : 'Empty');
}

// addRemoveElement(['add', 'add', 'remove', 'add', 'add']);

// 4
function rotateArray(arr, num) {
    let result = arr;

    for (let i = 0; i < num; i++) {
        result.unshift(result.pop());
    }

    console.log(result.join(' '));
}

// rotateArray(['1', '2', '3', '4'], 2);

// 5
function extract(arr) {
    let biggestNum = 0;
    let result = [];

    // for (const num of arr) {
    //     if (num >= biggestNum) {
    //         biggestNum = num;
    //         result.push(num)
    //     }
    // }

    arr.reduce((acumulator, num) => {
        num >= biggestNum ? biggestNum = num && acumulator.push(num) : null;

        return acumulator;
    }, result);

    console.log(result);
    return result;
}

// extract([1, 3, 8, 4, 10, 12, 3, 2, 24]);

// 6
function listOfNames(arr) {
    let orderedArr = arr.sort((a, b) => a.localeCompare(b));

    for (let i = 0; i < orderedArr.length; i++) {
        let element = orderedArr[i];
        console.log(`${i + 1}.${element}`);
    }
}

// listOfNames(["John", "Bob", "Christina", "Ema"]);


// 7
function sortNums(arr) {
    let newarr = [];

    let orderArr = arr.sort((a, b) => a - b);
    let arrLenght = orderArr.length;

    let sliceArr1 = orderArr.slice(0, arrLenght / 2);
    let sliceArr2 = orderArr.slice(arrLenght / 2, arrLenght).reverse();

    for (let i = 0; i < sliceArr1.length; i++) {
        const element = sliceArr1[i];

        newarr.push(element);

        for (let x = i; x < sliceArr2.length; x++) {
            const el = sliceArr2[x];

            newarr.push(el);
            break;
        }

    }

    // console.log(newarr);
    return newarr;
}

// function solve7(arr) {
//     arr = arr.sort((a, b) => {
//         return a - b;
//     })
//     const result = [];
//     while (arr.length != 0) {
//         result.push(arr.shift(), arr.pop());
//     }

//     console.log(result);
//     return result;
// }

// solve7([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);

//  9
function magicMatrice(arr) {
    let isMagicRows = true;
    let isMagicCols = true;

    // check rows
    let targetSum = 0;

    for (let x = 0; x < arr.length; x++) {
        let element = arr[x];
        let resultx = element[0] + element[1] + element[2];

        if (x === 0) {
            targetSum = resultx;
        }

        if (resultx !== targetSum) {
            isMagicRows = false;
            break;
        }
    }

    // check cols
    const colsSum = [];

    for (let y = 0; y < arr.length; y++) {
        for (let z = 0; z < arr[y].length; z++) {
            if (colsSum[z]) {
                colsSum[z] += arr[y][z];
            }
            else {
                colsSum[z] = arr[y][z];
            }
        }
    }

    // check if elements are equal
    isMagicCols = colsSum.every(e => e === colsSum[0]);

    console.log(isMagicRows && isMagicCols ? true : false);
}

magicMatrice([[1, 0, 0], [0, 0, 1], [0, 1, 0]]);