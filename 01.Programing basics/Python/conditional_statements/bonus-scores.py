number = float(input())

bonusPoints = 0

if (number <= 100):
    bonusPoints += 5
elif (number > 1000):
    bonusPoints += number * 0.1
elif (number > 100):
    bonusPoints += number * 0.2

if(number % 2 == 0):
    bonusPoints += 1
elif(number % 10 == 5):
    bonusPoints += 2

print(bonusPoints)
print(number + bonusPoints)