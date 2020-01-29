//1
let arr = ['One', 'Two', 'Three', 'Four', 'Five', '-'];

function printArrayWithGivenDelimiter(arr) {
    let delimiter = arr[arr.length - 1];
    let arr2 = arr.slice(0, arr.length - 1);
    console.log(arr2.join(delimiter));
}


//2
let input = ['5', '20', '31', '4', '20', '2']

function printNthElement(input) {

    let n = +input[input.length - 1];
    let inputUpdate = input.slice(0, input.length - 1);
    let counter = 0;

    for (let i = 0; i < inputUpdate.length; i++) {

        if (i === counter) {
            let element = inputUpdate[i];
            console.log(element);

            counter += n;
        }

    }
}


//3
let commands = ['add', 'add', 'remove', 'add', 'add'];

function addAndRemove(commands) {

    let arr = [];
    let errMessage = "Empty"
    let add = "add";
    let remove = "remove";
    let counter = 1;

    for (let i = 0; i < commands.length; i++) {

        let currentCommand = commands[i];

        if (currentCommand === add) {
            arr.push(counter);
        }

        if (currentCommand === remove) {
            arr = arr.slice(0, arr.length - 1);
            // arr.pop();
        }

        counter++;
    }

    //print
    if (arr.length === 0) {
        console.log(errMessage);
    }
    else {
        console.log(arr.join("\n"))
    }
}


//4

