using System.Collections.Generic;
using System.Drawing;

namespace MartinezCarrilloBraulioCF
{
    class Agent
    {
		readonly string _ID;
		Vertex _init_v;
		int _edge_indx;
		int _path_indx;
		readonly int _vel;
		bool _walk_ctl;
		readonly float _size;
		bool _inMotion;
		Edge[] _path;
		Point _last_position;
		
		public Agent(string ID, Vertex init_v)
		{
			_ID = ID;
			_init_v = init_v;
			_edge_indx = 0;
			_path_indx = -1;
			_vel = 5;
			_walk_ctl = false;
			_size = init_v.Circle.Radius / 2;
			_inMotion = true;
			_path = null;
			_last_position = init_v.Circle.XY;
		}

		public string ID
        {
			get => _ID;
        }

		public Vertex InitialVertex
		{
			get => _init_v;
			set => _init_v = value;
		}

		public int EdgeIndex
		{
			get => _edge_indx;
			set => _edge_indx = value;
		}

		public int PathIndex
		{
			get => _path_indx;
			set => _path_indx = value;
		}

		public float Size
        {
			get => _size;
        }

		public bool InMotion
        {
			get => _inMotion;
			set => _inMotion = value;
        }

		public Edge[] Path
        {
			get => _path;
			set => _path = value;
        }

		public Point LastPosition
        {
			get => _last_position;
			set => _last_position = value;
        }

		public (Edge[], bool, int, int) MainData
        {
			get => (_path, _inMotion, _edge_indx, _path_indx);
			set => (_path, _inMotion, _edge_indx, _path_indx) = value;
        }

		public void ChoosePath()
		{
			if (_edge_indx < _path.Length)
            {
				var p = _path[_edge_indx].Path;
				if (_init_v.Circle.XY == p[^1])
				{
					_path_indx = p.Length - 1;
					_walk_ctl = false;
				}
				else
				{
					_path_indx = 0;
					_walk_ctl = true;
				}
            }
			else
            {
				_inMotion = false;
            }
		}

		public bool Walk1()
		{
			if (_path_indx == -1) return false;
			if (_walk_ctl)
			{
				if (_path_indx + _vel < _path[_edge_indx].Count - 1)
				{
					_path_indx += _vel;
					return true;
				}
			}
			else
			{
				if (_path_indx - _vel > 0)
				{
					_path_indx -= _vel;
					return true;
				}
			}
			_init_v = _path[_edge_indx].InitVtx;
			_edge_indx++;
			return false;
		}

		public bool Walk2()
		{
			if (_path_indx == -1) return false;
			if (_walk_ctl)
			{
				if (_path_indx + _vel < _path[_edge_indx].Count - 1)
				{
					_path_indx += _vel;
					return true;
				}
			}
			else
			{
				if (_path_indx - _vel > 0)
				{
					_path_indx -= _vel;
					return true;
				}
			}
			_init_v = _path[_edge_indx].InitVtx;
			_inMotion = false;
			return false;
		}

		public override string ToString()
		{
			return "Instancia de agente en " + _init_v.ToString();
		}
	}
}
