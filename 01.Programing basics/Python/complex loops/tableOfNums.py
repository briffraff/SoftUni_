n = int(input())
num = 0

for i in range(0, n):
    for k in range(0, n):
        num = i + k + 1
        if (num > n):
            num = 2 * n - num
        print(num, end = " ")
    print()
