namespace CALreader
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_head = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSort = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDown = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStripTv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.датуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.событиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.toolStrip_head.SuspendLayout();
            this.contextMenuStripTv.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 429);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(295, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip_head
            // 
            this.toolStrip_head.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.toolStripButtonSort,
            this.toolStripButtonUp,
            this.toolStripButtonDown});
            this.toolStrip_head.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_head.Name = "toolStrip_head";
            this.toolStrip_head.Size = new System.Drawing.Size(295, 25);
            this.toolStrip_head.TabIndex = 2;
            this.toolStrip_head.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&Новый файл календаря";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Открыть файл календаря";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Сохранить файл календаря";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Печатать файл календаря";
            this.printToolStripButton.Visible = false;
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSort
            // 
            this.toolStripButtonSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSort.Image = global::CALreader.Properties.Resources.sort_az_descending;
            this.toolStripButtonSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSort.Name = "toolStripButtonSort";
            this.toolStripButtonSort.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSort.Text = "Сортировать по дате";
            // 
            // toolStripButtonUp
            // 
            this.toolStripButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUp.Image = global::CALreader.Properties.Resources.up;
            this.toolStripButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUp.Name = "toolStripButtonUp";
            this.toolStripButtonUp.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUp.Text = "Развернуть дерево";
            // 
            // toolStripButtonDown
            // 
            this.toolStripButtonDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDown.Image = global::CALreader.Properties.Resources.down;
            this.toolStripButtonDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDown.Name = "toolStripButtonDown";
            this.toolStripButtonDown.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDown.Text = "Свернуть дерево";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Calendar files|*.CAL|All files|*.*";
            this.openFileDialog.Title = "Откройте файл календаря";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Calendar files|*.CAL|All files|*.*";
            this.saveFileDialog.Title = "Сохраните файл календаря";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ico_watch.gif");
            this.imageList.Images.SetKeyName(1, "favicon.ico");
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.contextMenuStripTv;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.ItemHeight = 24;
            this.treeView.LabelEdit = true;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(295, 404);
            this.treeView.TabIndex = 8;
            // 
            // contextMenuStripTv
            // 
            this.contextMenuStripTv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAdd,
            this.правитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStripTv.Name = "contextMenuStripTv";
            this.contextMenuStripTv.Size = new System.Drawing.Size(136, 70);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.датуToolStripMenuItem,
            this.событиеToolStripMenuItem});
            this.toolStripMenuItemAdd.Image = global::CALreader.Properties.Resources.edit_add;
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItemAdd.Text = "Добавить";
            // 
            // датуToolStripMenuItem
            // 
            this.датуToolStripMenuItem.Image = global::CALreader.Properties.Resources.ico_watch;
            this.датуToolStripMenuItem.Name = "датуToolStripMenuItem";
            this.датуToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.датуToolStripMenuItem.Text = "Дату";
            // 
            // событиеToolStripMenuItem
            // 
            this.событиеToolStripMenuItem.Image = global::CALreader.Properties.Resources.favicon;
            this.событиеToolStripMenuItem.Name = "событиеToolStripMenuItem";
            this.событиеToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.событиеToolStripMenuItem.Text = "Событие";
            // 
            // правитьToolStripMenuItem
            // 
            this.правитьToolStripMenuItem.Image = global::CALreader.Properties.Resources.edit_16;
            this.правитьToolStripMenuItem.Name = "правитьToolStripMenuItem";
            this.правитьToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.правитьToolStripMenuItem.Text = "Править";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Image = global::CALreader.Properties.Resources.del_16;
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 451);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolStrip_head);
            this.Controls.Add(this.statusStrip);
            this.Name = "FormMain";
            this.Text = "Редактор календаря";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip_head.ResumeLayout(false);
            this.toolStrip_head.PerformLayout();
            this.contextMenuStripTv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip_head;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolStripButtonSort;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTv;
        private System.Windows.Forms.ToolStripMenuItem правитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDown;
        private System.Windows.Forms.ToolStripButton toolStripButtonUp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem датуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem событиеToolStripMenuItem;
    }
}

