inputText = input()

inputLenght = inputText.__len__()
sum = 0

for i in range(0, inputLenght):
    if (inputText[i] == "a"):
        sum += 1
    elif (inputText[i] == "e"):
        sum += 2
    elif (inputText[i] == "i"):
        sum += 3
    elif (inputText[i] == "o"):
        sum += 4
    elif (inputText[i] == "u"):
        sum += 5

print(sum)