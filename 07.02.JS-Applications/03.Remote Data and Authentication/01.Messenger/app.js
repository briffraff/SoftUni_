async function attachEvents() {
    let url = 'http://localhost:3030/jsonstore/messenger';

    let textArea = document.querySelector('#messages');
    let refreshBtn = document.getElementById('refresh');
    let submitBtn = document.getElementById('submit');

    refreshBtn.addEventListener('click', loadMessages.bind(null, textArea, url));
    submitBtn.addEventListener('click', onSubmit.bind(null, textArea, url));
    loadMessages(textArea, url);
}

async function loadMessages(textArea, url) {
    let result = await fetch(url);
    let data = await result.json();
    let messages = Object.values(data).map(m => `${m.author}: ${m.content}`).join('\n');

    textArea.value = messages;
}

async function onSubmit(textArea, url) {
    let a = document.querySelector('[name="author"]');
    let c = document.querySelector('[name="content"]');

    if (a.value != '' && c.value != '') {
        let [author, content] = [a.value, c.value];
        let data = { author, content };

        await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        }).then(res => {
            console.log('Request complete! response:', res);
        });

        textArea.value += '\n' + `${author}: ${content}`;
        c.value = '';
    }
}

attachEvents();