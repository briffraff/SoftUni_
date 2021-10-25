
// 1.Rectangle
class Rectangle {

    Width = 0
    Height = 0
    Color = ""

    constructor(width, height, color) {
        this.Width = width;
        this.Height = height;
        this.Color = color;
        this.calcArea();
    }

    calcArea() {
        return this.Width * this.Height;
    }
}

// let rect = new Rectangle(4, 5, 'Red');
// console.log(rect.Width);
// console.log(rect.Height);
// console.log(rect.Color);
// console.log(rect.calcArea());

//  2. Data Class
class Request {

    Method = ""
    Url = ""
    Version = ""
    Message = ""

    constructor(method, uri, version, message) {
        this.Method = method;
        this.Url = uri;
        this.Version = version;
        this.Message = message;
        this.Response = undefined;
        this.fulfilled = false;
    }
}

// 3.Tickets
function TicketsData(tickets, sortCommand) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let ticketsArr = [];

    for (const ticket of tickets) {

        const [destination, price, stat] = ticket.match(/([A-Za-z0-9 ]+)\|([0-9]+\.[0-9]+)\|([a-z]+)/).slice(1,);

        let newTicket = new Ticket(destination, Number(price), stat);
        ticketsArr.push(newTicket);
    }

    //sorting
    // if (sortCommand == "destination") {
    //     ticketsArr.sort((a, b) => a.destination.localeCompare(b.destination))
    // } else if (sortCommand == "price") {
    //     ticketsArr.sort((a, b) => a.price - b.price)
    // } else {
    //     ticketsArr.sort((a, b) => a.status.localeCompare(b.status))
    // }

    //sorting
    ticketsArr.sort((a, b) => {
        return typeof (a[sortCommand]) === 'number' ? a[sortCommand] - b[sortCommand] : a[sortCommand].localeCompare(b[sortCommand])
    })

    console.log(ticketsArr);
    return ticketsArr;
}

// TicketsData(['Philadelphia|94.20|available',
//     'New York City|95.99|available',
//     'New York City|95.99|sold',
//     'Boston|126.20|departed'],
//     'destination'
// );

//  4 Sorted List
class List {
    constructor() {
        this.numbers = [];
        this.size = this.numbers.length;
    }

    updateSize = () => this.size = this.numbers.length;
    orderList = () => this.numbers.sort((a, b) => a - b);

    add(number) {
        this.numbers.push(number);
        this.updateSize();
        this.orderList();
    }

    remove(index) {
        if (this.numbers[index] !== undefined) {
            this.numbers.splice(index, 1);
            this.updateSize();
            this.orderList();
        }
    }

    get(index) {
        index = Number(index);
        if (this.numbers[index] !== undefined) {
            this.updateSize();
            this.orderList();
            return this.numbers[index];
        }
    }
}
// let list = new List();
// list.add(5);
// list.add(6);
// list.add(7);
// console.log(list.get(1));
// list.remove(1);
// console.log(list.get(1));



//  5. Length Limit
class Stringer {
    constructor(s, l) {
        this.innerString = s
        this.innerLength = l
    }

    increase(v) {
        this.innerLength += v
    }
    decrease(v) {
        const result = this.innerLength - v
        this.innerLength = result < 0 ? 0 : result
    }

    toString() {
        if (this.innerLength === 0) return '...'

        if (this.innerString.length > this.innerLength) {
            return `${this.innerString.slice(0, this.innerLength)}...`
        }

        return this.innerString
    }
}

// let test = new Stringer("Test", 5);
// console.log(test.toString()); // Test

// test.decrease(3);
// console.log(test.toString()); // Te...

// test.decrease(5);
// console.log(test.toString()); // ...

// test.increase(4);
// console.log(test.toString()); // Test

// 6

