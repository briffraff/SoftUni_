# Pepi spechelil bilet z svetovnoto
# той трябвало да въведе единствено число – поредният номер на печелившата комбинация
# При достигане на този номер се генерира 5-символен код, съдържащ следната информация за мача:
# Като бонус Пепи получава и парична награда на стойност сумата от ASCII кодовете на буквите, събрана с цифрите на билетната комбинация.
# Напишете програма, която генерира билетната комбинация и изчислява нейната сума.

nomerKombinaciq = int(input())

counter = 0
combination = ""
prize = 0

for x1 in range(66, 76 + 1):
    symbol1 = chr(x1)
    for x2 in range(102, 97 - 1, -1):
        symbol2 = chr(x2)
        for x3 in range(65, 67 + 1):
            symbol3 = chr(x3)
            for x4 in range(1, 11):
                for x5 in range(10, 0, -1):
                    if (x1 % 2 == 0):
                        counter += 1
                        combination = f"{symbol1}{symbol2}{symbol3}{x4}{x5}"
                        prize = x1 + x2 + x3 + x4 + x5
                        if (counter == nomerKombinaciq):
                            print(f"Ticket combination: {combination}")
                            print(f"Prize: {prize} lv.")
