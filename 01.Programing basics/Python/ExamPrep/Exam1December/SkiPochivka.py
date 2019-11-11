# Преди да отиде обаче, трябва да резервира хотел и да изчисли колко ще му струва престоя.
# . Съществуват следните видове помещения, със следните цени за престой:
# 	"room for one person" – 18.00 лв за нощувка
# 	"apartment" – 25.00 лв за нощувка
# 	"president apartment" – 35.00 лв за нощувка

dniPrestoi = int(input())
vidPomeshtenie = input()
ocenka = input()

room = 18.00
apartment = 25.00
presidentApartment = 35.00

sumaZaHotel = 0
namalenie = 0

if (dniPrestoi < 10):
    if (vidPomeshtenie == "room for one person"):
        sumaZaHotel = (dniPrestoi - 1) * room

    elif (vidPomeshtenie == "apartment"):
        sumaZaHotel = (dniPrestoi - 1) * apartment
        namalenie = (sumaZaHotel * 30) / 100
        sumaZaHotel -= namalenie

    elif (vidPomeshtenie == "president apartment"):
        sumaZaHotel = (dniPrestoi - 1) * presidentApartment
        namalenie = (sumaZaHotel * 10) / 100
        sumaZaHotel -= namalenie

elif (dniPrestoi >= 10 and dniPrestoi <= 15):
    if (vidPomeshtenie == "room for one person"):
        sumaZaHotel = (dniPrestoi - 1) * room

    elif (vidPomeshtenie == "apartment"):
        sumaZaHotel = (dniPrestoi - 1) * apartment
        namalenie = (sumaZaHotel * 35) / 100
        sumaZaHotel -= namalenie

    elif (vidPomeshtenie == "president apartment"):
        sumaZaHotel = (dniPrestoi - 1) * presidentApartment
        namalenie = (sumaZaHotel * 15) / 100
        sumaZaHotel -= namalenie

elif (dniPrestoi > 15):
    if (vidPomeshtenie == "room for one person"):
        sumaZaHotel = (dniPrestoi - 1) * room

    elif (vidPomeshtenie == "apartment"):
        sumaZaHotel = (dniPrestoi - 1) * apartment
        namalenie = (sumaZaHotel * 50) / 100
        sumaZaHotel -= namalenie

    elif (vidPomeshtenie == "president apartment"):
        sumaZaHotel = (dniPrestoi - 1) * presidentApartment
        namalenie = (sumaZaHotel * 20) / 100
        sumaZaHotel -= namalenie

if(ocenka == "positive"):
    bakshish = (sumaZaHotel * 25)/100
    sumaZaHotel += bakshish
elif(ocenka == "negative"):
    bakshish = (sumaZaHotel * 10)/100
    sumaZaHotel -= bakshish

print(f"{sumaZaHotel:.2f}")
