number = int(input())

numberStr = str(number)
totalResult = 0

for x in numberStr:
    num = int(x)
    totalResult += num

print(totalResult)
