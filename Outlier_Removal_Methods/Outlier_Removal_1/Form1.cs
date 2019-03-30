using Mapack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Outlier_Removal_1.ICPTransformation;

namespace Outlier_Removal_1
{
    public partial class Form1 : Form
    {
        List<Point> Shape1 = new List<Point>();
        List<Point> Shape2 = new List<Point>();
        List<Point> Shape2Transformed = new List<Point>();
        Transformation T = new Transformation();


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Initialise Shapes Button
        {
            Shape1.Clear();
            Shape2.Clear();
            Point p1a = new Point(20, 30);
            Point p2a = new Point(120, 50);
            Point p3a = new Point(160, 80);
            Point p4a = new Point(180, 300);
            Point p5a = new Point(100, 220);
            Point p6a = new Point(50, 280);
            Point p7a = new Point(20, 140);
            Shape1.Add(p1a);
            Shape1.Add(p2a);
            Shape1.Add(p3a);
            Shape1.Add(p4a);
            Shape1.Add(p5a);
            Shape1.Add(p6a);
            Shape1.Add(p7a);
            Transformation T2 = new Transformation();
            T2.A = 1.05; T2.B = 0.05; T2.T1 = 15; T2.T2 = 22;
            Shape2 = ApplyTransformation(T2, Shape1);
            Shape2[2] = new Point(Shape2[2].X + 10, Shape2[2].Y + 3);// change one point
                                                                     // add outliers to both shapes
            Point ptOutlier1 = new Point(200, 230);
            Shape1.Add(ptOutlier1);
            Point ptOutLier2 = new Point(270, 160);
            Shape2.Add(ptOutLier2);
            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = panShape1.CreateGraphics();
            DisplayShape(Shape1, pBlue, g);
            DisplayShape(Shape2, pRed, g);

        }

        private void button2_Click(object sender, EventArgs e) // Apply Transformation Button
        {
            T = ICPTransformation.ComputeTransformation(Shape1, Shape2);
            MessageBox.Show("Cost = " + ICPTransformation.ComputeCost(Shape1, Shape2, T).ToString());
            List<Point> Shape2T = ApplyTransformation(T, Shape2);
            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = panShape2.CreateGraphics();
            DisplayShape(Shape1, pBlue, g);
            DisplayShape(Shape2T, pRed, g);
        }

        void DisplayShape(List<Point> Shp, Pen pen, Graphics g)
        {
            Point? prevPoint = null; // nullable
            foreach (Point pt in Shp)
            {
                g.DrawEllipse(pen, new Rectangle(pt.X - 2, pt.Y - 2, 4, 4));
                if (prevPoint != null)
                    g.DrawLine(pen, (Point)prevPoint, pt);
                prevPoint = pt;
            }
            g.DrawLine(pen, Shp[0], Shp[Shp.Count - 1]);
        }
        List<Point> ApplyTransformation(Transformation T, List<Point> shpList)
        {
            List<Point> TList = new List<Point>();
            foreach (Point pt in shpList)
            {
                double xprime = T.A * pt.X + T.B * pt.Y + T.T1;
                double yprime = T.B * pt.X * -1 + T.A * pt.Y + T.T2;
                Point pTrans = new Point((int)xprime, (int)yprime);
                TList.Add(pTrans);
            }
            return TList;
        }


