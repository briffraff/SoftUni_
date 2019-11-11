import math

firstBrother = float(input())
secondBrother = float(input())
thirdBrother = float(input())
fatherBusyTime = float(input())

brothersTiming = 1/(1/firstBrother + 1/secondBrother + 1/thirdBrother)
busyTime = brothersTiming * 1.15
remainingTime = busyTime - fatherBusyTime

print(f"Cleaning time: {busyTime:.2f}")
if (busyTime < fatherBusyTime):
    print(f"Yes, there is a surprise - time left -> {math.floor(math.fabs(remainingTime))} hours.")
else:
    remainingTime = math.fabs(remainingTime)
    print(f"No, there isn't a surprise - shortage of time -> {math.ceil(remainingTime)} hours.")
