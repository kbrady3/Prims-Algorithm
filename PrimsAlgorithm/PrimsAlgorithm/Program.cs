using System;

namespace PrimsAlgorithm
{
    class Program
    {
        public static void Main(string[] args)
        {
            int rows = 5;
            Coordinates[] collection = new Coordinates[rows];

            int[,] graph = new int[,] { { 0, 2, 0, 6, 0 },
                                      { 2, 0, 3, 8, 5 },
                                      { 0, 3, 0, 0, 7 },
                                      { 6, 8, 0, 0, 9 },
                                      { 0, 5, 7, 9, 0 } };

            //Loops through 2-dimensional array to get all nonzero values (the weights)
            int uBound0 = graph.GetUpperBound(0);
            int uBound1 = graph.GetUpperBound(1);
            for (int x = 0; x <= uBound0; x++)
            {
                Console.WriteLine("ROW: " + x);

                for (int y = 0; y <= uBound1; y++)
                {
                    int weight = graph[x, y];
                    Console.WriteLine("Weight: " + weight + ", Coordinates: " + x + "," + y);

                    //Insert all nonzero numbers into collection
                    if(weight != 0)
                    {
                        collection[x] = new Coordinates(x, y, weight);
                    }
                }
            }
            //End 2-dimensional array loop

            Coordinates[] tempCollection = new Coordinates[rows];
            tempCollection = collection;

            foreach(Coordinates c in collection)
            {
                //Compare each collection with each temp collection until a collection (x, y, w) = tempCollection (y, x, w). Then delete that tempCollection. (Since the array is mirrored over the center diagonal line, we don't want duplicate values. This removes the duplicate values. For example, if c.x = 0, c.y = 1, and c.w = 5, and we're comparing that to temp.x = 1, temp.y = 0, and temp.w = 5, it's the same edge, so we want to remove that set of coordinates from the original array.)
            }

            Console.ReadLine();
        }
    }
}
