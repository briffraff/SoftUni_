#На конзолата се въвежда рекордът в секунди, който Георги трябва да подобри
#разстоянието в метри, което трябва да изкачи
#  времето в секунди, за което той изкачва 1 метър.
#CEL: Да се напише програма, която изчислява дали се е справил със задачата
#наклона на терена го забавя на всеки 50 м. с 30 секунди.
#Да се изчисли времето в секунди, за което Георги ще изкачи разстоянието до върха и разликата спрямо рекорда.
import math

rekordSekundi = float(input())
razstoqnieMetri = float(input())
vremeZaMetur = float(input())

vreme = razstoqnieMetri * vremeZaMetur

zabavqne = math.floor(razstoqnieMetri / 50)
vremeZabavqne = zabavqne * 30

obshtoVreme = vreme + vremeZabavqne

if(obshtoVreme < rekordSekundi):
    print(f"Yes! The new record is {obshtoVreme:.2f} seconds.")
elif(obshtoVreme >= rekordSekundi):
    print(f"No! He was {(obshtoVreme - rekordSekundi):.2f} seconds slower.")
