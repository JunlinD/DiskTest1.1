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
            
            
            uiTabControl1.AddPage(Page1);
            
            //OrderWriteAndVerify(0, 100, 1, 1, 1);
            //RandomWriteAndVerify(0, 5);
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
