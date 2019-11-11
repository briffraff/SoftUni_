# Pepi iska da razbere dali otborut mu shte specheli
# ако отборът е вкарал повече голове в дадена среща, отколкото е получил, то той побеждава и получава 3 точки
# ако броят на вкараните и получените голове е равен, получава 1 точка
# при загуба броят на точките не се променя
# Окончателно отборът се класира, ако общият брой на вкараните голове от всички изиграни срещи е по-голям или равен на броя на получените.

# CEL : Dali otborut se klasira?

imeOtbor = input()
izigraniMachove = int(input())
obshtoVkaraniGolove = 0
obshtoPolucheniGolove = 0
tochki = 0
pobedi = 0

if (izigraniMachove != 0):
    for mach in range(izigraniMachove):
        vkaraniGolove = int(input())
        polucheniGolove = int(input())

        obshtoVkaraniGolove += vkaraniGolove
        obshtoPolucheniGolove += polucheniGolove

        if (vkaraniGolove > polucheniGolove):
            pobedi += 1
            tochki += 3
        elif (vkaraniGolove == polucheniGolove):
            tochki += 1
        elif (polucheniGolove > vkaraniGolove):
            tochki += 0

    razlika = obshtoVkaraniGolove - obshtoPolucheniGolove

    if (obshtoVkaraniGolove >= obshtoPolucheniGolove):
        print(f"{imeOtbor} has finished the group phase with {tochki} points.")
        print(f"Goal difference: {razlika}.")
    elif(obshtoPolucheniGolove > obshtoVkaraniGolove):
        print(f"{imeOtbor} has been eliminated from the group phase.")
        print(f"Goal difference: {razlika}.")
