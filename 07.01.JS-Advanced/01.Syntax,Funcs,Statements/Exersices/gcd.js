var a = 2154
var b = 458

function nod(a, b) {

    let tempA = a;
    let tempB = b;

    while (tempB !== 0) {
        let temp = tempA % tempB;
        tempA = tempB;
        tempB = temp;
    }

    return tempA;
}

console.log(nod(a,b))