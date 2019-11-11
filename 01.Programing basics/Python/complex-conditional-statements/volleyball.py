year = input()
p = float(input())
h = float(input())

totalPlays = h
normalWeekends = 48 - h
totalPlays = totalPlays + (normalWeekends * 0.75)
totalPlays = totalPlays + (p * 2 / 3)

if (year == "leap"):
    totalPlays = totalPlays + (totalPlays * 0.15)

print(int(totalPlays))
