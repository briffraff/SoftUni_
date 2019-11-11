# Вашата задача е да напишете програма която да следи до каква височина е достигнал Атанас и за колко дни е изкачил върха
# Той започва изкачването си от ден първи от базов лагер, който е на 5 364 метра, а самият връх е на 8 848м
# Преди всяко изкачване на определени метри, Атанас може да си почине в някой лагер и да продължи на следващия ден
# да продължи изкачването без да спре, като максималното време, в което той може да изкачва върха е 5 дни.
# Програмата приключва при получаване на командата "END", при достигане на върха(8 848м) или при превишаване на разрешените 5 дни за изкачване


obshtoDni = 1
izkacheniMetri = 0
nachalnaVisochina = 5364
krainaVisochina = 8848

while True:
    pochivka = input()

    if(pochivka == "Yes"):
        obshtoDni += 1
    if(obshtoDni > 5):
        break

    if (pochivka == "END"):
        break

    izkacheniMetri = int(input())

    nachalnaVisochina += izkacheniMetri

    if (nachalnaVisochina >= krainaVisochina):
        break

if (nachalnaVisochina >= krainaVisochina):
    print(f"Goal reached for {obshtoDni} days!")

elif (nachalnaVisochina < krainaVisochina):
    print(f"Failed!")
    print(f"{nachalnaVisochina}")