        private void button3_Click(object sender, EventArgs e) // Outlier Removal Button
        {

            List<Point> ResList1 = new List<Point>();
            List<Point> ResList2 = new List<Point>();
            int Outlier_Index = OutlineRemoval(Shape1, Shape2, T);
            int counter = 0;

            while (counter < Shape1.Count - 1)
            {

                if (counter == Outlier_Index) continue;

                ResList1.Add(Shape1[counter]);
                ResList2.Add(Shape2[counter]);

                counter++;
            }

            Transformation Tfinal = ICPTransformation.ComputeTransformation(ResList1, ResList2);
            List<Point> Shape2T = ApplyTransformation(Tfinal, ResList2);
            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = panShape3.CreateGraphics();
            DisplayShape(ResList1, pBlue, g);
            DisplayShape(Shape2T, pRed, g);
            MessageBox.Show("Cost = " + ICPTransformation.ComputeCost(ResList1, ResList2, Tfinal).ToString());

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        RANSAC RansacOutlierRemoval()
        {

            RANSAC rsc = new RANSAC();
            List<Point> tmp1 = new List<Point>();
            List<Point> tmp2 = new List<Point>();

            int attempts=0;
            int k = 30; // Actual number of attempts configured. 
            int threshold = 5; // Threshold measured on top of the cost, above which we will not add the new point to model.
            int d = 4; // Minimum number of points to accept proposed model.
            int sample = 3; // Initial random points at the start of the process. 

            double cost = int.MaxValue;
            double attempt_error;


            int[] rand_ind = new int[sample];

            while (attempts<k)
            {
                double running_cost;
                Point tmp_random1 = new Point();
                Point tmp_random2 = new Point();
                Transformation R = new Transformation();

                for (int i = 0; i<sample; i++)
                {

                    Random r = new Random();

                    int randomIndex = r.Next(Shape1.Count);
                    
                    while (rand_ind.Contains(randomIndex))
                    {
                        randomIndex = r.Next(Shape1.Count);
                    }
                    tmp_random1 = Shape1[randomIndex];
                    tmp_random2 = Shape2[randomIndex];

                    tmp1.Add(tmp_random1);
                    tmp2.Add(tmp_random2);

                    rand_ind[i] = randomIndex;
                }

                R = ICPTransformation.ComputeTransformation(tmp1, tmp2);
                running_cost = ICPTransformation.ComputeCost(tmp1, tmp2, R);

                List<Point> running_consensus_set1 = new List<Point>(tmp1);
                List<Point> running_consensus_set2 = new List<Point>(tmp2);


                for (int j = 0; j < Shape1.Count; j++)
                {

                    if (rand_ind.Contains(j)) continue; // random index has been used and point is on model list already.

                    else          // New random index - Add point to list and compute cost of hypothetical model.
                    {

                        //tmp1.Add(Shape1[j]);
                        //tmp2.Add(Shape2[j]);
                        running_consensus_set1.Add(Shape1[j]);
                        running_consensus_set2.Add(Shape2[j]);

                        Transformation tmp_model = ICPTransformation.ComputeTransformation(running_consensus_set1, running_consensus_set2);
                        double tmp_cost = ICPTransformation.ComputeCost(running_consensus_set1, running_consensus_set2, tmp_model);

                        if (Math.Abs(running_cost - tmp_cost) >= threshold)
                        {
                            running_consensus_set1.RemoveAt(running_consensus_set1.Count - 1);
                            running_consensus_set2.RemoveAt(running_consensus_set2.Count - 1);
                        }
                    }
                }

                        if (running_consensus_set1.Count > d)
                        {
                            Transformation transf_model = ICPTransformation.ComputeTransformation(running_consensus_set1, running_consensus_set2);
                            attempt_error = ICPTransformation.ComputeCost(running_consensus_set1, running_consensus_set2, transf_model);

                            if (rsc.best_error != running_cost) rsc.best_error = running_cost;

                            if ( attempt_error < cost ) // First iteration will go in here, as cost is set to high value. 
                            {

                                cost = attempt_error;
                                rsc.best_consensus1 = running_consensus_set1;
                                rsc.best_consensus2 = running_consensus_set2;
                                rsc.best_model = transf_model;
                                rsc.best_error = attempt_error;
                            }
                        }

                attempts = attempts + 1;

            }

            return rsc;
        }

        private void button4_Click(object sender, EventArgs e) // RANSAC Outlier Removal
        {
            RANSAC rsc = new RANSAC();
            rsc = RansacOutlierRemoval();

            List<Point> res1 = new List<Point>();
            List<Point> res2 = new List<Point>();

            for (int i = 0; i < Shape1.Count; i++) {

                if(rsc.best_consensus1.Contains(Shape1[i])) {

                    res1.Add(Shape1[i]);
                    res2.Add(Shape2[i]);
                }
            }

            List<Point> result_shape2 = ApplyTransformation(rsc.best_model, res2);

            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = panShape3.CreateGraphics();
            DisplayShape(res1, pBlue, g);
            DisplayShape(result_shape2, pRed, g);
            MessageBox.Show("Cost = " + rsc.best_error);

        }
    }
}
