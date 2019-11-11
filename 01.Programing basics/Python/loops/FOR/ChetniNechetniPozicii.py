n = int(input())

OddSum = 0
OddMin = 1000000000.0
OddMax = -1000000000.0
EvenSum = 0
EvenMin = 1000000000.0
EvenMax = -1000000000.0

if (n == 0):
    OddMin = "No"
    OddMax = "No"
    EvenMin = "No"
    EvenMax = "No"

if(n == 1):
    EvenMin = "No"
    EvenMax = "No"

for num in range(1, n + 1):

    number = float(input())

    # Even
    if (num % 2 == 0):
        if (number < EvenMin):
            EvenMin = number
        if (number > EvenMax):
            EvenMax = number
        EvenSum += number

    # Odd
    if (num % 2 != 0):
        if (number < OddMin):
            OddMin = number
        if (number > OddMax):
            OddMax = number
        OddSum += number

if(OddMin.is_integer()):
    print(f"OddSum={int(OddSum)},")
else:
    print(f"OddSum={OddSum:g},")

if(OddMin.is_integer()):
    print(f"OddMin={int(OddMin)},")
else:
    print(f"OddMin={OddMin},")

if(OddMax.is_integer()):
    print(f"OddMax={int(OddMax)},")
else:
    print(f"OddMax={OddMax}")

if(EvenSum.is_integer()):
    print(f"EvenSum={int(EvenSum)},")
else:
    print(f"EvenSum={EvenSum}")

if(EvenMin.is_integer()):
    print(f"EvenMin={int(EvenMin)},")
else:
    print(f"EvenMin={EvenMin},")

if(EvenMax.is_integer()):
    print(f"EvenMax={int(EvenMax)}")
else:
    print(f"EvenMax={EvenMax:g}")
