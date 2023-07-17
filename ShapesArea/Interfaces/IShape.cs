/// <summary>
/// Represents a geometric shape.
/// </summary>
public interface IShape
{
    /// <summary>
    /// Gets the area of the shape.
    /// </summary>
    double Area => CalculateSquare();
    
    /// <summary>
    /// Calculates the area of the shape.
    /// </summary>
    double CalculateSquare();
}