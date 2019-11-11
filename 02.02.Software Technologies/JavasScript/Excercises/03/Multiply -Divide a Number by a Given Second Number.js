function multiplyDivide(nums) {

    nums = (nums).map(Number);
    let numN = nums[0];
    let numX = nums[1];
    let result = 0;

    if (numX >= numN) {
        result = numN * numX;
    }
    else {
        result = numN / numX;
    }
    console.log(result);
}

multiplyDivide([2, 3]);