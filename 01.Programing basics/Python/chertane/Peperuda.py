import math

n = int(input())

sidesWidth = int(n-1)
zvezdichki = n - 2

print("*" * zvezdichki + "\ /" + "*" * zvezdichki)

for x in range(0,int(n/2-1)):
    print("-" * zvezdichki + "\ /" + "-" * zvezdichki)
    print("*" * zvezdichki + "\ /" + "*" * zvezdichki)

print(" " * sidesWidth + "@" + " " * sidesWidth)

print("*" * zvezdichki + "/ \\" + "*" * zvezdichki)

for x in range(0,int(n/2-1)):
    print("-" * zvezdichki + "/ \\" + "-" * zvezdichki)
    print("*" * zvezdichki + "/ \\" + "*" * zvezdichki)

