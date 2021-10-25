
//----------- 1
function fruits(input){
    let split = input.split(/[, \+]+/);
    
    let [fruit, weight, price, money] = split;
    
    weight = weight / 1000;
    money = (weight * price);
    
    let message = `I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`;
    console.log(message);
    
}

let input = '\'apple\', 1563, 2.35'.replace('\'','').replace('\'','');
// fruits(input);



//----------- 2
function gcd(a, b) {
    while (b != 0) {
        const temp = b;
        b = a % b;
        a = temp;
    }
 
    return a;
}

// gcb(10,50);



//----------- 3 
function sameNumbers(input) {
    
    let isSame = false;
    let targetNumber = 0;
    let sum = 0;
    let numbers = [...input.toString()];

    targetNumber = numbers[0];

    numbers.forEach(number => {
        
        if(targetNumber === number)
        {
            isSame = true;
        }
        else
        {
            isSame = false;
        }

        sum += +number;
    });

    console.log(isSame);
    console.log(sum);

}

// sameNumbers(22223);



//----------- 4

function previousDate (year, month, day) {

    let backDays = 1;
    const date = new Date(year, month, day);
    date.setDate(date.getDate() - backDays);

    let message = `${date.getFullYear()}-${date.getMonth()}-${date.getDate()}`;

    console.log(message);
}

// previousDate(2016, 9, 30);


//----------- 9

function getWords(input){
    const regex = new RegExp('[A-za-z]+', 'g');
    let words = [...('' + input).matchAll(regex)].map(word => word[0].toUpperCase()).join(', ');
    
    let noWordsMsg = 'No words found';
    const isEmpty = words.length === 0;
    console.log(isEmpty ? noWordsMsg : words);

    // if(words.length !== 0) {
    //     console.log(words);
    // } else {
    //     console.log("No words found!")
    // }

}

getWords('Hi, how are you?');
