﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

/// <summary>
/// ImageOption 的摘要说明
/// </summary>
public class ImageOperation
{
      /// <summary>
    /// 圆角生成（但是只能是一个角）
    /// </summary>
    /// <param name="image">源图片 Image</param>
    /// <param name="roundCorner">圆角位置</param>
    /// <returns>处理好的Image</returns>
    public static Bitmap CreateRoundedCorner(Bitmap image, RoundRectanglePosition roundCorner)
    {
        Graphics g = Graphics.FromImage(image);
        //保证图片质量
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.CompositingQuality = CompositingQuality.HighQuality;
        Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
        //构建圆角外部路径
        GraphicsPath rectPath = CreateRoundRectanglePath(rect, image.Width / 10, roundCorner); 
        //圆角背景用白色填充
        Brush b = new SolidBrush(Color.White);
        g.DrawPath(new Pen(b), rectPath);
        g.FillPath(b, rectPath);
        g.Dispose();
        return image;
    }
    /// <summary>
    /// 目标图片的圆角位置
    /// </summary>
    public enum RoundRectanglePosition
    {
        /// <summary>
        /// 左上角
        /// </summary>
        TopLeft,
        /// <summary>
        /// 右上角
        /// </summary>
        TopRight,
        /// <summary>
        /// 左下角
        /// </summary>
        BottomLeft,
        /// <summary>
        /// 右下角
        /// </summary>
        BottomRight
    }
    /// <summary>
    /// 构建GraphicsPath路径
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="radius"></param>
    /// <param name="rrPosition">图片圆角位置</param>
    /// <returns>返回GraphicPath</returns>
    private static GraphicsPath CreateRoundRectanglePath(Rectangle rect, int radius, RoundRectanglePosition rrPosition)
    {
        GraphicsPath rectPath = new GraphicsPath();
        switch (rrPosition)
        {
            case RoundRectanglePosition.TopLeft:
                {
                    rectPath.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90);
                    rectPath.AddLine(rect.Left, rect.Top, rect.Left, rect.Top + radius);
                    break;
                }
            case RoundRectanglePosition.TopRight:
                {
                    rectPath.AddArc(rect.Right - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
                    rectPath.AddLine(rect.Right, rect.Top, rect.Right - radius, rect.Top);
                    break;
                }
            case RoundRectanglePosition.BottomLeft:
                {
                    rectPath.AddArc(rect.Left, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
                    rectPath.AddLine(rect.Left, rect.Bottom - radius, rect.Left, rect.Bottom);
                    break;
                }
            case RoundRectanglePosition.BottomRight:
                {
                    rectPath.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
                    rectPath.AddLine(rect.Right - radius, rect.Bottom, rect.Right, rect.Bottom);
                    break;
                }
        }
        return rectPath;
    }


    /// <summary>
    /// 图片缩放
    /// </summary>
    /// <param name="b">源图片Bitmap</param>
    /// <param name="dstWidth">目标宽度</param>
    /// <param name="dstHeight">目标高度</param>
    /// <returns>处理完成的图片 Bitmap</returns>
    public static Bitmap ResizeBitmap(Bitmap b, int dstWidth, int dstHeight)
    {
        Bitmap dstImage = new Bitmap(dstWidth, dstHeight);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dstImage);
        //   设置插值模式 
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
        //   设置平滑模式 
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //用Graphic的DrawImage方法通过设置大小绘制新的图片实现缩放
        g.DrawImage(b, new Rectangle(0, 0, dstImage.Width, dstImage.Height), new Rectangle(0, 0, b.Width, b.Height),GraphicsUnit.Pixel);
        g.Save();
        g.Dispose();
        return dstImage;
    }
}
