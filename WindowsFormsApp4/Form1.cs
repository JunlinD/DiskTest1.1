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
using static DiskTest11.Disk;
namespace DiskTest11
{

    public partial class Form1 :Sunny.UI.UIForm
    {
        private const int DEAFAUT_BLOCKSIZE = 512;
        ArrayList Disk_Driver_List = new ArrayList();
        ArrayList Disk_Informaion_List = new ArrayList();
        ArrayList Disk_Choose_Information = new ArrayList();
        private byte[] TestArray;
        private byte[] CompareArray;
        private Disk Page1;
        public Form1()
        {
            InitializeComponent();
            
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
            Page1 = new Disk();
            
            Init_Disk_Information();
            Init_Disk_Driver();
            Init_Test_Parameters();
            
            uiTabControl1.AddPage(Page1);
            Start_Test();
            //OrderWriteAndVerify(0, 100, 1, 1, 1);
            //RandomWriteAndVerify(0, 5);
        }

        private void Start_Test()
        {
            for(int i=0;i<Disk_Choose_Information.Count;i++)
            {
                ChooseInformation chooseInformation = (ChooseInformation)Disk_Choose_Information[i];
                DriverLoader driverLoader = (DriverLoader)Disk_Driver_List[i];
                if(chooseInformation.TestOrNot==true)
                {
                    if(chooseInformation.TestMode==0)//随机读写验证
                    {
                        RandomWriteAndVerify(i, chooseInformation.TestNum, chooseInformation.TestTime);
                    }
                    else if(chooseInformation.TestMode == 1)//随机只读
                    {
                        RandomOnlyRead(i, chooseInformation.TestNum, chooseInformation.TestTime);
                    }
                    else if(chooseInformation.TestMode == 2)//随机只写
                    {
                        RandomOnlyWrite(i, chooseInformation.TestNum, chooseInformation.TestTime);
                    }
                    else if(chooseInformation.TestMode == 3)//顺序读写验证
                    {
                        OrderWriteAndVerify(i, chooseInformation.TestPercent, chooseInformation.TestDataMode, chooseInformation.BlockSize, chooseInformation.TestCircle);
                    }
                    else if(chooseInformation.TestMode==4)//顺序只读
                    {
                        OrderOnlyRead(i, chooseInformation.TestPercent, chooseInformation.TestDataMode, chooseInformation.BlockSize, chooseInformation.TestCircle);
                    }
                    else if(chooseInformation.TestMode==5)//顺序只写
                    {
                        OrderOnlyWrite(i, chooseInformation.TestPercent, chooseInformation.TestDataMode, chooseInformation.BlockSize, chooseInformation.TestCircle);
                    }
                    else
                    {
                        MessageBox.Show("测试模式错误！");
                    }
                }
                else
                {
                    MessageBox.Show("该磁盘无法进行测试，请检查选项");
                }
            }
        }

