import math

x1 = float(input())
y1 = float(input())
x2 = float(input())
y2 = float(input())

x = math.fabs(x1-x2)
y = math.fabs(y1-y2)

area = x*y
perimeter = (x+y)*2

print(area)
print(perimeter)