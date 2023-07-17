/// <summary>
/// Represents a 2D point with X and Y coordinates.
/// </summary>
public class Point2D : IEquatable<Point2D>
{
    /// <summary>
    /// Gets the X-coordinate of the point.
    /// </summary>
    public double X { get; }
    
    /// <summary>
    /// Gets the Y-coordinate of the point.
    /// </summary>
    public double Y { get; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Point2D"/> class.
    /// </summary>
    /// <param name="x">The X-coordinate of the point.</param>
    /// <param name="y">The Y-coordinate of the point.</param>
    public Point2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Calculates the Euclidean distance between this point and another point.
    /// </summary>
    /// <param name="p">The other point.</param>
    /// <returns>The distance between the two points.</returns>
    public double Distance(Point2D p)
    {
        double dx = X - p.X;
        double dy = Y - p.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
    
    /// <summary>
    /// Determines whether two specified <see cref="Point2D"/> objects are equal.
    /// </summary>
    /// <param name="left">The first point to compare.</param>
    /// <param name="right">The second point to compare.</param>
    /// <returns><c>true</c> if the points are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Point2D left, Point2D right) => left.Equals(right);
    
    /// <summary>
    /// Determines whether two specified <see cref="Point2D"/> objects are not equal.
    /// </summary>
    /// <param name="left">The first point to compare.</param>
    /// <param name="right">The second point to compare.</param>
    /// <returns><c>true</c> if the points are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Point2D left, Point2D right) => !left.Equals(right);
    
    /// <summary>
    /// Determines whether the current <see cref="Point2D"/> object is equal to another Point2D object.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns><c>true</c> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <c>false</c>.</returns>
    public bool Equals(Point2D? other)
    {
        if (ReferenceEquals(null, other)) 
            return false;
        
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    /// <summary>
    /// Determines whether the current <see cref="Point2D"/> object is equal to another object.
    /// </summary>
    /// <param name="obj">An object to compare with this object.</param>
    /// <returns><c>true</c> if the current object is equal to the <paramref name="obj"/> parameter; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj) => obj is Point2D p && Equals(p);
    
    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode() => HashCode.Combine(X, Y);
}