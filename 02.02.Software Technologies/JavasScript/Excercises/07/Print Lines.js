function printLines(input){
    for(let newLine of input)
    {
        if(newLine === "Stop")
        {
            return;
        }
        console.log(newLine);
    }
}
printLines([3,6,5,4,"Stop",10,12]);