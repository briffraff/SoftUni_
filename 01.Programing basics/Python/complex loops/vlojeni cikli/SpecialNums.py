n = int(input())

for num in range(1111, 9999 + 1):

    number = str(num)
    a = int(number[3])
    b = int(number[2])
    c = int(number[1])
    d = int(number[0])

    if (a == 0 or b == 0 or c == 0 or d == 0):
        continue
    if (n % a == 0 and n % b == 0 and n % c == 0 and n % d == 0):
        print(f"{num}", end = " ")
