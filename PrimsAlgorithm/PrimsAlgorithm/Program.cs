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

            foreach (Coordinates c in collection)
            {
                Console.WriteLine(c.coordinatesAndWeight[0] + ", " + c.coordinatesAndWeight[1] + ", " + c.coordinatesAndWeight[2]);
            }
            Console.WriteLine(collection.Length);

            for (int e = 0; e < collection.Length; e++)
            {
                int originalX = collection[e].coordinatesAndWeight[0];
                int originalY = collection[e].coordinatesAndWeight[1];
                int originalW = collection[e].coordinatesAndWeight[2];

                for (int k = 0; k < collection.Length; k++)
                {
                    //Compare collection[e] with collection[k]
                    int compareX = collection[k].coordinatesAndWeight[0];
                    int compareY = collection[k].coordinatesAndWeight[1];
                    int compareW = collection[k].coordinatesAndWeight[2];

                    if(originalX == compareY && originalY == compareX && originalW == compareW)
                    {
                        //Remove the comparing collection by setting all values to 0
                        collection[k].coordinatesAndWeight[0] = 0;
                        collection[k].coordinatesAndWeight[1] = 0;
                        collection[k].coordinatesAndWeight[2] = 0;
                    }
                }
            }

            foreach(Coordinates c in collection)
            {
                Console.WriteLine(c.coordinatesAndWeight[0] + ", " + c.coordinatesAndWeight[1] + ", " + c.coordinatesAndWeight[2]);
            }

            Console.ReadLine();
        }
    }
}
