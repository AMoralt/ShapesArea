public class TriangleTests
{
    [Theory]
    [InlineData(0, 0, 3, 0, 0, 4)]
    [InlineData(0, 0, 2, 2, 2, 0)]
    public void Triangle_Constructor_ValidPoints_CreatesTriangle(double ax, double ay, double bx, double by, double cx, double cy)
    {
        // Arrange
        var pointA = new Point2D(ax, ay);
        var pointB = new Point2D(bx, by);
        var pointC = new Point2D(cx, cy);

        // Act
        var triangle = new Triangle(pointA, pointB, pointC);

        // Assert
        Assert.Equal(pointA, triangle.PointA);
        Assert.Equal(pointB, triangle.PointB);
        Assert.Equal(pointC, triangle.PointC);
    }

    [Theory]
    [InlineData(0, 0, 1, 0, 2, 0)] // degenerate triangle
    [InlineData(0, 0, 0, 0, 0, 0)] // degenerate triangle
    public void Triangle_Constructor_InvalidPoints_ThrowsArgumentException(double ax, double ay, double bx, double by, double cx, double cy)
    {
        // Arrange
        var pointA = new Point2D(ax, ay);
        var pointB = new Point2D(bx, by);
        var pointC = new Point2D(cx, cy);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Triangle(pointA, pointB, pointC));
    }

    [Theory]
    [InlineData(0, 0, 3, 0, 0, 4, 6)] 
    [InlineData(3, 2, 7, 5, 0, 0, 0.5)]
    public void Triangle_Area_CalculatesAreaCorrectly(double ax, double ay, double bx, double by, double cx, double cy, double expected)
    {
        // Arrange
        var pointA = new Point2D(ax, ay);
        var pointB = new Point2D(bx, by);
        var pointC = new Point2D(cx, cy);

        IShape triangle = new Triangle(pointA, pointB, pointC);

        // Act
        var area = triangle.Area;

        // Assert
        Assert.Equal(expected, area);
    }

    [Theory]
    [InlineData(0, 0, 3, 3, 3, 0, true)]
    [InlineData(0, 0, 3, 3, 6, 0, true)]
    [InlineData(0, 0, 1, 1, 6, 0, false)]
    [InlineData(5, 5, 1, 1, 6, 0, false)]
    public void Triangle_IsRightAngled_ChecksRightAngleCorrectly(double ax, double ay, double bx, double by, double cx, double cy, bool expected)
    {
        // Arrange
        var pointA = new Point2D(ax, ay);
        var pointB = new Point2D(bx, by);
        var pointC = new Point2D(cx, cy);

        var triangle = new Triangle(pointA, pointB, pointC);

        // Act
        var isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.Equal(expected, isRightAngled);
    }

    [Fact]
    public void Triangle_Equals_CompareEqualTriangles_ReturnsTrue()
    {
        // Arrange
        var pointA1 = new Point2D(0, 0);
        var pointB1 = new Point2D(3, 0);
        var pointC1 = new Point2D(0, 4);

        var pointA2 = new Point2D(0, 0);
        var pointB2 = new Point2D(0, 4);
        var pointC2 = new Point2D(3, 0);

        var triangle1 = new Triangle(pointA1, pointB1, pointC1);
        var triangle2 = new Triangle(pointA2, pointB2, pointC2);

        // Act
        var areEqual = triangle1.Equals(triangle2);

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void Triangle_Equals_CompareUnequalTriangles_ReturnsFalse()
    {
        // Arrange
        var pointA1 = new Point2D(0, 0);
        var pointB1 = new Point2D(3, 0);
        var pointC1 = new Point2D(0, 4);

        var pointA2 = new Point2D(0, 0);
        var pointB2 = new Point2D(4, 0);
        var pointC2 = new Point2D(0, 3);

        var triangle1 = new Triangle(pointA1, pointB1, pointC1);
        var triangle2 = new Triangle(pointA2, pointB2, pointC2);

        // Act
        var areEqual = triangle1.Equals(triangle2);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Triangle_Equals_CompareWithNull_ReturnsFalse()
    {
        // Arrange
        var pointA = new Point2D(0, 0);
        var pointB = new Point2D(3, 0);
        var pointC = new Point2D(0, 4);

        var triangle = new Triangle(pointA, pointB, pointC);

        // Act
        var areEqual = triangle.Equals(null);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Triangle_Equals_CompareWithNonTriangleObject_ReturnsFalse()
    {
        // Arrange
        var pointA = new Point2D(0, 0);
        var pointB = new Point2D(3, 0);
        var pointC = new Point2D(0, 4);

        var triangle = new Triangle(pointA, pointB, pointC);
        var otherObject = new object();

        // Act
        var areEqual = triangle.Equals(otherObject);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Triangle_GetHashCode_ReturnsCorrectHashCode()
    {
        // Arrange
        var pointA1 = new Point2D(0, 0);
        var pointB1 = new Point2D(3, 0);
        var pointC1 = new Point2D(0, 4);

        var pointA2 = new Point2D(0, 0);
        var pointB2 = new Point2D(3, 0);
        var pointC2 = new Point2D(0, 4);

        var triangle1 = new Triangle(pointA1, pointB1, pointC1);
        var triangle2 = new Triangle(pointA2, pointB2, pointC2);

        // Act
        var hashCode1 = triangle1.GetHashCode();
        var hashCode2 = triangle2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }
}
