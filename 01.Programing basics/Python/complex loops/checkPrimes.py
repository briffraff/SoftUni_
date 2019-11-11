import math

num = int(input())

if(num < 0):
    num = math.fabs(num)

kvadrat = int(math.sqrt(num))
isPrime = True

if (num > 1):
    for i in range(2, kvadrat + 1, 1):
        if (num % i == 0):
            isPrime = False
            break
else:
    isPrime = False

print(isPrime and "Prime" or "Not Prime")
print("Prime" if isPrime else "Not Prime")
