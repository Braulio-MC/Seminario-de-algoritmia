using System;
using System.Collections.Generic;
using System.Drawing;


namespace MartinezCarrilloBraulioCF
{
    public class Graph
    {
        readonly List<Vertex> _vertexLst;
        int _edgeCount;

        public Graph()
        {
            _vertexLst = new List<Vertex>();
            _edgeCount = 0;
        }

        public int Count
        {
            get => _vertexLst.Count;
        }

        public IReadOnlyCollection<Vertex> VertexList
        {
            get => _vertexLst;
        }

        public int EdgeCount
        {
            get =>  _edgeCount;
            set => _edgeCount = value;
        }

        public void AddVertex(Vertex v)
        {
            _vertexLst.Add(v);
        }

        static public float Distance(Point xy1, Point xy2)
        {
            return (float)Math.Sqrt(Math.Pow((xy2.X - xy1.X), 2) + Math.Pow((xy2.Y - xy1.Y), 2));
        }

        public Vertex SearchForVertex(object obj)
        {
            var id = obj as string;
            for (int i = 0; i < Count; i++)
            {
                if (id == this[i].Circle.ID)
                {
                    return this[i];
                }
            }
            return null;
        }

        public void Clear()
        {
            _vertexLst.Clear();
            _edgeCount = 0;
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

        public int Count
        {
            get => _edgesLst.Count;
        }

        public Circle Circle
        {
            get => _circle;
        }

        public IReadOnlyCollection<Edge> Edges
        {
            get => _edgesLst;
        }

        public void AddEdge(Edge e)
        {
            _edgesLst.Add(e);
        }

        public int EdgeExists(Vertex v_b)
        {
            for (int i = 0; i < _edgesLst.Count; i++)
            {
                if (v_b == _edgesLst[i].AsocVtx)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            _edgesLst.Clear();
        }

        public override string ToString()
        {
            return _circle.ToString();
        }

        public Edge this[int i]
        {
            get => _edgesLst[i];
        }
    }

    public class Edge
    {
        readonly Vertex _init_v, _asoc_v;
        readonly Point[] _path;
        readonly float _weight;

        public Edge(Vertex init_v, Vertex asoc_v, Point[] path, float weight)
        {
            _init_v = init_v;
            _asoc_v = asoc_v;
            _path = path;
            _weight = weight;
        }

        public Vertex InitVtx
        {
            get => _init_v;
        }

        public Vertex AsocVtx
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

        public override string ToString()
        {
            return "V asoc: " + _asoc_v + ", peso: " + _weight;
        }

        public Point this[int i]
        {
            get => _path[i];
        }
    }
}
