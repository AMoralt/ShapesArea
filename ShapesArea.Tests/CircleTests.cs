public class CircleTests
{
    [Theory]
    [InlineData(0, 0, 5)]
    [InlineData(3, 4, 2.5)]
    public void Circle_Constructor_ValidCenterAndRadius_CreatesCircle(double centerX, double centerY, double radius)
    {
        // Arrange
        var center = new Point2D(centerX, centerY);

        // Act
        var circle = new Circle(center, radius);

        // Assert
        Assert.Equal(center, circle.Center);
        Assert.Equal(radius, circle.Radius);
    }

    [Fact]
    public void Circle_Area_CalculatesAreaCorrectly()
    {
        // Arrange
        var center = new Point2D(0, 0);
        var radius = 3.5;
        IShape circle = new Circle(center, radius);
        var expectedArea = Math.PI * radius * radius;

        // Act
        var area = circle.Area;

        // Assert
        Assert.Equal(expectedArea, area);
    }

    [Fact]
    public void Circle_Equals_CompareEqualCircles_ReturnsTrue()
    {
        // Arrange
        var center1 = new Point2D(0, 0);
        var radius1 = 5;
        var center2 = new Point2D(0, 0);
        var radius2 = 5;
        var circle1 = new Circle(center1, radius1);
        var circle2 = new Circle(center2, radius2);

        // Act
        var areEqual = circle1.Equals(circle2);

        // Assert
        Assert.True(areEqual);
    }

    [Fact]
    public void Circle_Equals_CompareUnequalCircles_ReturnsFalse()
    {
        // Arrange
        var center1 = new Point2D(0, 0);
        var radius1 = 5;
        var center2 = new Point2D(3, 4);
        var radius2 = 2.5;
        var circle1 = new Circle(center1, radius1);
        var circle2 = new Circle(center2, radius2);

        // Act
        var areEqual = circle1.Equals(circle2);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Circle_Equals_CompareWithNull_ReturnsFalse()
    {
        // Arrange
        var center = new Point2D(0, 0);
        var radius = 5;
        var circle = new Circle(center, radius);

        // Act
        var areEqual = circle.Equals(null);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Circle_Equals_CompareWithNonCircleObject_ReturnsFalse()
    {
        // Arrange
        var center = new Point2D(0, 0);
        var radius = 5;
        var circle = new Circle(center, radius);
        var otherObject = new object();

        // Act
        var areEqual = circle.Equals(otherObject);

        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void Circle_GetHashCode_ReturnsCorrectHashCode()
    {
        // Arrange
        var center1 = new Point2D(0, 0);
        var radius1 = 5;
        var center2 = new Point2D(0, 0);
        var radius2 = 5;
        var circle1 = new Circle(center1, radius1);
        var circle2 = new Circle(center2, radius2);

        // Act
        var hashCode1 = circle1.GetHashCode();
        var hashCode2 = circle2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }
}
