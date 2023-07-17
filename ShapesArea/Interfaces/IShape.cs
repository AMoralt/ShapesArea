/// <summary>
/// Represents a geometric shape.
/// </summary>
public interface IShape
{
    /// <summary>
    /// Gets the area of the shape.
    /// </summary>
    double Area => CalculateArea();
    
    /// <summary>
    /// Calculates the area of the shape.
    /// </summary>
    double CalculateArea();
}