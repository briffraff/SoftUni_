function solve(input) {
   // document.querySelector('#btnSend').addEventListener('click', onClick);

   // function onClick() {
   // ['PizzaHut - Peter 500, George 300, Mark 800',
   //    'TheLake - Bob 1300, Joe 780, Jane 660']

   // let inputsDiv = document.getElementById('inputs').children;
   // let textareaValue = inputsDiv[1].value;
   let inputsDiv = input;
   let textareaValue = inputsDiv;
   let textArr = textareaValue.slice(2, -2).split(',');
   let textareaValuelenght = textArr.length;


   function getRestName(restInfo) {
      let restName = restInfo[0].trim();
      return restName;
   }

   function getWorkers(restInfo) {
      let workers = {};

      let restWorkers = restInfo[1].split(',').map(x => x.trim());

      restWorkers.forEach(worker => {
         let workerModel = { salary: 0 };
         let currentWorker = {};

         let [wName, wSalary] = worker.split(' ');

         currentWorker = workerModel;
         currentWorker.salary = wSalary;

         workers[wName] = currentWorker;
      });

      return workers;
   }

   function getBestSalary(workersInput) {
      let best = 0;

      let split = workersInput.split(',').map(x => x.trim());

      split.forEach(w => {
         let [name, sal] = w.split(' ');

         if (best < sal) {
            best = sal;
         }
      });

      return best;
   }

   function getAverageSalary(workersInput) {
      let average = 0;

      let split = workersInput.split(',').map(x => x.trim());
      let workersCount = split.length;

      split.forEach(w => {
         let [name, sal] = w.split(' ');
         average += +sal;
      });

      average = average / workersCount;

      return average;
   }

   function manageRestaurants(restaurantsArray) {
      let restaurants = {};

      //restaurants
      restaurantsArray.forEach((restaurant, i) => {
         let currentRest = {};

         let restModel = {
            workers: {},
            bestSalaray: 0,
            averageSalaray: 0
         };

         let splitRestInfo = restaurant.split('-');
         let rName = getRestName(splitRestInfo);
         let rWorkers = getWorkers(splitRestInfo);
         let rBestSal = getBestSalary(splitRestInfo[1]);
         let rAverageSal = getAverageSalary(splitRestInfo[1]);

         currentRest = restModel;
         currentRest.workers = rWorkers;
         currentRest.bestSalaray = rBestSal;
         currentRest.averageSalaray = rAverageSal;

         restaurants[rName] = currentRest;

      });

      return restaurants;
   }

   let restaurants = manageRestaurants(textArr);

   // function bestAndAverageSalaryCalc(restaurants) {
   //    let averageSalary = 0;
   //    let bestSalary = 0;

   //    Object.keys(restaurants).forEach(rest => {
   //       let workers = restaurants[rest].workers;

   //       Object.keys(workers).forEach(name => {

   //          let salary = workers[name].salary;
   //          averageSalary += +salary;

   //          if (bestSalary < restaurants[rest].bestSalaray) {
   //             restaurants[rest].bestSalaray = bestSalary;
   //          }
   //       })

   //       averageSalary = averageSalary / Object.keys(workers).length;

   //       if (averageSalary < restaurants[rest].averageSalaray) {
   //          restaurants[rest].averageSalaray = averageSalary;
   //       }

   //    });
   // };

   // bestAndAverageSalaryCalc(restaurants);
}
// }

solve('["PizzaHut - Peter 500 , George 300, Mark 800","TheLake - Bob 1300, Joe 780, Jane 660"]');

