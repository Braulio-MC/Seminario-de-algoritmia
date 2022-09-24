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
    public partial class VentanaPrincipal : Form
    {
        Bitmap _bmp;
        readonly Grafo _g;

        public VentanaPrincipal()
        {
            InitializeComponent();
            _bmp = null;
            _g = new Grafo();
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
        }

        private void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            if (dialogoAbrirImagen.ShowDialog() == DialogResult.OK)
            {
                _bmp = new Bitmap(dialogoAbrirImagen.FileName);
                PteBoxPrincipal.Image = _bmp;
                lblMensajes.Text = "";
                _g.Clear();
                TviewGrafo.Nodes.Clear();
                Proceso();
            }
        }

        private void Proceso()
        {
            lblMensajes.Text = "Construyendo vertices...";
            lblMensajes.Refresh();
            VolcaCirculosAGrafo();
            if (_g.Count < 2)
            {
                lblMensajes.Text = "No es posible construir aristas";
                return;
            }
            lblMensajes.Text = "Construyendo aristas...";
            lblMensajes.Refresh();
            ConectaVertices();
            lblMensajes.Text = "Recoloreando circulos...";
            lblMensajes.Refresh();
            RecoloreaCirculos();
            var datos = _g.CalculaCentrosCercanos();
            Circulo c1 = datos.Item1.Circulo, c2 = datos.Item2.Circulo;
            float p = datos.Item3;
            lblMensajes.Text = "Par de centros mas cercanos: (" + c1.ToString2() + ", " + c2.ToString2() + ")" + " con distancia de " + p;
            ColoreaCirculo(Brushes.DarkRed, c1.XY.X, c1.XY.Y, (float)c1.Radio, c1.ID);
            ColoreaCirculo(Brushes.DarkRed, c2.XY.X, c2.XY.Y, (float)c2.Radio, c2.ID);
            PteBoxPrincipal.Refresh();
        }

        private void VolcaCirculosAGrafo()
        {
            int num_circulos = 0;
            string ID;
            while (true)
            {
                (int, int, int) datos = BuscaCirculo();
                if (datos.Item1 != 0 && datos.Item2 != 0)
                {
                    ID = "C" + num_circulos;
                    _g.AgregaVertice(new Circulo(ID, new Point(datos.Item1, datos.Item2), datos.Item3));
                    TviewGrafo.BeginUpdate();
                    TviewGrafo.Nodes.Add(ID);
                    TviewGrafo.EndUpdate();
                    ColoreaCirculo(Brushes.LightSkyBlue, datos.Item1, datos.Item2, datos.Item3, ID);
                    num_circulos++;
                    PteBoxPrincipal.Refresh();
                    TviewGrafo.Refresh();
                } else
                {
                    break;
                }
            }
        }

        private (int, int, int) BuscaCirculo()
        {
            int x_centro = 0, y_centro = 0, y_inferior, radio = 0;
            for (int y = 0; y < _bmp.Height; y++)
            {
                for (int x = 0; x < _bmp.Width; x++)
                {
                    Color c = _bmp.GetPixel(x, y);
                    if (c.R + c.G + c.B == 0)
                    {
                        (x_centro, y_centro, y_inferior) = EncuentraCentro(x, y);
                        radio = y_inferior - y_centro;
                        return (x_centro, y_centro, radio);
                    }
                }
            }
            return (x_centro, y_centro, radio);
        }

        private (int, int, int) EncuentraCentro(int x, int y_superior)
        {
            int y_inferior = y_superior, y_centro, x_derecha, x_izquierda, x_centro;
            Color c = _bmp.GetPixel(x, y_inferior + 1);
            while (c.R + c.G + c.B != 765)
            {
                y_inferior++;
                c = _bmp.GetPixel(x, y_inferior + 1);
            }
            y_centro = (y_superior + y_inferior) / 2;
            x_derecha = x;
            c = _bmp.GetPixel(x_derecha + 1, y_centro);
            while (c.R + c.G + c.B != 765)
            {
                x_derecha++;
                c = _bmp.GetPixel(x_derecha + 1, y_centro);
            }
            x_izquierda = x;
            c = _bmp.GetPixel(x_izquierda - 1, y_centro);
            while (c.R + c.G + c.B != 765)
            {
                x_izquierda--;
                c = _bmp.GetPixel(x_izquierda - 1, y_centro);
            }
            x_centro = (x_izquierda + x_derecha) / 2;
            return (x_centro, y_centro, y_inferior);
        }

        private void ColoreaCirculo(Brush brocha, int x_centro, int y_centro, float radio, string ID)
        {
            if (x_centro != 0 && y_centro != 0)
            {
                float d = (radio + 2) * 2;
                Graphics g = Graphics.FromImage(_bmp);
                g.FillEllipse(brocha, x_centro - (radio + 2), y_centro - (radio + 2), d, d);
                g.DrawString(ID, new Font("Arial", 30, FontStyle.Bold), 
                    Brushes.DarkBlue, x_centro + radio, y_centro - radio);
            }
        }

        private void ConectaVertices()
        {
            Point xy1, xy2;
            for (int i = 0; i < _g.Count; i++)
            {
                xy1 = _g[i].Circulo.XY;
                for (int j = i + 1; j < _g.Count; j++)
                {
                    xy2 = _g[j].Circulo.XY;
                    float peso = _g.CalculaDistancia(xy1, xy2);
                    _g[i].AgregaArista(_g[j], peso);
                    _g[j].AgregaArista(_g[i], peso);
                    TviewGrafo.Nodes[i].Nodes.Add(_g[i].Circulo.ID + " | " + _g[j].Circulo.ID + " | " + peso);
                    TviewGrafo.Nodes[j].Nodes.Add(_g[j].Circulo.ID + " | " + _g[i].Circulo.ID + " | " + peso);
                    _g.AgregaCentro((_g[i], _g[j], peso));
                    DibujaArista(xy1, xy2, peso);
                    PteBoxPrincipal.Refresh();
                }
            }
        }

        private void RecoloreaCirculos()
        {
            for (int i = 0; i < _g.Count; i++)
            {
                ColoreaCirculo(Brushes.LightSkyBlue, _g[i].Circulo.XY.X, _g[i].Circulo.XY.Y, (float)_g[i].Circulo.Radio, _g[i].Circulo.ID);
                PteBoxPrincipal.Refresh();
            }
        }

        private Vertice PerteneceA(int x_c, int y_c)
        {
            int x_i, y_i;
            double r_i;
            for (int i = 0; i < _g.Count; i++)
            {
                x_i = _g[i].Circulo.XY.X;
                y_i = _g[i].Circulo.XY.Y;
                r_i = _g[i].Circulo.Radio;
                double comprobacion = Math.Pow((x_i - x_c), 2) + Math.Pow((y_i - y_c), 2) - Math.Pow(r_i, 2);
                if (comprobacion < 0)
                {
                    return _g[i];
                }
            }
            return null;
        }

        private void DibujaArista(Point xy1, Point xy2, float peso)
        {
            Graphics g = Graphics.FromImage(_bmp);
            g.DrawLine(new Pen(Color.LightSteelBlue, 2), xy1, xy2);
            g.DrawString(peso.ToString(), new Font("Arial", 10, FontStyle.Bold), 
                Brushes.Black, (xy1.X + xy2.X) / 2, (xy1.Y + xy2.Y) / 2);
        }
    }
}
