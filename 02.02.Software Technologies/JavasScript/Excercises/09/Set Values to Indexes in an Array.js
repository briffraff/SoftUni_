function valueToIndex(input) {

    let numCount = Number(input[0]);
    let array = new Array(numCount).fill(0);

    for (let i = 1; i < input.length; i++) {
        let split = input[i].split(' ');
        let index = Number(split[0]);
        let value = number(split[2]);
        array[index] = value;
    }

    for (let num of array) {
        console.log(num);
}
}