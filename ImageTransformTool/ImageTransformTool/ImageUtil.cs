using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using FreeImageAPI;

namespace ImageTransformTool
{
    class ImageUtil
    {

        private static readonly IDictionary<string, ImageFormat> formatDict = new Dictionary<string, ImageFormat>()
        {
            { "bmp", ImageFormat.Bmp },{ "ico", ImageFormat.Icon },{ "jpg", ImageFormat.Jpeg },
            { "jpeg", ImageFormat.Jpeg },{ "png", ImageFormat.Png },{ "tif", ImageFormat.Tiff }
        };

        private static readonly IDictionary<string, FREE_IMAGE_FORMAT> conplexedFormatDict = new Dictionary<string, FREE_IMAGE_FORMAT>()
        {
            { "tga", FREE_IMAGE_FORMAT.FIF_TARGA }
        };

        public static bool transform(FileInfo inputFileInfo, string outputPath)
        {
            if (formatDict.ContainsKey(FileUtil.getSuffix(inputFileInfo.Name)) &&
                formatDict.ContainsKey(FileUtil.getSuffix(outputPath)))
            {
                return simpleTransform(inputFileInfo, outputPath);
            }
            return complexTransform(inputFileInfo, outputPath);
        }

        public static string[] getSupportedSuffixs()
        {
            IList<string> supportedSuffixList = new List<string>();
            foreach (string suffix in formatDict.Keys)
            {
                supportedSuffixList.Add(suffix);
            }
            foreach (string suffix in conplexedFormatDict.Keys)
            {
                supportedSuffixList.Add(suffix);
            }
            return supportedSuffixList.ToArray<string>();
        }

        private static bool simpleTransform(FileInfo inputFileInfo, string outputPath)
        {
            bool flag = false;
            if (inputFileInfo.Exists)
            {
                flag = true;
                convertToBitmap(inputFileInfo).Save(outputPath, formatDict[FileUtil.getSuffix(outputPath)]);
            }
            return flag;
        }

        private static bool complexTransform(FileInfo inputFileInfo, string outputPath)
        {
            return complexedSave(complexedLoad(inputFileInfo), outputPath);
        }

        private static Bitmap convertToBitmap(FileInfo inputFileInfo)
        {
            if (formatDict.ContainsKey(FileUtil.getSuffix(inputFileInfo.Name)))
            {
                return new Bitmap(inputFileInfo.FullName);
            }
            throw new Exception();
        }

        private static FIBITMAP complexedLoad(FileInfo inputFileInfo)
        {
            FIBITMAP fibitmap = FIBITMAP.Zero;
            FREE_IMAGE_FORMAT freeImageFormat = getComplexedFormat(FileUtil.getSuffix(inputFileInfo.Name));
            FREE_IMAGE_LOAD_FLAGS freeImageLoadFlags = FREE_IMAGE_LOAD_FLAGS.DEFAULT;
            if (FREE_IMAGE_FORMAT.FIF_UNKNOWN != freeImageFormat)
            {
                fibitmap = FreeImage.Load(freeImageFormat, inputFileInfo.FullName, freeImageLoadFlags);
            }
            return fibitmap;
        }

        private static bool complexedSave(FIBITMAP fibitmap, string outputPath)
        {
            bool flag = false;
            if (!fibitmap.IsNull)
            {
                flag = true;
                FreeImage.Save(getComplexedFormat(FileUtil.getSuffix(outputPath)), fibitmap, outputPath, FREE_IMAGE_SAVE_FLAGS.DEFAULT);
                FreeImage.Unload(fibitmap);
            }
            return flag;
        }

        private static FREE_IMAGE_FORMAT getComplexedFormat(string suffix)
        {
            FREE_IMAGE_FORMAT freeImageFormat = FREE_IMAGE_FORMAT.FIF_UNKNOWN;
            if (conplexedFormatDict.ContainsKey(suffix))
            {
                freeImageFormat = conplexedFormatDict[suffix];
            }
            else if (formatDict.ContainsKey(suffix))
            {
                freeImageFormat = FreeImage.GetFormat(formatDict[suffix]);
            }
            return freeImageFormat;
        }

    }
}
