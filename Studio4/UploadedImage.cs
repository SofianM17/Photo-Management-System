using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Studio4
{
    public class UploadedImage
    {
        public string ImgName { get; set; }
        public DateTime DateCreated { get; set; }
        
        public ImageSource ImgSrcAsImageSource { get; set; }
        
        public double ImgPrice { get; set; }

        public string ImgSrc { get; set; }

        public string ImgDescription { get; set; }

        public UploadedImage() { }

        // when uploading a new image, create a new object of this class and pass the constructor params
        public UploadedImage(string name, string src, string description, double price)
        {
            ImgName = name;
            DateCreated = DateTime.Now;
            ImgSrc = src;
            ImgPrice = price;
            ImgDescription = description;
        }

    }
}
