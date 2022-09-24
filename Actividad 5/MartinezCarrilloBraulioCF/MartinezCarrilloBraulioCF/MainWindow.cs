using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace MartinezCarrilloBraulioCF
{
    public partial class MainWindow : Form
    {
        Bitmap _bmp;
        Bitmap _bmpAnimation;
        readonly Graph _g;
        readonly List<Agent> _agentLst;
        Vertex _objveVertex;

        public MainWindow()
        {
            InitializeComponent();
            _bmp = null;
            _bmpAnimation = null;
            _g = new();
            _agentLst = new();
            _objveVertex = null;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LblMessages.Text = "";
        }

        private void BtnOpnMainImg_Click(object sender, EventArgs e)
        {
            if (OpnFileMainImg.ShowDialog() == DialogResult.OK)
            {
                ClearAll();
                _bmp = new(OpnFileMainImg.FileName);
                _bmpAnimation = new(_bmp.Width, _bmp.Height);
                PteBoxMainImg.BackgroundImage = _bmp;
                PteBoxMainImg.Image = _bmpAnimation;
                Process();
            }
        }

        private void Process()
        {
            LblMessages.Text = "Construyendo vertices...";
            LblMessages.Refresh();
            DumpVtxToGraph();
            LblMessages.Text = "Construyendo aristas...";
            LblMessages.Refresh();
            MakeEdges();
            LblMessages.Text = "Clic izquierdo para colocar un objetivo\nClic derecho para colocar un agente";
        }

        private void DumpVtxToGraph()
        {
            int circle_count = 0;
            string ID;
            SolidBrush sb = new(Color.FromArgb(1, 1, 1));
            while (true)
            {
                (int, int, int) data = SearchForCircle();
                if (data.Item1 != 0 && data.Item2 != 0)
                {
                    ID = "C" + circle_count;
                    var c = new Circle(ID, new(data.Item1, data.Item2), data.Item3);
                    _g.AddVertex(new(c));
                    DrawCircle(sb, _bmp, c.XY.X, c.XY.Y, c.Radius);
                    circle_count++;
                    PteBoxMainImg.Refresh();
                }
                else
                {
                    break;
                }
            }
            _agentLst.Capacity = _g.Count - 1;
        }

        private (int, int, int) SearchForCircle()
        {
            int center_x = 0, center_y = 0, lower_y, radius = 0;
            for (int y = 0; y < _bmp.Height; y++)
            {
                for (int x = 0; x < _bmp.Width; x++)
                {
                    Color c = _bmp.GetPixel(x, y);
                    if (c.R + c.G + c.B == 0)
                    {
                        (center_x, center_y, lower_y) = SearchForCterWthHghrY(x, y);
                        radius = lower_y - center_y;
                        return (center_x, center_y, radius);
                    }
                }
            }
            return (center_x, center_y, radius);
        }

        private (int, int, int) SearchForCterWthHghrY(int x, int higher_y)
        {
            int lower_y = higher_y, center_y, right_x, left_x, center_x;
            Color c = _bmp.GetPixel(x, lower_y + 1);
            while (c.R + c.G + c.B != 765)
            {
                lower_y++;
                c = _bmp.GetPixel(x, lower_y + 1);
            }
            center_y = (higher_y + lower_y) / 2;
            right_x = x;
            c = _bmp.GetPixel(right_x + 1, center_y);
            while (c.R + c.G + c.B != 765)
            {
                right_x++;
                c = _bmp.GetPixel(right_x + 1, center_y);
            }
            left_x = x;
            c = _bmp.GetPixel(left_x - 1, center_y);
            while (c.R + c.G + c.B != 765)
            {
                left_x--;
                c = _bmp.GetPixel(left_x - 1, center_y);
            }
            center_x = (left_x + right_x) / 2;
            return (center_x, center_y, lower_y);
        }

        private (int, int) SearchForCterAnyXY(int rounded_x, int rounded_y)
        {
            int lower_y = rounded_y, higher_y = rounded_y;
            int left_x = rounded_x, right_x = rounded_x;
            int center_x, center_y;
            Color c = _bmp.GetPixel(rounded_x, higher_y - 1);
            while (c.R + c.G + c.B == 3)
            {
                higher_y--;
                c = _bmp.GetPixel(rounded_x, higher_y - 1);
            }
            c = _bmp.GetPixel(rounded_x, lower_y + 1);
            while (c.R + c.G + c.B == 3)
            {
                lower_y++;
                c = _bmp.GetPixel(rounded_x, lower_y + 1);
            }
            center_y = (higher_y + lower_y) / 2;
            c = _bmp.GetPixel(left_x - 1, center_y);
            while (c.R + c.G + c.B == 3)
            {
                left_x--;
                c = _bmp.GetPixel(left_x - 1, center_y);
            }
            c = _bmp.GetPixel(right_x + 1, center_y);
            while (c.R + c.G + c.B == 3)
            {
                right_x++;
                c = _bmp.GetPixel(right_x + 1, center_y);
            }
            center_x = (left_x + right_x) / 2;
            return (center_x + 1, center_y);
        }

        private static void DrawCircle(Brush brush, Bitmap bmp, int center_x, int center_y, float radius)
        {
            float diam = radius * 2;
            Graphics g = Graphics.FromImage(bmp);
            g.FillEllipse(brush, center_x - radius, center_y - radius, diam, diam);
        }

        private static void DrawEdge(Pen pen, Bitmap bmp, Point xy1, Point xy2)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(pen, xy1, xy2);
        }

        private void MakeEdges()
        {
            Point xy1, xy2;
            Point[] path;
            float weight;
            Edge e;
            for (int i = 0; i < _g.Count; i++)
            {
                xy1 = _g[i].Circle.XY;
                for (int j = i + 1; j < _g.Count; j++)
                {
                    xy2 = _g[j].Circle.XY;
                    path = DDA(xy1.X, xy1.Y, xy2.X, xy2.Y);
                    if (path != null)
                    {
                        weight = Graph.Distance(xy1, xy2);
                        e = new(_g[i], _g[j], path, weight);
                        _g[i].AddEdge(e);
                        _g[j].AddEdge(new(_g[j], _g[i], path, weight));
                        DrawEdge(Pens.Black, _bmp, xy1, xy2);
                    }
                }
            }
            PteBoxMainImg.Refresh();
        }

        private bool IsValidPxl(int rounded_x, int rounded_y, Vertex v_a, Vertex v_b)
        {
            var pxl = _bmp.GetPixel(rounded_x, rounded_y);
            var pxl_sum = pxl.R + pxl.G + pxl.B;
            if (pxl_sum == 765 || pxl_sum == 0)
            {
                return true;
            }
            if (pxl_sum == 3)
            {
                var c = SearchForCterAnyXY(rounded_x, rounded_y);
                var is_valid_v = BelongsTo(c.Item1, c.Item2);
                if (is_valid_v != null)
                {
                    if (is_valid_v == v_a)
                    {
                        return true;
                    }
                    if (is_valid_v == v_b)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private Point[] DDA(float init_x, float init_y, float final_x, float final_y)
        {
            float m, b;
            float x_k, y_k;
            var v_a = BelongsTo((int)init_x, (int)init_y);
            var v_b = BelongsTo((int)final_x, (int)final_y);
            Point[] path;
            int n, i = 0;
            if (init_x == final_x)
            {
                int rounded_x = (int)Math.Round(init_x);
                n = Math.Abs((int)(final_y - init_y)) + 1;
                path = new Point[n];
                if (init_y < final_y)
                {
                    for (y_k = init_y; y_k <= final_y; y_k++)
                    {
                        int rounded_y = (int)Math.Round(y_k);
                        path[i].X = rounded_x;
                        path[i++].Y = rounded_y;
                        if (!IsValidPxl(rounded_x, rounded_y, v_a, v_b))
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    for (y_k = final_y; y_k <= init_y; y_k++)
                    {
                        int rounded_y = (int)Math.Round(y_k);
                        path[i].X = rounded_x;
                        path[i++].Y = rounded_y;
                        if (!IsValidPxl(rounded_x, rounded_y, v_a, v_b))
                        {
                            return null;
                        }
                    }
                }
                return path;
            }
            else
            {
                m = (final_y - init_y) / (final_x - init_x);
                b = init_y - m * init_x;
                if (m <= 1 && m >= -1)
                {
                    n = Math.Abs((int)(final_x - init_x)) + 1;
                    path = new Point[n];
                    if (init_x < final_x)
                    {
                        for (x_k = init_x; x_k <= final_x; x_k++)
                        {
                            y_k = m * x_k + b;
                            int rounded_x = (int)Math.Round(x_k);
                            int rounded_y = (int)Math.Round(y_k);
                            path[i].X = rounded_x;
                            path[i++].Y = rounded_y;
                            if (!IsValidPxl(rounded_x, rounded_y, v_a, v_b))
                            {
                                return null;
                            }
                        }
                    }
                    else
                    {
                        for (x_k = final_x; x_k <= init_x; x_k++)
                        {
                            y_k = m * x_k + b;
                            int rounded_x = (int)Math.Round(x_k);
                            int rounded_y = (int)Math.Round(y_k);
                            path[i].X = rounded_x;
                            path[i++].Y = rounded_y;
                            if (!IsValidPxl(rounded_x, rounded_y, v_a, v_b))
                            {
                                return null;
                            }
                        }
                    }
                }
                else
                {
                    n = Math.Abs((int)(final_y - init_y)) + 1;
                    path = new Point[n];
                    if (init_y < final_y)
                    {
                        for (y_k = init_y; y_k <= final_y; y_k++)
                        {
                            x_k = (y_k - b) / m;
                            int rounded_x = (int)Math.Round(x_k);
                            int rounded_y = (int)Math.Round(y_k);
                            path[i].X = rounded_x;
                            path[i++].Y = rounded_y;
                            if (!IsValidPxl(rounded_x, rounded_y, v_a, v_b))
                            {
                                return null;
                            }
                        }
                    }
                    else
                    {
                        for (y_k = final_y; y_k <= init_y; y_k++)
                        {
                            x_k = (y_k - b) / m;
                            int rounded_x = (int)Math.Round(x_k);
                            int rounded_y = (int)Math.Round(y_k);
                            path[i].X = rounded_x;
                            path[i++].Y = rounded_y;
                            if (!IsValidPxl(rounded_x, rounded_y, v_a, v_b))
                            {
                                return null;
                            }
                        }
                    }
                }
                return path;
            }
        }

        private void ClearAll()
        {
            _bmp = null;
            _bmpAnimation = null;
            _agentLst.Clear();
            LblMessages.Text = "";
            _objveVertex = null;
            _g.Clear();
        }

        private Vertex BelongsTo(int center_x, int center_y)
        {
            int x_i, y_i;
            float r_i;
            for (int i = 0; i < _g.Count; i++)
            {
                x_i = _g[i].Circle.XY.X;
                y_i = _g[i].Circle.XY.Y;
                r_i = _g[i].Circle.Radius;
                double belongsto = Math.Pow(x_i - center_x, 2) + Math.Pow(y_i - center_y, 2) - Math.Pow(r_i, 2);
                if (belongsto < 0)
                {
                    return _g[i];
                }
            }
            return null;
        }

        private Point CoordinatesTransform(Point p_p)
        {
            float w_p = PteBoxMainImg.Width;
            float h_p = PteBoxMainImg.Height;
            float w_b = _bmp.Width;
            float h_b = _bmp.Height;
            float p_w = w_p / w_b;
            float p_h = h_p / h_b;
            float d_w = 0;
            float d_h = 0;
            float x_b, y_b, p;
            if (p_w < p_h)
            {
                p = p_w;
                d_h = Math.Abs(h_b * p - h_p) / 2;
            }
            else
            {
                p = p_h;
                d_w = Math.Abs(w_b * p - w_p) / 2;
            }
            x_b = (p_p.X - d_w) / p;
            y_b = (p_p.Y - d_h) / p;
            return new Point((int)Math.Round(x_b), (int)Math.Round(y_b));
        }

        private bool CanAnimate()
        {
            return _agentLst.Any(a => a.InMotion == true);
        }

        private void BtnAnimation_Click(object sender, EventArgs e)
        {
            if (_agentLst.Count == 0 || _g.Count < 3 || _objveVertex == null) return;
            Graphics g = Graphics.FromImage(_bmpAnimation);
            SolidBrush sb = new(Color.FromArgb(1, 1, 1));
            LblMessages.Text = "";
            _g.VertexList.Where(v => v != _objveVertex).ToList()
                .ForEach(v => DrawCircle(sb, _bmp, v.Circle.XY.X, v.Circle.XY.Y, v.Circle.Radius));
            while (CanAnimate()) 
            {
                g.Clear(Color.Transparent);
                foreach (var agent in _agentLst)
                {
                    if (agent.InMotion)
                    {
                        if (_objveVertex == null)
                        {
                            if (agent.Walk2())
                            {
                                agent.LastPosition = agent.Path[agent.EdgeIndex][agent.PathIndex];
                            }
                        }
                        else
                        {
                            if (!agent.Walk1())
                            {
                                agent.ChoosePath();
                            }
                            else
                            {
                                agent.LastPosition = agent.Path[agent.EdgeIndex][agent.PathIndex];
                            }
                            if (agent.InitialVertex == _objveVertex)
                            {
                                var c = _objveVertex.Circle;
                                LblMessages.Text = agent.ID + " alcanzo el objetivo";
                                LblMessages.Refresh();
                                DrawCircle(sb, _bmp, c.XY.X, c.XY.Y, c.Radius);
                                _objveVertex = null;
                            }
                        }
                    }
                    DrawCircle(Brushes.Aqua, _bmpAnimation, agent.LastPosition.X, agent.LastPosition.Y, agent.Size);
                }
                PteBoxMainImg.Refresh();
            }
        }

        private void PteBoxMainImg_MouseMove(object sender, MouseEventArgs e)
        {
            if (_objveVertex != null)
            {
                Vertex v;
                Graphics g = Graphics.FromImage(_bmpAnimation);
                var p = CoordinatesTransform(e.Location);
                v = BelongsTo(p.X, p.Y);
                g.Clear(Color.Transparent);
                if (v != null)
                {
                    var minimum = _g.GetMinimumPath(_objveVertex, v);
                    foreach (var edge in minimum)
                    {
                        DrawEdge(new Pen(Color.IndianRed, 7), _bmpAnimation, edge.InitVtx.Circle.XY, edge.AsocVtx.Circle.XY);
                    }
                }
                PteBoxMainImg.Refresh();
            }
        }

        private void PteBoxMainImg_MouseClick(object sender, MouseEventArgs e)
        {
            if (_bmp != null)
            {
                var p_b = CoordinatesTransform(e.Location);
                var v = BelongsTo(p_b.X, p_b.Y);
                if (v != null)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        if (v != _objveVertex)
                        {
                            if (_agentLst.Count < _g.Count - 1)
                            {
                                if (!_agentLst.Exists(e => e.InitialVertex == v))
                                {
                                    LblMessages.Text = "";
                                    var agent = new Agent("A-" + v.Circle.ID, v);
                                    _agentLst.Add(agent);
                                }
                                else
                                {
                                    LblMessages.Text = "No se puede agregar mas de un agente por vertice";
                                }
                            }
                            else
                            {
                                LblMessages.Text = "Limite de agentes alcanzado";
                            }
                        }
                        else
                        {
                            LblMessages.Text = "No se puede agregar a un vertice que tiene el objetivo asignado";
                        }
                    }
                    if (e.Button == MouseButtons.Left)
                    {
                        if (_objveVertex == null)
                        {
                            if (!_agentLst.Exists(a => a.InitialVertex == v))
                            {
                                _objveVertex = v;
                                var c = v.Circle;
                                DrawCircle(Brushes.IndianRed, _bmp, c.XY.X, c.XY.Y, c.Radius / 2);
                                _g.Dijkstra(_objveVertex);
                            }
                            else
                            {
                                LblMessages.Text = "No se puede agregar a un vertice que tiene un agente asignado";
                            }
                        }
                        else
                        {
                            LblMessages.Text = "El objetivo ya esta asignado";
                            LblMessages.Refresh();
                        }
                    }
                    if (_agentLst.Count > 0)
                    {
                        if (_objveVertex != null)
                        {
                            _agentLst.ForEach(a => a.MainData = (_g.GetMinimumPath(_objveVertex, a.InitialVertex), true, 0, -1));
                        }
                    }
                    _agentLst.ForEach(a => DrawCircle(Brushes.Aqua, _bmp, a.LastPosition.X, a.LastPosition.Y, a.Size));
                    PteBoxMainImg.Refresh();
                }
            }
        }
    }
}
