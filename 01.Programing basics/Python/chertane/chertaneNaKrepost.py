n = int(input())

chovki = int(n/2)

#TOP
print("/" + "^" * chovki + "\\" + "_" * chovki + "/" + "^" * chovki + "\\")

#MID

for x in range(n-3):
    print("|" + " " * chovki + " " + " " * chovki + " " + " " * chovki + "|")

#BOTT
print("|" + " " * chovki + " " + "_" * chovki + " " + " " * chovki + "|")

print("\\" + "_" * chovki + "/" + " " * chovki + "\\" + "_" * chovki + "/")

