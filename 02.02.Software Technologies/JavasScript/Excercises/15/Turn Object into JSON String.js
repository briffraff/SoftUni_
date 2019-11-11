function ObjectToJSONString(input) {
    let object = {};
    for (let pair of input) {
        let split = pair.split("->");
        let key = split[0].trim();
        let value = split[1].trim();
        if (!isNaN(value)) {
            value = parseFloat(value);
        }
        object[key] = value;
    }

    let json = JSON.stringify(object);
    console.log(json);
}