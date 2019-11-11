age = float(input())
gender = input().lower()

if(age < 16):
    if(gender == "m"):
         print("Master")
    elif(gender == "f"):
        print("Miss")
else:
    if(gender == "m"):
        print("Mr.")
    elif(gender == "f"):
        print("Ms.")