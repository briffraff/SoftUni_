import math

n = int(input())

zvezdichki = "*" * n * 2
midFreeSpace = " " * n
nakloneniCherti = "/" * ((n * 2) - 2)
center = "|" * n

#TOP
print(zvezdichki + midFreeSpace + zvezdichki)

#MID
for x in range(n - 2):

    i = math.floor(n / 2)
    if (n % 2 != 0):
        if (x == i - 1):
            print(f"*{nakloneniCherti}*{center}*{nakloneniCherti}*")
        else:
            print(f"*{nakloneniCherti}*{midFreeSpace}*{nakloneniCherti}*")

    if (n % 2 == 0):
        if (x == i - 2):
            print(f"*{nakloneniCherti}*{center}*{nakloneniCherti}*")
        else:
            print(f"*{nakloneniCherti}*{midFreeSpace}*{nakloneniCherti}*")

#BOTT
print(zvezdichki + midFreeSpace + zvezdichki)
