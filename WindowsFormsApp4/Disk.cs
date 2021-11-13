using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskTest11
{
    public partial class Disk : Sunny.UI.UIPage
    {
        public Disk()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            //设定字体大小为12px      

            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));

        }
        public void addColumn(string name,decimal size,long sectorsize)
        {
            int index = this.dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = name;
            dataGridView1.Rows[index].Cells[1].Value = size;
            dataGridView1.Rows[index].Cells[2].Value = "";
            dataGridView1.Rows[index].Cells[3].Value = sectorsize;
            dataGridView1.Rows[index].Cells[4].Value = "512B";
            
        }
        private void StartTestClick(object sender, EventArgs e)
        {
            
        }
        public bool returnTestOrNot()
        {
            return this.TestOrNot.Checked;
        }
        public int returnTestMode()
        {
            if (this.TestMode.SelectedItem == null)
                return -1;
            return this.TestMode.SelectedIndex;
        }
        public int returnTestDataMode()
        {
            if (this.TestDataMode.SelectedItem == null)
                return -1;
            return this.TestDataMode.SelectedIndex;
        }
        public int returnTestPercent()
        {
            int percent;
            bool isallnum = int.TryParse(TestPercent.Text, out percent);
            if (CircleNumble.Text == null || isallnum == false)
            {
                return 0;
            }
            return percent;
        }
        public int returnBlockSize()
        {
            if (this.BlockSize.SelectedItem == null)
                return 0;
            return Convert.ToInt32(this.BlockSize.SelectedItem.ToString());
        }
        public long returnTestTime()
        {
            long testtime;
            bool isallnum = long.TryParse(TestTime.Text,out testtime);
            if (TestTime.Text == null || !isallnum)
                return 0;
            return testtime;
        }
        public int returnTestCircle()
        {
            int circle;
            bool isallnum = int.TryParse(CircleNumble.Text, out circle);
            if(CircleNumble.Text==null||isallnum==false)
            {
                return 0;
            }
            return circle;
        }
        public long returnTestNum()
        {
            long testnum;
            bool isallnum = long.TryParse(TestNum.Text, out testnum);
            if (TestNum.Text == null || !isallnum)
                return 0;
            return testnum;
        }

    }
}
