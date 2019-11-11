broiOcenki = int(input())
taskName = ""

scoreCounter = 0
sumOftheScores = 0
lowScoresCounter = 0

while True:
    lastProblem = taskName
    taskName = input()

    if (taskName == "Enough"):

        averageScore = sumOftheScores/scoreCounter
        print(f"Average score: {averageScore:.2f}")
        print(f"Number of problems: {scoreCounter}")
        print(f"Last problem: {lastProblem}")
        break

    ocenka = int(input())

    sumOftheScores += ocenka
    scoreCounter += 1

    if (ocenka <= 4):
        lowScoresCounter += 1

    if (lowScoresCounter == broiOcenki):
        print(f"You need a break, {lowScoresCounter} poor grades.")
        break
