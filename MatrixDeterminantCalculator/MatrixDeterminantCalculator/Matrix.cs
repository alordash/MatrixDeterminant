using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixDeterminantCalculator {

    public class Matrix {
        private double[,] matrix;
        public readonly int width;
        public readonly int height;

        public Matrix(double[][] nums) {
            width = nums.Length;
            height = width == 0 ? 0 : nums[0].Length;
            matrix = new double[width, height];
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    matrix[x, y] = nums[x][y];
                }
            }
        }

        public Matrix(int w, int h) {
            this.width = w;
            this.height = h;
            matrix = new double[w, h];
        }

        public double this[int i, int j] {
            get { return this.matrix[i, j]; }
            set { this.matrix[i, j] = value; }
        }

        public Matrix CalculateMinor(int x0, int y0) {
            if (x0 >= width || y0 >= height) {
                return null;
            }
            Matrix minor = new Matrix(width - 1, height - 1);
            int xOffset = 0;
            int yOffset = 0;
            for (int x = 0; x < width; x++) {
                if (x == x0) {
                    xOffset = 1;
                    continue;
                }
                for (int y = 0; y < height; y++) {
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

        public async Task<double> CalculateDeterminant() {
            if (width != height) {
                return double.NaN;
            }
            if(width == 1) {
                return matrix[0, 0];
            }
            if(width == 2) {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            await Task.Delay(1);
            double determinant = 0;
            for (int i = 0; i < width; i++) {
                var m = matrix[i, 0];
                if (m != 0) {
                    var minor = CalculateMinor(i, 0);
                    double minorDeterminant = m * (await minor.CalculateDeterminant()) * (((2 + i) & 1) == 0 ? 1 : -1);
                    determinant += minorDeterminant;
                }
            }
            return determinant;
        }
    }
}
