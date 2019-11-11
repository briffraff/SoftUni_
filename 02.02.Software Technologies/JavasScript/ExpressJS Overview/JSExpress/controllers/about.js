const path = require('path');

module.exports = {
    about: (reg, res) => {
        res.sendFile(path.resolve('./static/about.html'))
    }
};