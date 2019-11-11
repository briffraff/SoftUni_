from sys import exit

a = int(input())
b = int(input())
maxBroiParoli = int(input())

x1 = 0
x2 = 0
x3 = 0
x4 = 0

generiraniParoli = 0

for x1 in range(34, 55 + 1):
    for x2 in range(63, 96 + 1):
        if (x4 == b):
            exit(0)
        for x3 in range(1, a + 1):
            for x4 in range(1, b + 1):

                x1 += 1
                x2 += 1

                if (x1 == 55):
                    x1 = 34
                if (x2 == 96):
                    x2 = 64

                if (generiraniParoli == maxBroiParoli):
                    exit(0)
                elif (x3 == a + 1 and x4 == b + 1):
                    break
                else:
                    print(f"{chr(x1)}{chr(x2)}{x3}{x4}{chr(x2)}{chr(x1)}", end = "|")
                    generiraniParoli += 1
