from sys import argv

def main():
    f = open('C:/Users/anguyen/Desktop/Advent/2021/Dive/input.txt', 'r')
    content = f.read()
    f.close()
    data = content.strip().split('\n')
    
    print(dive(data))

def dive(input):
    currentX = 0
    currentY = 0
    currentAim = 0
    for i in input:
        tempSplit = i.split(" ")
        if(tempSplit[0] == 'forward'):
            currentX += int(tempSplit[1])
            currentY -= currentAim * int(tempSplit[1])
        elif(tempSplit[0] == 'up'):
            currentAim -= int(tempSplit[1])
        elif(tempSplit[0] == 'down'):
            currentAim += int(tempSplit[1])
        else:
            print('error')
        print(currentX, currentY, currentAim)
    
    currentY = min(0, currentY)
    return abs(currentY) * currentX

if __name__ == "__main__":
    main()


