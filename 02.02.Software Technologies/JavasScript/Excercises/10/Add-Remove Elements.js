function addRemove (inputArr){

    let array = new Array();

    for(let command of inputArr){
        let split = command.split(' ');
        let cmd = split[0];
        let number = Number(split[1]);

        switch(cmd){
            case "add":
                array.push(number);
                break;
            case "remove":
                array.splice(number,1);
                break;
        }
    }

    for(let num of array){
        console.log(num);
    }
}
addRemove(["add 3","add 5","remove 1","add 2"]);