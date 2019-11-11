num = 0

while num < 1 or num > 100:
    num = int(input())

    if (num < 1 or num > 100):
        print("Invalid number!")
    else:
        break

print(f"The number is: {str(num)}")
