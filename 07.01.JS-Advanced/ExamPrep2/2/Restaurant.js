class Restaurant {
    constructor(budget) {

        this.budgetMoney = Number(budget);
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(input) {
        for (let p of input) {
            let [name, quantity, productTotalPrice] = p.split(' ');

            if (this.budgetMoney >= productTotalPrice) {
                if (this.stockProducts.hasOwnProperty(name) == false) {
                    this.stockProducts[name] = 0;
                }

                this.stockProducts[name] += Number(quantity);
                this.history.push(`Successfully loaded ${quantity} ${name}`);

                this.budgetMoney -= productTotalPrice;
            }
            else {
                this.history.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }
        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price) {

        if (this.menu.hasOwnProperty(meal) == false) {
            let newMeal = {
                products: [],
                price
            };

            for (let product of neededProducts) {
                // let [productName, productQuantity] = product.split(' ');
                newMeal.products.push(product);
            }

            this.menu[meal] = newMeal;
        }
        else {
            return `The ${meal} is already in the our menu, try something different.`;
        }

        function size(obj) {
            return Object.keys(obj).length;
        }

        if (size(this.menu) != 1) {
            return `Great idea! Now with the ${meal} we have ${size(this.menu)} meals in the menu, other ideas?`;
        }
        else {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        }
    }

    showTheMenu() {
        if (this.menu.length == 0) {
            return 'Our menu is not ready yet, please come later...';
        }
        else {
            let result = [];

            for (let meal in this.menu) {
                result.push(`${meal} - $ ${this.menu[meal].price}`);
            }

            return result.join('\n');
        }
    }

    makeTheOrder(meal) {
        let mealInfo = this.menu[meal];
        let makeMeal = true;

        if (mealInfo == undefined) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
        else {
            let updatedStock = Object.assign({}, this.stockProducts);

            let products = Object.entries(mealInfo)[0][1];
            for (let x of products) {
                let [name, quantity] = x.split(' ');

                let checkProducts = Object.entries(this.stockProducts).some(x => x[0] == name && x[1] >= quantity);

                if (checkProducts == false) {
                    makeMeal = false;
                    break;
                }

                updatedStock[name] -= quantity;
            }

            if (makeMeal) {
                this.budgetMoney += mealInfo.price;
                this.stockProducts = updatedStock;
                return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${mealInfo.price}.`;
            }
            else {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }
    }
}

let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

console.log(kitchen.showTheMenu());
console.log(kitchen.makeTheOrder('frozenYogurt'));
