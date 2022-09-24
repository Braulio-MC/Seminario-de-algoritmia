namespace MartinezCarrilloBraulioCF
{
    class DijkstraElement
    {
        float _accumulatedWeight;
        Vertex _sourceVtx;
        bool _isDefinitive;

        public DijkstraElement()
        {
            _accumulatedWeight = float.PositiveInfinity;
            _sourceVtx = null;
            _isDefinitive = false;
        }

        public float AccumulatedWeight
        {
            get => _accumulatedWeight;
            set => _accumulatedWeight = value;
        }

        public Vertex SourceVertex
        {
            get => _sourceVtx;
            set => _sourceVtx = value;
        }

        public bool IsDefinitive
        {
            get => _isDefinitive;
            set => _isDefinitive = value;
        }
    }
}
