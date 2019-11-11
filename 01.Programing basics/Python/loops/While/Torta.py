import math

broiParchetapoShirina = int(input())
broiParchetaPoDuljina = int(input())

obshtBroiParcheta = broiParchetaPoDuljina * broiParchetapoShirina

vzetiParcheta = 0
razlika = 0

while True:
    inputText = input()

    if (inputText == "STOP"):
        print(f"{razlika} pieces are left.")
        break
    else:
        vzetiParcheta += int(inputText)

    razlika = obshtBroiParcheta - vzetiParcheta

    if (obshtBroiParcheta < vzetiParcheta):
        print(f"No more cake left! You need {math.fabs(razlika):.0f} pieces more.")
        break

