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
    public partial class ventanaPrincipal : Form
    {
        private Bitmap _bitImagen;
        private Bitmap _circuloProcesado;
        private readonly List<Circulo> _lstCircs;
        private readonly Ordena _o;

        public ventanaPrincipal()
        {
            InitializeComponent();
            _bitImagen = null;
            _lstCircs = new List<Circulo>();
            _o = new Ordena();
        }

        private void ventanaPrincipal_Load(object sender, EventArgs e)
        {
            lblAdvertencia.Text = "";
        }

        private void btnAbrirImagen_Click(object sender, EventArgs e)
        {
            if (dialogoSelecImagen.ShowDialog() == DialogResult.OK)
            {
                _bitImagen = new Bitmap(dialogoSelecImagen.FileName);
                _circuloProcesado = new Bitmap(_bitImagen.Width, _bitImagen.Height);
                pteBoxImagenProc.Image = _bitImagen;
                lblAdvertencia.Text = "";
                _lstCircs.Clear();
                lstBoxCircs.Items.Clear();
                pteBoxCircProc.Image = null;
                cboxOrdenar.Text = "";
            }
        }

        private void ActualizaInterfaz(int radio, int xCentro, int yCentro, int xIzquierda, int y)
        {
            if (xCentro != 0 && yCentro != 0)
            {
                lblAdvertencia.Text = "X izquierda: " + xIzquierda + "\nY superior: " + y;
                Graphics g = Graphics.FromImage(_circuloProcesado);
                g.Clear(Color.White);
                g.FillEllipse(Brushes.Black, _circuloProcesado.Width / 4, _circuloProcesado.Height / 4, radio * 2, radio * 2);
                pteBoxCircProc.Image = _circuloProcesado;
                Circulo c = new Circulo("C" + radio + new Random().Next(4, 1532), radio, new Point(xCentro, yCentro));
                lstBoxCircs.Items.Add(c);
                _lstCircs.Add(c);
                g = Graphics.FromImage(_bitImagen);
                g.FillEllipse(Brushes.White, xIzquierda - 2, y - 2, (radio + 3) * 2, (radio + 3) * 2);
                this.Refresh();
            }
        }

        private (int, int, int) EncuentraCentro(int x, int ySuperior)
        {
            int yInferior = ySuperior, yCentro, xDerecha, xIzquierda, xCentro;
            Color colorPixel = _bitImagen.GetPixel(x, yInferior + 1);
            while (colorPixel.R + colorPixel.G + colorPixel.B != 765)
            { 
                yInferior++; 
                colorPixel = _bitImagen.GetPixel(x, yInferior + 1);
            }
            yCentro = (yInferior + ySuperior) / 2;
            xDerecha = x;
            colorPixel = _bitImagen.GetPixel(xDerecha + 1, yCentro);
            while (colorPixel.R + colorPixel.G + colorPixel.B != 765) 
            { 
                xDerecha++; 
                colorPixel = _bitImagen.GetPixel(xDerecha + 1, yCentro);
            }
            xIzquierda = x;
            colorPixel = _bitImagen.GetPixel(xIzquierda - 1, yCentro);
            while (colorPixel.R + colorPixel.G + colorPixel.B != 765) 
            { 
                xIzquierda--; 
                colorPixel = _bitImagen.GetPixel(xIzquierda - 1, yCentro);
            }
            xCentro = (xDerecha + xIzquierda) / 2;
            return (xCentro, yCentro, xIzquierda);
        }

        private (int, int, int, int, int) BuscaCirculo()
        {
            int x, y, xCentro = 0, yCentro = 0, xIzquierda = 0, radio = 0;
            for (y = 0; y < _bitImagen.Height; y++)
            {
                for (x = 0; x < _bitImagen.Width; x++)
                {
                    Color colorPixel = _bitImagen.GetPixel(x, y);
                    if (colorPixel.R + colorPixel.G + colorPixel.B == 0)
                    {
                        (xCentro, yCentro, xIzquierda) = EncuentraCentro(x, y);
                        radio = yCentro - y;
                        return (radio, xCentro, yCentro, xIzquierda, y);
                    }
                }
            }
            return (radio, xCentro, yCentro, xIzquierda, y);
        }

        private void btnProcesarImagen_Click(object sender, EventArgs e)
        {
            if (_bitImagen != null)
            {
                var info = (-1, -1, -1, -1, -1);
                int numCircs = 0;
                while (info.Item2 != 0 && info.Item3 != 0)
                {
                    info = BuscaCirculo();
                    ActualizaInterfaz(info.Item1, info.Item2, info.Item3, info.Item4, info.Item5);
                    numCircs++;
                } 
                lblAdvertencia.Text = "Mapa de bits procesado\nSe procesaron " + (numCircs - 1) + " circulos\n\nClic sobre la lista para ver las propiedades\ndel circulo en cuestion";
            }
            else
            {
                lblAdvertencia.Text = "Selecciona una imagen para procesar";
            }
        }

        private void cboxOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBoxCircs.Items.Clear();
            switch (cboxOrdenar.SelectedIndex)
            {
                case 0:
                    _o.SelectionSort(_lstCircs);
                    break;
                case 1:
                    _o.InsertionSort(_lstCircs);
                    break;
                case 2:
                    _o.BubbleSort(_lstCircs);
                    break;
                default:
                    break;
            }
            lstBoxCircs.Items.AddRange(_lstCircs.ToArray());
        }

        private void lstBoxCircs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var d = _lstCircs[lstBoxCircs.SelectedIndex].Datos;
            Graphics g = Graphics.FromImage(_circuloProcesado);
            g.Clear(Color.White);
            g.FillEllipse(Brushes.Black, _circuloProcesado.Width / 4, _circuloProcesado.Height / 4, d.Item2 * 2, d.Item2 * 2);
            pteBoxCircProc.Image = _circuloProcesado;
            lblAdvertencia.Text = "ID: " + d.Item1 + "\nArea: " + d.Item4 + "\nDiametro: " + (d.Item2 * 2);
        }
    }

    internal class Ordena
    {
        public Ordena()
        {

        }

        private void Intercambiar(List<Circulo> circs, int indice1, int indice2)
        {
            Circulo tmp = circs[indice1];
            circs[indice1] = circs[indice2];
            circs[indice2] = tmp;
        }

        public void BubbleSort(List<Circulo> circs) 
        {
            for (int i = 0; i < circs.Count; i++)
            {
                bool ordenado = false;
                for (int j = 0; j < circs.Count - 1; j++)
                {
                    if (circs[j].Area < circs[j + 1].Area)
                    {
                        Intercambiar(circs, j, j + 1);
                        ordenado = true;
                    }
                }
                if (ordenado == false)
                {
                    break;
                }
            }
        }

        public void SelectionSort(List<Circulo> circs)
        {
            for (int i = 0; i < circs.Count; i++)
            {
                int indiceMenor = i;
                for (int j = i + 1; j < circs.Count; j++)
                {
                    if (circs[j].Centro.X < circs[indiceMenor].Centro.X)
                    {
                        indiceMenor = j;
                    }
                }
                Intercambiar(circs, i, indiceMenor);
            }
        }

        public void InsertionSort(List<Circulo> circs)
        {
            for (int i = 0; i < circs.Count; i++)
            {
                int actual = i;
                while (actual > 0 && circs[actual].Centro.Y < circs[actual - 1].Centro.Y)
                {
                    Intercambiar(circs, actual, actual - 1);
                    actual--;
                }
            }
        } 
    }

    internal class Circulo
    {
        private string _ID;
        private int _radio;
        private Point _centro;
        private readonly double _area;

        public Circulo(string ID, int radio, Point centro)
        {
            _ID = ID;
            _radio = radio;
            _centro = centro;
            _area = Math.Pow(_radio, 2) * Math.PI;
        }

        public string ID 
        { 
            get => _ID;
            set => _ID = value;
        }

        public int Radio
        {
            get => _radio;
            set => _radio = value;
        }

        public Point Centro 
        { 
            get => _centro;
            set => _centro = value;
        }

        public double Area 
        {
            get => _area;
        }

        public (string, int, Point, double) Datos 
        { 
            get => (_ID, _radio, _centro, _area); 
        }

        override public string ToString()
        {
            return "Radio: " + _radio + "   Centro: " + _centro.ToString();
        }
    }
}