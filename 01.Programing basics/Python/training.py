list = ["kivi","praskova","pupesh","banan","cheresha","borovinka"]

imePlod = input().lower()

if(list.__contains__(imePlod) == False):
    print(f"{imePlod} does not contains in the shop!")
else:
    firstLetter = imePlod[0]
    imePlod = imePlod.replace(firstLetter,firstLetter.upper())
    if(firstLetter == firstLetter.lower()):
        print(f"{imePlod}")

############################################
novoIme = "praskova"

if(novoIme == "praskova" and imePlod == "kivi" or imePlod == "kivi"):
    print(True)
else:
    print(False)

#########################################
isContains = list.__contains__(imePlod) == False

if(isContains):
    print(isContains)
else:
    print(isContains)

