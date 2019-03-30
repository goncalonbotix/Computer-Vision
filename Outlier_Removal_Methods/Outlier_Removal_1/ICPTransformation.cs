using Mapack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Outlier_Removal_1
{
    class ICPTransformation
    {
        public static Transformation ComputeTransformation(List<Point> Shp1, List<Point> Shp2)
        {
            Matrix A = new Matrix(4, 4);
            Matrix B = new Matrix(4, 1);
            for (int i = 0; i < Shp1.Count; i++)
            {
                int x1 = Shp1[i].X;
                int x2 = Shp2[i].X;
                int y1 = Shp1[i].Y;
                int y2 = Shp2[i].Y;

                A[0, 0] += 2 * x2 * x2 + 2 * y2 * y2;
                A[1, 0] += 0;
                A[2, 0] += 2 * x2;
                A[3, 0] += 2 * y2;
                A[0, 1] += 0;
                A[1, 1] += 2 * x2 * x2 + 2 * y2 * y2;
                A[2, 1] += 2 * y2;
                A[3, 1] += 2 * x2 * (-1);
                A[0, 2] += 2 * x2;
                A[1, 2] += 2 * y2;
                A[2, 2] += 2;
                A[3, 2] += 0;
                A[0, 3] += 2 * y2;
                A[1, 3] += 2 * x2 * (-1);
                A[2, 3] += 0;
                A[3, 3] += 2;

                B[0, 0] += 2 * x2 * x1 + 2 * y1 * y2;
                B[1, 0] += 2 * x1 * y2 - 2 * x2 * y1;
                B[2, 0] += 2 * x1;
                B[3, 0] += 2 * y1;
            }

            Matrix Ainv = A.Inverse;
            Matrix Res = Ainv * B;
            Transformation T = new Transformation();
            T.A = Res[0, 0];
            T.B = Res[1, 0];
            T.T1 = Res[2, 0];
            T.T2 = Res[3, 0];
            return T;
        }
        public static double ComputeCost(List<Point> P1List, List<Point> P2List, Transformation T)
        {
            double cost = 0;
            for (int i = 0; i < P1List.Count; i++)
            {
                double xprime = T.A * P2List[i].X + T.B * P2List[i].Y + T.T1;
                double yprime = -1 * T.B * P2List[i].X + T.A * P2List[i].Y + T.T2;
                cost += (P1List[i].X - xprime) * (P1List[i].X - xprime) +
                (P1List[i].Y - yprime) * (P1List[i].Y - yprime);
            }
            return cost;
        }

        public static int OutlineRemoval(List<Point> P1List, List<Point> P2List, Transformation T)
        {
            double max = 0;
            int Outlier_Index = 0;
            double[] cost = new double[P1List.Count];
            List<Point> Res = new List<Point>();

            for (int i = 0; i < P1List.Count; i++)
            {

                List<Point> list1 = new List<Point>();
                List<Point> list2 = new List<Point>();

                double xprime = T.A * P2List[i].X + T.B * P2List[i].Y + T.T1;
                double yprime = -1 * T.B * P2List[i].X + T.A * P2List[i].Y + T.T2;

                cost[i] = (P1List[i].X - xprime) * (P1List[i].X - xprime) +
                (P1List[i].Y - yprime) * (P1List[i].Y - yprime);


                if (cost[i] > max)
                {
                    max = cost[i];
                    Outlier_Index = i;
                }
            }

            
            return Outlier_Index;
        } 
    }
}