using System;

public class Square : Shape
{
    private double _side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double Area()
    {
        return _side * _side; // Area of a square is side^2
    }
}