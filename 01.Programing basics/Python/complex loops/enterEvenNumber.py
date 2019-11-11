number = 1
while number % 2 != 0:
    number = int(input("Enter even number: "))

    if (number % 2 != 0):
        print("Invalid number!")
    else:
        break

print(f"Even number entered: {number}")

