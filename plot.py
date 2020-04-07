import matplotlib.pyplot as plt



def readFile(fileName, X, Y):
    with open (fileName, "r") as fp:
        for line in fp:
            x, y = line.split();
            #print(x,y)
            X.append(float(x));
            Y.append(float(y)*1e10);


def plot(color, aperture):
    try:
        X = [];
        Y = [];
        fileName = "PhotoelectricEffect/currentVSvoltage_" + color +"_" + aperture+ ".dat"
        print("read from: " + fileName);
        readFile(fileName, X, Y);
        size =1;
        if(aperture == "2cm"):
            size = 1;

        if(aperture == "4cm"):
            size = 2;
        plt.scatter(X, Y, c=color, s = size)
    except:
        print("no " + color);


plt.figure();
plot("blue", "2cm")
plot("blue", "4cm")
plot("blue", "8cm")
plot("green","2cm")
#plot("red")

plt.show();
