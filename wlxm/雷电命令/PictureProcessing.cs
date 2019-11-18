using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuciferSrcipt
{
    /// <summary>
    /// 图片处理类
    /// </summary>
    public class PictureProcessing
    {
        #region 单例模式变量
        private static readonly object obj = new object();
        private static PictureProcessing pictureProcessing = null;
        #endregion

        private PictureProcessing()
        {

        }
        /// <summary>
        /// 单例模式====双层互锁
        /// </summary>
        /// <returns></returns>
        public static PictureProcessing GetObject()
        {
            if (pictureProcessing == null)
            {
                lock (obj)
                {
                    if (pictureProcessing == null)
                    {
                        pictureProcessing = new PictureProcessing();
                    }
                }
            }
            return pictureProcessing;
        }
        #region 从大图中截取一部分图片
        /// <summary>
        /// 从大图中截取一部分图片
        /// </summary>
        /// <param name="fromImagePath">来源图片地址</param>     
        /// <param name="toImagePath">保存图片地址</param>
        /// <param name="offsetX">从偏移X坐标位置开始截取</param>
        /// <param name="offsetY">从偏移Y坐标位置开始截取</param>
        /// <param name="width">图片的宽度</param>
        /// <param name="height">图片的高度</param>
        /// <returns></returns>
        public void CaptureImage(string fromImagePath, string toImagePath, int offsetX, int offsetY, int width, int height)
        {
            //原图片文件
            Image fromImage = Image.FromFile(fromImagePath);
            //创建新图位图
            Bitmap bitmap = new Bitmap(width, height);
            //创建作图区域
            Graphics graphic = Graphics.FromImage(bitmap);
            //截取原图相应区域写入作图区
            graphic.DrawImage(fromImage, 0, 0, new Rectangle(offsetX, offsetY, width, height), GraphicsUnit.Pixel);
            //从作图区生成新图
            Image saveImage = Image.FromHbitmap(bitmap.GetHbitmap());
            //保存图片
            saveImage.Save(toImagePath, System.Drawing.Imaging.ImageFormat.Png);
            //释放资源   
            saveImage.Dispose();
            fromImage.Dispose();
            graphic.Dispose();
            bitmap.Dispose();
        }
        #endregion
        #region 灰度转化
        /// <summary>
        /// 根据RGB，计算灰度值
        /// </summary>
        /// <param name="posClr">Color值</param>
        /// <returns>灰度值，整型</returns>
        private int GetGrayNumColor(Color posClr)
        {
            return (posClr.R * 19595 + posClr.G * 38469 + posClr.B * 7472) >> 16;
        }
        /// <summary>
        /// 灰度转换,逐点方式
        /// </summary>
        public Bitmap GrayByPixels(string path)
        {
            Bitmap bmpobj = new Bitmap(path);
            for (int i = 0; i < bmpobj.Height; i++)
            {
                for (int j = 0; j < bmpobj.Width; j++)
                {
                    int tmpValue = GetGrayNumColor(bmpobj.GetPixel(j, i));
                    bmpobj.SetPixel(j, i, Color.FromArgb(tmpValue, tmpValue, tmpValue));
                }
            }
            return bmpobj;
        }
        #endregion
    }
}
