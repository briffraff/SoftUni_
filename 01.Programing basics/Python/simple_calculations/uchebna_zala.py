import math

duljina = float(input())
shirina = float(input())

mestaPoDuljinata = math.floor((duljina*100) / 120)
mestapoShirinata = math.floor((shirina*100 - 100) / 70)

broiMesta = (mestapoShirinata * mestaPoDuljinata) - 3

print(broiMesta)
