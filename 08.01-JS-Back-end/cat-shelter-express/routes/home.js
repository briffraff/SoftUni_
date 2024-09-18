var express = require('express');
var router = express.Router();

var { getRouteHandler, search } = require('../controllers/home');

router.route('/')
    .get(getRouteHandler);

router.route('/search')
    .get(search);

module.exports = router;