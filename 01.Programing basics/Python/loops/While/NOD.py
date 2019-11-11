a = float(input())
b = float(input())

nod = 0

while b != 0:
    oldB = b
    b = a % b
    nod = oldB

print(nod)
