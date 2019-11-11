let express = require('express');
let http = require('http');

http.createServer((req,res) => {
    res.end("<h1>Hello JS</h1>")
})
    .listen(3000, () => console.log("Listening to port 3000"));