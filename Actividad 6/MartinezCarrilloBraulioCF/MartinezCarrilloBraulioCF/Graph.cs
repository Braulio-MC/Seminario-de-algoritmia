﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace MartinezCarrilloBraulioCF
{
    public class Graph
    {
        readonly List<Vertex> _vertexLst;
        DijkstraElement[] _dijkstraElements;

        public Graph()
        {
            _vertexLst = new List<Vertex>();
            _dijkstraElements = null;
        }

        public int Count
        {
            get => _vertexLst.Count;
        }

        public void AddVertex(Vertex v)
        {
            _vertexLst.Add(v);
        }

        static public float Distance(Point xy1, Point xy2)
        {
            return (float)Math.Sqrt(Math.Pow((xy2.X - xy1.X), 2) + Math.Pow((xy2.Y - xy1.Y), 2));
        }

        private void InitDijkstraVector(Vertex init_vertex)
        {
            _dijkstraElements = new DijkstraElement[Count];
            int indx = 0;
            for (int i = 0; i < _vertexLst.Count; i++)
            {
                if (_vertexLst[i] == init_vertex)
                {
                    indx = i;
                }
                _dijkstraElements[i] = new();
            }
            var e = _dijkstraElements[indx];
            e.AccumulatedWeight = 0;
            e.SourceVertex = init_vertex;
        }

        private int SmallerNotDefinitive()
        {
            var enumerable = _dijkstraElements.Where(e => e.IsDefinitive == false);
            return Array.FindIndex(_dijkstraElements, e => e.AccumulatedWeight ==
            enumerable.Min(e => e.AccumulatedWeight) && e.IsDefinitive == false);
        }

        private int ChooseDefinitive()
        {
            var smaller_indx = SmallerNotDefinitive();
            _dijkstraElements[smaller_indx].IsDefinitive = true;
            return smaller_indx;
        }

        private void UpdateDijkstraElements(int smaller_index)
        {
            float current_weight = _dijkstraElements[smaller_index].AccumulatedWeight;
            var v = _vertexLst[smaller_index];
            foreach (var edge in v.Edges)
            {
                var i_weight = current_weight + edge.Weight;
                var index = SearchForIndexOf(edge.DestinationVertex);
                if (_dijkstraElements[index].AccumulatedWeight > i_weight)
                {
                    _dijkstraElements[index].AccumulatedWeight = i_weight;
                    _dijkstraElements[index].SourceVertex = v;
                }
            }
        }

        public void Dijkstra(Vertex init_vertex)
        {
            InitDijkstraVector(init_vertex);
            while (_dijkstraElements.Any(a => a.IsDefinitive == false))
            {
                UpdateDijkstraElements(ChooseDefinitive());
            }
        }

        public List<Edge> MinPath(Vertex init_vertex, Vertex final_vertex)
        {
            List<Edge> el = new();
            Vertex source_v;
            while (final_vertex != init_vertex)
            {
                source_v = _dijkstraElements[SearchForIndexOf(final_vertex)].SourceVertex;
                if (source_v == null) break;
                el.Add(final_vertex[final_vertex.EdgeExists(source_v)]);
                final_vertex = source_v;
            }
            return el;
        }

        public List<Edge> DFS(Vertex init_v)
        {
            List<Vertex> visited = new();
            List<Edge> path = new();
            DFS(init_v, visited, path);
            return path;
        }

        private void DFS(Vertex v, List<Vertex> visited, List<Edge> path)
        {
            visited.Add(v);
            foreach (var e_i in v.Edges)
            {
                if (!visited.Exists(v_i => v_i == e_i.DestinationVertex))
                {
                    path.Add(v[v.EdgeExists(e_i.DestinationVertex)]);
                    DFS(e_i.DestinationVertex, visited, path);
                    path.Add(e_i.DestinationVertex[e_i.DestinationVertex.EdgeExists(v)]);
                }
            }
        }

        public int SearchForIndexOf(Vertex v)
        {
            for (int i = 0; i < _vertexLst.Count; i++)
            {
                if (_vertexLst[i] == v)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            _vertexLst.Clear();
            if (_dijkstraElements != null)
            {
                Array.Clear(_dijkstraElements, 0, _dijkstraElements.Length);
            }
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

        public Edge[] Edges
        {
            get => _edgesLst.ToArray();
        }

        public void AddEdge(Edge e)
        {
            _edgesLst.Add(e);
        }

        public int EdgeExists(Vertex v_b)
        {
            for (int i = 0; i < _edgesLst.Count; i++)
            {
                if (v_b == _edgesLst[i].DestinationVertex)
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
        readonly string _ID;
        readonly Vertex _dest_v;
        readonly Point[] _path;
        readonly float _weight;

        public Edge(string ID, Vertex dest_v, Point[] path, float weight)
        {
            _ID = ID;
            _dest_v = dest_v;
            _path = path;
            _weight = weight;
        }

        public string ID
        {
            get => _ID;
        }

        public Vertex DestinationVertex
        {
            get => _dest_v;
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
            return "Destino: " + _dest_v + ", peso: " + _weight;
        }

        public Point this[int i]
        {
            get => _path[i];
        }
    }
}
