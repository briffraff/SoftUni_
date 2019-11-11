number = int(input())

numberStr = str(number)

firstNum = int(numberStr[2])
secondNum = int(numberStr[1])
thirdNum = int(numberStr[0])

for x1 in range(1, firstNum + 1):
    for x2 in range(1, secondNum + 1):
        for x3 in range(1, thirdNum + 1):
            if (x1 != 0 and x2 != 0 and x3 != 0):
                print(f"{x1} * {x2} * {x3} = {x1*x2*x3};")
            else:
                break
