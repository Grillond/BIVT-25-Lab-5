using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                int negatives = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives++;
                    }
                }
                answer[j] = negatives;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                int minIdx = 0;

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minIdx = j;
                    }
                }

                for (int j = minIdx; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }

                matrix[i, 0] = min;
            }
            // end
        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows, cols + 1];
            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int maxIdx = 0;

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIdx = j;
                    }
                }

                for (int j = 0; j <= maxIdx; j++)
                {
                    answer[i, j] = matrix[i, j];
                }

                answer[i, maxIdx + 1] = max;

                for (int j = maxIdx + 1; j < cols; j++)
                {
                    answer[i, j + 1] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int maxIdx = 0;

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIdx = j;
                    }
                }

                int sum = 0;
                int count = 0;

                for (int j = maxIdx + 1; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }

                if (count > 0)
                {
                    int average = sum / count;

                    for (int j = 0; j < maxIdx; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = average;
                        }
                    }
                }
            }
            // end
        }
        public void Task5(int[,] matrix, int k)
        {
            // code here
            bool flag = matrix != null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == 0 || cols == 0)
                flag = false;

            if (k < 0 || k >= cols)
                flag = false;

            if (!flag)
                return;

            int[] maxElements = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int maxInRow = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxInRow)
                        maxInRow = matrix[i, j];
                }
                maxElements[rows - 1 - i] = maxInRow;
            }

            for (int i = 0; i < rows; i++)
            {
                matrix[i, k] = maxElements[i];
            }
            // end
        }
        public void Task6(int[,] matrix, int[] array)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool flag = true;

            if (rows == 0 || cols == 0)
                flag = false;

            if (array.Length == 0)
                flag = false;

            if (cols != array.Length)
                flag = false;

            if (!flag)
                return;

            for (int j = 0; j < cols; j++)
            {
                int max = matrix[0, j];
                int maxIdx = 0;

                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIdx = i;
                    }
                }

                if (array[j] > max)
                {
                    matrix[maxIdx, j] = array[j];
                }
            }
            // end
        }

        public void Task7(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] minVals = new int[rows];
            int[] rowIdxs = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }
                minVals[i] = min;
                rowIdxs[i] = i;
            }

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                    if (minVals[i] < minVals[j])
                    {
                        int tempMin = minVals[i];
                        minVals[i] = minVals[j];
                        minVals[j] = tempMin;

                        int tempIdx = rowIdxs[i];
                        rowIdxs[i] = rowIdxs[j];
                        rowIdxs[j] = tempIdx;
                    }
                }
            }

            int[,] temp = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    temp[i, j] = matrix[rowIdxs[i], j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = temp[i, j];
                }
            }
            // end
        }

        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);

            if (matrix.GetLength(1) != rows)
                return null;

            answer = new int[2 * rows - 1];
            int idx = 0;

            for (int d = rows - 1; d >= 1 - rows; d--)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    int j = i - d;
                    if (j >= 0 && j < rows)
                    {
                        sum += matrix[i, j];
                    }
                }
                answer[idx++] = sum;
            }
            // end

            return answer;
        }

        public void Task9(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);

            if (matrix.GetLength(1) != rows)
                return;

            if (k < 0 || k >= rows)
                return;

            int maxRow = 0, maxCol = 0;
            int maxAbs = Math.Abs(matrix[0, 0]);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    int absVal = Math.Abs(matrix[i, j]);
                    if (absVal > maxAbs)
                    {
                        maxAbs = absVal;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            int[,] temp = new int[rows, rows];

            for (int i = 0; i < rows; i++)
            {
                int rowIdx = i;
                if (i == k) rowIdx = maxRow;
                else if (i < k && i < maxRow) rowIdx = i;
                else if (i < k && i >= maxRow) rowIdx = i + 1;
                else if (i > k && i <= maxRow) rowIdx = i - 1;
                else if (i > k && i > maxRow) rowIdx = i;

                for (int j = 0; j < rows; j++)
                {
                    int colIdx = j;
                    if (j == k) colIdx = maxCol;
                    else if (j < k && j < maxCol) colIdx = j;
                    else if (j < k && j >= maxCol) colIdx = j + 1;
                    else if (j > k && j <= maxCol) colIdx = j - 1;
                    else if (j > k && j > maxCol) colIdx = j;

                    temp[i, j] = matrix[rowIdx, colIdx];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[i, j] = temp[i, j];
                }
            }
            // end

        }

        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (colsA != rowsB)
                return null;

            answer = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int m = 0; m < colsA; m++)
                    {
                        sum += A[i, m] * B[m, j];
                    }
                    answer[i, j] = sum;
                }
            }

            // end

            return answer;
        }

        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            answer = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                        count++;
                }

                answer[i] = new int[count];
                int index = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][index++] = matrix[i, j];
                    }
                }
            }

            // end

            return answer;
        }

        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int total = 0;
            foreach (var row in array)
            {
                total += row.Length;
            }

            int n = (int)Math.Ceiling(Math.Sqrt(total));
            answer = new int[n, n];

            int curRow = 0;
            int curCol = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[curRow, curCol] = array[i][j];
                    curCol++;
                    if (curCol >= n)
                    {
                        curCol = 0;
                        curRow++;
                    }
                }
            }

            // end

            return answer;
        }
    }
}
