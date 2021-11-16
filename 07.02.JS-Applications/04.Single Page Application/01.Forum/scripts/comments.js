import { showView, cre, isEmpty, ClearField } from './dom.js';
import { globalConstants as gc } from './globalConstants.js';
import * as crud from './CRUD.js';

const section = document.getElementById('detailsView');
section.remove();

let name = section.querySelector('.theme-name');
let container = section.querySelector('#postContainer');
let form = section.querySelector('#answerForm');
let text = form.querySelector('#comment');
let username = form.querySelector('#username');
let postBtn = form.querySelector('button');
postBtn.addEventListener('click', onPost);

let currentTopicID = null;

export async function showDetails(topicId) {
    showView(section);
    name.replaceChildren();
    container.replaceChildren(cre('p', {}, 'Loading...'));
    currentTopicID = topicId;
    await loadComments();
}

function onPost(event) {
    event.preventDefault();
    if (event.target.textContent == 'Post') {
        addComment();
    }
}

async function addComment() {
    let isSomeEmpty = [text, username].some(field => isEmpty(field));
    if (isSomeEmpty == false) {

        const commentData = {
            'content': text.value,
            'author': username.value,
            'topicId': currentTopicID,
            'creationTime': new Date(Date.now()),
        };

        await crud.POST(gc.commentsUrl, commentData, gc.completeMsg);

        ClearField(text, username);
        loadComments();
    }
}

async function loadComments() {
    container.replaceChildren(cre('p', {}, 'Loading...'));

    try {
        let require = [crud.GET(gc.url + `/${currentTopicID}`)];
        let data = await Promise.all(require);
        let topic = Object.values(data)[0];

        let req = [crud.GET(gc.commentsUrl)];
        let d = await Promise.all(req);
        let comments = Object.values(d[0]).filter(c => c.topicId == currentTopicID);

        displayTopic(topic, comments);

    } catch (err) {
        alert(err.message);
    }
}

function createHeader(topic) {
    let img = './img/profile.png';
    const element = cre('div', { className: 'header' }, '');
    element.innerHTML =
        `<img src='${img}' alt="avatar">
        <p>
            <span>${topic.username}</span> posted on 
            <time>${topic.creationTime}</time>
        </p>
        <p class="post-content">${topic.text}</p>`;

    return element;
}

function createUserComment(comment) {
    const element = cre('div', { id: 'user-comment' }, '');
    element.innerHTML =
        `<div class="topic-name-wrapper">
            <div class="topic-name">
                <p><strong>${comment.author}</strong> commented on <time>${comment.creationTime}</time></p>
                <div class="post-content">
                    <p>${comment.content}</p>
                </div>
            </div>
        </div>`;

    return element;
}


function displayTopic(topic, comments) {
    name.replaceChildren(cre('h2', {}, topic.title));
    container.replaceChildren(createHeader(topic));
    container.append(...comments.map(createUserComment));
}