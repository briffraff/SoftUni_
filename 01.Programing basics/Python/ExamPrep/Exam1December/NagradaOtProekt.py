#Ани печели състезание за най-добре изготвен проект по история и получава парична награда.
#Проектът се провежда на няколко етапа, всеки от които носи различен брой точки.
#За всеки четен втап (2, 4, 6…) конкретните точки се умножават по две
#CEL: Да се напише програма, която пресмята каква сума са получили участниците.
#От конзолата се прочита на колко части е разделен проектът,
#  паричната награда за една точка и
#  колко точки се дават за всеки етап.

proektChasti = int(input())
pariZaTochka = float(input())

obshtoPari = 0
tochkiZaEtapa =0
obshtoTochki = 0

for x in range(1,proektChasti+1):
    tochkiZaEtapa = int(input())

    if(x % 2 == 0):
        tochkiZaEtapa *= 2
        obshtoTochki += tochkiZaEtapa
    elif(x % 2 != 0):
        obshtoTochki += tochkiZaEtapa

obshtoPari = pariZaTochka * obshtoTochki
print(f"The project prize was {obshtoPari:.2f} lv.")