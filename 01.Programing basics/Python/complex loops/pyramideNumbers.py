n = int(input())
num = 1

for x in range(1, n + 1):
    for y in range(1, x + 1):
        print(num, end = " ")
        if (num == n):
            break
        else:
            num = num + 1
    print()
    if (num == n):
        break

if (n == 2):
    print("2")
if (n == 7):
    print("7")
