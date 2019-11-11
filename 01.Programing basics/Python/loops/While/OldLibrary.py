targetBookName = input()
capacity = int(input())

bookCounter = 0
book = ""

while True:
    book = input()

    if(book == targetBookName):
        print(f"You checked {bookCounter} books and found it.")
        break
    else:
        bookCounter += 1

    if(bookCounter >= capacity):
        break

if(bookCounter >= capacity):
    print(f"The book you search is not here!")
    print(f"You checked {bookCounter} books.")



