function sumNumbers(...args) {
    let sum = 0;
    [...args].forEach(x => {
        sum += x;
    });

    return sum;
};

exports.modules = sumNumbers;