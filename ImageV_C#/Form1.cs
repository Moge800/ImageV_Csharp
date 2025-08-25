namespace ImageV_C_
{
    public partial class Form1 : Form
    {
        private List<Image> images = new List<Image>(); // グローバルに変更

        public Form1()
        {
            InitializeComponent();
            // MainPictureWindowの初期設定
            MainPictureWindow.SizeMode = PictureBoxSizeMode.Zoom;
            MainPictureWindow.BorderStyle = BorderStyle.Fixed3D;
            MainPictureWindow.BackColor = Color.LightGray;
            MainPictureWindow.Dock = DockStyle.Fill;
            MainPictureWindow.Image = null; // 初期状態では画像を表示しない
        }

        private void SetDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = fbd.SelectedPath;
                    string[] imageFiles = Directory.GetFiles(selectedPath, "*.*")
                        .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                       file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                    if (imageFiles.Length > 0)
                    {
                        // 既存の画像リソースを解放
                        foreach (var img in images)
                        {
                            img.Dispose();
                        }
                        images.Clear();

                        // 必要な画像だけを読み込む
                        foreach (string file in imageFiles.Take(100)) // 最大100枚まで
                        {
                            using (var tempImage = Image.FromFile(file))
                            {
                                images.Add(new Bitmap(tempImage)); // Bitmapに変換してリソースを解放
                            }
                        }

                        // 最初の画像を表示
                        MainPictureWindow.Image = images[0];
                    }
                    else
                    {
                        MessageBox.Show("選択されたフォルダに画像ファイルが含まれていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RightImage_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                // 現在表示されている画像のインデックスを取得
                int currentIndex = images.IndexOf(MainPictureWindow.Image);
                // 次の画像のインデックスを計算
                int nextIndex = (currentIndex + 1) % images.Count;
                // 次の画像を表示
                MainPictureWindow.Image = images[nextIndex];
            }
        }

        private void LeftImage_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                // 現在表示されている画像のインデックスを取得
                int currentIndex = images.IndexOf(MainPictureWindow.Image);
                // 前の画像のインデックスを計算
                int prevIndex = (currentIndex - 1 + images.Count) % images.Count;
                // 前の画像を表示
                MainPictureWindow.Image = images[prevIndex];
            }
        }
    }
}
