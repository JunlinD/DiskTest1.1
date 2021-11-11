using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiskTestLib;

namespace DiskTest11
{

    public partial class Form1 :Sunny.UI.UIForm
    {
        private const int DEAFAUT_BLOCKSIZE = 512;
        ArrayList Disk_Driver_List = new ArrayList();
        ArrayList Disk_Informaion_List = new ArrayList();
        private byte[] TestArray;
        private byte[] CompareArray;
        public Form1()
        {
            InitializeComponent();
            Init_Disk_Information();
            Init_Disk_Driver();
            OrderWriteAndVerify(0, 100, 1, 1, 1);
            int pageIndex = 100;
            TreeNode parent = Menu.CreateNode("Setting", pageIndex);
            Menu.CreateChildNode(parent, "Disk", ++pageIndex);
            Menu.CreateChildNode(parent, "Errors", ++pageIndex);
            Menu.CreateChildNode(parent, "Logging", ++pageIndex);
            pageIndex = 200;
            parent = Menu.CreateNode("Test", pageIndex);
            Menu.CreateChildNode(parent, "Test", ++pageIndex);
            Menu.CreateChildNode(parent, "Testting", ++pageIndex);
            Menu.CreateChildNode(parent, "Log", ++pageIndex);
            Menu.CreateChildNode(parent, "Information", ++pageIndex);
            Disk Page1 = new Disk();
            uiTabControl1.AddPage(new Disk());
        }
        public void Init_Disk_Information()
        {
            ManagementClass Diskobject = new ManagementClass("Win32_DiskDrive");//获取一个磁盘实例对象
            ManagementObjectCollection moc = Diskobject.GetInstances();//获取对象信息的集合            
            int id = 0;
            foreach (ManagementObject mo in moc)
            {
                if (mo.Properties["InterfaceType"].Value.ToString() == "USB")
                {
                    try
                    {
                        //产品名称
                        string name = mo.Properties["Name"].Value.ToString();
                        string sector_size_s = mo.Properties["TotalSectors"].Value.ToString();
                        long sector_size = Convert.ToInt64(sector_size_s);

                        string size_s = mo.Properties["Size"].Value.ToString();
                        double size_d = Convert.ToDouble(size_s)/(1024*1024*1024);
                        decimal size = decimal.Round(decimal.Parse("" + size_d),2);
                        //long size = Convert.ToInt64(size_s);
                        DiskInformation d = new DiskInformation(name, sector_size, size, id++);
                        Disk_Informaion_List.Add(d);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if(id==0)
            {
                MessageBox.Show("未检测到设备！");
            }
        }
        public void Init_Disk_Driver()
        {
            if(Disk_Informaion_List.Count<=0)
            {
                MessageBox.Show("未检测到设备！");
                return;
            }
            for(int i=0;i<Disk_Informaion_List.Count;i++)
            {
                DiskInformation information = (DiskInformation)Disk_Informaion_List[i];
                DriverLoader driver = new DriverLoader(information);
                Disk_Driver_List.Add(driver);
            }
        }
        public void OrderWriteAndVerify(int driver_index,int percent=100,int test_mode=0,int block_size=1,int circle=1)
        {
            if(Disk_Driver_List.Count<=0)
            {
                MessageBox.Show("未检测到设备！");
                return;
            }
            DriverLoader driver = (DriverLoader)Disk_Driver_List[driver_index];
            TestArray = new byte[DEAFAUT_BLOCKSIZE * block_size];
            CompareArray = new byte[DEAFAUT_BLOCKSIZE * block_size];
            //long actual_size = ((driver.DiskInformation.DiskSectorSize / block_size)*percent)/100;
            long actual_size = 10;
            if(test_mode==0||test_mode==1)
            {
                int error_num = 0;
                Init_TestArray(block_size, test_mode);
                for(long i=0;i<actual_size;i++)
                {
                    driver.WritSector(TestArray, i, block_size);
                    CompareArray = driver.ReadSector(i, block_size);
                    error_num += VerifyArray(TestArray, CompareArray);
                }
                if (error_num == 0)
                    Console.WriteLine("读写测试完成，测试了"+actual_size+"次未发生错误！");
            }
            else if(test_mode==2)
            {
                int error_num = 0;
                for (long i = 0; i < actual_size; i++)
                {
                    Init_TestArray(block_size, test_mode);
                    driver.WritSector(TestArray, i, block_size);
                    CompareArray = driver.ReadSector(i, block_size);
                    error_num += VerifyArray(TestArray, CompareArray);
                }
                if (error_num == 0)
                    Console.WriteLine("读写测试完成，测试了" + actual_size + "次未发生错误！");
            }
            else
            {
                Console.WriteLine("测试模式不存在，请重新选择!");
            }
        }

        public void Init_TestArray(int block_size,int mode)
        {
            if (block_size == 0)
            {
                MessageBox.Show("块大小不能为0");
                return;
            }              
            if(mode==0)
            {
                for (int i = 0; i < block_size * DEAFAUT_BLOCKSIZE; i++)
                {
                    TestArray[i] = 0;
                }
            }
            else if(mode==1)
            {
                for (int i = 0; i < block_size * DEAFAUT_BLOCKSIZE; i++)
                {
                    TestArray[i] = 255;
                }
            }
            else if(mode==2)
            {
                Random R = new Random();
                for (int i = 0; i < block_size * DEAFAUT_BLOCKSIZE; i++)
                {

                    TestArray[i] = (byte)R.Next(0,255);
                }
            }
            
        }
        public int VerifyArray(byte[] testarray,byte[] comparearray)
        {
            if(testarray.Length!=comparearray.Length)
            {
                Console.WriteLine("数组长度不匹配！");
            }
            int error_num=0;
            for(int i = 0; i < testarray.Length; i++)
            {
                if(testarray[i]!=comparearray[i])
                {
                    Console.WriteLine("当前位置" + i + "出错，正确数据为" + testarray[i] + "错误数据为：" + comparearray[i]);
                    error_num++;
                }
            }
            return error_num;

        }
        public long NextLong(long A, long B)
        {
            Random R = new Random((int)DateTime.Now.Ticks);
            long myResult = A;
            //-----
            long Max = B, Min = A;
            if (A > B)
            {
                Max = A;
                Min = B;
            }
            double Key = R.NextDouble();
            myResult = Min + (long)((Max - Min) * Key);
            //-----
            return myResult;
        }
        private void Menu_MenuItemClick(TreeNode node, Sunny.UI.NavMenuItem item, int pageIndex)
        {
            Disk Page1 = new Disk();
            Errors Page2 = new Errors();
            Test2 Page4 = new Test2();
            Logging Page3 = new Logging();
            Testing Page5 = new Testing();
            Information Page6 = new Information();
            Log Page7 = new Log();
            switch (pageIndex)
            {
                case 100:
                    break;
                case 101:
                    uiTabControl1.Controls.Clear();
                    uiTabControl1.AddPage(Page1);
                    break;
                case 102:
                    uiTabControl1.Controls.Clear();
                    uiTabControl1.AddPage(Page2);
                    break;
                case 103:
                    uiTabControl1.Controls.Clear();
                    uiTabControl1.AddPage(Page3);
                    break;
                case 201:
                    uiTabControl1.Controls.Clear();
                    uiTabControl1.AddPage(Page4);
                    break;
                case 202:
                    uiTabControl1.Controls.Clear();
                    uiTabControl1.AddPage(Page5);
                    break;
                case 203:
                    uiTabControl1.Controls.Clear();
                    uiTabControl1.AddPage(Page7);
                    break;
                case 204:
                    uiTabControl1.Controls.Clear();
                    uiTabControl1.AddPage(Page6);
                    break;

            }
        }
    }
}
