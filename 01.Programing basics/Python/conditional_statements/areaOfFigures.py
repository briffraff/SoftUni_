import math

figure = input()
result = 0

if (figure == "square" or figure == "circle"):
    n = float(input())
    if (figure == "square"):
        result = n * n
    elif (figure == "circle"):
        result = math.pi * n * n

if (figure == "rectangle" or figure == "triangle"):
    n = float(input())
    x = float(input())
    if (figure == "rectangle"):
        result = n * x
    if (figure == "triangle"):
        result = n * x / 2

print(f"{result:.3f}")
