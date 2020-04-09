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
        
        plt.scatter(X, Y, c="red", s = 2)
    except:
        print("no " + color + "nm, " + aperture + " cm." );

fig = plt.figure()
plot("365", "2")
plot("365", "4")
plot("365", "8")
#plot("436","2")
#plot("577", "2")

plt.show();
fig.savefig("currentVSvoltage.png");