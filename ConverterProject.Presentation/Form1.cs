using ConverterProject.Presentation.Business;

namespace ConverterProject.Presentation
{
    public partial class frm_xmltocsv : Form
    {
        OpenFileDialog? openFileDialogRead;
        FolderBrowserDialog? openFileDialogWrite;

        public frm_xmltocsv()
        {
            InitializeComponent();
        }

        private void btn_chooseReadFile_Click(object sender, EventArgs e)
        {
            openFileDialogRead = new OpenFileDialog();
            openFileDialogRead.InitialDirectory = AppConstants.TempFolderPath;
            openFileDialogRead.Filter = AppConstants.Filter;

            if (openFileDialogRead.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialogRead.FileName;
                txt_readpath.Text = selectedFilePath;
            }
        }

        private void btn_chooseWriteFile_Click(object sender, EventArgs e)
        {
            openFileDialogWrite = new FolderBrowserDialog();
            openFileDialogWrite.InitialDirectory = AppConstants.TempFolderPath;

            if (openFileDialogWrite.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialogWrite.SelectedPath;
                txt_writepath.Text = selectedFilePath;
            }
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            string readFilePath = txt_readpath.Text;
            string writeFilePath = txt_writepath.Text;
            string customFileName = txt_writeName.Text.Trim();

            if (string.IsNullOrEmpty(readFilePath) || string.IsNullOrEmpty(writeFilePath))
            {
                MessageBox.Show("Lütfen bir Excel dosyası seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FileManager.ConvertXmlToCsv(readFilePath, writeFilePath, customFileName);
        }
    }
}
