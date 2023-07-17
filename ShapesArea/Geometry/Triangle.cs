/// <summary>
/// Represents a triangle shape.
/// </summary>
public class Triangle : IShape, IEquatable<Triangle>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Triangle"/> class.
    /// </summary>
    /// <param name="pointA">The first vertex of the triangle.</param>
    /// <param name="pointB">The second vertex of the triangle.</param>
    /// <param name="pointC">The third vertex of the triangle.</param>
    public Triangle(Point2D pointA, Point2D pointB, Point2D pointC)
    {
        var sideA = pointB.Distance(pointC);
        var sideB = pointA.Distance(pointC);
        var sideC = pointA.Distance(pointB);

        ValidateTriangleSides(sideA, sideB, sideC);
        
        PointA = pointA;
        PointB = pointB;
        PointC = pointC;
    }

    /// <summary>
    /// Gets the first vertex of the triangle.
    /// </summary>
    public Point2D PointA { get; }
    
    /// <summary>
    /// Gets the second vertex of the triangle.
    /// </summary>
    public Point2D PointB { get; }
    
    /// <summary>
    /// Gets the third vertex of the triangle.
    /// </summary>
    public Point2D PointC { get; }
    
    /// <summary>
    /// Gets the length of side A.
    /// </summary>
    public double SideA => PointB.Distance(PointC);
    
    /// <summary>
    /// Gets the length of side B.
    /// </summary>
    public double SideB => PointA.Distance(PointC);
    
    /// <summary>
    /// Gets the length of side C.
    /// </summary>
    public double SideC => PointA.Distance(PointB);

    /// <summary>
    /// Calculates the area of the triangle.
    /// </summary>
    public double CalculateArea()
    {
        return 0.5d * Math.Abs((PointA.X - PointC.X) * (PointB.Y - PointC.Y) 
                               - (PointB.X - PointC.X) * (PointA.Y - PointC.Y));
    }

    /// <summary>
    /// Checks if the triangle is right-angled.
    /// </summary>
    /// <returns><c>true</c> if the triangle is right-angled; otherwise, <c>false</c>.</returns>
    public bool IsRightAngled()
    {
        double firstSqr = SideA * SideA;
        double secondSqr = SideB * SideB;
        double thirdSqr = SideC * SideC;
        var tolerance = 1E-12;

        return Math.Abs(firstSqr - (secondSqr + thirdSqr)) < tolerance
            || Math.Abs(secondSqr - (thirdSqr + firstSqr)) < tolerance
            || Math.Abs(thirdSqr - (firstSqr + secondSqr)) < tolerance;
    }

    private void ValidateTriangleSides(double sideA, double sideB, double sideC)
    {
        var tolerance = 1E-12;
        
        if (sideA < tolerance || sideB < tolerance || sideC < tolerance)
            throw new ArgumentException("Side lengths cannot be approximately zero.");

        if (Math.Abs(sideA + sideB - sideC) < tolerance
            || Math.Abs(sideA + sideC - sideB) < tolerance
            || Math.Abs(sideB + sideC - sideA) < tolerance)
        {
            throw new ArgumentException("Incorrect side values. The sum of any two sides must be greater than the third side.");
        }
    }

    /// <summary>
    /// Determines whether two specified <see cref="Triangle"/> objects are equal.
    /// </summary>
    /// <param name="left">The first triangle to compare.</param>
    /// <param name="right">The second triangle to compare.</param>
    /// <returns><c>true</c> if the triangles are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Triangle left, Triangle right) => left.Equals(right);
    
    /// <summary>
    /// Determines whether two specified <see cref="Triangle"/> objects are not equal.
    /// </summary>
    /// <param name="left">The first triangle to compare.</param>
    /// <param name="right">The second triangle to compare.</param>
    /// <returns><c>true</c> if the triangles are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Triangle left, Triangle right) => !left.Equals(right);
    
    /// <summary>
    /// Determines whether the current <see cref="Triangle"/> object is equal to another Triangle object.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns><c>true</c> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <c>false</c>.</returns>
    public bool Equals(Triangle? other)
    {
        if (ReferenceEquals(null, other)) 
            return false;

        var isPointAEqual = PointA.Equals(other.PointA) 
                            || PointA.Equals(other.PointB) 
                            || PointA.Equals(other.PointC);
        
        var isPointBEqual = PointB.Equals(other.PointA)
                            || PointB.Equals(other.PointB) 
                            || PointB.Equals(other.PointC);
        
        var isPointCEqual = PointC.Equals(other.PointA) 
                            || PointC.Equals(other.PointB) 
                            || PointC.Equals(other.PointC);
        
        return isPointAEqual && isPointBEqual && isPointCEqual;
    }
    
    /// <summary>
    /// Determines whether the current <see cref="Triangle"/> object is equal to another object.
    /// </summary>
    /// <param name="obj">An object to compare with this object.</param>
    /// <returns><c>true</c> if the current object is equal to the <paramref name="obj"/> parameter; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj) => obj is Triangle tr && Equals(tr);

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode() => HashCode.Combine(PointA, PointB, PointC);
}