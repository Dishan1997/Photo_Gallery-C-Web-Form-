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

namespace PhotoGallery2
{
    public partial class Form1 : Form
    {
        bool bf = false;
        int p = 0, p1=1, flag=0;
        int clk = 1;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            button1.Enabled = false;
            button3.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.Width = 100;
            //dataGridView1.Columns.Height = 100;

            // dataGridView1.Size = 100,100;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*string[] files = Directory.GetFiles(@"C:\Users\HP\Pictures\newPic");
            DataTable table = new DataTable();
            table.Columns.Add("File Name");
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = new FileInfo(files[i]);
                table.Rows.Add(file.Name);
            }
            dataGridView1.DataSource = table; */
        }
         string path = @"C:\Users\HP\Pictures\newPic\";
        string[] imageName1 = new string[10000];         
        public void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = true;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            OpenFileDialog fd = new OpenFileDialog();
            if (fbd.ShowDialog() == DialogResult.OK) {
                path = fbd.SelectedPath;
                path= path+@"\";
               // Console.WriteLine("path in button =" + path);
               // fd.Filter = "Image Files | *.jpg; *.jpeg; *.png;";
                string[] files = Directory.GetFiles(path);
                DataTable table = new DataTable();
                //table.Rows.Le
                table.Columns.Add("File Name", typeof(Image));
               // table.width = AutoCompleteMode.

                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = new FileInfo(files[i]);
                    string path1 = file.Name;
                    Console.WriteLine("path1 in button =" + path1);
                    Console.WriteLine("file.name=" + file.Name);
                    //table.Rows.Add(path1);
                    //Image ig;
                    //Image ig1 = Image.FromFile(file.FullName);
                    //  table.Columns.Size
                    //table.Rows.Add(Image.FromFile(file.FullName));
                    //int x = ig1.Width;
                    PictureBox pc = new PictureBox();
                    pc.Width = 10;
                    pc.Height = 10;
                    pc.Image = Image.FromFile(file.FullName);
                    pc.SizeMode = PictureBoxSizeMode.CenterImage;
                    table.Rows.Add(pc.Image);
                    imageName1[i] = file.Name;              
                }
                dataGridView1.DataSource = table;
                
            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        int r,c;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r1 = dataGridView1.CurrentCell.RowIndex;
            string imageName = imageName1[r1];
            Console.WriteLine("imageName=" + imageName + "\n");
            // string imageName = dataGridView1[dataGridView1.CurrentCell.RowIndex, dataGridView1.CurrentCell.ColumnIndex].Tag.ToString();
            Console.WriteLine("imagename=" + imageName + "\n");
            Image img = Image.FromFile(path + imageName);
            pictureBox1.Image = img;
            r = e.RowIndex;
            c = e.ColumnIndex;
            
        }

        //previous
        private void button1_Click(object sender, EventArgs e)
        {
            r = dataGridView1.CurrentCell.RowIndex;
            c = dataGridView1.CurrentCell.ColumnIndex;
            r--;
            if (r == -1)
            {
                Console.WriteLine("inside if in next" + "\n");

                r = dataGridView1.Rows.Count - 2;
            }
            Console.WriteLine("r in next=" + r + "\n");
            dataGridView1.CurrentCell = dataGridView1.Rows[r].Cells[dataGridView1.CurrentCell.ColumnIndex];
            //dataGridView1.CurrentRow = r;
            var args = new DataGridViewCellEventArgs(r, c);
            dataGridView1_CellContentClick(dataGridView1, args);
        }

        //next
        private void button3_Click(object sender, EventArgs e)
        {
            r = dataGridView1.CurrentCell.RowIndex;
            c= dataGridView1.CurrentCell.ColumnIndex;
            r++;
            if (r == dataGridView1.Rows.Count-1)
            {
                r = 0;
                //Console.WriteLine("executing if for r="+ r+ "and dataGridView1.Rows.Count="+ dataGridView1.Rows.Count+ "\n");
            }
            //Console.WriteLine("r in next=" + r + "\n");
            dataGridView1.CurrentCell = dataGridView1.Rows[r].Cells[dataGridView1.CurrentCell.ColumnIndex];
            var args = new DataGridViewCellEventArgs(r, c);
            dataGridView1_CellContentClick(dataGridView1, args);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
