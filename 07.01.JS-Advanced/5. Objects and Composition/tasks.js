//  1
function calorieObject(arr) {
    const object = {};

    for (let x = 0; x < arr.length; x++) {
        const element = arr[x];

        if (x % 2 == 0) {
            object[element] = +arr[x + 1];
        }
    }

    console.log(object);
}

// calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);

//  2
function constructionView(object) {
    let dizz = object.dizziness;

    if (dizz === true) {
        object.levelOfHydrated += object.weight * 0.1 * object.experience;
        object.dizziness = false;
    }

    console.log(object);
    return object;
}

// constructionView({
//     weight: 95,
//     experience: 3,
//     levelOfHydrated: 0,
//     dizziness: false
// }
// );

//  3
function carFactory(object) {
    let result = {
        model: '',
        engine: { power: 0, volume: 0 },
        carriage: { type: '', color: '' },
        wheels: [0, 0, 0, 0],
    };

    const carriages = {
        Hatchback: { type: 'hatchback', color: '' },
        Coupe: { type: 'coupe', color: '' },
    };

    const engines = {
        Small: { power: 90, volume: 1800 },
        Normal: { power: 120, volume: 2400 },
        Monster: { power: 200, volume: 3500 },
    };

    // if (object !== null) {

        //model
        function setModel(name) {
            if (name !== '') {
                return name;
            }
        }

        //wheelsize
        function setWheels(wheelsize) {
            if (wheelsize % 2 === 0) {
                let wSize = Math.round(wheelsize - 1);
                return [wSize, wSize, wSize, wSize];
            }

            let wheels = (new Array(4).fill(wheelsize));

            return wheels;
        }

        //engine
        function setEngine(power) {
            var engine = {};

            if (power != null) {
                if (power <= 90) {
                    engine = engines.Small;
                } else if (power <= 120) {
                    engine = engines.Normal;
                } else if (power <= 200) {
                    engine = engines.Monster;
                }
            }
            return engine;
        }

        //carriage
        function setCarriage(color, type) {

            var currentCarriage = {};

            if (type !== '' && color !== '') {
                if (type.toLowerCase() === 'Hatchback'.toLowerCase()) {
                    currentCarriage = carriages.Hatchback;
                }
                if (type.toLowerCase() === 'Coupe'.toLowerCase()) {
                    currentCarriage = carriages.Coupe;
                }
                currentCarriage.color = color;
            }

            return currentCarriage;
        }
    // }

    result = {
        model: setModel(object.model),
        engine: setEngine(object.power),
        carriage: setCarriage(object.color, object.carriage),
        wheels: setWheels(object.wheelsize),
    };

    // Object.entries(result).forEach(x => console.log(`${x[0]} => ${x[1]}`));
    console.log(result);
    // return result;
}

