using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace MartinezCarrilloBraulioCF
{
	class Predator : Agent
	{
		readonly Random _rand;
		readonly Color _normalRadarColor;
		readonly Color _onTrackingRadarColor;
		float _radarSize;
		bool _isHunting;
		bool _isOnPrev;

		public Predator(Vertex init_v, int radar_size)
			: base(init_v, "Predator")
		{
			_rand = new();
			_edge_indx = -1;
			_normalRadarColor = Color.FromArgb(120, 152, 251, 152);
			_onTrackingRadarColor = Color.FromArgb(120, 254, 0, 0);
			_radarSize = _size * radar_size;
			_vel = 1;
			_isHunting = false;
			_isOnPrev = true;
		}

		public Color NormalRadarColor
		{
			get => _normalRadarColor;
		}

		public Color OnTrackingRadarColor
		{
			get => _onTrackingRadarColor;
		}

		public float RadarSize
		{
			get => _radarSize;
			set => _radarSize = _size * value;
		}

		public bool IsHunting
		{
			get => _isHunting;
			set => _isHunting = value;
		}

		public bool IsOnPrev
        {
			get => _isOnPrev;
			set => _isOnPrev = value;
        }

		public int DestinationExists(Vertex dest)
        {
			return Array.FindIndex(_init_v.Edges, e => e.DestinationVertex == dest);
        }

		public Agent OnTrackingOf(List<Agent> agent_list)
		{
			int x_i, y_i;
			int x, y;
			foreach (var a_i in agent_list)
			{
				if (a_i.ID == "Predator") continue;
				x_i = _last_position.X;
				y_i = _last_position.Y;
				x = a_i.LastPosition.X;
				y = a_i.LastPosition.Y;
				double belongsto = Math.Pow(x_i - x, 2) + Math.Pow(y_i - y, 2) - Math.Pow(_radarSize, 2);
				if (belongsto < 0)
				{
					_vel = a_i.Speed * 120 / 100;
					return a_i;
				}
			}
			_vel = 1;
			return null;
		}

		public bool InTouchWith(Agent a)
		{
			int x_p = _last_position.X;
			int y_p = _last_position.Y;
			int x_a = a.LastPosition.X;
			int y_a = a.LastPosition.Y;
			double intouch = Math.Pow(x_p - x_a, 2) + Math.Pow(y_p - y_a, 2) - Math.Pow(_size, 2);
			if (intouch < 0)
				return true;
			return false;
		}

		public override void ChoosePath()
		{
			_edge_indx = _rand.Next(_init_v.Count);
			var p = _init_v[_edge_indx].Path;
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

		public override bool Walk1()
		{
			if (_path_indx == -1) return false;
			_isOnPrev = false;
			if (_walk_ctl)
			{
				if (_path_indx + _vel < _init_v[_edge_indx].Count - 1)
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
			_init_v = _init_v[_edge_indx].DestinationVertex;
			_path_indx = -1;
			_isOnPrev = true;
			return false;
		}

		public override bool Walk2(Func<int, int, Vertex> belongsto)
		{
			if (_path_indx == -1)
			{
				_inMotion = false;
				return false;
			}
			_isOnPrev = false;
			if (_walk_ctl)
			{
				if (_path_indx + _vel < _init_v[_edge_indx].Count - 1)
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
			_isOnPrev = true;
			_edge_indx = 0;
			return false;
		} 

		public void NonRandomChoosePath()
        {
			if (_path.Any())
			{
				var p = _path[0];
				if (_init_v.Circle.XY == p.Path[^1])
				{
					_path_indx = p.Path.Length - 1;
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
				_isOnPrev = true;
				_isHunting = false;
				return;
			}
		}

		public bool NonRandomWalk()
		{
			if (_path_indx == -1) return false;
			_isOnPrev = false;
			if (_walk_ctl)
			{
				if (_path_indx + _vel < _path[0].Count - 1)
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
			_init_v = _path[0].DestinationVertex;
			_path_indx = -1;
			_isOnPrev = true;
			_path.RemoveAt(0);
			_isHunting = false;
			return false;
		}

		public bool ToPrev()
        {
			if (_path_indx == -1) return false;
			_isOnPrev = false;
			if (_walk_ctl)
			{
				if (_path_indx - _vel > 0)
				{
					_path_indx -= _vel;
					return true;
				}
			}
			else
			{
				if (_path_indx + _vel < _init_v[_edge_indx].Count - 1)
				{
					_path_indx += _vel;
					return true;
				}
			}
			_path_indx = -1;
			_isOnPrev = true;
			_isHunting = false;
			return false;
		}
	}
}