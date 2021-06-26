using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testlab
{
    public class Matrix
    {

        double[] A;
        public Matrix() { }
        public Matrix(int n)
        {   
            A = new double[n];
         
            for (int i = 0; i < n; i++)
                A[i] = (n + 1) - i;
        }

        public double[] Solve(double[] right)
        {

            int n = A.Length;
            double[] x = new double[n];
            x[0] = 1.0 / A[0];
            double[] y = new double[n];
            y[0] = x[0];
            for (int k = 1; k <= n - 1; k++)
            {   
                double Fk = 0;
                for (int i = 0; i < k; i++)
                    Fk += A[k - i] * x[i];
          
                double Gk = 0;
                for (int i = 0; i < k; i++)
                    Gk += A[i + 1] * y[i];
               
                double rk = 1.0 / (1.0 - Fk * Gk);
            	
                double sk = -rk * Fk;
              
                double tk = -rk * Gk;
                double[] x_old = new double[k];
                for (int i = 0; i < k; i++)
                    x_old[i] = x[i];
                double[] y_old = new double[k];
                for (int i = 0; i < k; i++)
                    y_old[i] = y[i];
                x[0] = x_old[0] * rk + 0 * sk;
                for (int i = 1; i < k; i++)
                    x[i] = x_old[i] * rk + y_old[i - 1] * sk;
                x[k] = 0 * rk + y_old[k - 1] * sk;
                y[0] = x_old[0] * tk + 0 * rk;
                for (int i = 1; i < k; i++)
                    y[i] = x_old[i] * tk + y_old[i - 1] * rk;
                y[k] = 0 * tk + y_old[k - 1] * rk;
            }

           
            double[,] matrix_a = new double[n, n];
            double[,] matrix_b = new double[n, n];
            double[,] matrix_c = new double[n, n];
            double[,] matrix_d = new double[n, n];


            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    matrix_a[i, j] = (i >= j) ? x[i - j] : 0;
                    matrix_b[i, j] = (j >= i) ? y[n - 1 - j + i] : 0;
                    matrix_c[i, j] = (i > j) ? y[i - 1 - j] : 0;
                    matrix_d[i, j] = (j > i) ? x[n - 1 - j + 1 + i] : 0;
                }

            double[,] matrix_ab = new double[n, n];
            double[,] matrix_cd = new double[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    double sum_ab = 0;
                    double sum_cd = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sum_ab += matrix_a[i, k] * matrix_b[k, j];
                        sum_cd += matrix_c[i, k] * matrix_d[k, j];
                    }
                    matrix_ab[i, j] = sum_ab;
                    matrix_cd[i, j] = sum_cd;
                }

            double[,] matrix_res = new double[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix_res[i, j] = (1.0 / x[0]) * (matrix_ab[i, j] - matrix_cd[i, j]);


            double[] answer = new double[n];

            for (int i = 0; i < n; i++)
            {
                answer[i] = 0;
                for (int j = 0; j < n; j++)
                    answer[i] += matrix_res[i, j] * right[j];
            }

            return answer;
        }

        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < A.Length; i++)
                text += A[i] + " ";
            return text;
        }
    }
}
