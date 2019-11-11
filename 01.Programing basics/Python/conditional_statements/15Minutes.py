hours = int(input())
minutes = int(input())

minutes = minutes + 15

if (minutes > 59):
    hours = hours + 1
    minutes = minutes - 60

if (hours > 24):
    hours = 1
elif (hours > 23):
    hours = 0

if (minutes < 10):
    print(f"{hours}:0{minutes % 60}")
else:
    print(f"{hours}:{minutes % 60}")
