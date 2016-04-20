/**
 * 
 * Author       - Md. Alamin Mahamud
 * Date         - 29 - Aug - 2015
 * Description  - Create Directory if doesnot Exists
 * 
 * 
 * 
 **/

using System;
using System.IO;

namespace ScreenCaptureModule
{
    class Create_Directory
    {
        string ModuleName = "MyScreenCapture";
        public string CreateDir()
        {
            string myPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar + "" + ModuleName;

            bool exists = Directory.Exists(myPath);

            if (!exists)
                Directory.CreateDirectory(myPath);

            return myPath + Path.DirectorySeparatorChar;
        }

    }
}
