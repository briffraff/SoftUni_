cenaHimikali = 5.80
cenaMarkeri = 7.20
cenaPreparatLitur = 1.20

himikaliBroiPaketi = int(input())
markeriBroiPaketi = int(input())
litriPreparat = float(input())
procentNamalenie = int(input())

razhodHimikali = himikaliBroiPaketi * cenaHimikali
razhodMarkeri = markeriBroiPaketi * cenaMarkeri
razhodPreparat = litriPreparat * cenaPreparatLitur

obshtRazhod = razhodHimikali + razhodMarkeri + razhodPreparat

namalenie = (obshtRazhod * procentNamalenie) / 100

krainaSuma = obshtRazhod - namalenie

print(f"{krainaSuma:.3f}")