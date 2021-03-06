﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolCode
{
    public class ImageUtility
    {
        /// <summary>
        /// 利用一个字符串制作BitMap
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fontSize"></param>
        /// <param name="fontName"></param>
        /// <param name="useBreush"></param>
        /// <returns></returns>
        public static Bitmap StringToBitMap(string input, int fontSize = 25, string fontName = null, Brush useBreush = null)
        {
            if (string.IsNullOrWhiteSpace(fontName))
            {
                InstalledFontCollection useInstalledFontCollection = new InstalledFontCollection();
                var FontFamilies = useInstalledFontCollection.Families;
                fontName = FontFamilies[0].Name;
            }


            Font useFont = new Font(fontName, fontSize);

            Bitmap useBitMap = new Bitmap(1, 1);

            var useGraphic = Graphics.FromImage(useBitMap);

            int useWidth = (int)useGraphic.MeasureString(input, useFont).Width;

            int useHight = (int)useGraphic.MeasureString(input, useFont).Height;

            useBitMap = new Bitmap(useBitMap, new Size(useWidth, useHight));

            useGraphic = Graphics.FromImage(useBitMap);

            useGraphic.Clear(Color.White);
            useGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            useGraphic.TextRenderingHint = TextRenderingHint.AntiAlias;

            if (null == useBreush)
            {
                useBreush = Brushes.Black;
            }

            useGraphic.DrawString(input, useFont, useBreush, new PointF(0.0f, 0.0f));

            useGraphic.Flush();

            useGraphic.Dispose();

            return useBitMap;
        }

        /// <summary>
        /// 调整透明度
        /// </summary>
        /// <param name="inputImage"></param>
        /// <param name="useAlapha"></param>
        /// <returns></returns>
        public static Bitmap AdjustImageAlapha(Bitmap inputImage, int useAlapha = 100)
        {

            Bitmap useImage = new Bitmap(inputImage.Width, inputImage.Height, PixelFormat.Format32bppArgb);
            for (int h = 0; h < inputImage.Height; h++)
            {
                for (int w = 0; w < inputImage.Width; w++)
                {
                    Color c = inputImage.GetPixel(w, h);
                    useImage.SetPixel(w, h, Color.FromArgb(useAlapha, c.R, c.G, c.B));
                }
            }

            return useImage;

        }
    }
}
