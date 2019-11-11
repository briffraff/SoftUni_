duljina = int(input())
shirochina = int(input())
visochina = int(input())
procentDrugi = float(input())

obemNaAkvarium = duljina*shirochina*visochina
procentDrugi = (obemNaAkvarium*procentDrugi)/100

chistObemLitri = (obemNaAkvarium-procentDrugi)*0.001

print(f"{chistObemLitri:.3f}")