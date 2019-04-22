using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace AtlasTool
{
    class AtlasFacade
    {
        private Loader loader;
        private Parser parser;
        private Cutter cutter;
        
        public Bitmap[] images { get; private set; }

        public AtlasFacade()
        {
            loader = new Loader();
            parser = new Parser();
            cutter = new Cutter();
        }

        //校验
        public bool Valid(string imagePath)
        {
            return imagePath.ToLower().EndsWith(".png");
        }
        //处理
        public void Process(string imagePath)
        {
            //加载
            loader.Load(imagePath);
            Bitmap sourceImage = loader.Image;//获得图片源
            string configInfo = loader.Config;//获得配置信息
            //解析
            parser.Parse(configInfo,sourceImage.Width,sourceImage.Height);
            SpriteInfo[] spriteInfos = parser.SpriteInfos;//获得每张图片的信息
            //切割
            cutter.Cut(sourceImage,spriteInfos);
            images = cutter.images;//获得所有图片的集合
        }
        //保存
        public void Save(string savePath=null)
        {
            if (savePath == null)
                savePath = loader.RootDir;
            for (int i = 0; i < images.Length; i++)
            {
                string fileName = savePath + "\\" + parser.SpriteInfos[i].Name+".png";
                images[i].Save(fileName,ImageFormat.Png);
            }
        }
    }
}
