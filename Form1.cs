using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AtlasTool
{
    public partial class Form1 : Form
    {
        string filePath = null;
        AtlasFacade atlas = new AtlasFacade();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (filePath == null)
            {
                MessageBox.Show("请拖入要切割的图片");
                return;
            }
            try
            {
                //处理图片
                atlas.Process(filePath);
                //保存图片,使用默认路径
                atlas.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("图片解析错误："+ex.Message);
                return;
            }
            MessageBox.Show("图片解析成功");
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            filePath = (e.Data.GetData(DataFormats.FileDrop)as string [])[0];
            if (!atlas.Valid(filePath))
            {
                MessageBox.Show("图片格式需要png");
                return;
            }
            picBox.Load(filePath);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
           
        }

        

    }
}
