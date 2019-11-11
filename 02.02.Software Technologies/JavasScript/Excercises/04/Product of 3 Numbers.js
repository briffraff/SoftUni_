function positiveNegative(nums) {

    nums = (nums).map(Number);

    let countNegative = 0;
    let countPositive = 0;
    let countZero = 0;

    for (let i = 0; i < nums.length; i++) {
        if (nums[i] > 0) {
            countPositive++;
        }
        if (nums[i] < 0) {
            countNegative++;
        }
        if (nums[i] === 0) {
            countZero++;
        }
    }

    if (countZero >= 1) {
        console.log("Positive");
    }
    else {
        if (countNegative % 2 === 0) {
            console.log("Positive");
        }
        else if (countNegative % 2 !== 0) {
            console.log("Negative");
        }
    }
}

positiveNegative([0, 0, 0]);