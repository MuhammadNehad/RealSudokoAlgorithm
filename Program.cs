// See https://aka.ms/new-console-template for more information
using RealSudokoAlgorithm;

int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };

int[][] goodSudoku3 =  {
                      new int[] {8,15,11,1, 6,2,10,14, 12,7,13,3, 16,9,4,5},
                      new int[] {10,6,3,16, 12,5,8,4, 14,15,1,9, 2,11,7,13},
                      new int[] {14,5,9,7, 11,3,15,13, 8,2,16,4 ,12,10,1,6},
                      new int[] {4,13,2,12, 1,9,7,16, 6,10,5,11 ,3,15,8,14},

                      new int[] {9,2,6,15, 14,1,11,7, 3,5,10,16, 4,8,13,12},
                      new int[] {3,16,12,8, 2,4,6,9, 11,14,7,13, 10,1,5,15},
                      new int[] {11,10,5,13, 8,12,3,15, 1,9,4,2, 7,6,14,16},
                      new int[] {1,4,7,14, 13,10,16,5, 15,6,8,12, 9,2,3,11},

                      new int[] { 13 ,7, 16, 5, 9 ,6, 1, 12,  2 ,8, 3, 10,  11, 14, 15 ,4},
                      new int[] {2 ,12, 8 ,11 , 7, 16, 14, 3 , 5, 4, 6, 15, 1, 13 ,9, 10},
                      new int[] {6, 3, 14 ,4 , 10 ,15, 13, 8 , 7, 11 ,9 ,1 , 5, 12, 16, 2 },
                      new int[] {15, 1, 10, 9 , 4, 11, 5, 2 , 13, 16 ,12, 14 , 8, 3, 6, 7},

                      new int[] {12, 8, 4, 3,  16, 7 ,2 ,10,  9 ,13, 14, 6 , 15, 5, 11, 1},
                      new int[] {5, 11 ,13, 2 , 3, 8, 4 ,6 , 10, 1, 15 ,7 , 14, 16, 12 ,9 },
                      new int[] {7, 9 ,1, 6,15, 14, 12 ,11 , 16, 3 ,2, 5,  13, 4 ,10, 8 },
                      new int[] {16, 14, 15, 10 , 5,13, 9, 17 , 4, 12, 11, 8  ,6, 7, 2, 3 },
                        };

Console.WriteLine(Sudoko.SundokoAlogrithm(goodSudoku1));
Console.WriteLine(Sudoko.SundokoAlogrithm(goodSudoku3));

namespace RealSudokoAlgorithm
{

    struct NumbersPositions
    {
        public int number = 0;
        public List<int> cols = new List<int>();
        public List<int> rows = new List<int>();
        public List<int[]> boxPlotPositions = new List<int[]>();
        public NumbersPositions() { }
    }
    public class Sudoko
    {

        public static bool SundokoAlogrithm(int[][] puzzle)
        {
            List<NumbersPositions> positions = new List<NumbersPositions>();
            NumbersPositions numbersPositions = new NumbersPositions();
            int N = puzzle.Length;
            double sqrrt = Math.Sqrt(N);
            double boxPercent = 100 / sqrrt;
            if (puzzle == null || puzzle.Length == 0 || sqrrt % 1 > 0)
            {
                return false;
            }

            for (int i = 0; i < N; i++)
            {
                int rowLength = puzzle[i].Length;
                if (rowLength > N)
                {
                    return false;
                }
                for (int j = 0; j < N; j++)
                {

                    int cell = puzzle[i][j];

                    if (cell < 1 || cell > 16)
                    {
                        return false;
                    }
                    int box = i + j;
                    int curCOlPerc = (int)Math.Round((double)100 * j / N, 3);
                    int CurrentBox = (int)(0.05f + (curCOlPerc / boxPercent));
                    int plot = (int)Math.Floor(((double)i / (double)sqrrt) + 1) - 1;

                    int[] boxPosition = new int[] { box, plot };

                    numbersPositions = positions.FirstOrDefault(mNumber => mNumber.number == cell);
                    if (numbersPositions.Equals(default(NumbersPositions)))
                    {
                        numbersPositions = new NumbersPositions();
                        numbersPositions.number = cell;
                        numbersPositions.rows.Add(i);
                        numbersPositions.cols.Add(j);
                        numbersPositions.boxPlotPositions.Add(new int[] { box, plot });
                        positions.Add(numbersPositions);
                    }
                    else
                    {
                        if (numbersPositions.cols.Contains(j) || numbersPositions.rows.Contains(i) || numbersPositions.boxPlotPositions.Contains(boxPosition))
                        {
                            return false;
                        }
                        else
                        {
                            int index = positions.FindIndex(mNumber => mNumber.number == cell);
                            numbersPositions.boxPlotPositions.Add(new int[] { box, plot });
                            numbersPositions.rows.Add(i);
                            numbersPositions.cols.Add(j);
                            positions[index] = numbersPositions;
                        }
                    }
                }
            }

            return true;
        }
    }
}