function PascalCamelCase() {

    let text = document.getElementById('text').value;
    let namingConvention = document.getElementById('naming-convention').value;

    let makeVar = '';

    //example: thisIsAnExample
    if (namingConvention == 'Camel Case' || namingConvention == 'Pascal Case') {
        let splitInput = text.toLowerCase().split(' ');

        for (let i = 0; i < splitInput.length; i++) {

            if (i == 0 && namingConvention === 'Camel Case') {
                let firstWord = splitInput[0];
                makeVar += firstWord;
                continue;
            }

            makeVar += (splitInput[i][0].toUpperCase() + splitInput[i].slice(1,));
        }
    }
    else {
        makeVar = 'Error!';
    }

    document.getElementById('result').textContent = makeVar;
}
