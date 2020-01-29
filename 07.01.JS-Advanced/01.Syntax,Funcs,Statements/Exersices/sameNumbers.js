let a = 22222;

function sameNumber(a) {
    let isEqual = true;
    let split = a.toString().split('');
    let firstElement = split[0];
    let sum = +firstElement;

    for (let i = 1; i < split.length; i++) {

        let temp = split[i];

        if (firstElement !== temp) {
            isEqual = false;
        }

        sum += +temp;
    }

    console.log(isEqual);
    console.log(sum);
}

sameNumber(a);