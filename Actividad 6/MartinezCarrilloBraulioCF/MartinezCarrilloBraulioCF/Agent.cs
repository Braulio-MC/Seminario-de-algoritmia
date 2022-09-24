using System.Drawing;
using System.Collections.Generic;
using System;

namespace MartinezCarrilloBraulioCF
{
	abstract class Agent
	{
		protected readonly string _ID;
		protected Vertex _init_v;
		protected int _edge_indx;
		protected int _path_indx;
		protected int _vel;
		protected bool _walk_ctl;
		protected readonly float _size;
		protected bool _inMotion;
		protected List<Edge> _path;
		protected Point _last_position;

		public Agent(Vertex init_v, string ID)
		{
			_ID = ID;
			_init_v = init_v;
			_edge_indx = 0;
			_path_indx = -1;
			_vel = 5;
			_walk_ctl = false;
			_size = init_v.Circle.Radius / 2;
			_inMotion = true;
			_path = new();
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

		public int Speed
		{
			get => _vel;
			set => _vel = value;
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

		public List<Edge> Path
		{
			get => _path;
			set => _path = value;
		}

		public Point LastPosition
		{
			get => _last_position;
			set => _last_position = value;
		}

		public (List<Edge>, bool, int, int) MainData
		{
			get => (_path, _inMotion, _edge_indx, _path_indx);
			set => (_path, _inMotion, _edge_indx, _path_indx) = value;
		}

		public (bool, int, int) MainData2
		{
			get => (_inMotion, _edge_indx, _path_indx);
			set => (_inMotion, _edge_indx, _path_indx) = value;
		}

		public abstract void ChoosePath();

		public abstract bool Walk1();

		public abstract bool Walk2(Func<int, int, Vertex> f);

		public override string ToString()
		{
			return "Instancia de agente en " + _init_v.ToString();
		}
	}
}
