using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasTool
{
    /// <summary>
    /// 从配置文件中解析出每张spriteinfo的信息
    /// </summary>
    class Parser
    {
        public SpriteInfo[] SpriteInfos { get; private set; }
        public void Parse(string configContex,int width,int height)
        {
            List<SpriteInfo> list = new List<SpriteInfo>();
            string[] lineContexts= configContex.Split(new char[]{'\n'},StringSplitOptions.RemoveEmptyEntries);//以换行符分割配置信息
            foreach (string line in lineContexts)
            {   //brand_copyright 126 14 0.86328125 0.17773438 0.123046875 0.013671875
                //   name        width height  x      y 
                string[] args = line.Split(' ');
                SpriteInfo info = new SpriteInfo(
                    args[0],
                    (int)(Convert.ToSingle(args[3])*width),
                    (int)(Convert.ToSingle(args[4])*height),
                    Convert.ToInt32(args[1]),
                    Convert.ToInt32(args[2])
                    );
                list.Add(info);
            }
            SpriteInfos = list.ToArray();
        }
    }
}