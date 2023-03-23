using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Runtime.InteropServices.ObjectiveC;

namespace PDI_PROYECTO
{
    public partial class Form1 : Form
    {
        public string Path = @"E:\Escuela_Jair\PDI_PROYECT\PDI_PROYECTO\Fotos";
        private bool HayDispositivos;
        private FilterInfoCollection MisDispositivos;
        private VideoCaptureDevice miWEbCam;
        public Form1()
        {
            CargaDispositivos();
            InitializeComponent();
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
                    comboBox1.Text = MisDispositivos[0].Name.ToString();
                }
            }
            else
            {
                HayDispositivos = false;
            }
        }

        private void Capturando(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = Imagen;
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

        private void pictureBox1_Click(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            CerrarwebCam();
            int i = comboBox1.SelectedIndex;
            string NombreVideo = MisDispositivos[i].MonikerString;
            miWEbCam = new VideoCaptureDevice(NombreVideo);
            miWEbCam.NewFrame += new NewFrameEventHandler(Capturando);
            miWEbCam.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarwebCam();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(miWEbCam!= null && miWEbCam.IsRunning)
            {
                pictureBox2.Image = pictureBox1.Image;
                pictureBox2.Image.Save(Path + "prueba.jpg", ImageFormat.Jpeg);
            }
        }
    }
}