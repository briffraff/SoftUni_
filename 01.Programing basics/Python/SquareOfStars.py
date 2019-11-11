n = int(input())
stars = "*"

print(n * stars)

for x in range(1, (n - 1)):
    print("*" + (" ") * (n - 2) + "*")

print(n * stars)
