# Напишете програма, която изчислява колко ще е цената за поръчката. При въвеждане на невалиден ресторант да се отпечатва: {име на ресторанта} is invalid restaurant!

import math

vidSushi = input()
imeRestorant = input()
broiPorcii = int(input())
dostavka = input()

cena = 0
obshtaSuma = 0

if (imeRestorant == "Sushi Zone"):
    if (vidSushi == "sashimi"):
        cena = 4.99
    elif (vidSushi == "maki"):
        cena = 5.29
    elif (vidSushi == "uramaki"):
        cena = 5.99
    elif (vidSushi == "temaki"):
        cena = 4.29

elif (imeRestorant == "Sushi Time"):
    if (vidSushi == "sashimi"):
        cena = 5.49
    elif (vidSushi == "maki"):
        cena = 4.69
    elif (vidSushi == "uramaki"):
        cena = 4.49
    elif (vidSushi == "temaki"):
        cena = 5.19

elif (imeRestorant == "Sushi Bar"):
    if (vidSushi == "sashimi"):
        cena = 5.25
    elif (vidSushi == "maki"):
        cena = 5.55
    elif (vidSushi == "uramaki"):
        cena = 6.25
    elif (vidSushi == "temaki"):
        cena = 4.75

elif (imeRestorant == "Asian Pub"):
    if (vidSushi == "sashimi"):
        cena = 4.50
    elif (vidSushi == "maki"):
        cena = 4.80
    elif (vidSushi == "uramaki"):
        cena = 5.50
    elif (vidSushi == "temaki"):
        cena = 5.50

obshtaSuma = broiPorcii * cena

if (imeRestorant != "Sushi Zone" and imeRestorant != "Sushi Time" and imeRestorant != "Sushi Bar" and imeRestorant != "Asian Pub"):
    print(f"{imeRestorant} is invalid restaurant!")
else:
    if (dostavka == "Y"):
        dostavkaSuma = obshtaSuma * 20 / 100
        obshtaSuma = obshtaSuma + dostavkaSuma
        print(f"Total price: {math.ceil(obshtaSuma)} lv.")
    if (dostavka == "N"):
        print(f"Total price: {math.ceil(obshtaSuma)} lv.")
