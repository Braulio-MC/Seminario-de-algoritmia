using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartinezCarrilloBraulioCF
{
    public partial class MainWindow : Form
    {
        Bitmap _bmp;
        Bitmap _bmpAnimation;
        readonly Graph _g;
        Agent _agent;

        public MainWindow()
        {
            InitializeComponent();
            _bmp = null;
            _g = new();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LblMessages.Text = "";
        }

        private void BtnOpnMainImg_Click(object sender, EventArgs e)
        {
            if (OpnFDlgMainImg.ShowDialog() == DialogResult.OK)
            {
                _bmp = new(OpnFDlgMainImg.FileName);
                _bmpAnimation = new(_bmp.Width, _bmp.Height);
                PteBoxMainImg.BackgroundImage = _bmp;
                PteBoxMainImg.Image = _bmpAnimation;
                ClearAll();
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
            LblMessages.Text = "Esperando vertice de inicio y de fin...";
            LblMessages.Refresh();
        }

        private void DumpVtxToGraph()
        {
            int circle_count = 0;
            string ID;
            while (true)
            {
                (int, int, int) data = SearchForCircle();
                if (data.Item1 != 0 && data.Item2 != 0)
                {
                    ID = "C" + circle_count;
                    _g.AddVertex(new(ID, new(data.Item1, data.Item2), data.Item3));
                    TViewGraph.BeginUpdate();
                    TViewGraph.Nodes.Add(ID);
                    TViewGraph.EndUpdate();
                    CboxInitVtx.Items.Add(ID);
                    CboxFinalVtx.Items.Add(ID);
                    DrawCircle(Brushes.Gray, _bmp, data.Item1, data.Item2, data.Item3);
                    circle_count++;
                    PteBoxMainImg.Refresh();
                    TViewGraph.Refresh();
                }
                else
                {
                    break;
                }
            }
            CboxInitVtx.Refresh();
            CboxFinalVtx.Refresh();
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
            while (c.R + c.G + c.B == 384)
            {
                higher_y--;
                c = _bmp.GetPixel(rounded_x, higher_y - 1);
            }
            c = _bmp.GetPixel(rounded_x, lower_y + 1);
            while (c.R + c.G + c.B == 384)
            {
                lower_y++;
                c = _bmp.GetPixel(rounded_x, lower_y + 1);
            }
            center_y = (higher_y + lower_y) / 2;
            c = _bmp.GetPixel(left_x - 1, center_y);
            while (c.R + c.G + c.B == 384)
            {
                left_x--;
                c = _bmp.GetPixel(left_x - 1, center_y);
            }
            c = _bmp.GetPixel(right_x + 1, center_y);
            while (c.R + c.G + c.B == 384)
            {
                right_x++;
                c = _bmp.GetPixel(right_x + 1, center_y);
            }
            center_x = (left_x + right_x) / 2;
            return (center_x + 1, center_y);
        }

        private static void DrawCircle(Brush brush, Bitmap bmp ,  int center_x, int center_y, float radius)
        {
            if (center_x != 0 && center_y != 0)
            {
                float diam = (radius + 2) * 2;
                Graphics g = Graphics.FromImage(bmp);
                g.FillEllipse(brush, center_x - (radius + 2), center_y - (radius + 2), diam, diam);
            }
        }

        private void DrawEdge(Point xy1, Point xy2)
        {
            Graphics g = Graphics.FromImage(_bmp);
            g.DrawLine(Pens.Black, xy1, xy2);
        }

        private void MakeEdges()
        {
            Point xy1, xy2;
            for (int i = 0; i < _g.Count; i++)
            {
                xy1 = _g[i].Circle.XY;
                for (int j = i + 1; j < _g.Count; j++)
                {
                    xy2 = _g[j].Circle.XY;
                    var (path, IsTrue) = DDA(xy1.X, xy1.Y, xy2.X, xy2.Y);
                    if (IsTrue)
                    {
                        float weight = Graph.Distance(xy1, xy2);
                        _g[i].AddEdge(_g[j], path, weight);
                        _g[j].AddEdge(_g[i], path, weight);
                        TViewGraph.Nodes[i].Nodes.Add(_g[i].Circle.ID + " | " + _g[j].Circle.ID + " | " + weight);
                        TViewGraph.Nodes[j].Nodes.Add(_g[j].Circle.ID + " | " + _g[i].Circle.ID + " | " + weight);
                        DrawEdge(xy1, xy2);
                        PteBoxMainImg.Refresh();
                    }
                }
            }
        }

        private bool IsValidPxl(int rounded_x, int rounded_y, Vertex v_a, Vertex v_b)
        {
            var pxl = _bmp.GetPixel(rounded_x, rounded_y);
            var pxl_sum = pxl.R + pxl.G + pxl.B;
            var pxl_result = false;
            if (pxl_sum == 765 || pxl_sum == 0)
            {
                pxl_result = true;
            }
            if (pxl_sum == 384)
            {
                var c = SearchForCterAnyXY(rounded_x, rounded_y);
                var is_valid_v = BelongsTo(c.Item1, c.Item2);
                if (is_valid_v != null)
                {
                    if (is_valid_v.Circle.ID == v_a.Circle.ID)
                    {
                        pxl_result = true;
                    }
                    if (is_valid_v.Circle.ID == v_b.Circle.ID)
                    {
                        pxl_result = true;
                    }
                }
            }
            return pxl_result;
        }

        private (Point[], bool) DDA(float init_x, float init_y, float final_x, float final_y)
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
                            return (null, false);
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
                            return (null, false);
                        }
                    }
                }
                return (path, true);
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
                                return (null, false);
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
                                return (null, false);
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
                                return (null, false);
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
                                return (null, false);
                            }
                        }
                    }
                }
                return (path, true);
            }    
        }

        private void ClearAll()
        {
            TViewGraph.Nodes.Clear();
            CboxInitVtx.Items.Clear();
            CboxInitVtx.Text = "";
            CboxFinalVtx.Items.Clear();
            CboxFinalVtx.Text = "";
            LblMessages.Text = "";
            CboxInitVtx.Visible = true;
            CboxFinalVtx.Visible = true;
            BtnAnimation.Visible = false;
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

        private void CboxInitVtx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboxFinalVtx.SelectedIndex != -1)
            {
                var init_ID = (string)CboxInitVtx.Items[CboxInitVtx.SelectedIndex];
                var final_ID = (string)CboxFinalVtx.Items[CboxFinalVtx.SelectedIndex];
                Vertex vtx_objve = null;
                if (init_ID != final_ID)
                {
                    for (int i = 0; i < _g.Count; i++)
                    {
                        if (_g[i].Circle.ID == init_ID)
                        {
                            _agent = new(_g[i]);
                            var data = _agent.Vtx.Circle.Data;
                            DrawCircle(Brushes.YellowGreen, _bmpAnimation, data.Item2, data.Item3, 8);
                            PteBoxMainImg.Refresh();
                        }
                        if (_g[i].Circle.ID == final_ID)
                        {
                            vtx_objve = _g[i];
                        }
                    }
                    _agent.ObjveVtx = vtx_objve;
                    LblMessages.Text = "";
                    CboxInitVtx.Visible = false;
                    CboxFinalVtx.Visible = false;
                    BtnAnimation.Visible = true;
                }
                else
                {
                    LblMessages.Text = "Valores invalidos";
                    LblMessages.Refresh();
                }
            } 
            else
            {
                LblMessages.Text = "Esperando valor para vertice fin...";
                LblMessages.Refresh();
            }
        }

        private void CboxFinalVtx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboxInitVtx.SelectedIndex != -1)
            {
                var init_ID = (string)CboxInitVtx.Items[CboxInitVtx.SelectedIndex];
                var final_ID = (string)CboxFinalVtx.Items[CboxFinalVtx.SelectedIndex];
                Vertex vtx_objve = null;
                if (init_ID != final_ID)
                {
                    for (int i = 0; i < _g.Count; i++)
                    {
                        if (_g[i].Circle.ID == init_ID)
                        {
                            _agent = new(_g[i]);
                            var data = _agent.Vtx.Circle.Data;
                            DrawCircle(Brushes.YellowGreen, _bmpAnimation, data.Item2, data.Item3, 8);
                            PteBoxMainImg.Refresh();
                        }
                        if (_g[i].Circle.ID == final_ID)
                        {
                            vtx_objve = _g[i];
                        }
                    }
                    _agent.ObjveVtx = vtx_objve;
                    LblMessages.Text = "";
                    CboxInitVtx.Visible = false;
                    CboxFinalVtx.Visible = false;
                    BtnAnimation.Visible = true;
                }
                else
                {
                    LblMessages.Text = "Valores invalidos";
                    LblMessages.Refresh();
                }
            }
            else
            {
                LblMessages.Text = "Esperando valor para vertice inicio...";
                LblMessages.Refresh();
            }
        }

        private void BtnAnimation_Click(object sender, EventArgs e)
        {
            LblMessages.Text = "Intentando alcanzar a " + _agent.ObjveVtx.Circle.ID;
            Graphics g = Graphics.FromImage(_bmpAnimation);
            Point p;
            for (int i = 0; i < _g.Count; i++)
            {
                if (_agent.Vtx == _agent.ObjveVtx)
                {
                    LblMessages.Text = "Exito el objetivo fue alcanzado";
                    break;
                }
                _agent.ChoosePath();
                if (i == _g.Count - 1 || _agent.NonVisitedCount == 0)
                {
                    LblMessages.Text = "Fracaso el objetivo no fue alcanzado";
                    break;
                }
                var edge = _agent.Vtx.GetEdge(_agent.EdgeIndex);
                while (_agent.Walk())
                {
                    p = edge.GetPoint(_agent.PathIndex); 
                    g.Clear(Color.Transparent);
                    DrawCircle(Brushes.YellowGreen, _bmpAnimation, p.X, p.Y, 8);
                    PteBoxMainImg.Refresh();
                }
            }
        }
    }
}