carFactory(
{
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
);


// 4
function heroicInventory(input) {
    // let heros = []
    // arr.map(x => x.split(' / '))
    //     .map(x => heros.push({ name: x[0], level: +x[1], items: x[2].split(', ').sort((a, b) => a.localeCompare(b)).join(', ') }))

    // heros.sort((a, b) => a.level - b.level)
    //     .map(x => console.log(`Hero: ${x.name}\nlevel => ${x.level}\nitems => ${x.items}`))  

    let heroData = [];
    for (let i = 0; i < input.length; i++) {
        let currentHeroEl = input[i].split(' / ');

        let currentHeroName = currentHeroEl[0];
        let currentHeroLevel = Number(currentHeroEl[1]);

        let currentHeroItems = [];
        if (currentHeroEl.length > 2) {
            currentHeroItems = currentHeroEl[2].split(', ');
        }

        let hero = {
            name: currentHeroName,
            level: currentHeroLevel,
            items: currentHeroItems
        };
        heroData.push(hero);
    }
    console.log(JSON.stringify(heroData));
}

// heroicInventory(['Jake / 1000 / Gauss, HolidayGrenade']);


// 5
function lowestPricesInCities(input) {
    const products = {};

    for (const line of input) {
        let [town, product, price] = line.split(' | ');
        price = Number(price);

        if (!products.hasOwnProperty(product)) {
            products[product] = new Map();
        }

        products[product].set(town, price);
    }

    for (const [product, townsAndPrices] of Object.entries(products)) {
        const lowestPrice = [...townsAndPrices].reduce((acc, v) => acc[1] <= v[1] ? acc : v);
        console.log(`${product} -> ${lowestPrice[1]} (${lowestPrice[0]})`);
    }
}

// lowestPricesInCities(['Sample Town | Sample Product | 1000',
//     'Sample Town | Orange | 2',
//     'Sample Town | Peach | 1',
//     'Sofia | Orange | 3',
//     'Sofia | Peach | 2',
//     'New York | Sample Product | 1000.1',
//     'New York | Burger | 10']
// );


//  6
function storeCatalogue(arr) {
    let template = '{productName} : {productPrice}';

    let result = {};
    let divider = ' : ';

    if (arr != undefined) {

        for (const product of arr) {
            if (product.includes(divider)) {
                let [productName, productPrice] = product.split(' : ');
                let firstLetter = productName[0].toUpperCase();
                let productToAdd = `${productName}: ${productPrice}`;

                if (!result.hasOwnProperty(firstLetter)) {
                    result[firstLetter] = [productToAdd];
                }
                else {
                    result[firstLetter].push(productToAdd);
                }
            }
        }
    }

    Object.entries(result).sort()
        .forEach(x => {
            console.log(x[0]);
            x[1].sort()
                .forEach(p => { console.log(`  ${p}`); });
        });
}

// storeCatalogue(['Appricot : 20.4',
//     'Fridge : 1500',
//     'TV : 1499',
//     'Deodorant : 10',
//     'Boiler : 300',
//     'Apple : 1.25',
//     'Anti-Bug Spray : 15',
//     'T-Shirt : 10']
// );


//  7
function townsJSON(input) {
    let results = [];
    let town = {};
    let headings = input[0]
        .split('|')
        .filter(x => x != '')
        .map(z => z.trim());

    //set keys - headings
    for (const heading of headings) {
        if (heading == 'Town') {
            town[heading] = '';
            continue;
        }
        town[heading] = 0;
    }

    //set towns info
    let towns = input.slice(1,);

    for (const t of towns) {
        let [townName, latitute, longitute] = t
            .split('|')
            .filter(x => x != '')
            .map(z => z.trim());

        town[headings[0]] = townName;
        town[headings[1]] = +(Number(latitute)).toFixed(2);
        town[headings[2]] = +(Number(longitute)).toFixed(2);

        results.push(town);
        town = {};
    }

    //print result
    let toJson = (JSON.stringify(results));
    // console.log(results);
    return toJson;
}

// townsJSON(
//     ['| Town | Latitude | Longitude |',
//         '| Veliko Turnovo | 43.0757 | 25.6172 |',
//         '| Monatevideo | 34.50 | 56.11 |']

// );


// 8
function rectangle(width, height, color) {

    let check = [width, height, color].every(x => x != undefined);
    let checkW = (/([0-9]+)/g).test(width);
    let checkH = (/([0-9]+)/g).test(height);
    let checkColor = (/([A-Za-z]+)/g).test(color);

    let rect = {};
    rect.calcArea = () => { };

    if (check && checkW && checkH && checkColor) {
        rect['width'] = Number(width);
        rect['height'] = Number(height);
        rect['color'] = `${color[0].toUpperCase()}${color.slice(1,)}`;
        rect.calcArea = () => {
            let area = (width * height);
            return area;
        };
    }
    else {
        console.log('invalid input');
    }

    return rect;
}

// let rect = rectangle(4, 5, 'red');
// console.log(rect.width);
// console.log(rect.height);
// console.log(rect.color);
// console.log(rect.calcArea());


//  9
function sortedList() {
    let warning = 'Invalid input!';

    let result = {};
    result.nums = [];
    result.size = result.nums.length,

        result.checkInput = function (input) {
            var pattern = /([0-9]+)/g;
            var check = (pattern).test(input);

            // if (checkInput) {
            //     return input;
            // }
            // else {
            //     console.log(warning);
            // }

            return check ? input : console.log(warning);
        };

    result.add = function (element) {
        var check = this.checkInput(element);

        if (check && typeof (element) === 'number') {
            //TODO check the input - could be array?
            this.nums.push(element);
            this.nums.sort((a, b) => a - b);
            this.size++;
        }
        else {
            console.log('The array takes only numbers.');
        }
    };

    result.remove = function (index) {
        var check = this.checkInput(index);

        if (check && index >= 0 && index < this.nums.length) {
            this.nums.splice(index, 1);
            this.nums.sort((a, b) => a - b);
            this.size--;
        } else {
            console.error('remove - The index is outside the bounds of the array');
        }
    };

    result.get = function (index) {
        var check = this.checkInput(index);

        if (check && index < this.nums.length && index >= 0) {
            return this.nums[index];
        } else if (index >= this.nums.length) {
            return this.nums.length;
        }else {
            console.error('get - The index is outside the bounds of the array');
        }
    };

    // console.log(Object.values(result));
    return result;
}

// let list = sortedList();
// list.add(5);
// list.add(6);
// console.log(list.size);
// list.add(7);
// console.log(list.get(1));
// list.remove(1);
// console.log(list.get(1));

