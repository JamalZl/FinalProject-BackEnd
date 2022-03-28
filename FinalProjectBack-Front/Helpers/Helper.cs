using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBack_Front.Helpers
{
    public class Helper
    {
        public static void  DeleteImg(string root,string folder,string imgName)
        {
            string fullPath = Path.Combine(root, folder, imgName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

        }
    }
}
