projekciq = input()
redove = int(input())
koloni = int(input())

broiMesta = redove * koloni
obshtaSuma = 0

if (projekciq == "Premiere"):
    obshtaSuma = broiMesta * 12.00
elif (projekciq == "Normal"):
    obshtaSuma = broiMesta * 7.50
elif (projekciq == "Discount"):
    obshtaSuma = broiMesta * 5.00

print(f"{obshtaSuma:.2f} leva")
