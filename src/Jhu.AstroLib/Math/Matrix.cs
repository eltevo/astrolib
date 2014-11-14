using System;

namespace Jhu.AstroLib
{
    static class Matrix
    {
        public static double[] Multiply(double[] a, double[] b)
        {
            double[] r = new double[9];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    r[3 * i + j] = 0;

                    for (int k = 0; k < 3; k++)
                    {
                        r[3 * i + j] += a[3 * i + k] * b[3 * k + j];
                    }
                }
            }

            return r;
        }

        public static void Multiply(double[] r, ref double x, ref double y, ref double z)
        {
            double nx = r[3 * 0 + 0] * x + r[3 * 0 + 1] * y + r[3 * 0 + 2] * z;
            double ny = r[3 * 1 + 0] * x + r[3 * 1 + 1] * y + r[3 * 1 + 2] * z;
            double nz = r[3 * 2 + 0] * x + r[3 * 2 + 1] * y + r[3 * 2 + 2] * z;

            x = nx; y = ny; z = nz;
        }
    }
}
