using System.Drawing;

public class Circulo
{
	readonly string _id;
	Point _x_y;
	readonly double _radio;

	public Circulo(string id, Point x_y, double radio)
	{
		_id = id;
		_x_y = x_y;
		_radio = radio;
	}

	public string ID
    {
		get => _id;
    }

    public Point XY
	{ 
		get => _x_y; 
	}

	public double Radio
    {
		get => _radio;
    }

	public string ToString2()
    {
		return _id + " " + _x_y;
    }

    public override string ToString()
    {
		return "ID: " + _id + ", XY: " + _x_y.ToString() + ", radio: " + _radio;
    }
}
