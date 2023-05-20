using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PDI_PROYECTO
{
    internal class Smooth
    {
        public  Bitmap ImageSharpen( Bitmap image)
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
            for (int i = 2; i < w - 2; i++)
            {
                for (int j = 2; j < h - 2; j++)
                {
                    int p = i * 3 + j * image_data.Stride;
                    for (int k = 0; k < 3; k++)
                    {
                        double val = 0d;
                        for (int xkernel = -1; xkernel < 2; xkernel++)
                        {
                            for (int ykernel = -1; ykernel < 2; ykernel++)
                            {
                                int kernel_p = k + p + xkernel * 3 + ykernel * image_data.Stride;
                                val += buffer[kernel_p] * Kernels.Laplacian[xkernel + 1, ykernel + 1];
                            }
                        }
                        val = val > 0 ? val : 0;
                        result[p + k] = (byte)((val + buffer[p + k]) > 255 ? 255 : (val + buffer[p + k]));
                    }
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
        public static class Kernels
        {
            public static double[,] Laplacian
            {
                get
                {
                    return new double[,]
                    {
                     { 0,-1, 0 },
                     {-1, 4,-1 },
                     { 0,-1, 0 }
                    };
                }
            }
        }
    }
}
