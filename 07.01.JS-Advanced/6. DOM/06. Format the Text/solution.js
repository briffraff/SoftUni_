function solve(input) {
  let divExercise = Array.from(document.getElementById('exercise').children);
  let [textArea, formatBtn, outputArea] = divExercise;
  let text = textArea.value;

  let sentences = text.split('.')
    .map(x => `${x.trim()}.`)
    .filter(z => z != '.');

  let paragraph = '';
  let paragraphs = [];

  //paragraph
  for (let i = 0; i < sentences.length; i += 3) {
    //paragraph
    for (let z = 0; z < 3; z++) {
      if (sentences[z + i]) {
        paragraph += sentences[z + i];
      }
    }
    paragraphs.push(`<p>${paragraph}</p>`);
    paragraph = '';
  }

  paragraphs.forEach((p) => {
    outputArea.innerHTML += p;
  });

  console.log(paragraphs);
}