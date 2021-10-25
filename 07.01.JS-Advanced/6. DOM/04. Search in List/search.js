// function search() {
//    let townsElements = Array.from(document.getElementById('towns').children);
//    let searchFieldValue = document.getElementById('searchText').value;
//    let searchBtn = document.getElementsByTagName('button')[0].textContent;

//    let matches = 0;
//    let towns = [];

//    for (const town of townsElements) {
//       towns.push(town.textContent);
//    }

//    for (const town of towns) {
//       let isFound = town.includes(searchFieldValue);

//       if (isFound) {
//          matches++;
//          [...document.getElementsByTagName('li')].forEach(element => {
//             if (element.textContent == town) {
//                element.style.fontWeight = 'bold';
//                element.style.textDecoration = 'underline';
//             }
//          });
//       }
//    }

//    if (searchBtn == 'Search' && matches != undefined) {
//       let result = document.getElementById('result').textContent = `${matches} matches found`;
//    }
// }

function search() {
   let townsElements = Array.from(document.getElementById('towns').children);
   let searchFieldValue = document.getElementById('searchText').value;
   let searchBtn = document.getElementsByTagName('button')[0].textContent;

   let matches = 0;
   let towns = [];

   for (const town of townsElements) {
      if (town.textContent.includes(searchFieldValue)) {
         matches++;
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
      }
   }

   if (searchBtn == 'Search' && matches != undefined) {
      let result = document.getElementById('result').textContent = `${matches} matches found`;
   }
}
