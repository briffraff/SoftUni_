# Cenite zavisqt ot otbora na dadenata strana
# CEl: Sumata na zakupenite suveniri!

imeOtbor = input()
vidSuvenir = input()
broiZakupeniSuveniri = int(input())

obshtaSuma = 0
cena = 0

if (imeOtbor == "Argentina"):
    if (vidSuvenir == "flags"):
        cena = 3.25
    if (vidSuvenir == "caps"):
        cena = 7.20
    if (vidSuvenir == "posters"):
        cena = 5.10
    if (vidSuvenir == "stickers"):
        cena = 1.25

elif (imeOtbor == "Brazil"):
    if (vidSuvenir == "flags"):
        cena = 4.20
    if (vidSuvenir == "caps"):
        cena = 8.50
    if (vidSuvenir == "posters"):
        cena = 5.35
    if (vidSuvenir == "stickers"):
        cena = 1.20

elif (imeOtbor == "Croatia"):
    if (vidSuvenir == "flags"):
        cena = 2.75
    if (vidSuvenir == "caps"):
        cena = 6.90
    if (vidSuvenir == "posters"):
        cena = 4.95
    if (vidSuvenir == "stickers"):
        cena = 1.10

elif (imeOtbor == "Denmark"):
    if (vidSuvenir == "flags"):
        cena = 3.10
    if (vidSuvenir == "caps"):
        cena = 6.50
    if (vidSuvenir == "posters"):
        cena = 4.80
    if (vidSuvenir == "stickers"):
        cena = 0.90

obshtaSuma = broiZakupeniSuveniri * cena

if (imeOtbor != "Argentina" and imeOtbor != "Croatia" and imeOtbor != "Denmark" and imeOtbor != "Brazil"):
    print("Invalid country!")

elif (vidSuvenir != "flags" and vidSuvenir != "stickers" and vidSuvenir != "posters" and vidSuvenir != "caps"):
    print("Invalid stock!")

else:
    print(f"Pepi bought {broiZakupeniSuveniri} {vidSuvenir} of {imeOtbor} for {obshtaSuma:.2f} lv.")
