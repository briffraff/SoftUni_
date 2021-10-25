function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {

      let results = [];

      let searchField = document.getElementById('searchField');
      let searchValue = searchField.value;

      //<tbody>
      let rows = document.getElementsByTagName('tbody');

      //HTMLCollection[tr,tr,tr,tr,tr]
      let rowsArray = rows[0].children;

      // console.log(rowsArray);

      Array.from(rowsArray).forEach((row, i) => {
         //HTMLCollection[td,td,td]
         let dataRowArray = row.children;

         if (rowsArray[i].className == 'select') {
            rowsArray[i].removeAttribute('class');
         }

         Array.from(dataRowArray).forEach((cell,z) =>{
            //cell data
            let currentCell = cell.textContent;

            //check if search pattern exists in the current cell and set row - class select
            if (currentCell.includes(searchValue)) {
               row.className = 'select';
            }
         });
      });

      // clear search field
      document.querySelector('#searchField').value = '';
   }
}