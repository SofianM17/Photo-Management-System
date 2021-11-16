using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Studio4
{
    public class Album
    {
        private List<UploadedImage> _albumImages = new List<UploadedImage>();
        private DateTime _dateCreated;

        public string Name { get; set; }

        // constructor, when initializing, must set an album name
        public Album(string albumName) {
            Name = albumName;
            _dateCreated = DateTime.Now;
        }

        // adding an image to the album
        public void AddImageToAlbum(UploadedImage image) { _albumImages.Add(image); }

        //removing an image from the album
        public void RemoveImageFromAlbum(UploadedImage image) { _albumImages.Remove(image); }

        // return the entire list of the albums images
        public List<UploadedImage> GetImages() { return _albumImages; }



        // get the date the album was created
        public DateTime GetCreationDate() { return _dateCreated; }
    }
}
