using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PDI_PROYECTO
{
    internal class Clustering
    {
        public  Bitmap KMeansClusteringSegmentation(Bitmap image, int clusters)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            byte[] result = new byte[bytes];
            int[] means = new int[clusters];
            Random rnd = new Random();

            for (int i = 0; i < clusters; i++)
            {
                int init_mean = rnd.Next(1, 255);
                while (means.Contains((byte)init_mean))
                {
                    init_mean = rnd.Next(1, 255);
                }
                means[i] = (byte)init_mean;
            }

            double error = new double();
            List<byte>[] samples = new List<byte>[clusters];

            while (true)
            {
                for (int i = 0; i < clusters; i++)
                {
                    samples[i] = new List<byte>();
                }

                for (int i = 0; i < bytes; i += 3)
                {
                    double norm = 999;
                    int cluster = 0;

                    for (int j = 0; j < clusters; j++)
                    {
                        double temp = Math.Abs(buffer[i] - means[j]);
                        if (norm > temp)
                        {
                            norm = temp;
                            cluster = j;
                        }
                    }
                    samples[cluster].Add(buffer[i]);

                    for (int c = 0; c < 3; c++)
                    {
                        result[i + c] = (byte)means[cluster];
                    }
                }

                int[] new_means = new int[clusters];

                for (int i = 0; i < clusters; i++)
                {
                    for (int j = 0; j < samples[i].Count(); j++)
                    {
                        new_means[i] += samples[i][j];
                    }

                    new_means[i] /= (samples[i].Count() + 1);
                }

                int new_error = 0;

                for (int i = 0; i < clusters; i++)
                {
                    new_error += Math.Abs(means[i] - new_means[i]);
                    means[i] = new_means[i];
                }

                if (error == new_error)
                {
                    break;
                }
                else
                {
                    error = new_error;
                }
            }

            Bitmap res_img = new Bitmap(w, h);
            BitmapData res_data = res_img.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            Marshal.Copy(result, 0, res_data.Scan0, bytes);
            res_img.UnlockBits(res_data);

            return res_img;
        }
    }
}
