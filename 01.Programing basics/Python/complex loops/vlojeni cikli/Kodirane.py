n = int(input())
Nstr = n.__str__()
Nlenght = n.__str__().__len__()

currentNum = 0
symbol = None

for i in range(Nlenght - 1, -1, -1):
    currentNum = int(Nstr[i])

    if(currentNum == 0):
        print("ZERO")
    else:
        symbol = chr(currentNum + 33)
        print(symbol * currentNum)
