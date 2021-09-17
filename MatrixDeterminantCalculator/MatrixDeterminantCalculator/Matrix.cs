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
            for(int x = 0; x < w; x++) {
                for(int y = 0; y < h; y++) {
                    matrix[x, y] = nums[x][y];
                }
            }
        }

        public double this[int i, int j] {
            get { return this.matrix[i, j]; }
            set { this.matrix[i, j] = value; }
        }
    }
}
