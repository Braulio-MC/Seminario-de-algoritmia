using System.Collections.Generic;
using System.Linq;


namespace MartinezCarrilloBraulioCF
{
    class Prim
    {
        readonly List<Edge> _prom_set;
        readonly HashSet<Vertex> _s;
        readonly MinHeap _heap;
        HashSet<Vertex> _vertexLst;
        int _numberOfTrees;

        public Prim()
        {
            _prom_set = new();
            _s = new();
            _heap = new();
            _vertexLst = new();
            _numberOfTrees = 0;
        }

        public HashSet<Vertex> VertexList
        {
            set => _vertexLst = value;
            get => _vertexLst;
        }

        public int NumberOfTrees
        {
            get => _numberOfTrees;
        }
        
        public void InitHeap(int edge_count)
        {
            _heap.Init(edge_count);
        }
        private void AddToS(Vertex v)
        {
            _s.Add(v);
            _heap.AddRange(v.Edges.ToArray());
        }

        private Vertex ChooseFromVertexList()
        {
            _numberOfTrees++;
            return _vertexLst.Except(_s).First();
        }
         
        public void Clear()
        {
            _numberOfTrees = 0;
            _prom_set.Clear();
            _s.Clear();
            _vertexLst.Clear();
            _heap.Clear();
        }

        private int Viable(Edge e)
        {
            if (_s.Contains(e.InitVtx) && !_s.Contains(e.AsocVtx))
            {
                return 0;
            }
            if (_s.Contains(e.AsocVtx) && !_s.Contains(e.InitVtx))
            {
                return 1;
            }
            return -1;
        }

        public IReadOnlyCollection<Edge> GetPromisingSet(Vertex v)
        {
            if (v.Edges.Count != 0)
            {
                Edge curr_edge;
                int is_viable;
                AddToS(v);
                while(_s.Count < _vertexLst.Count)
                {
                    if (_heap.IsEmpty()) AddToS(ChooseFromVertexList());
                    curr_edge = _heap.Del();
                    is_viable = Viable(curr_edge);
                    if (is_viable != -1)
                    {
                        _prom_set.Add(curr_edge);
                        if (is_viable == 0)
                        {
                            AddToS(curr_edge.AsocVtx);
                        }
                        else
                        {
                            AddToS(curr_edge.InitVtx);
                        }
                    }
                }
                _numberOfTrees++;
            }
            return _prom_set;
        }
    }
}
