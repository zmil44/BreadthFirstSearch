using System;
using System.Collections.Generic;

namespace BreadthFirstSearch
{
    public class BFS
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("This program is to test Breadth First Search");

            /* The problem i am attempting to solve is the following
             * 
             * Given a 2d array with values 0 (trench), 1 (flat ground), and 9 (obstacle), return the minimum distance
             * a robot has to move to remove the obstacle. The robot can only travel on flat ground, cannot leave the matrix
             * and can only travel north, south, east, or west. The robot will always start at 0,0. If the robot cannot reach 
             * the obstacle return -1
             * 
             * sample input 
             * [
             *  [1,0,0],
             *  [1,0,0],
             *  [1,9,1]
             * ]
             * 
             * output : 3
             * 
             */
        }

        public static int search(int[,] matrix)
        {
            int ROW = matrix.GetLength(0);
            int COLUMN = matrix.GetLength(1);
            int[] dRow = { -1, 0, 1, 0 };
            int[] dColumn = { 0, 1, 0, -1 };
            bool[,] visited = new bool[ROW, COLUMN];
            int count = 0;
            Queue<Pair> queue = new Queue<Pair>();
            queue.Enqueue(new Pair(0, 0));
            visited[0, 0] = true;

            //in case obstacle is in starting zone
            if (matrix[0, 0] == 9)
            {
                return 0;
            }
            while (queue.Count != 0)
            {
                //current cell you are on
                Pair cell = queue.Peek();
                int x = cell.first;
                int y = cell.second;
                //checking if current cell is the obstacle
                if (matrix[x,y] == 9)
                {
                    return count-1;
                }

                queue.Dequeue();


                for (int i=0; i< 4; i++)
                {
                    int adjX = x + dRow[i];
                    int adjY = y + dColumn[i];
                    if(isValid(visited, adjX, adjY, ROW, COLUMN, matrix))
                    {
                        queue.Enqueue(new Pair(adjX, adjY));
                        visited[adjX, adjY] = true;
                        
                    }
                }

                count++;
            }
            return -1;
        }

        public static bool isValid(bool [,] visited, int x, int y, int ROW, int COLUMN, int[,] matrix )
        {
            if(x <0 || x >= ROW || y < 0 || y >= COLUMN)
            {
                return false;
            }
            if (visited[x, y])
            {
                return false;
            }
            if(matrix[x,y] == 0)
            {
                return false;
            }
            return true;
        }
    }

    public class Pair
    {
        public int first, second;
        public Pair(int first, int second)
        {
            this.first = first;
            this.second = second;
        }
    }
}
