# Pepi otiva do magazina da si kupi suvenir
# CEL: Dali parite shte mu stignat?

# Артикул	    hoodie	keychain	T-shirt	   flag	  sticker
# Цена в лева	30	        4	        20	    15	    1

biudjet = int(input())
broiPredmeti = int(input())

razhod = 0
cena = 0

predmet = ""
for x in range(broiPredmeti):
    predmet = input()

    if (predmet == "hoodie"):
        cena = 30
    elif (predmet == "keychain"):
        cena = 4
    elif (predmet == "T-shirt"):
        cena = 20
    elif (predmet == "flag"):
        cena = 15
    elif (predmet == "sticker"):
        cena = 1

    razhod += cena

if (biudjet >= razhod):
    print(f"You bought {broiPredmeti} items and left with {biudjet - razhod} lv.")
elif (razhod > biudjet):
    print(f"Not enough money, you need {razhod - biudjet} more lv.")
