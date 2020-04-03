import matplotlib.pyplot as plt


X = [];
Y = [];

with open ("PhotoelectricEffect/currentVSvoltage.dat", "r") as fp:
    for line in fp:
        x, y = line.split();
        print(x,y)
        X.append(float(x));
        Y.append(float(y)*1e12);

plt.figure();
plt.scatter(X, Y)
plt.show();