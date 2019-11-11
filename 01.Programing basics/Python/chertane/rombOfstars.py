n = int(input())

#TOP

freespace = n-1

for x in range(1,n,+1):
    print((" " * freespace) + "* "*x)
    freespace -= 1

#MID
print("* " * n)

#BOTT

freespace += 1
for x in range(n,1,-1):
    x -= 1
    print((" " * freespace) + "* "*x)
    freespace += 1


#  *
# * *
#* * *
# * *
#  *
