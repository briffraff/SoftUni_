numbersCount = int(input())

resultMax = 0

for i in range(1,numbersCount+1):
    inputNums = int(input())
    if(i == 1):
        resultMax = inputNums

    if(inputNums > resultMax):
        resultMax = inputNums

print(resultMax)