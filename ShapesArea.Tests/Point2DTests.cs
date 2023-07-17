public class Point2DTests
{
    [Fact]
    public void Point2D_Constructor_ValidCoordinates_CreatesPoint()
    {
        // Arrange
        double x = 3.5;
        double y = 2.1;

        // Act
        var point = new Point2D(x, y);

        // Assert
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData(0, 0, 3, 4, 5)]
    [InlineData(1, 2, 4, 6, 5)]
    public void Point2D_Distance_CalculatesDistanceCorrectly(double x1, double y1, double x2, double y2, double expectedDistance)
    {
        // Arrange
        var point1 = new Point2D(x1, y1);
        var point2 = new Point2D(x2, y2);

        // Act
        var distance = point1.Distance(point2);

        // Assert
        Assert.Equal(expectedDistance, distance);
    }

    [Fact]
    public void Point2D_Equals_CompareEqualPoints_ReturnsTrue()
    {
        // Arrange
        var point1 = new Point2D(2.5, 3.7);
        var point2 = new Point2D(2.5, 3.7);

        // Act
        var areEqual = point1.Equals(point2);

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void Point2D_Equals_CompareUnequalPoints_ReturnsFalse()
    {
        // Arrange
        var point1 = new Point2D(2.5, 3.7);
        var point2 = new Point2D(4.2, 1.9);

        // Act
        var areEqual = point1.Equals(point2);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Point2D_Equals_CompareWithNull_ReturnsFalse()
    {
        // Arrange
        var point = new Point2D(2.5, 3.7);

        // Act
        var areEqual = point.Equals(null);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Point2D_Equals_CompareWithNonPoint2DObject_ReturnsFalse()
    {
        // Arrange
        var point = new Point2D(2.5, 3.7);
        var otherObject = new object();

        // Act
        var areEqual = point.Equals(otherObject);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Point2D_GetHashCode_ReturnsCorrectHashCode()
    {
        // Arrange
        var point1 = new Point2D(2.5, 3.7);
        var point2 = new Point2D(2.5, 3.7);

        // Act
        var hashCode1 = point1.GetHashCode();
        var hashCode2 = point2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }
}
