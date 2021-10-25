function getArticleGenerator(articles) {

    function addArticle() {

        let article = document.createElement('article');
        let articleSentense = articles.shift();

        if (articleSentense != undefined) {
            article.textContent = articleSentense;

            let content = document.querySelector('#content');
            content.appendChild(article);
        }
    }

    return addArticle;
}
