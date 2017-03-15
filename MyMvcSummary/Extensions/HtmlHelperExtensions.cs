using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;
using ZXing.Common;

namespace MyMvcSummary.Extensions
{
    public static class HtmlHelperExtensions
    {
       
        //@Html.GenerateRelayQrCode(http://write.blog.csdn.net/postedit)
        public static IHtmlString GenerateRelayQrCode(this  HtmlHelper helper, string qrValue, int height = 250, int width = 250, int margin = 0)
        {
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = margin
                }
            };
            using (var bitmap = barcodeWriter.Write(qrValue))
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Gif);
                var img = new TagBuilder("img");
                img.MergeAttribute("alt", "your alt tag");
                img.Attributes.Add("src", String.Format("data:image/gif;base64,{0}",
                Convert.ToBase64String(stream.ToArray())));
                return new HtmlString(img.ToString(TagRenderMode.SelfClosing));
            }
        }
    }
}