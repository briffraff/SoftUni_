class SummerCamp {

    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { 'child': 150, 'student': 300, 'collegian': 500 };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        let conditions = Object.entries(this.priceForTheCamp);
        let isCondition = conditions.some(c => c[0] == condition);
        let getCondition = conditions.filter(c => c[0] == condition);

        if (isCondition) {
            let neededMoney = getCondition[0][1];

            if (this.listOfParticipants.some(p => p.name == name)) {
                return `The ${name} is already registered at the camp.`;
            }
            else if (money < neededMoney) {
                return 'The money is not enough to pay the stay at the camp.';
            }
            else {
                let participant = {
                    name,
                    condition,
                    power: 100,
                    wins: 0
                };

                this.listOfParticipants.push(participant);
                return `The ${name} was successfully registered.`;
            }
        }
        else {
            return 'Unsuccessful registration at the camp.';
        }
    }

    unregisterParticipant(name) {
        let checkForParticipant = this.listOfParticipants.filter(p => p.name == name);

        if (checkForParticipant == 0) {
            return `The ${name} is not registered in the camp.`;
        }
        else {
            let updateList = this.listOfParticipants.filter(p => p != checkForParticipant[0]);
            this.listOfParticipants = updateList;
        }

        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2) {

        let firstOne = this.listOfParticipants.find(x => x.name == participant1);
        let secondOne = this.listOfParticipants.find(x => x.name == participant2);

        if (typeOfGame == 'WaterBalloonFights') {
            if (!firstOne) {
                throw new Error('Invalid entered name/s.');
            }

            if (!secondOne) {
                throw new Error('Invalid entered name/s.');
            }

            if (firstOne.condition != secondOne.condition) {
                // throw new Error('Choose players with equal condition.');
            }

            if (firstOne.power > secondOne.power) {
                firstOne.wins += 1;
                return `The ${firstOne.name} is winner in the game ${typeOfGame}.`;
            } else if (firstOne.power < secondOne.power) {
                secondOne.wins += 1;
                return `The ${secondOne.name} is winner in the game ${typeOfGame}.`;
            } else {
                return 'There is no winner.';
            }

        } else if (typeOfGame == 'Battleship') {
            firstOne.power += 20;
            return `The ${participant1} successfully completed the game ${typeOfGame}.`;
        }
    }

    toString() {
        let result = [];
        result.push(`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`);
        let sortedArr = this.listOfParticipants.slice().sort((a, b) => b.wins - a.wins);

        for (let participant of sortedArr) {
            result.push(`${participant.name} - ${participant.condition} - ${participant.power} - ${participant.wins}`);
        }
        return result.join('\n');
    }
}

// class SummerCamp2 {
//     constructor(organizer, location) {
//         this.organizer = organizer;
//         this.location = location;
//         this.priceForTheCamp = { 'child': 150, 'student': 300, 'collegian': 500 };
//         this.listOfParticipants = [];
//     }

//     registerParticipant(name, condition, money) {
//         if (!this.priceForTheCamp.hasOwnProperty(condition)) {
//             throw new Error('Unsuccessful registration at the camp.');
//         }
//         if (this.listOfParticipants.some(x => x.name === name)) {
//             return `The ${name} is already registered at the camp.`;
//         }
//         if (this.priceForTheCamp[condition] > money) {
//             return 'The money is not enough to pay the stay at the camp.';
//         }
//         this.listOfParticipants.push({ name, condition, power: 100, wins: 0 });
//         return `The ${name} was successfully registered.`;
//     }

//     unregisterParticipant(name) {
//         let current = this.listOfParticipants.findIndex(x => x.name === name);
//         if (current === -1) {
//             throw new Error(`The ${name} is not registered in the camp.`);
//         }
//         this.listOfParticipants.splice(current, 1);
//         return `The ${name} removed successfully.`;
//     }

//     timeToPlay(typeOfGame, participant1, participant2) {
//         let player1 = this.listOfParticipants.find(x => x.name === participant1);
//         let player2 = this.listOfParticipants.find(x => x.name === participant2);
//         if (player1 === undefined) {
//             throw new Error('Invalid entered name/s.');
//         }
//         if (typeOfGame === 'WaterBalloonFights' && player2 === undefined) {
//             throw new Error('Invalid entered name/s.');
//         }
//         if (typeOfGame === 'WaterBalloonFights' && (player1.condition !== player2.condition)) {
//             // throw new Error(`Choose players with equal condition.`)
//         }
//         if (typeOfGame === 'Battleship') {
//             player1.power += 20;
//             return `The ${participant1} successfully completed the game ${typeOfGame}.`;
//         }
//         if (typeOfGame === 'WaterBalloonFights') {
//             if (player1.power > player2.power) {
//                 player1.wins++;
//                 return `The ${participant1} is winner in the game ${typeOfGame}.`;
//             } else if (player1.power < player2.power) {
//                 player2.wins++;
//                 return `The ${participant2} is winner in the game ${typeOfGame}.`;
//             } else {
//                 return 'There is no winner.';
//             }
//         }
//     }

//     toString() {
//         let result = [];
//         result.push(`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`);
//         let sorted = this.listOfParticipants.sort((a, b) => b.wins - a.wins);
//         for (let el of sorted) {
//             result.push(`${el.name} - ${el.condition} - ${el.power} - ${el.wins}`);
//         }
//         return result.join('\n');
//     }
// }

const summerCamp = new SummerCamp('Jane Austen', 'Pancharevo Sofia 1137, Bulgaria');
console.log(summerCamp.registerParticipant('Petar Petarson', 'student', 300));
console.log(summerCamp.timeToPlay('Battleship', 'Petar Petarson'));
console.log(summerCamp.registerParticipant('Sara Dickinson', 'child', 200));
console.log(summerCamp.timeToPlay('WaterBalloonFights', 'Petar Petarson', 'Sara Dickinson'));
console.log(summerCamp.registerParticipant('Dimitur Kostov', 'student', 300));
console.log(summerCamp.timeToPlay('WaterBalloonFights', 'Petar Petarson', 'Dimitur Kostov'));

console.log(summerCamp.toString());
