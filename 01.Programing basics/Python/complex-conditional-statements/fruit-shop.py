import math

fruit = input().lower()
day = input().lower()
amount = float(input())
price = -1

if (day == "monday" or day == "tuesday" or day == "wednesday" or day == "thursday" or day == "friday"):
    if (fruit == "banana"):

        price = amount * 2.5

    elif (fruit == "apple"):

        price = amount * 1.20

    elif (fruit == "orange"):

        price = amount * 0.85

    elif (fruit == "grapefruit"):

        price = amount * 1.45

    elif (fruit == "kiwi"):

        price = amount * 2.70

    elif (fruit == "pineapple"):

        price = amount * 5.50

    elif (fruit == "grapes"):

        price = amount * 3.85

    else:

        print("error")

elif (day == "saturday" or day == "sunday"):

    if (fruit == "banana"):

        price = amount * 2.7

    elif (fruit == "apple"):

        price = amount * 1.25

    elif (fruit == "orange"):

        price = amount * 0.90

    elif (fruit == "grapefruit"):

        price = amount * 1.60

    elif (fruit == "kiwi"):

        price = amount * 3.00

    elif (fruit == "pineapple"):

        price = amount * 5.60

    elif (fruit == "grapes"):

        price = amount * 4.20

    else:

        print("error")

else:

    print("error")

print(round(price, 2))
