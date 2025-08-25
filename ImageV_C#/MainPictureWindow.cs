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
            // 必要に応じて画像表示処理をここに追加
        }

        /// <summary>
        /// Windows フォーム デザイナ サポート用のメソッド
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
