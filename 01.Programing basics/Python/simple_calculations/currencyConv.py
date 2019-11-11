suma = float(input())
vhodnaValuta = input()
izhodnaValuta = input()

lev = 1.0
dollar = 1.79549
euro = 1.95583
pound = 2.53405

result = 0

while (vhodnaValuta == "BGN"):
    if (izhodnaValuta == "USD"):
        result = suma / dollar
    if (izhodnaValuta == "EUR"):
        result = suma / euro
    if (izhodnaValuta == "GBP"):
        result = suma / pound
    if (izhodnaValuta == "BGN"):
        result = suma
    break

while (vhodnaValuta == "USD"):
    if (izhodnaValuta == "USD"):
        result = suma
    if (izhodnaValuta == "EUR"):
        result = (suma / euro) * dollar
    if (izhodnaValuta == "GBP"):
        result = (suma / pound) * dollar
    if (izhodnaValuta == "BGN"):
        result = (suma / lev) * dollar
    break

while (vhodnaValuta == "GBP"):
    if (izhodnaValuta == "USD"):
        result = (suma / dollar) * pound
    if (izhodnaValuta == "EUR"):
        result = (suma / euro) * pound
    if (izhodnaValuta == "GBP"):
        result = suma
    if (izhodnaValuta == "BGN"):
        result = (suma / lev) * pound
    break

while (vhodnaValuta == "EUR"):
    if (izhodnaValuta == "USD"):
        result = (suma / dollar) * euro
    if (izhodnaValuta == "EUR"):
        result = suma
    if (izhodnaValuta == "GBP"):
        result = (suma / pound) * euro
    if (izhodnaValuta == "BGN"):
        result = (suma / lev) * euro
    break

print(f"{result:.2f} {izhodnaValuta}")
