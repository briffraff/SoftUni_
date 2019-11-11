import math

dohod = float(input())
sredenUspeh = float(input())
minimalnaRabotnaZaplata = float(input())

socialnaStipendiq = (minimalnaRabotnaZaplata * 35) / 100
stipendiqOtlichenUspeh = sredenUspeh * 25

if (dohod < minimalnaRabotnaZaplata and sredenUspeh > 4.5 and socialnaStipendiq > stipendiqOtlichenUspeh):

    print(f"You get a Social scholarship {math.floor(socialnaStipendiq)} BGN")

elif (sredenUspeh >= 5.5 and stipendiqOtlichenUspeh >= socialnaStipendiq):

    print(f"You get a scholarship for excellent results {math.floor(stipendiqOtlichenUspeh)} BGN")
else:
    print(f"You cannot get a scholarship!")
