import math

n = int(input())
sum = 0
currentMaxNumber = 0

for x in range (n):
    number = int(input())

    #namirame nai-golqmoto vuvedeno chislo
    if(number > currentMaxNumber):
        currentMaxNumber = number

    sum += number
#izvajdame nai-golqmoto chislo ot sumata
sum -= currentMaxNumber

#ako sumata e ravna na nai-golqmoto chiso
if(sum == currentMaxNumber):
    print(f"Yes Sum = {math.fabs(currentMaxNumber)}")
else:
    diff = currentMaxNumber - sum
    print(f"No Diff = {math.fabs(diff)}")

