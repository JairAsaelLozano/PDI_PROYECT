using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ObjectiveC;
using System.Windows.Forms;
using System;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace PDI_PROYECTO
{
    public partial class Form1 : Form
    {
        public string Path = @"E:\Escuela_Jair\PDI_PROYECT\PDI_PROYECTO\Fotos";
        private bool HayDispositivos;
        private FilterInfoCollection MisDispositivos;
        private VideoCaptureDevice miWEbCam;
        sobel sobel = new sobel();
        Clustering cluster = new Clustering();
        Boundary bound = new Boundary();
        Smooth smooth = new Smooth();
        Sal_pimienta SalPimienta = new Sal_pimienta();
        Ruido_Gaussiano gasnoise = new Ruido_Gaussiano();
        Bitmap StaticImage;
        public Form1()
        {
            InitializeComponent();
            CargaDispositivos();
            comboBox2.Items.Add("Normal");
            comboBox2.Items.Add("Sobel");
            comboBox2.Items.Add("Clustering");
            comboBox2.Items.Add("Boundary");
            comboBox2.Items.Add("Smooth");
            comboBox2.Items.Add("Sal & Pimienta");
            comboBox2.Items.Add("Ruido Gaussiano");
            comboBox2.SelectedIndex = 0;
        }

        public void CargaDispositivos()
        {
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MisDispositivos.Count > 0)
            {
                HayDispositivos = true;
                for (int i = 0; i < MisDispositivos.Count; i++)
                {
                    comboBox1.Items.Add(MisDispositivos[i].Name.ToString());

                }
                comboBox1.Text = MisDispositivos[0].ToString();
            }
            else
            {
                HayDispositivos = false;
            }
        }

        private void CapturandoSobel(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            Bitmap imagenGrises = sobel.ToGrayscale(Imagen);
            Bitmap imagenSobel = sobel.ApplySobelFilter(imagenGrises);
            pictureBox3.Image = imagenSobel;
        }

        private void CapturandoNormal(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBox3.Image = Imagen;
        }

        private void CapturandoClustering(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();

            pictureBox3.Image = cluster.KMeansClusteringSegmentation(Imagen, 2);
        }

        private void CapturandoBoundary(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();

            pictureBox3.Image = bound.BoundaryExtraction(Imagen, 10);

        }

        private void CapturandoSmooth(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();

            pictureBox3.Image = smooth.ImageSharpen(Imagen);
        }

        private void CapturandoSalyPimienta(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();

            pictureBox3.Image = SalPimienta.ImpulseNoise(Imagen);
        }

        private void CapturandoGassNoise(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();

            pictureBox3.Image = gasnoise.GaussianNoise(Imagen);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void CerrarwebCam()
        {
            if (miWEbCam != null && miWEbCam.IsRunning)
            {
                miWEbCam.SignalToStop();
                miWEbCam = null;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarwebCam();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CerrarwebCam();
            int i = comboBox1.SelectedIndex;
            int a = comboBox2.SelectedIndex;

            string NombreVideo = MisDispositivos[i].MonikerString;
            miWEbCam = new VideoCaptureDevice(NombreVideo);
            if (Fotoradio.Checked)
            {
                if (a == 0)
                {
                    miWEbCam.NewFrame += new NewFrameEventHandler(CapturandoNormal);
                }
                if (a == 1)
                {
                    miWEbCam.NewFrame += new NewFrameEventHandler(CapturandoSobel);
                }
                if (a == 2)
                {
                    miWEbCam.NewFrame += new NewFrameEventHandler(CapturandoClustering);
                }
                if (a == 3)
                {
                    miWEbCam.NewFrame += new NewFrameEventHandler(CapturandoBoundary);
                }
                if (a == 4)
                {
                    miWEbCam.NewFrame += new NewFrameEventHandler(CapturandoSmooth);
                }
                if (a == 5)
                {
                    miWEbCam.NewFrame += new NewFrameEventHandler(CapturandoSalyPimienta);
                }
                if (a == 6)
                {
                    miWEbCam.NewFrame += new NewFrameEventHandler(CapturandoGassNoise);
                }
            }
            if (imagenradio.Checked)
            {
                if (a == 0)
                {
                    pictureBox3.Image = StaticImage;
                }
                if (a == 1)
                {

                    Bitmap imagenGrises = sobel.ToGrayscale(StaticImage);
                    Bitmap imagenSobel = sobel.ApplySobelFilter(imagenGrises);
                    pictureBox3.Image = imagenSobel;
                }
                if (a == 2)
                {
                    pictureBox3.Image = cluster.KMeansClusteringSegmentation(StaticImage, 2);
                }
                if (a == 3)
                {

                    pictureBox3.Image = bound.BoundaryExtraction(StaticImage, 10);
                }
                if (a == 4)
                {
                    pictureBox3.Image = smooth.ImageSharpen(StaticImage);
                }
                if (a == 5)
                {
                    pictureBox3.Image = SalPimienta.ImpulseNoise(StaticImage);
                }
                if (a == 6)
                {
                    pictureBox3.Image = gasnoise.GaussianNoise(StaticImage);
                }
            }
            miWEbCam.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (miWEbCam != null && miWEbCam.IsRunning)
            {
                pictureBox2.Image = pictureBox3.Image;
                pictureBox2.Image.Save(Path + "prueba.jpg", ImageFormat.Jpeg);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            // Crea un objeto OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Establece las propiedades del cuadro de di�logo de archivo
            openFileDialog.Title = "Seleccionar imagen";
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif";

            // Muestra el cuadro de di�logo de archivo y verifica si se seleccion� un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtiene la ruta del archivo seleccionado
                string filePath = openFileDialog.FileName;

                // Carga la imagen en el PictureBox
                StaticImage = (Bitmap)System.Drawing.Image.FromFile(filePath);
                pictureBox3.Image = System.Drawing.Image.FromFile(filePath);
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[,] histograma = new int[3, 256];
            Bitmap imagen = new Bitmap(pictureBox3.Image);
            // Recorrer cada p�xel de la imagen y aumentar el recuento correspondiente
            for (int x = 0; x < imagen.Width; x++)
            {
                for (int y = 0; y < imagen.Height; y++)
                {
                    Color pixel = imagen.GetPixel(x, y);
                    histograma[0, pixel.R]++;
                    histograma[1, pixel.G]++;
                    histograma[2, pixel.B]++;
                }
            }

            // Crear un Bitmap para mostrar el histograma
            Bitmap histogramaBitmap = new Bitmap(256, 100);
            Graphics g = Graphics.FromImage(histogramaBitmap);
            Pen penRojo = new Pen(Color.Red);
            Pen penVerde = new Pen(Color.Green);
            Pen penAzul = new Pen(Color.Blue);

            // Dibujar el histograma
            for (int i = 0; i < 256; i++)
            {
                g.DrawLine(penRojo, i, 100, i, 100 - histograma[0, i]);
                g.DrawLine(penVerde, i, 100, i, 100 - histograma[1, i]);
                g.DrawLine(penAzul, i, 100, i, 100 - histograma[2, i]);
            }

            // Mostrar el histograma en el PictureBox
            Histograma.Image = histogramaBitmap;
        }
    }
}