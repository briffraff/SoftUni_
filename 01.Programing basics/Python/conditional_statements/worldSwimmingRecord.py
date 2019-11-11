import math

recordInSec = float(input())
distanceInM = float(input())
oneMeterTime = float(input())

time = distanceInM * oneMeterTime
addTime = math.floor(distanceInM / 15) * 12.5
time = time + addTime
timeDif = math.fabs(time - recordInSec)

if(time < recordInSec ):
    print(f"Yes, he succeeded! The new world record is {time:.2f} seconds.")
else:
    print(f"No, he failed! He was {timeDif:.2f} seconds slower.")
