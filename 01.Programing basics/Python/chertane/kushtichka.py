n = int(input())

# TOP
if (n % 2 != 0):

    shirina = n
    tirenca = int((n - 1) / 2)
    zvezdichki = 1

    for x in range(int(n / 2 + 1)):
        print("-" * tirenca + "*" * zvezdichki + "-" * tirenca)
        tirenca -= 1
        zvezdichki += 2

#BOTT
    zvezdichki = n-2
    for x in range(0,int(n/2)):
        print("|" + "*" * zvezdichki + "|")

# TOP
if (n % 2 == 0):

    shirina = n
    tirenca = int((n / 2)-1)
    zvezdichki = 2

    for x in range(int(n / 2)):
        print("-" * tirenca + "*" * zvezdichki + "-" * tirenca)
        tirenca -= 1
        zvezdichki += 2

#BOTT
    zvezdichki = n-2
    for x in range(0,int(n/2)):
        print("|" + "*" * zvezdichki + "|")