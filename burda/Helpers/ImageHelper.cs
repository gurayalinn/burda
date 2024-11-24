using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burda.Helpers
{
    internal class ImageHelper
    {

        public static string GetImagePath(string imageName)
        {
            return $@"..\..\Images\{imageName}";
        }

        public static bool IsImageExist(string imageName)
        {
            return System.IO.File.Exists(GetImagePath(imageName));
        }

        public static string GetDefaultImage()
        {
            return GetImagePath("default.png");
        }

        public static string GetDefaultUserImage()
        {
            return GetImagePath("user.png");
        }

        public static Image GetImage(string imageName)
        {
            if (IsImageExist(imageName))
            {
                return Image.FromFile(GetImagePath(imageName));
            }
            else
            {
                return Image.FromFile(GetDefaultImage());
            }
        }

    }





}
