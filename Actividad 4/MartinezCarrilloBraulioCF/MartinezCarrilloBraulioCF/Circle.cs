using System.Drawing;

namespace MartinezCarrilloBraulioCF
{
	public class Circle
	{
		readonly string _id;
		Point _x_y;
		readonly float _radius;

		public Circle(string id, Point x_y, float radius)
		{
			_id = id;
			_x_y = x_y;
			_radius = radius;
		}

		public string ID
		{
			get => _id;
		}

		public Point XY
		{
			get => _x_y;
		}

		public float Radius
		{
			get => _radius;
		}

		public (string, int, int, float) Data
		{
			get => (_id, _x_y.X, _x_y.Y, _radius);
		}

		public string ToString2()
		{
			return _id + " " + _x_y;
		}

		public override string ToString()
		{
			return "ID: " + _id + ", XY: " + _x_y.ToString() + ", radio: " + _radius;
		}
	}

}
