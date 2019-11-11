import math

duljina = float(input())*100
shirina = float(input())*100
garderobStrana = float(input())*100

zala = duljina*shirina
garderob = garderobStrana*garderobStrana
peika = zala/10

svobodnoMqsto = zala-garderob-peika

tancior = 7040

broiTanciori = svobodnoMqsto/tancior

print(math.floor(broiTanciori))