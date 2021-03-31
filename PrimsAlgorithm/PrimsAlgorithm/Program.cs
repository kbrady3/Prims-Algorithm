using System;
using System.Collections.Generic;

namespace PrimsAlgorithm
{
    public class Program
    {
        static List<Coordinates> sortedCoords = new List<Coordinates>();

        public static int FindMin(List<Coordinates> coords)
        {
            int weight = 0;
            int minValue = int.MaxValue;
            Coordinates minCoordinates = coords[0];

            //Console.WriteLine("One execution of FindMin(), length of coords is: " + coords.Count);
            foreach (Coordinates c in coords)
            {
                //Console.WriteLine("Output of execution: " + c.coordinatesAndWeight[0] + ", " + c.coordinatesAndWeight[1] + ", " + c.coordinatesAndWeight[2]);
                weight = c.coordinatesAndWeight[2];

                if (weight < minValue && weight != 0)
                {
                    minValue = weight;
                    minCoordinates = c;
                }
            }

            sortedCoords.Add(minCoordinates);
            coords.Remove(minCoordinates);

            return minValue;
        }

        static void Main(string[] args)
        {
            List<Coordinates> coords = new List<Coordinates>();
            int rows = 5;

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
                //Console.WriteLine("ROW: " + x);

                for (int y = 0; y <= uBound1; y++)
                {
                    int weight = graph[x, y];
                    //Console.WriteLine("Weight: " + weight + ", Coordinates: " + x + "," + y);

                    //Insert all nonzero numbers into coords
                    if (weight != 0)
                    {
                        coords.Add(new Coordinates(x, y, weight));
                    }
                }
            }
            //End 2-dimensional array loop

            for (int e = 0; e < coords.Count; e++)
            {
                int originalX = coords[e].coordinatesAndWeight[0];
                int originalY = coords[e].coordinatesAndWeight[1];
                int originalW = coords[e].coordinatesAndWeight[2];

                for (int k = 0; k < coords.Count; k++)
                {
                    //Compare coords[e] with coords[k]
                    int compareX = coords[k].coordinatesAndWeight[0];
                    int compareY = coords[k].coordinatesAndWeight[1];
                    int compareW = coords[k].coordinatesAndWeight[2];

                    if (originalX == compareY && originalY == compareX && originalW == compareW)
                    {
                        //Remove the comparing coords by setting all values to 0
                        coords[k].coordinatesAndWeight[0] = 0;
                        coords[k].coordinatesAndWeight[1] = 0;
                        coords[k].coordinatesAndWeight[2] = 0;
                    }
                }
            }

            coords.RemoveAll(q => q.coordinatesAndWeight[0] == 0 && q.coordinatesAndWeight[1] == 0 && q.coordinatesAndWeight[2] == 0);
            //foreach (Coordinates c in coords)
            //{
            //    Console.WriteLine(c.coordinatesAndWeight[0] + ", " + c.coordinatesAndWeight[1] + ", " + c.coordinatesAndWeight[2]);
            //}
            //Console.WriteLine();

            //Call FindMin for as many rows as there are
            for (int i = 0; i < rows; i++){
                FindMin(coords);
            }

            Console.WriteLine("MST using Prim's Algorithm: ");
            foreach (Coordinates c in sortedCoords)
            {
                Console.WriteLine("Coordinates: (" + c.coordinatesAndWeight[0] + ", " + c.coordinatesAndWeight[1] + "), Weight: " + c.coordinatesAndWeight[2]);
            }

            Console.ReadLine();
        }
    }
}
