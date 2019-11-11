numbersCount = int(input())

resultMin = 0

for i in range(1,numbersCount+1):
    inputNums = int(input())
    if(i == 1):
        resultMin = inputNums

    if(inputNums < resultMin):
        resultMin = inputNums

print(resultMin)