
import sys
import numpy as np
import matplotlib.pyplot as plt
def main():

    x = np.ndarray((12,1))
    y = np.ndarray((12,1))

    x[0,0] = -12
    x[1,0] = -10
    x[2,0] = -8
    x[3,0] = -5
    x[4,0] = -2
    x[5,0] = 1
    x[6,0] = 2
    x[7,0] = 3
    x[8,0] = 4
    x[9,0] = 5
    x[10,0] = 6
    x[11,0] = 7

    y[0,0] = 24.2
    y[1,0] = 72.6 
    y[2,0] = 76.2
    y[3,0] = 42.2
    y[4,0] = 0
    y[5,0] = -0.6
    y[6,0] = 8.3
    y[7,0] = 26
    y[8,0] = 57
    y[9,0] = 108
    y[10,0] = 173
    y[11,0] = 230


    A = np.ndarray((4,4))

    a1=a2=a3=a4=b1=b2=b3=b4=c1=c2=c3=c4=d1=d2=d3=d4=e1=e2=e3=e4=0
    i=j=0

    for i in range(len(x)):
            
            a1+=x[i,0]*x[i,0]*x[i,0]*x[i,0]*x[i,0]*x[i,0]
            a2+=x[i,0]*x[i,0]*x[i,0]*x[i,0]*x[i,0]
            a3+=x[i,0]*x[i,0]*x[i,0]*x[i,0]
            a4+=x[i,0]*x[i,0]*x[i,0]

            b1+=x[i,0]*x[i,0]*x[i,0]*x[i,0]*x[i,0]
            b2+=x[i,0]*x[i,0]*x[i,0]*x[i,0]
            b3+=x[i,0]*x[i,0]*x[i,0]
            b4+=x[i,0]*x[i,0]

            c1+= x[i,0]*x[i,0]*x[i,0]*x[i,0]
            c2+= x[i,0]*x[i,0]*x[i,0]
            c3+= x[i,0]*x[i,0]
            c4+= x[i,0]

            d1+=x[i,0]*x[i,0]*x[i,0]
            d2+=x[i,0]*x[i,0]
            d3+=x[i,0]
            d4+=1

            e1+=y[i,0]*x[i,0]*x[i,0]*x[i,0]
            e2+=y[i,0]*x[i,0]*x[i,0]
            e3+=y[i,0]*x[i,0]
            e4+=y[i,0]


    A[0,0] = a1
    A[0,1] = b1
    A[0,2] = c1
    A[0,3] = d1
    A[1,0] = a2
    A[1,1] = b2
    A[1,2] = c2
    A[1,3] = d2
    A[2,0] = a3
    A[2,1] = b3
    A[2,2] = c3
    A[2,3] = d3
    A[3,0] = a4
    A[3,1] = b4
    A[3,2] = c4
    A[3,3] = d4

    z = np.ndarray((4,1))

    z[0,0] = e1
    z[1,0] = e2
    z[2,0] = e3
    z[3,0] = e4

    ainv = np.linalg.inv(A)
    res = np.dot(ainv,z) # a = res[0,0] and b=[1,0]
    print(res)
    # do a scatter plot of the data
    area = 10
    colors =['black']
    plt.scatter(x, y, s=area, c=colors, alpha=0.5, linewidths=8)
    plt.title('Linear Least Squares Regression')
    plt.xlabel('x')
    plt.ylabel('y')
    #plot the fitted line
    yfitted = x*x*x*res[0,0] + res[1,0]*x*x + res[2,0]*x + res[3,0]
    line,=plt.plot(x, yfitted, '--', linewidth=2) #line plot
    line.set_color('red')
    plt.show()

if __name__ == "__main__":
    sys.exit(int(main() or 0))