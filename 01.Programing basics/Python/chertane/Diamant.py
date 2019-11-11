n = int(input())

if (n == 1):
    print("*")
elif (n == 2):
    print("**")

if (n >= 3 and n % 2 != 0):
    leftRightTirenca = int((n - 1) / 2)
    midTirenca = 1

    print("-" * leftRightTirenca + "*" + "-" * leftRightTirenca)

    for x in range(0, leftRightTirenca):
        leftRightTirenca -= 1
        print("-" * leftRightTirenca + "*" + "-" * midTirenca + "*" + "-" * leftRightTirenca)
        midTirenca += 2

    midTirenca -= 2
    tirencaStart = int((n - 1) / 2)

    for x in range(0,tirencaStart-1):
        leftRightTirenca += 1
        midTirenca -= 2
        print("-" * leftRightTirenca + "*" + "-" * midTirenca + "*" + "-" * leftRightTirenca)

    leftRightTirenca = int((n - 1) / 2)
    print("-" * leftRightTirenca + "*" + "-" * leftRightTirenca)

if (n >= 3 and n % 2 == 0):
    leftRightTirenca = int((n - 1) / 2)
    midTirenca = 2

    print("-" * leftRightTirenca + "**" + "-" * leftRightTirenca)

    for x in range(0, leftRightTirenca):
        leftRightTirenca -= 1
        print("-" * leftRightTirenca + "*" + "-" * midTirenca + "*" + "-" * leftRightTirenca)
        midTirenca += 2

    midTirenca -= 2
    tirencaStart = int((n - 1) / 2)

    for x in range(0,tirencaStart-1):
        leftRightTirenca += 1
        midTirenca -= 2
        print("-" * leftRightTirenca + "*" + "-" * midTirenca + "*" + "-" * leftRightTirenca)

    leftRightTirenca = int((n - 1) / 2)
    print("-" * leftRightTirenca + "**" + "-" * leftRightTirenca)