class Company {

    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {

        [name, salary, position, department]
            .filter(x => {
                if (x == "" || x == undefined || x == null || salary < 0) {
                    throw Error("Invalid input!");
                }
            });

        let employee = {
            name: name,
            salary: salary,
            position: position,
            department: department
        }

        if (this.departments.hasOwnProperty(department)) {
            //////////////// not sure about this
            this.departments[department].push(employee);
            this.departments[department][0]['totalSalary'] += salary;
        }
        else {
            this.departments[department] = [{ totalSalary: salary }, employee];
        }

        return (`New employee is hired. Name: ${name}. Position: ${position}`);
    };


    bestDepartment() {
        let bestDepartment = "";
        let bestAvgSalary = 0;
        let personsInDep;
        let result = "";

        Object.keys(this.departments).forEach((dep) => {
            let currentDepartment = dep;
            let currentPersonsInDep = this.departments[currentDepartment];
            let currentPersonsInDepEntries = Object.entries(currentPersonsInDep);

            if (currentPersonsInDepEntries[0][1].totalSalary != 0) {
                let currentBestAvgSalary = currentPersonsInDepEntries[0][1].totalSalary / (currentPersonsInDepEntries.length - 1);

                if (currentBestAvgSalary > bestAvgSalary) {
                    bestAvgSalary = currentBestAvgSalary;
                    bestDepartment = currentDepartment;
                    personsInDep = currentPersonsInDepEntries;
                }
            }
        });

        result += `Best Department is: ${bestDepartment}\n`;
        result += `Average salary: ${bestAvgSalary.toFixed(2)}\n`;

        personsInDep
            .filter(x => x[0][0] != 0)
            .sort((a, b) => b[1].salary - a[1].salary || a[1].name.localeCompare(b[1].name))
            .forEach(emp => result += `${emp[1].name} ${emp[1].salary} ${emp[1].position}\n`);

        return result.trim();
    }
}

// class Company {
//     constructor() {
//         this.departments = new Map();
//     }
//     addEmployee(username, salary, position, department) {

//         if (!username || !salary || salary < 0 || !position || !department) {
//             throw new Error("Invalid input!");
//         }

//         let newEmployee = { username, salary, position, department };

//         if (this.departments.has(department)) {
//             this.departments.get(department).push(newEmployee);
//         } else {
//             this.departments.set(department, [newEmployee]);
//         }

//         return `New employee is hired. Name: ${username}. Position: ${position}`;
//     }

//     bestDepartment() {
//         let totalSalary = (department) => {
//             let totalSalary = department[1].reduce((acc, b) => { return acc += b.salary }, 0);
//             let averageSalary = (totalSalary / department[1].length).toFixed(2);
//             department.push(averageSalary);
//             return averageSalary;
//         };
//         let bestDepartment = [...this.departments].sort((a, b) => totalSalary(b) - totalSalary(a))[0];
//         let sortBySalaryAndName = bestDepartment[1].sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username));

//         let result = `Best Department is: ${bestDepartment.shift()}\n`;
//         result += `Average salary: ${bestDepartment.pop()}\n`;
//         sortBySalaryAndName.forEach(e => result += `${e.username} ${e.salary} ${e.position}\n`);

//         return result.trim();
//     }
// }

// let c = new Company();
// c.addEmployee("Stanimir", 2000, "engineer", "Construction");
// c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
// c.addEmployee("Slavi", 500, "dyer", "Construction");
// c.addEmployee("Stan", 2000, "architect", "Construction");
// c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
// c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
// c.addEmployee("Gosho", 1350, "HR", "Human resources");
// c.addEmployee("Gosho", 1350, "HR", "Human resources");
// console.log(c.bestDepartment());

//  7
class Hex {
    constructor(value) {
        this.value = value;
    }

    //// valueOf() This function should return the value property of the hex class.
    valueOf() {
        return this.value;
    }

    //// toString() This function will show its hexadecimal value starting with "0x"
    toString() {
        let prefix = "0x";
        let valueToHex = this.value.toString(16).toUpperCase();
        return (prefix + valueToHex);
    }

