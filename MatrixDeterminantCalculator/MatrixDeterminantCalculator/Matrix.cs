using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixDeterminantCalculator {

    public class Matrix {
        private double[,] matrix;
        public readonly int w;
        public readonly int h;

        public Matrix(double[][] nums) {
            w = nums.Length;
            h = w == 0 ? 0 : nums[0].Length;
            matrix = new double[w, h];
            for (int x = 0; x < w; x++) {
                for (int y = 0; y < h; y++) {
                    matrix[x, y] = nums[x][y];
                }
            }
        }

        public Matrix(int w, int h) {
            this.w = w;
            this.h = h;
            matrix = new double[w, h];
        }

        public double this[int i, int j] {
            get { return this.matrix[i, j]; }
            set { this.matrix[i, j] = value; }
        }

        public Matrix CalculateMinor(int x0, int y0) {
            if (x0 >= w || y0 >= h) {
                return null;
            }
            Matrix minor = new Matrix(w - 1, h - 1);
            int xOffset = 0;
            int yOffset = 0;
            for (int x = 0; x < w; x++) {
                if (x == x0) {
                    xOffset = 1;
                    continue;
                }
                for (int y = 0; y < h; y++) {
                    if (y == y0) {
                        yOffset = 1;
                        continue;
                    }
                    minor[x - xOffset, y - yOffset] = matrix[x, y];
                }
                yOffset = 0;
            }
            return minor;
        }

        public double CalculateDeterminant() {
            if(w != h) {
                return double.NaN;
            }
            if(w == 1) {
                return matrix[0, 0];
            }
            if(w == 2) {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            double determinant = 0;
            for(int i = 0; i < w; i++) {
                var minor = CalculateMinor(i, 0);
                double minorDeterminant = matrix[i, 0] * minor.CalculateDeterminant() * (((2 + i) & 1) == 0 ? 1 : -1);
                determinant += minorDeterminant;
            }
            return determinant;
        }
    }
}
