n = int(input())
l = int(input())

for x1 in range(1, n + 1):

    for x2 in range(1, n + 1):

        for x3 in range(97, 97 + l):
            symbol1 = chr(x3)

            for x4 in range(97, 97 + l):
                symbol2 = chr(x4)

                for x5 in range(1, n + 1):

                    if (x5 > x1 and x5 > x2):
                        print(f"{x1}{x2}{symbol1}{symbol2}{x5}", end = " ")
