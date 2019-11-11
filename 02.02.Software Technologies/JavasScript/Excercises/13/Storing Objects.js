function storingObjects(input) {
    let array = new Array();
    for (let string of input) {
        let split = string.split("->");
        let name = split[0].trim();
        let age = split[1].trim();
        let grade = split[2].trim();

        array.push({
            Name: name,
            Age: age,
            Grade: grade
        });
    }

    for (let person of array) {
        for (let key of Object.keys(person)) {
            console.log(`${key}: ${person[key]}`)
        }
    }
}