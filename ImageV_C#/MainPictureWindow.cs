using System;
using System.Windows.Forms;

namespace ImageV_C_
{
    public partial class MainPictureWindow : Form
    {
        private string[] _imageFiles;

        public MainPictureWindow(string[] imageFiles)
        {
            InitializeComponent();
            _imageFiles = imageFiles;
            // �K�v�ɉ����ĉ摜�\�������������ɒǉ�
        }

        /// <summary>
        /// Windows �t�H�[�� �f�U�C�i �T�|�[�g�p�̃��\�b�h
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainPictureWindow
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "MainPictureWindow";
            this.Text = "MainPictureWindow";
            this.ResumeLayout(false);
        }
    }
}
