# turisti otivat na more
# Да се напише програма, която пресмята общата сума в левове, която е необходима на туристите за тази екскурзия
# Разстоянието до морето е 210 километра, а цялата екскурзия е с продължителност 3 дни.
# Тяхната кола изразходва средно по 7 литра на всеки 100 километра, а цената на бензина е 1,85 лв. за един литър.
# За всеки ден от техния престой те харчат пари за храна и сувенири.
# Общата цена за хотел е Z лв. на ден. Като група, първия ден те получават 10% намаление за престоя, втория ден - 15% намаление, а третия ден - 20%.

pariHranazaDen = float(input())
pariSuveniriZaDen = float(input())
pariZaHotelZaDen = float(input())

nujenRazhodBenzinLitri = 420 / 100 * 7
nujniPariZaBenzin = nujenRazhodBenzinLitri * 1.85

razhodDrugi = (pariHranazaDen * 3) + (pariSuveniriZaDen * 3)

hotelDen1 = pariZaHotelZaDen * 0.9
hotelDen2 = pariZaHotelZaDen * 0.85
hotelDen3 = pariZaHotelZaDen * 0.80
razhodHotel = hotelDen1 + hotelDen2 + hotelDen3

obshtaSuma = nujniPariZaBenzin + razhodDrugi + razhodHotel
print(f"Money needed: {obshtaSuma:.2f}")