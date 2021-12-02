from sys import argv

def main():
    f = open('C:/Users/anguyen/Desktop/Advent/2021/SonarSweep/input.txt', 'r')
    content = f.read()
    f.close()
    data = content.strip().split('\n')
    print(countIncreaseWindow(data))

def countIncrease(data):
    count = 0
    for i in range(1, len(data)):
        if int(data[i]) > int(data[i-1]):
            count += 1
    return count

def countIncreaseWindow(data):
    count = 0
    previousSum = int(data[0]) + int(data[1]) + int(data[2])
    for i in range(3, len(data)):
        currentSum = int(data[i]) + int(data[i-1]) + int(data[i-2])
        if currentSum > previousSum:
            count += 1
        previousSum = currentSum
    return count

if __name__ == "__main__":
    main()


