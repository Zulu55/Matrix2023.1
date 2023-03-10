using System.Diagnostics.CodeAnalysis;

namespace Matrix.Logic
{
    public class MyMatrix
    {
        private int[,] _matrix;
        private int _n; // rows
        private int _m; // columns

        public MyMatrix()
        {
            _n = 10;
            _m = 10;
            _matrix = new int[_n, _m];
        }

        public MyMatrix(int n)
        {
            _n = n;
            _m = n;
            _matrix = new int[_n, _m];
        }

        public MyMatrix(int n, int m)
        {
            _n = n;
            _m = m;
            _matrix = new int[_n, _m];
        }

        public int N => _n;

        public int M => _m;

        public bool IsSquared => _n == _m;

        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    output += $"{_matrix[i, j]}\t";
                }
                output += "\n";
            }
            return output;
        }

        public void Fill()
        {
            Fill(1, 100);
        }

        public void Fill(int min, int max)
        {
            var random = new Random();
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    _matrix[i, j] = random.Next(min, max);
                }
            }
        }

        public MyArray GetMainDiagonal()
        {
            if (!IsSquared)
            {
                throw new Exception("The matrix is not squared");
            }

            var myArray = new MyArray(N);
            for (int i = 0; i < N; i++)
            {
                myArray.Add(_matrix[i, i]);
            }

            return myArray;
        }

        public MyArray GetSecondaryDiagonal()
        {
            if (!IsSquared)
            {
                throw new Exception("The matrix is not squared");
            }

            var myArray = new MyArray(N);
            for (int i = 0; i < N; i++)
            {
                myArray.Add(_matrix[i, N - i - 1]);
            }

            return myArray;
        }

        public string GetUpperTriangular()
        {
            if (!IsSquared)
            {
                throw new Exception("The matrix is not squared");
            }

            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i > j)
                    {
                        output+= "\t";
                    }
                    else
                    {
                        output += $"{_matrix[i, j]}\t";
                    }
                }
                output += "\n";
            }
            return output;
        }

        public string GetLowerTriangular()
        {
            if (!IsSquared)
            {
                throw new Exception("The matrix is not squared");
            }

            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    output += $"{_matrix[i, j]}\t";
                }
                output += "\n";
            }
            return output;
        }
    }
}
