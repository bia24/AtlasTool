using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace AtlasTool
{
    class Loader
    {
        public Bitmap Image { get; private set; }
        public string Config { get; private set; }
        public string RootDir { get; private set; }
        public void Load(string imagePath)
        {
            RootDir = Path.GetDirectoryName(imagePath);//获得文件根目录
            Image = new Bitmap(imagePath);//获得图片文件
            string configPath = RootDir +"\\"+Path.GetFileNameWithoutExtension(imagePath)+".txt";
            StreamReader sr = new StreamReader(configPath);
            Config = sr.ReadToEnd();
            sr.Close();//释放new出来的托管资源 
            sr.Dispose();//释放非托管资源
        }
        

    }
}
