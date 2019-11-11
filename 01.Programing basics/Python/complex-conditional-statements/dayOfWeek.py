input = int(input())

daysofweek = {
    1: "Monday",
    2: "Tuesday",
    3: "Wednesday",
    4: "Thursday",
    5: "Friday",
    6: "Saturday",
    7: "Sunday",
}

chosenDay = daysofweek[input]

if (input < 1 or input > 7):
    print("Error")
else:
    print(chosenDay)
