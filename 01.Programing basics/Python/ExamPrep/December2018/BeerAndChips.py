import math

imeFen = input()
obshtBudjet = float(input())
broiButilkiBira = int(input())
broiPaketiChips = int(input())

cenaBira = 1.20
razhodBiri = broiButilkiBira * cenaBira

cenaChips = razhodBiri * 0.45
razhodChips = math.ceil(broiPaketiChips * cenaChips)

obshtRazhod = razhodBiri + razhodChips

if (obshtBudjet >= obshtRazhod):
    print(f"{imeFen} bought a snack and has {obshtBudjet-obshtRazhod:.2f} leva left.")
elif (obshtRazhod > obshtBudjet):
    print(f"{imeFen} needs {obshtRazhod - obshtBudjet:.2f} more leva!")
