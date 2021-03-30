using System;
using System.Collections.Generic;
using System.Text;

namespace PrimsAlgorithm
{
    public class Coordinates
    {
        public int[] coordinatesAndWeight = new int[3];

        public Coordinates(int x, int y, int w)
        {
            coordinatesAndWeight[0] = x;
            coordinatesAndWeight[1] = y;
            coordinatesAndWeight[2] = w;
        }
    }
}
