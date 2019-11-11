broiMasi = int(input())
duljinaNaMasa = float(input())
shirinaNaMasa = float(input())

pokrivka = (duljinaNaMasa + 2*0.30)*(shirinaNaMasa + 2*0.30)
kare = (duljinaNaMasa/2)*(duljinaNaMasa/2)

obshtoPokrivki = broiMasi*pokrivka
obshtoKareta = broiMasi*kare

cenaPokrivki = obshtoPokrivki * 7
cenaKareta = obshtoKareta * 9

obshtoPari = cenaKareta + cenaPokrivki

print(f"{obshtoPari:.2f} USD")
print(f"{(obshtoPari*1.85):.2f} BGN")
