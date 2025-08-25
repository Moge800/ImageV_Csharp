namespace ImageV_C_
{
    public partial class Form1 : Form
    {
        private List<Image> images = new List<Image>(); // �O���[�o���ɕύX

        public Form1()
        {
            InitializeComponent();
            // MainPictureWindow�̏����ݒ�
            MainPictureWindow.SizeMode = PictureBoxSizeMode.Zoom;
            MainPictureWindow.BorderStyle = BorderStyle.Fixed3D;
            MainPictureWindow.BackColor = Color.LightGray;
            MainPictureWindow.Dock = DockStyle.Fill;
            MainPictureWindow.Image = null; // ������Ԃł͉摜��\�����Ȃ�
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
                        // �����̉摜���\�[�X�����
                        foreach (var img in images)
                        {
                            img.Dispose();
                        }
                        images.Clear();

                        // �K�v�ȉ摜������ǂݍ���
                        foreach (string file in imageFiles.Take(100)) // �ő�100���܂�
                        {
                            using (var tempImage = Image.FromFile(file))
                            {
                                images.Add(new Bitmap(tempImage)); // Bitmap�ɕϊ����ă��\�[�X�����
                            }
                        }

                        // �ŏ��̉摜��\��
                        MainPictureWindow.Image = images[0];
                    }
                    else
                    {
                        MessageBox.Show("�I�����ꂽ�t�H���_�ɉ摜�t�@�C�����܂܂�Ă��܂���B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RightImage_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                // ���ݕ\������Ă���摜�̃C���f�b�N�X���擾
                int currentIndex = images.IndexOf(MainPictureWindow.Image);
                // ���̉摜�̃C���f�b�N�X���v�Z
                int nextIndex = (currentIndex + 1) % images.Count;
                // ���̉摜��\��
                MainPictureWindow.Image = images[nextIndex];
            }
        }

        private void LeftImage_Click(object sender, EventArgs e)
        {
            if (images.Count > 0)
            {
                // ���ݕ\������Ă���摜�̃C���f�b�N�X���擾
                int currentIndex = images.IndexOf(MainPictureWindow.Image);
                // �O�̉摜�̃C���f�b�N�X���v�Z
                int prevIndex = (currentIndex - 1 + images.Count) % images.Count;
                // �O�̉摜��\��
                MainPictureWindow.Image = images[prevIndex];
            }
        }
    }
}