        private void Init_Test_Parameters()
        {
            for(int i=0;i<Disk_Driver_List.Count;i++)
            {
                if(Page1.returnTestOrNot())
                {
                    if(Page1.returnTestMode()==0|| Page1.returnTestMode() == 1|| Page1.returnTestMode() == 2)
                    {
                        
                        bool testornot = Page1.returnTestOrNot();
                        int testmode = Page1.returnTestMode();
                        long testtime = Page1.returnTestTime();
                        long testnum = Page1.returnTestNum();
                        ChooseInformation choose = new ChooseInformation();
                        choose.SetRandomParameters(testornot, testmode, testtime, testnum);
                        Disk_Choose_Information.Add(choose);
                    }
                    else
                    {
                        bool testornot = Page1.returnTestOrNot();
                        int testmode = Page1.returnTestMode();
                        int testdatamode = Page1.returnTestDataMode();
                        long testtime = Page1.returnTestTime();
                        int testcircle = Page1.returnTestCircle();
                        long testnum = Page1.returnTestNum();
                        int testpercent = Page1.returnTestPercent();
                        int blocksize = Page1.returnBlockSize();
                        ChooseInformation choose = new ChooseInformation();
                        choose.SetOrderParameters(testornot, testmode, testdatamode, testpercent, blocksize, testtime, testnum, testcircle);
                        Disk_Choose_Information.Add(choose);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化驱动器信息数组
        /// </summary>
        public void Init_Disk_Information()
        {
            ManagementClass Diskobject = new ManagementClass("Win32_DiskDrive");//获取一个磁盘实例对象
            ManagementObjectCollection moc = Diskobject.GetInstances();//获取对象信息的集合            
            int id = 0;
            int i = 1;
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
                        Page1.addColumn(name, size, sector_size);
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
        /// <summary>
        /// 初始化驱动器数组
        /// </summary>
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
        /// <summary>
        /// 顺序读写测试
        /// </summary>
        /// <param name="driver_index"></param>
        /// <param name="percent"></param>
        /// <param name="test_data_mode"></param>
        /// <param name="block_size"></param>
        /// <param name="circle"></param>
        public void OrderWriteAndVerify(int driver_index,int percent=100,int test_data_mode=0,int block_size=1,int circle=1)
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
            if(test_data_mode==0||test_data_mode==1)
            {
                int error_num = 0;
                Init_TestArray(block_size, test_data_mode);
                for(long i=0;i<actual_size;i++)
                {
                    driver.WritSector(TestArray, i, block_size);
                    CompareArray = driver.ReadSector(i, block_size);
                    error_num += VerifyArray(TestArray, CompareArray);
                }
                if (error_num == 0)
                    Console.WriteLine("读写测试完成，测试了"+actual_size+"次未发生错误！");
            }
            else if(test_data_mode==2)
            {
                int error_num = 0;
                for (long i = 0; i < actual_size; i++)
                {
                    Init_TestArray(block_size, test_data_mode);
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
        public void OrderOnlyWrite(int driver_index, int percent = 100, int test_data_mode = 0, int block_size = 1, int circle = 1)
        {
            if (Disk_Driver_List.Count <= 0)
            {
                MessageBox.Show("未检测到设备！");
                return;
            }
            DriverLoader driver = (DriverLoader)Disk_Driver_List[driver_index];
            TestArray = new byte[DEAFAUT_BLOCKSIZE * block_size];
            CompareArray = new byte[DEAFAUT_BLOCKSIZE * block_size];
            //long actual_size = ((driver.DiskInformation.DiskSectorSize / block_size)*percent)/100;
            long actual_size = 10;
            if (test_data_mode == 0 || test_data_mode == 1)
            {
                Init_TestArray(block_size, test_data_mode);
                for (long i = 0; i < actual_size; i++)
                {
                    driver.WritSector(TestArray, i, block_size);
                }
            }
            else if (test_data_mode == 2)
            {
                int error_num = 0;
                for (long i = 0; i < actual_size; i++)
                {
                    Init_TestArray(block_size, test_data_mode);
                    driver.WritSector(TestArray, i, block_size);
                }             
            }
            else
            {
                Console.WriteLine("测试模式不存在，请重新选择!");
            }
        }
        public void OrderOnlyRead(int driver_index, int percent = 100, int test_data_mode = 0, int block_size = 1, int circle = 1)
        {
            if (Disk_Driver_List.Count <= 0)
            {
                MessageBox.Show("未检测到设备！");
                return;
            }
            DriverLoader driver = (DriverLoader)Disk_Driver_List[driver_index];
            CompareArray = new byte[DEAFAUT_BLOCKSIZE * block_size];
            //long actual_size = ((driver.DiskInformation.DiskSectorSize / block_size)*percent)/100;
            long actual_size = 10;
            for (long i = 0; i < actual_size; i++)
            {
                CompareArray = driver.ReadSector(i, block_size);
            }
            
        }
        public void RandomWriteAndVerify(int driver_index,long test_num=0,long test_time=0,int test_mode=2)
        {
            if(Disk_Driver_List.Count<=0)
            {
                MessageBox.Show("未检测到设备！");
                return;
            }
            Random R = new Random();
            DriverLoader driver = (DriverLoader)Disk_Driver_List[driver_index];
            if(test_num==0)
            {
                long start_time = Environment.TickCount;
                int error_num = 0;
                while (true)
                {
                    int temp_block = R.Next(1, 5);
                    int actual_block_size = DEAFAUT_BLOCKSIZE * temp_block;
                    TestArray = new byte[actual_block_size];
                    CompareArray = new byte[actual_block_size];
                    Init_TestArray(temp_block,test_mode);
                    long pos = NextLong(0, driver.DiskInformation.DiskSectorSize-temp_block);
                    Console.WriteLine("写入" + pos + "扇区");
                    driver.WritSector(TestArray, pos, temp_block);
                    CompareArray = driver.ReadSector(pos, temp_block);
                    error_num += VerifyArray(TestArray, CompareArray);
                    long end_time = Environment.TickCount;
                    if (end_time - start_time >= test_time)
                        break;
                }
                if (error_num == 0)
                    Console.WriteLine("读写测试完成，测试了" + test_time + "毫秒未发生错误！");
            }
            else if(test_time==0)
            {
                long temp_num = 0;
                int error_num = 0;
                while (true)
                {
                    if (temp_num >= test_num)
                        break;
                    int temp_block = R.Next(1, 5);
                    int actual_block_size = DEAFAUT_BLOCKSIZE * temp_block;
                    TestArray = new byte[actual_block_size];
                    CompareArray = new byte[actual_block_size];
                    Init_TestArray(temp_block, test_mode);
                    long pos = NextLong(0, driver.DiskInformation.DiskSectorSize - temp_block);
                    Console.WriteLine("写入" + pos + "扇区");
                    driver.WritSector(TestArray, pos, temp_block);
                    CompareArray = driver.ReadSector(pos, temp_block);
                    error_num += VerifyArray(TestArray, CompareArray);
                    temp_num++;
                }
                if (error_num == 0)
                    Console.WriteLine("读写测试完成，测试了" + test_num + "次未发生错误！");
            }
        }
        public void RandomOnlyRead(int driver_index, long test_num = 0, long test_time = 0)
        {
            if (Disk_Driver_List.Count <= 0)
            {
                MessageBox.Show("未检测到设备！");
                return;
            }
            Random R = new Random();
            DriverLoader driver = (DriverLoader)Disk_Driver_List[driver_index];
            if (test_num == 0)
            {
                long start_time = Environment.TickCount;
                while (true)
                {
                    int temp_block = R.Next(1, 5);
                    int actual_block_size = DEAFAUT_BLOCKSIZE * temp_block;
                    CompareArray = new byte[actual_block_size];
                    long pos = NextLong(0, driver.DiskInformation.DiskSectorSize - temp_block);
                    CompareArray = driver.ReadSector(pos, temp_block);
                    long end_time = Environment.TickCount;
                    if (end_time - start_time >= test_time)
                        break;
                }
                Console.WriteLine("只读测试完成，测试了" + test_time + "毫秒未发生错误！");
            }
            else if (test_time == 0)
            {
                long temp_num = 0;
                while (true)
                {
                    if (temp_num >= test_num)
                        break;
                    int temp_block = R.Next(1, 5);
                    int actual_block_size = DEAFAUT_BLOCKSIZE * temp_block;
                    CompareArray = new byte[actual_block_size];
                    long pos = NextLong(0, driver.DiskInformation.DiskSectorSize - temp_block);
                    CompareArray = driver.ReadSector(pos, temp_block);
                    temp_num++;
                }
                Console.WriteLine("读写测试完成，测试了" + test_num + "次未发生错误！");
            }
        }
        public void RandomOnlyWrite(int driver_index, long test_num = 0, long test_time = 0,int test_mode=2)
        {
            if (Disk_Driver_List.Count <= 0)
            {
                MessageBox.Show("未检测到设备！");
                return;
            }
            Random R = new Random();
            DriverLoader driver = (DriverLoader)Disk_Driver_List[driver_index];
            if (test_num == 0)
            {
                long start_time = Environment.TickCount;
                while (true)
                {
                    int temp_block = R.Next(1, 5);
                    int actual_block_size = DEAFAUT_BLOCKSIZE * temp_block;
                    TestArray = new byte[actual_block_size];
                    Init_TestArray(temp_block, test_mode);
                    long pos = NextLong(0, driver.DiskInformation.DiskSectorSize - temp_block);
                    driver.WritSector(TestArray, pos, temp_block);
                    long end_time = Environment.TickCount;
                    if (end_time - start_time >= test_time)
                        break;
                }
                Console.WriteLine("写测试完成，测试了" + test_time + "毫秒！");
            }
            else if (test_time == 0)
            {
                long temp_num = 0;
                while (true)
                {
                    if (temp_num >= test_num)
                        break;
                    int temp_block = R.Next(1, 5);
                    int actual_block_size = DEAFAUT_BLOCKSIZE * temp_block;
                    TestArray = new byte[actual_block_size];
                    Init_TestArray(temp_block, test_mode);
                    long pos = NextLong(0, driver.DiskInformation.DiskSectorSize - temp_block);
                    driver.WritSector(TestArray, pos, temp_block);
                    temp_num++;
                }
                Console.WriteLine("写测试完成，测试了" + test_num + "次！");
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
