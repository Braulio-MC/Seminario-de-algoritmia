using System;
using System.Collections.Generic;
using System.Drawing;

public class Graph
{
    readonly List<Vertex> _vertexLst;
    readonly List<(Vertex, Vertex, float)> _centersLst;

    public Graph()
    {
        _vertexLst = new List<Vertex>();
        _centersLst = null;
        //_centersLst = new List<(Vertex, Vertex, float)>();
    }

    public void AddVertex(Circle circle)
    {
        _vertexLst.Add(new Vertex(circle));
    }

    public void AddCenter((Vertex, Vertex, float) c)
    {
        _centersLst.Add(c);
    }

    static public float Distance(Point xy1, Point xy2)
    {
        return (float)Math.Sqrt(Math.Pow((xy2.X - xy1.X), 2) + Math.Pow((xy2.Y - xy1.Y), 2));
    }

    public (Vertex, Vertex, float) ClosestPairPoints()
    {
        var menor = _centersLst[0];
        for (int i = 1; i < _centersLst.Count; i++)
        {
            if (_centersLst[i].Item3 < menor.Item3)
            {
                menor = _centersLst[i];
            }
        }
        return menor;
    }

    public int Count
    {
        get => _vertexLst.Count;
    }

    public void Clear()
    {
        //_centersLst.Clear();
        _vertexLst.Clear();
    }

    public Vertex this[int i]
    {
        get => _vertexLst[i];
    }
}

public class Vertex
{
    readonly List<Edge> _edgesLst;
    readonly Circle _circle;

    public Vertex(Circle circle)
    {
        _edgesLst = new List<Edge>();
        _circle = circle;
    }

    public void AddEdge(Vertex v_b, Point[] path, float weight)
    {
        _edgesLst.Add(new Edge(v_b, path, weight));
    }

    public bool EdgeExists(Vertex v_b)
    {
        foreach (var item in _edgesLst)
        {
            if (v_b.Equals(item.Vtx))
            {
                return true;
            }
        }
        return false;
    }

    public Edge GetEdge(int edge_indx)
    {
        return _edgesLst[edge_indx];
    }

    public int Count
    {
        get => _edgesLst.Count;
    }

    public Circle Circle
    {
        get => _circle;
    }

    public void Clear()
    {
        _edgesLst.Clear();
    }

    public override string ToString()
    {
        return _circle.ToString();
    }
}

public class Edge
{
    readonly Vertex _asoc_v;
    readonly Point[] _path;
    readonly float _weight;

    public Edge(Vertex asoc_v, Point[] path, float weight)
    {
        _asoc_v = asoc_v;
        _path = path;
        _weight = weight;
    }

    public Vertex Vtx
    {
        get => _asoc_v;
    }

    public Point[] Path
    {
        get => _path;
    }

    public float Weight
    {
        get => _weight;
    }

    public int Count
    {
        get => _path.Length;
    }

    public Point GetPoint(int path_indx)
    {
        return _path[path_indx];
    }

    public override string ToString()
    {
        return "V asoc: " + _asoc_v + ", peso: " + _weight;
    }
}