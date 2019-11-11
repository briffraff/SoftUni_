# Pepi se chudi kolko izkarva edin mach?
# cel: pechalbata ot edin mach i kolko pari se davat za blagotvoritelnost?
# Vseki sektor ima raven broi mesta !
# SektorPari -> (kapaciteta na stadiona * cenaZaBilet)/broiSektori
# BlagotvoritelnostPari -> (obshtaPechalba - prihodiSektor*0.75)/8

broiSektori = int(input())
kapacitetStadion = int(input())
cenaBilet = float(input())

obshtPrihod = kapacitetStadion * cenaBilet
prihodSektor = obshtPrihod / broiSektori
blagotvoritelnost = (obshtPrihod - (prihodSektor * 0.75)) / 8

print(f"Total income - {obshtPrihod:.2f} BGN")
print(f"Money for charity - {blagotvoritelnost:.2f} BGN")
