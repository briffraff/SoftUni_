var express = require('express');
var router = express.Router();

var { getRouteHandler, postRouteHandler } = require('../controllers/addBreed');

router.route('/')
    .get(getRouteHandler)
    .post(postRouteHandler);

module.exports = router;