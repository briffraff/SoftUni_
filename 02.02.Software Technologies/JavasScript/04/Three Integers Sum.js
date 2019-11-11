function sumThree([nums]){

    let arr = nums.split(' ').map(Number);
    // console.log(arr);

    let num1 = arr[0];
    let num2 = arr[1];
    let num3 = arr[2];

    if (num1 + num2 === num3){
        if(num1 > num2)
        {
            [num1,num2]=[num2,num1];
        }
        console.log(`${num1} + ${num2} = ${num3}`)
    }
    else if (num2 + num3 === num1){
        if(num2 > num3)
        {
            [num2,num3]=[num3,num2];
        }
        console.log(`${num2} + ${num3} = ${num1}`)
    }
    else if (num3 + num1 === num2){
        if(num3 > num1)
        {
            [num3,num1]=[num1,num3];
        }
        console.log(`${num3} + ${num1} = ${num2}`)
    }
    else
    {
        console.log("No");
    }
}
// sumThree(["8 15 7"]);