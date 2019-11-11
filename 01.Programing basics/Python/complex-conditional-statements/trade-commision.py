town = input().lower()

sales = float(input())

comission = 0.0

if (town == "sofia"):
    if (0 <= sales and sales <= 500):
        comission = 0.05
    elif (500 < sales and sales <= 1000):
        comission = 0.07
    elif (1000 < sales and sales <= 10000):
        comission = 0.08
    elif (sales > 10000):
        comission = 0.12

elif (town == "varna"):
    if (0 <= sales and sales <= 500):
        comission = 0.045
    elif (500 < sales and sales <= 1000):
        comission = 0.075
    elif (1000 < sales and sales <= 10000):
        comission = 0.1
    elif (sales > 10000):
        comission = 0.13


elif (town == "plovdiv"):
    if (0 <= sales and sales <= 500):
        comission = 0.055
    elif (500 < sales and sales <= 1000):
        comission = 0.08
    elif (1000 < sales and sales <= 10000):
        comission = 0.12
    elif (sales > 10000):
        comission = 0.145

if (town != "sofia" and town != "varna" and town != "plovdiv" and sales < 0):
    print("error")
else:
    suma = sales*comission
    print(f"{suma:.2f}")
