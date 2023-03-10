namespace Matrix.Logic
{
    public class MyArray
    {
        private int _top; // Logic size
        private int[] _array;

        public MyArray(int n)
        {
            N = n;
            _array = new int[n];
            _top = 0;
        }

        /// <summary>
        /// Indicates if the array is full
        /// </summary>
        public bool IsFull => _top == N;

        /// <summary>
        /// Indicates if the array is empty
        /// </summary>
        public bool IsEmpty => _top == 0;

        /// <summary>
        /// Physical size of the array
        /// </summary>
        public int N { get; } // Physical size

        public void Add(int number)
        {
            if (IsFull)
            {
                throw new Exception("The array is full.");
            }

            _array[_top] = number;
            _top++;
        }

        public void Insert(int number, int position)
        {
            if (IsFull)
            {
                throw new Exception("The array is full.");
            }

            if (position < 0)
            {
                position = 0;
            }

            if (position > _top)
            {
                position = _top;
            }

            for (int i = _top; i > position; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[position] = number;
            _top++;
        }

        public void Remove(int position)
        {
            if (IsEmpty)
            {
                throw new Exception("The array is empty.");
            }

            if (position < 0)
            {
                position = 0;
            }

            if (position > _top)
            {
                position = _top;
            }

            for (int i = position; i < _top - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _top--;
        }

        public void Fill()
        {
            Fill(1, 100);
        }

        public void Fill(int minimun, int maximun)
        {
            var random = new Random();
            for (int i = 0; i < N; i++)
            {
                _array[i] = random.Next(minimun, maximun);
            }
            _top = N;
        }

        public MyArray GetPrimes()
        {
            int primesCount = 0;
            for (int i = 0; i < _top; i++)
            {
                if (IsPrime(_array[i]))
                {
                    primesCount++;
                }
            }

            var primesArray = new MyArray(primesCount);
            for (int i = 0; i < _top; i++)
            {
                if (IsPrime(_array[i]))
                {
                    primesArray.Add(_array[i]);
                }
            }

            return primesArray;

        }

        public MyArray GetOdds()
        {
            int oddsCount = 0;
            for (int i = 0; i < _top; i++)
            {
                if (IsOdd(_array[i]))
                {
                    oddsCount++;
                }
            }

            var oddsArray = new MyArray(oddsCount);
            for (int i = 0; i < _top; i++)
            {
                if (IsOdd(_array[i]))
                {
                    oddsArray.Add(_array[i]);
                }
            }

            return oddsArray;
        }

        public MyArray GetNonRepeated()
        {
            int nonRepeatedCount = 0;
            for (int i = 0; i < _top; i++)
            {
                bool isRepeated = false;
                for (int j = 0; j < _top; j++)
                {
                    if (i != j && _array[i] == _array[j])
                    {
                        isRepeated = true;
                        break;
                    }
                }
                if (!isRepeated)
                {
                    nonRepeatedCount++;
                }
            }

            var nonRepeated = new MyArray(nonRepeatedCount);
            for (int i = 0; i < _top; i++)
            {
                bool isRepeated = false;
                for (int j = 0; j < _top; j++)
                {
                    if (i != j && _array[i] == _array[j])
                    {
                        isRepeated = true;
                        break;
                    }
                }
                if (!isRepeated)
                {
                    nonRepeated.Add(_array[i]);
                }
            }
            return nonRepeated;
        }

        public MyArray GetMostRepeated()
        {
            int[,] matrixCount = new int[_top, 2];
            int topMatrix = FillMatrixCount(matrixCount);
            OrderMatrixCount(matrixCount, topMatrix);
            int repeatedCounter = GetRepeatedCounter(matrixCount, topMatrix);
            return FillMostRepeated(repeatedCounter, matrixCount);
        }

        private MyArray FillMostRepeated(int repeatedCounter, int[,] matrixCount)
        {
            var mostRepeated = new MyArray(repeatedCounter);
            for (int i = 0; i < repeatedCounter; i++)
            {
                mostRepeated.Add(matrixCount[i, 0]);
            }
            return mostRepeated;
        }

        private int GetRepeatedCounter(int[,] matrixCount, int topMatrix)
        {
            int repeatedCounter = 1;
            for (; repeatedCounter < topMatrix; repeatedCounter++)
            {
                if (matrixCount[0, 1] != matrixCount[repeatedCounter, 1])
                {
                    break;
                }
            }
            return repeatedCounter;
        }

        private void OrderMatrixCount(int[,] matrixCount, int topMatrix)
        {
            for (int i = 0; i < topMatrix - 1; i++)
            {
                for (int j = i + 1; j < topMatrix; j++)
                {
                    if (matrixCount[i, 1] < matrixCount[j, 1])
                    {
                        Change(ref matrixCount[i, 0], ref matrixCount[j, 0]);
                        Change(ref matrixCount[i, 1], ref matrixCount[j, 1]);
                    }
                }
            }
        }

        private int FillMatrixCount(int[,] matrixCount)
        {
            int topMatrix = 0;
            for (int i = 0; i < _top; i++)
            {
                int j = 0;
                for (; j < topMatrix; j++)
                {
                    if (_array[i] == matrixCount[j, 0])
                    {
                        matrixCount[j, 1]++;
                        break;
                    }
                }
                if (j == topMatrix)
                {
                    matrixCount[topMatrix, 0] = _array[i];
                    matrixCount[topMatrix, 1] = 1;
                    topMatrix++;
                }
            }

            return topMatrix;
        }

        private bool IsOdd(int n)
        {
            return n % 2 == 0;
        }

        public override string ToString()
        {
            if (IsEmpty)
            {
                return "Empty array.";
            }

            string output = string.Empty;
            int count = 0;
            for (int i = 0; i < _top; i++)
            {
                output += $"{_array[i]}\t";
                count++;
                if (count > 9)
                {
                    count = 0;
                    output += "\n";
                }
            }
            return output;
        }

        public void Sort()
        {
            Sort(descending: false);
        }

        public void Sort(bool descending)
        {
            for (int i = 0; i < _top - 1; i++)
            {
                for (int j = i + 1; j < _top; j++)
                {
                    if (descending)
                    {
                        if (_array[i] < _array[j])
                        {
                            Change(ref _array[i], ref _array[j]);
                        }
                    }
                    else
                    {
                        if (_array[i] > _array[j])
                        {
                            Change(ref _array[i], ref _array[j]);
                        }
                    }
                }
            }
        }

        private bool IsPrime(int n)
        {
            if (n == 1) return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void Change(ref int a, ref int b)
        {
            int aux = a;
            a = b;
            b = aux;
        }
    }
}
