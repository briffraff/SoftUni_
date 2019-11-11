# Георги трябва да построи космически кораб, който да събира част от екипажа му
# За целта, той трябва да го направи така, че да има място за поне трима астронавти, но за не повече от 10.
# Всеки астронавт се нуждае от малка стая, която да е с размери: 2 метра ширина, 2 метра дължина и с 40 см по-висока от средната височина на астронавтите.
# CEL: Напишете програма, която изчислява обема на кораба, колко астронавта ще събере и принтира на конзолата дали  той е достатъчно голям.
import math

shirinaKorab = float(input())
duljinaKorab = float(input())
visochinaKorab = float(input())
srednaVisochinaAstronavti = float(input())

razmerStaq = 2 * 2 * (srednaVisochinaAstronavti + 0.40)
razmerKorab = shirinaKorab * duljinaKorab * visochinaKorab

broiAstronavti = math.floor(razmerKorab / razmerStaq)

if(broiAstronavti < 3):
    print(f"The spacecraft is too small.")
elif(broiAstronavti > 10):
    print(f"The spacecraft is too big.")
else:
    print(f"The spacecraft holds {broiAstronavti} astronauts.")
