//  initialize
let main = document.querySelector('main');

// show selected view
export function showView(view) {
    main.replaceChildren(view);
}

// create dom elements function
export function cre(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}

//  check if input field empty
export function isEmpty(field) {
    return field.value.trim() === '';
}

//  clear input fields
export function ClearField(...args) {
    [...args].forEach(f => f.value = '');
}

export function findEmpty(parentForm, ...args) {
    let result = 'Empty fields : ';

    args.forEach(x => {
        let empty = [...parentForm.querySelectorAll(x)].filter(f => f.value == '');
        empty.forEach(e => result += `\n- ${e.placeholder.replace('-', '').replace('...', '')}`);
    });
    console.log(result);
    return result;
}