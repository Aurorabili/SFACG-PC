using PropertyChanged;
using SFACGPC.Core;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SFACGPC.Data.ViewModel {
    [AddINotifyPropertyChangedInterface]
    public class BookContentViewModel {

        public static async Task<Paragraph> LoadData(int ChapID) {
            string src = await SFClient.Instance.GetChapContent(ChapID);
            src = Regex.Replace("\r\n" + src, @"\r\n\s*", "\r\n    ");
            Paragraph paragraph = new Paragraph();

            Match match = Regex.Match(src, @"\[img=\S*\].*?\[\/img\]");
            while (match.Success) {

                string imgurl = Regex.Match(match.Value, @"(?<=\[img=\S*\]).*?(?=\[\/img\])").Value;
                src = src.Remove(match.Index, match.Value.Length);
                string str = src.Substring(0, src.Length - match.Index);
                src = src.Remove(0, src.Length - match.Index);
                Run r = new Run(str);
                paragraph.Inlines.Add(r);
                InlineUIContainer inlineUI = new InlineUIContainer(get_image(imgurl));
                paragraph.Inlines.Add(inlineUI);
                match = Regex.Match(src, @"\[img=\S*\].*?\[\/img\]");
            }
            Run rd = new Run(src);
            paragraph.Inlines.Add(rd);
            paragraph.LineHeight = 30;
            return paragraph;
        }
        public BookContentViewModel() {
        }

        public static Image get_image(string url) {
            var image = new Image();
            try {
                System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
                System.Net.WebResponse webres = webreq.GetResponse();
                System.IO.Stream stream = webres.GetResponseStream();
                System.Drawing.Image img1 = System.Drawing.Image.FromStream(stream);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img1);
                IntPtr hBitmap = bmp.GetHbitmap();
                System.Windows.Media.ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                image.Source = WpfBitmap;
                image.Stretch = Stretch.Uniform;
                stream.Dispose();
            } catch (Exception e) {
                return null;
            }
            return image;
        }
    }
}
