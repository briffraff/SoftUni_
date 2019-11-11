import math

numberCount = int(input())

resultEven = 0
resultOdd = 0

for i in range(1, numberCount + 1):
    inputNums = int(input())

    if (i % 2 == 0):
        resultEven += inputNums
    elif(i % 2 != 0):
        resultOdd += inputNums

if (resultEven == resultOdd):
    print(f"Yes sum = {resultEven}")
else:
    print(f"No diff = {math.fabs(resultEven-resultOdd)}")
