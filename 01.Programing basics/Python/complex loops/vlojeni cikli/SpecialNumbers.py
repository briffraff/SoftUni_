n = int(input())

checker = 0

for num in range(1111, 9999 + 1):

    for x in str(num):
        x = int(x)

        if(x == 0):
            continue

        if (n % x == 0):
            checker += 1
        else:
            checker += 0

    numLength = num.__str__().__len__()
    if (checker == numLength):
        print(f"{num}", end = " ")

    checker = 0
