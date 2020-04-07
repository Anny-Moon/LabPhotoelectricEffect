import matplotlib.pyplot as plt



def readFile(fileName, X, Y):
    with open (fileName, "r") as fp:
        for line in fp:
            x, y = line.split();
            #print(x,y)
            X.append(float(x));
            Y.append(float(y)*1e12);


def plot(color):
    try:
        X = [];
        Y = [];
        fileName = "PhotoelectricEffect/currentVSvoltage_" + color + ".dat"
        print("read from: " + fileName);
        readFile(fileName, X, Y);
        plt.scatter(X, Y, c=color, s = 1)
    except:
        print("no " + color);


plt.figure();
plot("blue")
plot("green")
plot("red")

plt.show();
