class Movie {
    constructor(movieName, ticketPrice) {
        this.movieName = movieName;
        this.ticketPrice = Number(ticketPrice);
        this.screenings = [];
        this.totalProfit = 0;
        this.sold = 0;
    }

    newScreening(date, hall, description) {
        let check = this.screenings.filter(x => x.date == date && x.hall == hall);

        if (check.length > 1) {
            throw new Error(`Sorry, ${hall} hall is not available on ${date}`);
        }

        let screening = {
            date,
            hall,
            description
        };

        this.screenings.push(screening);
        return `New screening of ${this.movieName} is added.`;
    }

    endScreening(date, hall, soldTickets) {
        let checkForScreening = this.screenings.some(s => s.date == date && s.hall == hall);

        if (checkForScreening == false) {
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`);
        }
        else {
            let currentProfit = soldTickets * this.ticketPrice;
            this.totalProfit += currentProfit;

            this.sold += soldTickets;

            let getMovie = this.screenings.filter(x => x.date == date && x.hall == hall);
            let updateMovies = this.screenings.filter(x => x != getMovie[0]);
            this.screenings = updateMovies;

            return `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${currentProfit}`;
        }
    }

    toString() {
        let result = [];

        result.push(`${this.movieName} full information:`);
        result.push(`Total profit: ${this.totalProfit.toFixed(0)}$`);
        result.push(`Sold Tickets: ${this.sold}`);

        if (this.screenings.length > 0) {
            result.push('Remaining film screenings:');

            this.screenings
                .sort((a, b) => a.hall.localeCompare(b.hall))
                .forEach((x) => {
                    result.push(`${x.hall} - ${x.date} - ${x.description}`);
                });
        }
        else {
            result.push('No more screenings!');
        }

        return result.join('\n');
    }
}

let m = new Movie('Wonder Woman 1984', '10.00');
console.log(m.newScreening('October 2, 2020', 'IMAX 3D', '3D'));
console.log(m.newScreening('October 3, 2020', 'Main', 'regular'));
console.log(m.newScreening('October 4, 2020', 'IMAX 3D', '3D'));
console.log(m.endScreening('October 2, 2020', 'IMAX 3D', 150));
console.log(m.endScreening('October 3, 2020', 'Main', 78));
console.log(m.toString());

m.newScreening('October 4, 2020', '235', 'regular');
m.newScreening('October 5, 2020', 'Main', 'regular');
m.newScreening('October 3, 2020', '235', 'regular');
m.newScreening('October 4, 2020', 'Main', 'regular');
console.log(m.toString());
