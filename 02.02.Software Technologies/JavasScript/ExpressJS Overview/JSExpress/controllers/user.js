module.exports = {
    registerGet: (req, res) => {
        res.send(
            "<form method='post'>" +
            "<div style='text-align: center' >" +
            "<a href='/' style='float: right;'>home</a>" +
            "<h1>Register</h1>" +
            "<label for='num1'>Username: </label>" +
            "<input type='text' id='num1' name='user[username]'/><br><br>" +
            "<label for='num2'>E-mail: </label>" +
            "<input type='email' id='num2' name='user[email]'/><br><br>" +
            "<input type='submit'/>" +
            "</div>" +
            "</form>"
        )
    },

    registerPost: (req, res) => {
        let username = req.body.user.username;
        res.send(`Welcome ${username}`)
    },

    getUserById: (req, res) => {
        let id = req.params.id;
        res.send(`Welcome user with id: ${id}`)
    }
};