let typeOfFruit = "apple";
let grams = 1563;
let price = 2.35;

function calcMoney(typeOfFruit,grams,price) {

    let kg = (grams / 1000);
    let totalMoney = (kg * price);
    let result = `I need $${totalMoney.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${typeOfFruit}.`

    return result;
}

console.log(calcMoney(typeOfFruit,grams,price));
