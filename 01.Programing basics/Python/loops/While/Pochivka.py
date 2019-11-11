neededMoney = float(input())
money = float(input())

countDays = 0
daysSpend = 0

while True:
    command = input()
    value = float(input())
    countDays += 1

    if (command == "spend"):
        daysSpend += 1

        if (value >= money):
            money = 0
        else:
            money -= value

        if(daysSpend == 5):
            print("You can't save the money.")
            print(f"{countDays}")
            break

    if (command == "save"):
        daysSpend = 0
        money += value
        if (money == neededMoney):
            print(f"You saved the money for {countDays} days.")
            break
