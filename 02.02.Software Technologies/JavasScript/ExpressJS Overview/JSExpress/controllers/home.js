module.exports = {
    homeStart: (reg, res) => {
        res.end(
            "<a href='/register' style='float: right;'>register</a>" +
            "<h1 style='text-align: center'>Welcome to our site</h1>" +
            "<div style = 'text-align: center'>" +
            "<p style='color:orangered'>Articles</p>" +
            "<p style='color:cornflowerblue'>First Article</p>" +
            "<p style='color:cornflowerblue'>Second Article</p>" +
            "</div>"
        )
    }
};