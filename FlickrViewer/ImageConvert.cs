using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Encoder = System.Drawing.Imaging.Encoder;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #5 - Parallel Programming
/// ** Date (MM/dd/yyy) : 04/07/2020
/// ** Source           : https://www.andrewhoefling.com/Blog/Post/basic-image-manipulation-in-c-sharp
/// ** Revised by       : Harbin Ramo
/// <summary>
namespace FlickrViewer
{
    public class ImageConvert
    {
        // ** Image Conversion
        public byte[] AsImageFormatType(byte[] _imageData, ImageFormat _imageFormat)
        {
            using (MemoryStream _in = new MemoryStream(_imageData))
            using (MemoryStream _out = new MemoryStream())
            {
                var _imageStream = Image.FromStream(_in);
                _imageStream.Save(_out, _imageFormat);
                return _out.ToArray();
            }
        }

        // ** Image Resizing
        public byte[] Resize(byte[] _imageData, int _imageWidth, ImageFormat _imageFormat)
        {
            using (MemoryStream _memoryStream = new MemoryStream(_imageData))
            {
                var _imageObject = Image.FromStream(_memoryStream);

                int _image_Width = _imageObject.Width;
                int _image_Height = _imageWidth * _imageObject.Height;
                int _image_NewSize = (_image_Height) / _image_Width;

                var _newThumbnail = _imageObject.GetThumbnailImage(
                    _imageWidth, _image_NewSize, null, IntPtr.Zero);

                using (MemoryStream _myThumbnailStream = new MemoryStream())
                {
                    _newThumbnail.Save(_myThumbnailStream, _imageFormat);
                    return _myThumbnailStream.ToArray();
                }
            }
        }

        // ** Image Compress
        private ImageCodecInfo GetEncoder(ImageFormat _imageFormat)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
            {
                if (codec.FormatID == _imageFormat.Guid)
                {
                    return codec;
                }
            }

            return null;
        }

        public byte[] Compress(byte[] _imageData, long _imageValue, ImageFormat _imageFormat)
        {
            var _imageEncoder = GetEncoder(_imageFormat);

            using (MemoryStream _in = new MemoryStream(_imageData))
            using (MemoryStream _out = new MemoryStream())
            {
                var _currentImage = Image.FromStream(_in);

                if (_imageEncoder == null)
                {
                    _currentImage.Save(_out, ImageFormat.Jpeg);
                }
                else
                {
                    var _encoderQuality = Encoder.Quality;
                    var _encoderParameters = new EncoderParameters(1);
                    _encoderParameters.Param[0] = new EncoderParameter(_encoderQuality, 50L);
                    _currentImage.Save(_out, _imageEncoder, _encoderParameters);
                }

                return _out.ToArray();
            }
        }
    }
}
