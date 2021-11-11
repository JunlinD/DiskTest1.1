
namespace DiskTest11
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Menu = new Sunny.UI.UINavMenu();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Menu.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.Menu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Menu.FullRowSelect = true;
            this.Menu.ItemHeight = 50;
            this.Menu.Location = new System.Drawing.Point(3, 38);
            this.Menu.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Menu.Name = "Menu";
            this.Menu.ShowLines = false;
            this.Menu.Size = new System.Drawing.Size(150, 697);
            this.Menu.TabIndex = 0;
            this.Menu.MenuItemClick += new Sunny.UI.UINavMenu.OnMenuItemClick(this.Menu_MenuItemClick);
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(152, 38);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(985, 697);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1138, 736);
            this.Controls.Add(this.uiTabControl1);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UINavMenu Menu;
        private Sunny.UI.UITabControl uiTabControl1;
    }
}

