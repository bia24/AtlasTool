using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AtlasTool
{
    class Cutter
    {
        public Bitmap[] images { get; private set; }
        public void Cut(Bitmap sourceImage,SpriteInfo[] spriteInfos)
        {
            List<Bitmap> list = new List<Bitmap>();
            foreach (var info in spriteInfos)
            {
                Bitmap smallImage = new Bitmap(info.Width,info.Height); //建一张空白小图
                Graphics g = Graphics.FromImage(smallImage);//在小图上建立一个画板
                g.DrawImage(sourceImage,
                    new Rectangle(0,0,info.Width,info.Height),
                    new Rectangle(info.X,info.Y,info.Width,info.Height),
                    GraphicsUnit.Pixel); //将原图画到小图中
                g.Dispose();
                list.Add(smallImage);
            }
            images = list.ToArray();
        }
    }
}
