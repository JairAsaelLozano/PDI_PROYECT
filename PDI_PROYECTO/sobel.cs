using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDI_PROYECTO
{
    internal class sobel
    {
            // Método para convertir una imagen a escala de grises
            public Bitmap ToGrayscale(Bitmap imagen)
            {
                Bitmap imagenGrises = new Bitmap(imagen.Width, imagen.Height);

                for (int y = 0; y < imagen.Height; y++)
                {
                    for (int x = 0; x < imagen.Width; x++)
                    {
                        Color color = imagen.GetPixel(x, y);
                        int promedio = (color.R + color.G + color.B) / 3;
                        Color colorGrises = Color.FromArgb(promedio, promedio, promedio);
                        imagenGrises.SetPixel(x, y, colorGrises);
                    }
                }

                return imagenGrises;
            }

            // Método para aplicar el filtro de Sobel a una imagen en escala de grises
            public Bitmap ApplySobelFilter(Bitmap imagenGrises)
            {
                Bitmap imagenSobel = new Bitmap(imagenGrises.Width, imagenGrises.Height);

                int[,] sobelX = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                int[,] sobelY = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
                
                for (int y = 1; y < imagenGrises.Height - 1; y++)
                {
                    for (int x = 1; x < imagenGrises.Width - 1; x++)
                    {
                        int gx = 0;
                        int gy = 0;

                        for (int j = -1; j <= 1; j++)
                        {
                            for (int i = -1; i <= 1; i++)
                            {
                                Color color = imagenGrises.GetPixel(x + i, y + j);
                                int valorGrises = color.R;
                                gx += sobelX[i + 1, j + 1] * valorGrises;
                                gy += sobelY[i + 1, j + 1] * valorGrises;
                            }
                        }

                        int valorSobel = (int)Math.Sqrt(gx * gx + gy * gy);
                        valorSobel = Math.Min(valorSobel, 255);
                        Color colorSobel = Color.FromArgb(valorSobel, valorSobel, valorSobel);
                        imagenSobel.SetPixel(x, y, colorSobel);
                    }
                }

                return imagenSobel;
            }
        }
    
}