    //// plus({ number }) This function should add a number or Hex object and return a new Hex object.
    plus(number) {
        let result;

        if (typeof (number) === 'number' || number.constructor.name === 'Hex') {
            result = this.value + Number(number);
        }
        return new Hex(result);
    }

    //// minus({ number }) This function should subtract a number or Hex object and return a new Hex object.
    minus(number) {
        let result;

        if (typeof (number) === 'number' || number.constructor.name === 'Hex') {
            result = this.value - Number(number);
        }
        return new Hex(result);
    }

    //// parse({ string }) Create a parse class method that can parse Hexadecimal numbers and convert them to standard decimal numbers.
    parse(input) {
        let hexStr = input;
        let number = parseInt(hexStr, 16);
        return number;
    }
}

// let FF = new Hex(255);
// console.log(FF.toString());
// FF.valueOf() + 1 == 256;
// let a = new Hex(10);
// let b = new Hex(5);
// console.log(a.plus(b).toString());
// console.log(a.plus(b).toString() === '0xF');
// console.log(FF.parse('AAA'));


//  9. Auto-Engineering Company

class AutoRegister {
    constructor() {
        this.archive = {};
    }

    Add(cars) {
        if (cars != undefined) {
            cars.forEach((car) => {
                let [carBrand, carModel, producedCars] = car.match(/(?<brand>[A-Z].+?)\s?\|\s?(?<model>.+?)\s?\|\s?(?<quantity>\d+)/).slice(1,);

                if (this.archive.hasOwnProperty(carBrand) == false) {
                    this.archive[carBrand] = {};
                }

                if (this.archive[carBrand].hasOwnProperty(carModel) == false) {
                    this.archive[carBrand][carModel] = 0;
                }

                this.archive[carBrand][carModel] += Number(producedCars);
            });
        }
    }

    Archive(command) {
        if (command == "brands") {
            for (let brand in this.archive) {
                console.log(brand)
            }
        } else if (command == "models") {
            for (let brand in this.archive) {
                for (let model in this.archive[brand]) {
                    console.log(`###${model} -> ${this.archive[brand][model]}`)
                }
            }
        } else if (command == "full") {
            for (let brand in this.archive) {
                console.log(brand)
                for (let model in this.archive[brand]) {
                    console.log(`###${model} -> ${this.archive[brand][model]}`)
                }
            }
        }
    }
}

// let input = ['Audi | Q7 | 1000',
//     'Audi | Q6 | 100',
//     'BMW | X5 | 1000',
//     'BMW | X6 | 100',
//     'Citroen | C4 | 123',
//     'Volga | GAZ-24 | 1000000',
//     'Lada | Niva | 1000000',
//     'Lada | Jigula | 1000000',
//     'Citroen | C4 | 22',
//     'Citroen | C5 | 10'];

// let auto = new AutoRegister();
// auto.Add(input);
// auto.Archive("full");


function solve(input) {

    let cars = new Map();

    function Add(input) {
        if (input != undefined) {
            input.forEach((car) => {
                let [carBrand, carModel, producedCars] = car.match(/(?<brand>[A-Z].+?)\s?\|\s?(?<model>.+?)\s?\|\s?(?<quantity>\d+)/).slice(1,);

                if (cars.has(carBrand) == false) {
                    cars.set(carBrand, new Map());
                }

                if (cars.get(carBrand).has(carModel) == false) {
                    cars.get(carBrand).set(carModel, 0);
                }

                cars.get(carBrand).set(carModel, cars.get(carBrand).get(carModel) + Number(producedCars));
            });
        }
    }

    function Archive(command) {
        if (command == "full") {
            for (let brand of cars.keys()) {
                console.log(brand)
                for (let model of cars.get(brand).keys()) {
                    console.log(`###${model} -> ${cars.get(brand).get(model)}`);
                }
            }
        }
    }

    Add(input);
    Archive("full");
}

let input2 = ['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'];

solve(input2);