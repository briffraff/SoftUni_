dni = int(input())
broiSladkari = int(input())
torti = int(input())
gofreti = int(input())
palachinki = int(input())

cenaTorta = 45
cenaGofreta = 5.8
cenaPalachinka = 3.2

sumaZaDen = (torti * cenaTorta) + (gofreti * cenaGofreta) + (palachinki * cenaPalachinka)
subranaSuma = dni * sumaZaDen * broiSladkari

razhodi = (subranaSuma/8)

krainaSuma = subranaSuma - razhodi

print(f"{krainaSuma:.2f}")