n = int(input())

tirenca = n-2

print("+ " + ("- "*tirenca) + "+")

for x in range(n-2):
    print("| " + ("- "*tirenca) + "|")

print("+ " + ("- "*tirenca) + "+")

#+ - - +
#| - - |
#| - - |
#+ - - +
