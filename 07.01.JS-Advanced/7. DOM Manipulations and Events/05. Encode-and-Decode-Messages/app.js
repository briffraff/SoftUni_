function encodeAndDecodeMessages() {

    // get message from first textarea
    let main = document.getElementById('main');
    main.addEventListener('click', onclick);

    function onclick(ev) {
        let target = ev.target;
        let messageArea = target.parentElement.querySelector('textarea');
        let message = messageArea.value;

        let receiverArea = [...target.parentElement.parentElement.querySelectorAll('div textarea')][1];

        if (target.localName == 'button') {
            if (target.textContent.includes('Encode')) {
                // transfer transformed message to second textarea
                message = encondeMessage(message, 'encode');
                receiverArea.value = message;
                messageArea.value = '';

            } else if (target.textContent.includes('Decode')) {
                message = decodeMessage(message, 'decode');
                receiverArea.value = message;
            }
        }
    }

    function encondeMessage(message, action) {
        // loop through each character and add 1 to current ascii number
        let msg = convertAscii(message, action);
        return msg;
    }

    function decodeMessage(message, action) {
        // do the step back and visualize the message
        let msg = convertAscii(message, action);
        return msg;
    }

    function convertAscii(msg, action) {
        return [...msg].reduce((acc, c) => {
            let newAsciicode = 0;
            if (action == 'encode') { newAsciicode = (c.charCodeAt(0) + 1);};
            if (action == 'decode') { newAsciicode = (c.charCodeAt(0) - 1);};
            let char = String.fromCharCode(newAsciicode);

            return acc += char;
        }, '');
    }
}

// let a = ['a', 'b', 'c']
// let b = a.reduce((acc, c) => {
//     let newAsciicode = (c.charCodeAt(0) + 1)
//     let char = String.fromCharCode(newAsciicode);
//     return acc += char;
// }, '');
// console.log(b);
