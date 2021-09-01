using System;

namespace GeometricLayout.Common
{
    /// <summary>
    /// Class to hold coordinates for graph/triangle
    /// </summary>
    public class Coordinates : IEquatable<Coordinates>
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Property to hold information of X-axis.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Property to hold information of Y-axis.
        /// </summary>
        public int Y { get; set; }

        public bool Equals(Coordinates other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coordinates) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
