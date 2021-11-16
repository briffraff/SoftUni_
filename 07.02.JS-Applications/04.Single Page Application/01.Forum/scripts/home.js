import { globalConstants as gc } from './globalConstants.js';
import * as crud from './CRUD.js';
import { showView, cre, isEmpty, ClearField } from './dom.js';
import { showDetails } from './comments.js';

const homeView = document.querySelector('#homeView');
homeView.remove();

let newTopicBorder = homeView.querySelector(gc.newTopicBorderClass);
let form = newTopicBorder.querySelector('form');
let title = form.querySelector(gc.formTopic);
let username = form.querySelector(gc.formUsername);
let text = form.querySelector(gc.formText);

let cancelBtn = form.querySelector('button.cancel');
cancelBtn.addEventListener('click', onCancel);

let postBtn = form.querySelector('button.public');
postBtn.addEventListener('click', onPost);

let topicContainer = homeView.querySelector('#topicContainer');
topicContainer.addEventListener('click', openTopic);

export async function showHomeView() {
    showView(homeView);
    await loadTopics();
}

function onCancel(event) {
    event.preventDefault();
    if (event.target.textContent == 'Cancel') {
        form.reset();
    }
}

function onPost(event) {
    event.preventDefault();
    if (event.target.textContent == 'Post') {
        postTopic();
    }
}

async function postTopic() {
    let isSomeEmpty = [title, username, text].some(field => isEmpty(field));
    let today = new Date();

    if (isSomeEmpty == false) {
        let tData = {
            title: title.value,
            username: username.value,
            text: text.value,
            creationTime: today.toUTCString().split(' ').slice(0, 5).join(' ')
        };
        await crud.POST(gc.url, tData, gc.completeMsg);

        ClearField(title, username, text);
        loadTopics();
    }
    else {
        alert('All fields are require!');
    }
}

async function loadTopics() {
    topicContainer.replaceChildren(cre('p', {}, 'Loading...'));

    try {
        let requirement = [crud.GET(gc.url)];
        let data = await Promise.all(requirement); //[{},{},{}....]
        let topics = Object.values(data[0]);

        topics.forEach(topic => {

            let topicElement = cre('div', { className: 'topic-name-wrapper' }, '');
            topicElement.innerHTML =
                `<div id="${topic._id}" class="topic-name">
                <a href="#" class="normal">
                    <h2>${topic.title}</h2>
                </a>
                <div class="columns">
                    <div>
                        <p>Date: <time>${topic.creationTime}</time></p>
                        <div class="nick-name">
                            <p>Username: <span>${topic.username}</span></p>
                        </div>
                    </div>
                </div>
            </div>`;

            let isExists = [...topicContainer.children].some(r => r.innerHTML == topicElement.innerHTML);

            if (isExists == false) {
                topicContainer.appendChild(topicElement);
            }
        });
        topicContainer.querySelector('p').remove();

    } catch (error) {
        alert(error.message);
    }
}

function openTopic(event) {
    let target = event.target.tagName == 'H2';
    let parent = event.target.parentElement.className == 'normal';

    if (target && parent) {
        let topicId = event.target.parentElement.parentElement.id;
        showDetails(topicId);
    }
}