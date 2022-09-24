using System;
using System.Collections.Generic;

public class Agent
{
	Vertex _init_v;
	Vertex _objve_v;
	readonly List<Vertex> _visitedLst;
	readonly Random _rand;
	int _edge_indx, _path_indx, _vel;
	bool _walk_ctl; 

	public Agent(Vertex init_v)
	{
		_init_v = init_v;
		_objve_v = null;
		_visitedLst = new();
		_visitedLst.Add(_init_v);
		_rand = new();
		_edge_indx = -1;
		_path_indx = -1;
		_vel = 10;
		_walk_ctl = false;
	}

	public Vertex Vtx
    {
		get => _init_v;
		set => _init_v = value;
    }

	public Vertex ObjveVtx
    {
		get => _objve_v;
		set => _objve_v = value;
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

	public int NonVisitedCount
    {
		get => NonVisited().Length;
    }

	public int[] NonVisited()
    {
		List<int> nonVisitedLst = new();
		for (int i = 0; i < _init_v.Count; i++)
		{
			var is_visited = false;
			foreach (var v_i in _visitedLst)
			{
				if (_init_v.GetEdge(i).Vtx == v_i)
				{
					is_visited = true;
					break;
				}
			}
			if (!is_visited)
			{
				nonVisitedLst.Add(i);
			}
		}
		return nonVisitedLst.ToArray();
	}

	public void ChoosePath()
    {
		var lst = NonVisited();
		if (lst.Length == 0) { return; }
		_edge_indx = lst[_rand.Next(lst.Length)];
		var p = _init_v.GetEdge(_edge_indx).Path;
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

	public bool Walk()
	{	
		if (_walk_ctl)
        {
			if (_path_indx + _vel < _init_v.GetEdge(_edge_indx).Count - 1)
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
		_init_v = _init_v.GetEdge(_edge_indx).Vtx;
		_visitedLst.Add(_init_v);
		return false;
	}

	public override string ToString()
	{
		return "Instancia de agente en " + _init_v.ToString();
    }
}
