import { html, render } from '../node_modules/lit-html/lit-html.js';
import * as data from './data.js';

let tableBody = document.querySelector('.container tbody');
let searchField = document.querySelector('#searchField');

let userTemplate = (student) => html`
   <tr class="${student.selected ? 'select' : ''}">
      <td>${student.firstName} ${student.lastName}</td>
      <td>${student.email}</td>
      <td>${student.course}</td>
   </tr>`;

async function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   let students = Object.values(await data.getAllStudents());
   students.forEach(st => st.selected = false);

   update();

   function update() {
      let mappedStudents = students.map(userTemplate);
      render(mappedStudents, tableBody)
   }

   function onClick(event) {
      event.preventDefault();

      let match = searchField.value.trim().toLowerCase();

      students.map(st => st.selected = match && (st.firstName + " " + st.lastName).trim().toLowerCase().includes(match));

      // for (let student of students) {
      //    if (match && (student.firstName + " " + student.lastName).trim().toLowerCase().includes(match)) {
      //       student.selected = true;
      //    }
      //    else {
      //       student.selected = false;
      //    }
      // }
      
      update();
   }
}

solve();