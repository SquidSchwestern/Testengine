using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testengine
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }              
        public Vector(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
    
}
