using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSplitFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInputFile_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnInputFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var path = SelectPath();
            if(string.IsNullOrEmpty(path)) return;
            btnInputFile.Text = path;


        }

        private void btnOutputPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var path = SelectFolder();
            if (string.IsNullOrEmpty(path)) return;
            btnInputFile.Text = path;
        }

        // 选择文件：
        private string SelectPath()
        {
            string path = string.Empty;
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Files (*.*)|*.*"//如果需要筛选txt文件（"Files (*.txt)|*.txt"）
            };
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
            return path;
        }
        // 选择路径
        private string SelectFolder()
        {
            string path = string.Empty;
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            return path;
        }

        private void btnSplitFile_Click(object sender, EventArgs e)
        {
            var file =btnInputFile.Text;
            var splitFileFormat = btnOutputPath.Text;
            var fileInfo = new FileInfo(file);
            var name = Path.GetFileNameWithoutExtension(file);//这个就是获取文件名的
            var extensionName = fileInfo.Extension;
            splitFileFormat = Path.Combine(splitFileFormat, name + "{0}" + extensionName);
            SplitFileUtil.SplitFile(file, splitFileFormat);
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
