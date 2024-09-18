var express = require('express');
var router = express.Router();

var { getRouteHandler, postRouteHandler } = require('../controllers/shelterCat');

router.route('/:id')
    .get(getRouteHandler)
    .post(postRouteHandler);

module.exports = router;