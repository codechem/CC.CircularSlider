using System;

namespace CC
{
    public class DragEndEventArgs
    {
        public float X { get; set; }
        public float Y { get; set; }
        public double Value { get; set; }

        public DragEndEventArgs()
        {
        }
    }
}
