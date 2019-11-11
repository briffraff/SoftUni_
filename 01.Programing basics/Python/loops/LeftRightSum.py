import math

numberCount = int(input())

resultLeft = 0

for i in range(1, numberCount + 1):
    inputNums = int(input())
    resultLeft += inputNums

resultRight = 0

for i in range(1, numberCount + 1):
    inputNums = int(input())
    resultRight += inputNums

if(resultLeft == resultRight):
    print(f"Yes, sum = {resultLeft}")
else:
    print(f"No, diff = {math.fabs(resultLeft-resultRight)}")