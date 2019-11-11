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

while True:
    vidProdukt = input()

    if(vidProdukt == "stop"):
        print(f"Spend money: {izharcheniPari:.2f}")
        ostavashtiPari = budget - izharcheniPari
        print(f"Money left: {ostavashtiPari:.2f}")
        break

    broi = int(input())

    if(vidProdukt == "balloons"):
        broiBaloni += broi
        izharcheniPari += cenaBalon * broi

    elif(vidProdukt == "flowers"):
        broiCvetq += broi
        izharcheniPari += cenaCvete * broi

    elif(vidProdukt == "candles"):
        broiSveshti += broi
        izharcheniPari += cenaSvesht * broi

    elif(vidProdukt == "ribbon"):
        metriPandelka += broi
        izharcheniPari += cenaPandelkaMetur * broi

    if(izharcheniPari >= budget):
        print("All money is spent!")
        break

print(f"Purchased decoration is {broiBaloni} balloons, {metriPandelka} m ribbon, {broiCvetq} flowers and {broiSveshti} candles.")