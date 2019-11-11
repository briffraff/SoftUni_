gradusi = int(input())
dayState = input()
Outfit = ""
Shoes = ""

if(dayState == "Morning"):
    if(gradusi >= 10 and gradusi <= 18):
        Outfit = "Sweatshirt"
        Shoes = "Sneakers"
    elif(gradusi > 18 and gradusi <= 24):
        Outfit = "Shirt"
        Shoes = "Moccasins"
    elif(gradusi >= 25):
        Outfit = "T-Shirt"
        Shoes = "Sandals"

elif(dayState == "Afternoon"):
    if(gradusi >= 10 and gradusi <= 18):
        Outfit = "Shirt"
        Shoes = "Moccasins"
    elif(gradusi > 18 and gradusi <= 24):
        Outfit = "T-Shirt"
        Shoes = "Sandals"
    elif(gradusi >= 25):
        Outfit = "Swim Suit"
        Shoes = "Barefoot"

elif(dayState == "Evening"):
    if(gradusi >= 10 and gradusi <= 18):
        Outfit = "Shirt"
        Shoes = "Moccasins"
    elif(gradusi > 18 and gradusi <= 24):
        Outfit = "Shirt"
        Shoes = "Moccasins"
    elif(gradusi >= 25):
        Outfit = "Shirt"
        Shoes = "Moccasins"

print(f"It's {gradusi} degrees, get your {Outfit} and {Shoes}.")
