num = int(input())

result = 0
f0 = 1
f1 = 1

if (num < 2):
    print("1")
else:
    for x in range(2, num + 1, 1):
        result = f0 + f1
        f0 = f1
        f1 = result

    print(result)
