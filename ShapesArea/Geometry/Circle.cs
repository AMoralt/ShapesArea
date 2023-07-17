/// <summary>
/// Represents a circle shape.
/// </summary>
public class Circle : IShape, IEquatable<Circle>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class.
    /// </summary>
    /// <param name="center">The center point of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    public Circle(Point2D center, double radius)
    {
        Center = center;
        Radius = radius;
    }
    
    /// <summary>
    /// Gets the center point of the circle.
    /// </summary>
    public Point2D Center { get; }
    
    /// <summary>
    /// Gets the radius of the circle.
    /// </summary>
    public double Radius { get; }
    
    /// <summary>
    /// Calculates the area of the circle.
    /// </summary>
    public double CalculateSquare() => Radius * Radius * Math.PI;
    
    /// <summary>
    /// Determines whether two specified <see cref="Circle"/> objects are equal.
    /// </summary>
    /// <param name="left">The first circle to compare.</param>
    /// <param name="right">The second circle to compare.</param>
    /// <returns><c>true</c> if the circles are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Circle left, Circle right) => left.Equals(right);
    
    /// <summary>
    /// Determines whether two specified <see cref="Circle"/> objects are not equal.
    /// </summary>
    /// <param name="left">The first circle to compare.</param>
    /// <param name="right">The second circle to compare.</param>
    /// <returns><c>true</c> if the circles are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Circle left, Circle right) => !left.Equals(right);

    /// <summary>
    /// Determines whether the current <see cref="Circle"/> object is equal to another Circle object.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns><c>true</c> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <c>false</c>.</returns>
    public bool Equals(Circle? other)
    {
        if (ReferenceEquals(null, other))
            return false;
        
        return Radius.Equals(other.Radius) && Center.Equals(other.Center);
    }
    
    /// <summary>
    /// Determines whether the current <see cref="Circle"/> object is equal to another object.
    /// </summary>
    /// <param name="obj">An object to compare with this object.</param>
    /// <returns><c>true</c> if the current object is equal to the <paramref name="obj"/> parameter; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj) => obj is Circle c && Equals(c);

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode() => HashCode.Combine(Center, Radius);
}