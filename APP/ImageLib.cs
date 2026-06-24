using System.Drawing;
using System.Drawing.Imaging;

namespace APP;

public class ImageLib
{
    public byte[] ComperessTifArrayFromBitmap(Bitmap myBitmap)
    {
        //if (Width > 0 && Height > 0)
        //{
        //    myBitmap = ResizeBitmap(myBitmap, Width, Height);
        //}

        var jgpEncoder = GetEncoder(ImageFormat.Jpeg);

        // Create an Encoder object based on the GUID
        // for the Quality parameter category.
        var myEncoder =
            Encoder.Quality;

        // Create an EncoderParameters object.
        // An EncoderParameters object has an array of EncoderParameter
        // objects. In this case, there is only one
        // EncoderParameter object in the array.
        var myEncoderParameters = new EncoderParameters(1);

        var myEncoderParameter = new EncoderParameter(myEncoder, 70L);
        myEncoderParameters.Param[0] = myEncoderParameter;


        var myStream = new MemoryStream();
        myBitmap.Save(myStream, jgpEncoder, myEncoderParameters);


        myBitmap.Dispose();
        myBitmap = null;

        return myStream.ToArray();
    }

    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        var codecs = ImageCodecInfo.GetImageDecoders();
        foreach (var codec in codecs)
            if (codec.FormatID == format.Guid)
                return codec;

        return null;
    }


    public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
    {
        var result = new Bitmap(width, height);
        using (var g = Graphics.FromImage(result))
        {
            g.DrawImage(bmp, 0, 0, width, height);
        }

        return result;
    }

    public byte[] StreamToBytes(Stream input)
    {
        var buffer = new byte[16 * 1024];
        using (var ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0) ms.Write(buffer, 0, read);
            return ms.ToArray();
        }
    }

    //private byte[] ResizeImageByteArray(byte[] data)
    //{
    //    var image = Image.FromStream(ms);
    //    image = EditEXIF(image);
    //    var myBitmap = (Bitmap)image;

    //    int standardW = 824, standardH = 1170;
    //    //int standardW = 842, standardH = 595;
    //    //int standardW = 595, standardH = 842;
    //    int w = 0, h = 0;

    //    var wi = image.Width;
    //    var hi = image.Height;

    //    //Landscape
    //    if (image.Width > image.Height && image.Width > standardW)
    //    {
    //        var percent = image.Width / (float)standardW;
    //        h = (int)(image.Height / percent);

    //        w = standardW;
    //        myBitmap = new Bitmap(myBitmap, w, h);
    //        // myBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
    //    }

    //    if (image.Height > image.Width && image.Height > standardH)
    //    {
    //        var percent = image.Height / (float)standardH;
    //        w = (int)(image.Width / percent);

    //        h = standardH;

    //        myBitmap = new Bitmap(myBitmap, w, h);
    //    }

    //    if (image.Width == image.Height && image.Width > standardW)
    //    {
    //        var percent = image.Width / (float)standardW;
    //        h = (int)(image.Height / percent);

    //        w = standardW;
    //        myBitmap = new Bitmap(myBitmap, w, h);
    //    }

    //    return _imgLib.ComperessTifArrayFromBitmap(myBitmap);
    //}

    //private byte[] ResizeImageThumbnailByteArray(byte[] data)
    //{
    //    var image = Image.FromStream(ms);
    //    image = EditEXIF(image);
    //    var myBitmap = (Bitmap)image;

    //    int standardW = 165, standardH = 117;
    //    int w = 0, h = 0;

    //    //Landscape
    //    if (image.Width > image.Height && image.Width > standardW)
    //    {
    //        var percent = image.Width / (float)standardW;
    //        h = (int)(image.Height / percent);

    //        w = standardW;
    //        myBitmap = _imgLib.ResizeBitmap(myBitmap, w, h);
    //        // myBitmap.RotateFlip(RotateFlipType.Rotate90FlipY);
    //    }
    //    else
    //    {
    //        var percent = image.Height / (float)standardH;
    //        w = (int)(image.Width / percent);

    //        h = standardH;
    //        myBitmap = _imgLib.ResizeBitmap(myBitmap, w, h);
    //    }

    //    return _imgLib.ComperessTifArrayFromBitmap(myBitmap);
    //}

    //protected Image EditEXIF(Image img)
    //{
    //    if (Array.IndexOf(img.PropertyIdList, 274) > -1)
    //    {
    //        var orientation = (int)img.GetPropertyItem(274).Value[0];
    //        switch (orientation)
    //        {
    //            case 1:
    //                // No rotation required.
    //                break;
    //            case 2:
    //                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
    //                break;
    //            case 3:
    //                img.RotateFlip(RotateFlipType.Rotate180FlipNone);
    //                break;
    //            case 4:
    //                img.RotateFlip(RotateFlipType.Rotate180FlipX);
    //                break;
    //            case 5:
    //                img.RotateFlip(RotateFlipType.Rotate90FlipX);
    //                break;
    //            case 6:
    //                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
    //                break;
    //            case 7:
    //                img.RotateFlip(RotateFlipType.Rotate270FlipX);
    //                break;
    //            case 8:
    //                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
    //                break;
    //        }

    //        // This EXIF data is now invalid and should be removed.
    //        img.RemovePropertyItem(274);
    //    }

    //    return img;
    //}
}