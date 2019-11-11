n = int(input())

print(" " * n + " | " + " " * n)

freespace = n - 1

for x in range(1, n + 1):
    print((" " * freespace) + ("*" * x) + " | " + ("*" * x) + (" " * freespace))
    freespace -= 1
