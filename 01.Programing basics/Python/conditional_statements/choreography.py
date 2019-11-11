import math

broiStupki = int(input())
broiTanciori = int(input())
broiDniZaUchene = int(input())

stupkiZaden = math.ceil((broiStupki/broiDniZaUchene)/broiStupki*100)
procentZaVseki = stupkiZaden/broiTanciori

if(stupkiZaden < 13):
    print(f"Yes, they will succeed in that goal! {procentZaVseki:.2f}%.")
else:
    print(f"No, They will not succeed in that goal! Required {procentZaVseki:.2f}% steps to be learned per day.")
