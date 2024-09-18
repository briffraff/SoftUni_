const express = require('express');
const { engine } = require('express-handlebars');
const app = express();
const port = 2323;

app.use(express.urlencoded({ extended: false }));
app.use(express.static('public'));
app.engine('.hbs', engine({
    extname: '.hbs',
    defaultLayout: 'default',
}));
app.set('view engine', '.hbs');

const homeRouter = require('./routes/home');
const addBreedRouter = require('./routes/addBreed');
const addCatRouter = require('./routes/addCat');
const editCatRouter = require('./routes/editCat');
const shelterCatRouter = require('./routes/shelterCat');

app.use('/', homeRouter);
app.use('/add-breed', addBreedRouter);
app.use('/add-cat', addCatRouter);
app.use('/edit', editCatRouter);
app.use('/shelter', shelterCatRouter);

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`)
});