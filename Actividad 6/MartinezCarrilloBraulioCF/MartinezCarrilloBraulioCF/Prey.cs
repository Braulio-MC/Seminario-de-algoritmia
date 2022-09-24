using System;

namespace MartinezCarrilloBraulioCF
{
	class Prey : Agent
	{
		public Prey(Vertex init_v)
			: base(init_v, "Prey")
		{
			_vel = 5;
		}

		public override void ChoosePath()
		{
			if (_edge_indx < _path.Count)
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
		}

		public override bool Walk1()
		{
			if (_path_indx == -1) return false;
			if (_edge_indx == _path.Count)
            {
				_inMotion = false;
				return false;
            }
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
			_init_v = _path[_edge_indx].DestinationVertex;
			_edge_indx++;
			return false;
		}

		public override bool Walk2(Func <int, int, Vertex> belongsto)
		{
			if (_path_indx == -1)
			{
				_inMotion = false;
				return false;
			}
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
			_init_v = belongsto(_last_position.X, _last_position.Y);
			_inMotion = false;
			return false;
		}
	}
}
