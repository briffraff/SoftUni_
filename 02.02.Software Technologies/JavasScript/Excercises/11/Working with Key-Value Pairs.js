function KVPFunc(input) {

    let dict = {};

    for (let i = 0; i < input.length - 1; i++) {
        let inputSplit = input[i].split(' ');
        let key = inputSplit[0];
        let value = inputSplit[1];
        dict[key] = value;
    }

    if (dict.hasOwnProperty(input[input.length - 1])) {
        console.log(dict[input[input.length - 1]]);
    }
    else {
        console.log("None");
    }
}

KVPFunc(["3 test", "3 test1", "4 test2", "4 test3", "4 test5", "4"]);