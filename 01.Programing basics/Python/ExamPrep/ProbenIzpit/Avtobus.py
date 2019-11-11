# Avtobus Sofia-Burgas
# При тръгването си в автобуса има определен брой пътници
# На всяка спирка се качват и слизат определен брой пътници
# . Броят на спирките се въвежда от конзолата
# Също така, на всеки нечетен брой спирки се качват по двама проверяващи и слизат на четните спирки.
# CEL: Напишете програма, която изчислява колко пътника ще има в автобуса когато стигне в Бургас. ?

nachalenBroiPutnici = int(input())
broiSpirki = int(input())

broiPutnici = nachalenBroiPutnici
counterSpirki = 0

for x in range(broiSpirki):
    slizashti = int(input())
    kachvashti = int(input())

    counterSpirki += 1
    broiPutnici -= slizashti
    broiPutnici += kachvashti

    if (counterSpirki % 2 != 0):
        broiPutnici += 2

    if(counterSpirki % 2 == 0):
        broiPutnici -= 2

print(f"The final number of passengers is : {broiPutnici}")
