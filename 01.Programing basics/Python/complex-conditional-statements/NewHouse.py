cvetq = input()
broiCvetq = int(input())
budget = int(input())

krainaCena = 0

roza = 5
daliq = 3.8
lale = 2.8
narcis = 3
gladiola = 2.5

if (cvetq == "Roses"):
    if (broiCvetq > 80):
        krainaCena += (broiCvetq * roza) * 0.90
    else:
        krainaCena += broiCvetq * roza

if (cvetq == "Dahlias"):
    if (broiCvetq > 90):
        krainaCena += (broiCvetq * daliq) * 0.85
    else:
        krainaCena += broiCvetq * daliq

if (cvetq == "Tulips"):
    if (broiCvetq > 80):
        krainaCena += (broiCvetq * lale) * 0.85
    else:
        krainaCena += broiCvetq * lale

if (cvetq == "Narcissus"):
    if (broiCvetq < 120):
        krainaCena += (broiCvetq * narcis) * 1.15
    else:
        krainaCena += broiCvetq * narcis

if (cvetq == "Gladiolus"):
    if (broiCvetq < 80):
        krainaCena += (broiCvetq * gladiola) * 1.20
    else:
        krainaCena += broiCvetq * gladiola

if(krainaCena > budget):
    print(f"Not enough money, you need {krainaCena-budget:.2f} leva more.")
else:
    print(f"Hey, you have a great garden with {broiCvetq} {cvetq} and {budget-krainaCena:.2f} leva left.")

