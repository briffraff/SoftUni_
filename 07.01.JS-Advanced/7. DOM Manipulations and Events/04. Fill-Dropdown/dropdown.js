function addItem() {
    let inputText = document.querySelector('#newItemText');
    let inputValue = document.querySelector('#newItemValue');

    let option = document.createElement('option');
    option.value = inputValue.value;
    option.textContent = inputText.value;

    let menu = document.querySelector('#menu');
    menu.appendChild(option);

    function clear(inputText, inputValue) {
        inputText.value = '';
        inputValue.value = '';
    }
    
    clear(inputText, inputValue);
}


