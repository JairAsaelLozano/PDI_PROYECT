using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PDI_PROYECTO
{
    internal class Boundary
    {
        public  Bitmap BoundaryExtraction( Bitmap image, int se_dim)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            int o = (se_dim - 1) / 2;
            for (int i = o; i < w - o; i++)
            {
                for (int j = o; j < h - o; j++)
                {
                    int position = i * 3 + j * image_data.Stride;
                    byte val = 255;
                    for (int x = -o; x <= o; x++)
                    {
                        for (int y = -o; y <= o; y++)
                        {
                            int kposition = position + x * 3 + y * image_data.Stride;
                            val = Math.Min(val, buffer[kposition]);
                        }
                    }
                    for (int c = 0; c < 3; c++)
                    {
                        result[position + c] = val;
                    }
                }
            }

            for (int i = 0; i < bytes; i++)
            {
                result[i] = (byte)(buffer[i] - result[i]);
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
