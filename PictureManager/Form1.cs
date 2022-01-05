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

namespace PictureManager
{
    public partial class Form1 : Form
    {

        private string _savePath = Path.Combine(Environment.CurrentDirectory, "filepath.txt");

        public Form1()
        {
            InitializeComponent();

            string path = "";
            if (File.Exists(_savePath))
            path = File.ReadAllText(_savePath);
            if (!string.IsNullOrWhiteSpace(path))
            {
                tbPictureFileName.Text = path;
                pbMainPicture.Image = Bitmap.FromFile(path);
                btnClear.Visible = true;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg; *.bmp; *.jpeg; *.png)| *.jpg; *.bmp; *.jpeg; *.png";
            if (DialogResult.OK == ofd.ShowDialog())
            {
                tbPictureFileName.Text = ofd.FileName;
                pbMainPicture.Image = Bitmap.FromFile(ofd.FileName);
                btnClear.Visible = true;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (pbMainPicture.Image != null)
            {
                pbMainPicture.Image = null;
                tbPictureFileName.Text = null;
                btnClear.Visible = false;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            File.WriteAllText(_savePath, tbPictureFileName.Text);
        }

   
    }
}
