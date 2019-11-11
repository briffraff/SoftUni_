firstNumber = int(input())
secondNumber = int(input())

sumaChetni = 0
sumaNechetni = 0

for number in range(firstNumber, secondNumber + 1):
    # numberStr = number.__str__()
    # numberStrLen = numberStr.__len__()
    #
    # for x in range(1, numberStrLen + 1):
    #     numberToAdd = int(numberStr[x - 1])
    #
    #     if (x % 2 == 0):
    #         sumaChetni += numberToAdd
    #     elif (x % 2 != 0):
    #         sumaNechetni += numberToAdd

    j = 1
    for n in str(number):
        if (j % 2 == 0):
            sumaChetni += int(n)
        elif (j % 2 != 0):
            sumaNechetni += int(n)

        j += 1
    if (sumaChetni == sumaNechetni):
        print(f"{number}", end = " ")

    sumaNechetni = 0
    sumaChetni = 0
