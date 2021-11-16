using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Studio4
{

    static class GlobalData
    {
        public static bool SetDarkMode { get; set; }

        public static bool SetTips { get; set; }
        public static int SetTestInt { get; set; }

        // all uploaded images are stored in this list
       // public static List<UploadedImage> UploadedImages { get; set; }

        public static string username { get; set; }


        public static Account settingsPage { get; set; }

        public static Account uploadPage { get; set; }

        public static bool toRemove { get; set; }

        public static bool dark_mode { get; set; }

        // all uploaded images are stored in this list
        public static List<UploadedImage> UploadedImages { get; set; } = new List<UploadedImage>();
        
        //For testing photos//
        //public static List<UploadedImage> UploadedImages { get; set; } = new List<UploadedImage> {  new UploadedImage("Photo 1", "pack://application:,,,/Resources/sampleimage1.jpg", "hehe", 30)
        //};

        public static List<Album> albums { get; set; } = new List<Album>();

        public static List<InvoiceItem> InvoiceList { get; set; } = new List<InvoiceItem>();

        public static int ctr = 0;
        // array that remembers created pages.

        public static bool change_bool = false;
    }
}
