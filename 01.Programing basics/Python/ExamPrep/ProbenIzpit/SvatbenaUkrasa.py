budget = float(input())

broiBaloni =0
broiCvetq = 0
broiSveshti = 0
metriPandelka = 0

cenaBalon = 0.1
cenaCvete = 1.5
cenaSvesht = 0.5
cenaPandelkaMetur = 2

izharcheniPari = 0
nujniPari = 0
ostavashtiPari = 0

while True:
    vidProdukt = input()

    if(vidProdukt == "stop"):
        print(f"Spend money: {izharcheniPari:.2f}")
        ostavashtiPari = budget - izharcheniPari
        print(f"Money left: {ostavashtiPari:.2f}")
        break

    broi = int(input())

    if(vidProdukt == "balloons"):
        nujniPari = broi * cenaBalon
        if(nujniPari <= budget):
            budget -= nujniPari
            izharcheniPari += nujniPari
            broiBaloni += broi
        else:
            break

    if(vidProdukt == "flowers"):
        nujniPari = broi * cenaCvete
        if(nujniPari <= budget):
            budget -= nujniPari
            izharcheniPari += nujniPari
            broiCvetq += broi
        else:
            break

    if(vidProdukt == "candles"):
        nujniPari = broi * cenaSvesht
        if(nujniPari <= budget):
            budget -= nujniPari
            izharcheniPari += nujniPari
            broiSveshti += broi
        else:
            break

    if(vidProdukt == "ribbon"):
        nujniPari = broi * cenaPandelkaMetur
        if(nujniPari <= budget):
            budget -= nujniPari
            izharcheniPari += nujniPari
            metriPandelka += broi
        else:
            break

    if(izharcheniPari > budget):
        print("All money is spent!")
        break

print(f"Purchased decoration is {broiBaloni} balloons, {metriPandelka} m ribbon, {broiCvetq} flowers and {broiSveshti} candles.")