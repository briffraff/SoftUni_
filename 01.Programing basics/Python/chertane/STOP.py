n = int(input())
#TOP
tochki = (n+1)
tochkiZnak = "." * tochki

dolniCherti = (n*2+1)
dolniChertiZnak = "_" * dolniCherti

print(f"{tochkiZnak}{dolniChertiZnak}{tochkiZnak}")

tochki = tochki - 1
tochkiZnak2 = "." * tochki
dolniCherti = dolniCherti - 2
dolniChertiZnak2 = "_" * dolniCherti

print(f"{tochkiZnak2}//{dolniChertiZnak2}\\\\{tochkiZnak2}")

for x in range(1,n):
    tochki = tochki - 1
    tochkiZnak2 = "." * tochki
    dolniCherti = dolniCherti + 2
    dolniChertiZnak2 = "_" * dolniCherti
    print(f"{tochkiZnak2}//{dolniChertiZnak2}\\\\{tochkiZnak2}")

#MID

shirina = (n*4+3)
dolniCherti = int((shirina - 9)/2)
print("//" + "_" * dolniCherti + "STOP!" + "_" * dolniCherti + "\\\\")

#BOTT

shirina = (n * 4 + 3)
dolniCherti = shirina - 4

for x in range(0,n):
    print("." * x + "\\\\" + "_" * dolniCherti + "//" + "." * x)
    dolniCherti -= 2



