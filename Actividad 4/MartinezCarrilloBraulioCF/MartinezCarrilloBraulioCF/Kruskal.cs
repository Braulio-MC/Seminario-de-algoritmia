using System.Collections.Generic;


namespace MartinezCarrilloBraulioCF
{
    public class Kruskal
    {
        readonly List<Edge> _candidates;
        readonly List<Edge> _prom_set;
        readonly List<HashSet<Vertex>> _cc;
        int _numberOfVertex;
        int _numberOfTrees;

        public Kruskal()
        {
            _candidates = new();
            _prom_set = new();
            _cc = new();
            _numberOfVertex = 0;
            _numberOfTrees = 0;
        }
        
        public int NumberOfTrees
        {
            get => _numberOfTrees;
        }

        public void AddCandidate(Edge e)
        {
            _candidates.Add(e);
        }

        public void InitCC(Vertex v)
        {
            HashSet<Vertex> hs = new();
            hs.Add(v);
            _cc.Add(hs);
            _numberOfVertex++;
        }

        private class HashSetSearch
        {
            readonly Vertex _v;
            
            public HashSetSearch(Vertex v)
            {
                _v = v;
            }

            public bool Contains(HashSet<Vertex> hs)
            {
                return hs.Contains(_v);
            }
        }

        private int SearchForCCOf(Vertex v) 
        {
            var hss = new HashSetSearch(v);
            return _cc.FindIndex(hss.Contains);
        }

        private void Union(int c1_indx, int c2_indx)
        {
            _cc[c1_indx].UnionWith(_cc[c2_indx]);
            _cc.RemoveAt(c2_indx);
        }

        public void Clear()
        {
            _numberOfVertex = 0;
            _numberOfTrees = 0;
            _candidates.Clear();
            _prom_set.Clear();
            _cc.Clear();
        }

        private void Swap(int indx1, int indx2)
        {
            var tmp = _candidates[indx1];
            _candidates[indx1] = _candidates[indx2];
            _candidates[indx2] = tmp;
        }

        public void SortCandidates(int left, int right)
        {
            int beg = left, end = right;
            var pivot = _candidates[(beg + end) / 2];
            while (beg <= end)
            {
                while (_candidates[beg].Weight < pivot.Weight && left < right) { beg++; }
                while (_candidates[end].Weight > pivot.Weight && right > left) { end--; }
                if (beg <= end) 
                {
                    Swap(beg, end);
                    beg++;
                    end--;
                }
            }
            if (left < end)
            {
                SortCandidates(left, end);
            }
            if (right > beg)
            {
                SortCandidates(beg, right);
            }
        }

        public IReadOnlyCollection<Edge> GetPromisingSet()
        {
            int c1_indx, c2_indx;
            Edge curr_edge;
            if (_candidates.Count != 0) SortCandidates(0, _candidates.Count - 1);
            while (_prom_set.Count < _numberOfVertex - 1) 
            {
                if (_candidates.Count == 0) break;
                curr_edge = _candidates[0];
                _candidates.RemoveAt(0);
                c1_indx = SearchForCCOf(curr_edge.InitVtx);
                c2_indx = SearchForCCOf(curr_edge.AsocVtx);
                if (_cc[c1_indx] != _cc[c2_indx])
                {
                    _prom_set.Add(curr_edge);
                    Union(c1_indx, c2_indx);
                }
            }
            _numberOfTrees = _cc.Count != _numberOfVertex ? _cc.Count : 0;
            return _prom_set;
        }
    }
}
