
x = int(input())
print('*' * x)


for i in range(1, x - 1):
    print('*', end='')
    print(' ' * (x - 2), end='')
    print('*')


print('*' * x)
