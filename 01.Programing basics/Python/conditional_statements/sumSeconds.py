import math

p1 = int(input())
p2 = int(input())
p3 = int(input())

secondsCount = p1 + p2 + p3

minutes = math.floor(secondsCount / 60)
seconds = secondsCount % 60

if(secondsCount < 10 or seconds < 10):
    print(f"{minutes}:0{seconds}")
else:
    print(f"{minutes}:{seconds}")
