zelenchuciKgCena = float(input())
plodoveKgCena = float(input())
zelenchuci = int(input())
plodove = int(input())

prihodiZelenchuci = zelenchuci * zelenchuciKgCena
prihodiPlodove = plodove * plodoveKgCena

obshtoPrihodi = (prihodiPlodove + prihodiZelenchuci) / 1.94

print(obshtoPrihodi)
