using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;


namespace MartinezCarrilloBraulioCF
{
    public partial class MainWindow : Form
    {
        Bitmap _bmp;
        Bitmap _bmpTemp;
        readonly Graph _g;
        readonly Kruskal _k;
        readonly Prim _p;
        IReadOnlyCollection<Edge> _KruskalsPromSet;
        IReadOnlyCollection<Edge> _PrimsPromSet;

        public MainWindow()
        {
            InitializeComponent();
            _bmp = null;
            _bmpTemp = null;
            _g = new();
            _k = new();
            _p = new();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LblMessages.Text = "";
        }

        private void BtnChargeMainImg_Click(object sender, EventArgs e)
        {
            if (OpnFileDlgMainImg.ShowDialog() == DialogResult.OK)
            {
                ClearAll();
                _bmp = new Bitmap(OpnFileDlgMainImg.FileName);
                PteBoxMainImg.Image = _bmp;
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
            _KruskalsPromSet = _k.GetPromisingSet();
            LblMessages.Text = "Grafo listo";
            LblInitVertex.Visible = true;
            CBoxInitVertex.Visible = true;
        }

        private void DumpVtxToGraph()
        {
            int circle_count = 0;
            string ID;
            Vertex v;
            SolidBrush sb = new(Color.FromArgb(1, 1, 1));
            while (true)
            {
                (int, int, int) data = SearchForCircle();
                if (data.Item1 != 0 && data.Item2 != 0)
                {
                    ID = "C" + circle_count;
                    v = new(new(ID, new(data.Item1, data.Item2), data.Item3));
                    _g.AddVertex(v);
                    _k.InitCC(v);
                    CBoxInitVertex.Items.Add(ID);
                    DrawCircle(sb, _bmp, data.Item1, data.Item2, data.Item3);
                    circle_count++;
                    PteBoxMainImg.Refresh();
                }
                else
                {
                    break;
                }
            }
            _p.VertexList.UnionWith(_g.VertexList);
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
            if (center_x != 0 && center_y != 0)
            {
                float diam = (radius + 2) * 2;
                Graphics g = Graphics.FromImage(bmp);
                g.FillEllipse(brush, center_x - (radius + 2), center_y - (radius + 2), diam, diam);
            }
        }

        private static void DrawEdge(Pen pen, Bitmap bmp, Point xy1, Point xy2, int optional_id=0, string alg="Kruskal")
        {
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(pen, xy1, xy2);
            if (optional_id != 0)
            {
                var font = new Font("Arial", 30);
                if (alg == "Kruskal")
                {
                    var point = new Point((xy1.X + xy2.X) / 2, (xy1.Y + xy2.Y) / 2);
                    g.DrawString(optional_id.ToString(), font, Brushes.OrangeRed, point);
                }
                else
                {
                    var point = new Point((xy1.X + xy2.X) / 2, (xy1.Y + xy2.Y) / 2 + 40);
                    g.DrawString(optional_id.ToString(), font, Brushes.Magenta, point);
                }
            }
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
                    path =  DDA(xy1.X, xy1.Y, xy2.X, xy2.Y);
                    if (path != null)
                    {
                        weight = Graph.Distance(xy1, xy2);
                        e = new(_g[i], _g[j], path, weight);
                        _g[i].AddEdge(e);
                        _k.AddCandidate(e);
                        _g[j].AddEdge(new(_g[j], _g[i], path, weight));
                        _g.EdgeCount++;
                        DrawEdge(Pens.Black, _bmp, xy1, xy2);
                        PteBoxMainImg.Refresh();
                    }
                }
            }
            _p.InitHeap(_g.EdgeCount);
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
            _bmpTemp = null;
            PteBoxTmp.Visible = false;
            CBoxInitVertex.Items.Clear();
            CBoxInitVertex.Text = "";
            CBoxInitVertex.Visible = false;
            LblInitVertex.Visible = false;
            PteBoxMainImg.Size = new(652, 411);
            LblMessages.Text = "";
            RBtnKruskalsARM.Checked = false;
            RBtnPrimsARM.Checked = false;
            RBtnCompareKruskalPrim.Checked = false;
            _g.Clear();
            _k.Clear();
            _p.Clear();
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

        private void CBoxInitVertex_SelectedIndexChanged(object sender, EventArgs e)
        {
            _PrimsPromSet = _p.GetPromisingSet(_g.SearchForVertex(CBoxInitVertex.Items[CBoxInitVertex.SelectedIndex]));
        }

        private void Kruskals(Bitmap bmp)
        {
            Edge e;
            for (int i = 0; i < _KruskalsPromSet.Count; i++)
            {
                e = _KruskalsPromSet.ElementAt(i);
                DrawEdge(new(Color.OrangeRed, 4), bmp, e.InitVtx.Circle.XY, e.AsocVtx.Circle.XY, i + 1);
                PteBoxMainImg.Refresh();
            }
        }

        private void Prims(Bitmap bmp)
        {
            Edge e;
            for (int i = 0; i < _KruskalsPromSet.Count; i++)
            {
                e = _PrimsPromSet.ElementAt(i);
                DrawEdge(new(Color.Magenta, 4), bmp, e.InitVtx.Circle.XY, e.AsocVtx.Circle.XY, i + 1, "Prim");
                PteBoxMainImg.Refresh();
            }
        }

        private void RBtnKruskalsARM_CheckedChanged(object sender, EventArgs e)
        {
            if (_bmp != null)
            {
                LblMessages.Text = "";
                PteBoxTmp.Visible = false;
                PteBoxMainImg.Size = new(652, 411);
                _bmpTemp = null;
                Kruskals(_bmp);
                LblMessages.Text = "Numero de arboles con Kruskal: " + _k.NumberOfTrees;
                LblMessages.Refresh();
            }
            else
            {
                RBtnKruskalsARM.Checked = false;
                LblMessages.Text = "Imagen no cargada";
                LblMessages.Refresh();
            }
        }
        private void RBtnPrimsARM_CheckedChanged(object sender, EventArgs e)
        {
            if (_bmp != null && CBoxInitVertex.SelectedIndex != -1)
            {
                LblMessages.Text = "";
                CBoxInitVertex.Visible = false;
                LblInitVertex.Visible = false;
                PteBoxTmp.Visible = false;
                PteBoxMainImg.Size = new(652, 411);
                _bmpTemp = null;
                Prims(_bmp);
                LblMessages.Text = "Numero de arboles con Prim: " + _p.NumberOfTrees;
                LblMessages.Refresh();
            }
            else
            {
                RBtnPrimsARM.Checked = false;
                LblMessages.Text = "Imagen no cargada o vertice inicio no proporcionado";
                LblMessages.Refresh();
            }
        }

        private void RBtnCompareKruskalPrim_CheckedChanged(object sender, EventArgs e)
        {
            if (_bmp != null && CBoxInitVertex.SelectedIndex != -1)
            {
                PteBoxTmp.Visible = true;
                PteBoxMainImg.Size = new(327, 411);
                _bmpTemp = new(PteBoxMainImg.Image);
                PteBoxTmp.Image = _bmpTemp;
                Kruskals(_bmp);
                Prims(_bmpTemp);
                LblMessages.Text = "Visualizacion de Kruskal a la izquierda y Prim a la derecha";
                LblMessages.Refresh();
            }
            else
            {
                RBtnCompareKruskalPrim.Checked = false;
                LblMessages.Text = "Imagen no cargada o vertice inicio no proporcionado";
                LblMessages.Refresh();
            }
        }

    }
}
