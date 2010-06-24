using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CALreader
{
    public partial class FormMain : Form
    {
        string _calfile = string.Empty;

        public FormMain()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            toolStripButtonSort.Click += new EventHandler(toolStripButtonSort_Click);
            openToolStripButton.Click += new EventHandler(openToolStripButton_Click);
            newToolStripButton.Click += new EventHandler(newToolStripButton_Click);
            saveToolStripButton.Click += new EventHandler(saveToolStripButton_Click);
            treeView.AfterLabelEdit += new NodeLabelEditEventHandler(treeView_AfterLabelEdit);
            treeView.KeyUp += new KeyEventHandler(treeView_KeyUp);
            treeView.NodeMouseHover += new TreeNodeMouseHoverEventHandler(treeView_NodeMouseHover);
            toolStripButtonUp.Click += new EventHandler(toolStripButtonUp_Click);
            toolStripButtonDown.Click += new EventHandler(toolStripButtonDown_Click);
            contextMenuStripTv.Opening += new CancelEventHandler(contextMenuStripTv_Opening);
            правитьToolStripMenuItem.Click += new EventHandler(правитьToolStripMenuItem_Click);
            удалитьToolStripMenuItem.Click += new EventHandler(удалитьToolStripMenuItem_Click);
            датуToolStripMenuItem.Click += new EventHandler(датуToolStripMenuItem_Click);
            событиеToolStripMenuItem.Click += new EventHandler(событиеToolStripMenuItem_Click);
        }

        /// <summary>
        /// При добавлении нового события обновить тултип даты события
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="vievAct"></param>
        void SetRootNodeTooltip(TreeNode tn, bool vievAct)
        {
            if (tn != null && tn.Parent == null)
            {
                string time_tooltip = string.Empty;
                for (int i = 0; i < tn.Nodes.Count; i++)
                {
                    string time = tn.Nodes[i].Text;
                    if (vievAct)
                    {
                        time_tooltip += time.Substring(1) + " " + ((time.Substring(0, 1) == "+") ? "ВКЛ" : "ОТКЛ") + Environment.NewLine;
                    }
                    else
                    {
                        time_tooltip += time.Substring(1) + Environment.NewLine;
                    }
                }
                tn.ToolTipText = string.Format("Событий: {0}." + Environment.NewLine + "---------------------------" + Environment.NewLine + time_tooltip, tn.Nodes.Count);
            }
        }

        /// <summary>
        /// Добавление нового события к выбранной дате
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void событиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Parent == null)
            {
                switch (treeView.SelectedNode.Tag.ToString().ToUpperInvariant())
                {
                    case "DATE":
                        {
                            if (treeView.Nodes.ContainsKey(treeView.SelectedNode.Name))
                            {
                                //время
                                DateTime dt = DateTime.Now;
                                string t_text = "-" + dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00") + ":" + dt.Second.ToString("00");

                                TreeNode tn = new TreeNode();
                                tn.Name = t_text;
                                tn.Text = t_text;
                                tn.SelectedImageIndex = 1;
                                tn.ImageIndex = 1;
                                tn.Tag = "TIME";
                                treeView.SelectedNode.Nodes.Add(tn);
                                treeView.SelectedNode.Expand();
                                SetRootNodeTooltip(treeView.SelectedNode, false);
                                tn.EnsureVisible();
                                tn.BeginEdit();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Добавить новую дату
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void датуToolStripMenuItem_Click(object sender, EventArgs e)
        {
                //дату
                DateTime dt = DateTime.Now;
                string d_text = dt.Year.ToString("0000") + "." + dt.Month.ToString("00") + "." + dt.Day.ToString("00");

                TreeNode tn = new TreeNode();
                tn.Name = d_text;
                tn.Text = d_text;
                tn.SelectedImageIndex = 0;
                tn.ImageIndex = 0;
                tn.Tag = "DATE";
                tn.ToolTipText = string.Format("Событий: 0.");

                if (treeView.Nodes.ContainsKey(d_text))
                {
                    tn.Text = string.Empty;
                }

                treeView.Nodes.Add(tn);
                tn.EnsureVisible();
                tn.BeginEdit();
        }

        /// <summary>
        /// Стандартные реакции на нажатие клавиш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        DeleteSelectedNode();
                    }
                    break;

                case Keys.F2:
                    {
                        EditSelectedNode();
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// логика пунктов меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void contextMenuStripTv_Opening(object sender, CancelEventArgs e)
        {
            правитьToolStripMenuItem.Enabled = (treeView.SelectedNode == null) ? false : true;
            удалитьToolStripMenuItem.Enabled = (treeView.SelectedNode == null) ? false : true;
            событиеToolStripMenuItem.Enabled = (treeView.SelectedNode == null) ? false : 
                                               (treeView.SelectedNode.Parent != null) ? false :
                                               (!isDate(treeView.SelectedNode.Text)) ? false : true;

        }   
        
        /// <summary>
        /// Обработчик события удаления ноды
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedNode();
        }

        /// <summary>
        /// Обработчик события правки ноды
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void правитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedNode();
        }

        /// <summary>
        /// Обработчик события при попадании курсора мышки в область ноды
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeView_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            SetRootNodeTooltip(e.Node, true);
        }

        /// <summary>
        /// Обработчик события зыкрытия формы (запрос на сохранение)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения в файле календаря?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveCalendarGL();
            }
        }

        /// <summary>
        /// Удалить выбранную ноду
        /// </summary>
        private void DeleteSelectedNode()
        {
            if (treeView.SelectedNode != null)
            {
                if (MessageBox.Show("Удалить " + treeView.SelectedNode.Text + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    treeView.SelectedNode.Remove();
                    if (treeView.SelectedNode != null)
                    {
                        SetRootNodeTooltip(treeView.SelectedNode.Parent, true);
                    }
                }
            }
        }

        /// <summary>
        /// Править выбранную ноду
        /// </summary>
        private void EditSelectedNode()
        {
            if (treeView.SelectedNode != null)
            {
                treeView.SelectedNode.BeginEdit();
            }
        }

        /// <summary>
        /// Является ли строка датой
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        bool isDate(string text)
        {
            return Regex.IsMatch(text, @"^\d{4}\.\d{2}\.\d{2}$", RegexOptions.Singleline);
        }

        /// <summary>
        /// Проверка на валидность введенных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Parent == null)//1 Уровень - дата
            {
                if (e.Label != null)
                {
                    if (!isDate(e.Label))//@"^\d{4}.(1[0-2]|0[1-9])\d{2}.(3[0-1]|[0-2][0-9])\d{2}$"
                    {
                        MessageBox.Show("Введенное значение не распознано как дата (ГГГГ.ММ.ДД)");
                        e.CancelEdit = true;
                        e.Node.BeginEdit();
                    }
                    else
                    {
                        if (treeView.Nodes.ContainsKey(e.Label))
                        {
                            MessageBox.Show("Введенная дата уже есть в списке. Добавление даты отменено (ГГГГ.ММ.ДД)");
                            e.CancelEdit = true;
                            e.Node.BeginEdit();
                        }
                        else
                        {
                            e.Node.Name = e.Label.Replace(",", ".");
                        }
                    }
                }
            }
            else
            {
                switch (e.Node.Tag.ToString().ToUpperInvariant())//2 ур.
                {
                    case "TIME"://время
                        {
                            if (e.Label != null)
                            {
                                if (!Regex.IsMatch(e.Label, @"^(\+|\-)\d{2}:\d{2}:\d{2}$", RegexOptions.Singleline))
                                {
                                    MessageBox.Show("Введенное значение не распознано как:" + Environment.NewLine + Environment.NewLine + "Включение во время +ЧЧ.ММ.СС" + Environment.NewLine + "или" + Environment.NewLine + "Отключение во время -ЧЧ.ММ.СС");
                                    e.CancelEdit = true;
                                }
                                else
                                {
                                    e.Node.Name = e.Label;
                                    SetRootNodeTooltip(treeView.SelectedNode.Parent, true);
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveCalendarGL();
        }

        /// <summary>
        /// Сохранить календарь в файл (с проверкой наличия и запросом имени, если файла нет)
        /// </summary>
        private void SaveCalendarGL()
        {
            if (File.Exists(_calfile) && !string.IsNullOrEmpty(_calfile))
            {
                SaveCalendar(_calfile);
            }
            else
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _calfile = saveFileDialog.FileName;
                    SaveCalendar(_calfile);
                }
            }
        }

        /// <summary>
        /// Сохранить календарь в файл (без проверок)
        /// </summary>
        /// <param name="file"></param>
        void SaveCalendar(string file)
        {
            string cal_text = string.Empty;
            int events = 0;
            int days = 0;

            foreach (TreeNode tn in treeView.Nodes)
            {
                if (!string.IsNullOrEmpty(tn.Text))
                {
                    days++;
                    cal_text += "#" + tn.Text;
                    foreach (TreeNode tnc in tn.Nodes)
                    {
                        events++;
                        cal_text += tnc.Text;
                        toolStripStatusLabelInfo.Text = string.Format("Сохранено дней: {0}, событий: {1}.", days, events);
                    }
                }
            }
            cal_text += "#";

            using (StreamWriter sw = new StreamWriter(file, false, Encoding.ASCII))
            {
                sw.Write(cal_text);
                sw.Close();
            }
        }

        /// <summary>
        /// Очистить все контролы
        /// </summary>
        private bool ClearAllControls()
        {
            if (MessageBox.Show("Производится очистка. Все несохраненные изменения будут потеряны.", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                treeView.BeginUpdate();
                treeView.Nodes.Clear();
                _calfile = string.Empty;
                treeView.EndUpdate();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Загрузка календаря из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void openToolStripButton_Click(object sender, EventArgs e)
        {
            treeView.BeginUpdate();
            bool accept_open = true;

            if (treeView.Nodes.Count > 0)
            {
                accept_open=ClearAllControls();
            }

            if (accept_open && openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _calfile = openFileDialog.FileName;
                
                string cal_text = string.Empty;
                using(StreamReader sr = new StreamReader(_calfile, Encoding.ASCII))
                {
                    cal_text=sr.ReadToEnd();
                    sr.Close();
                }

                string[] arr_dtimes = Regex.Split(cal_text, "#", RegexOptions.Singleline);
                //2010.01.01+00:00:01-00:07:39+16:19:00
                //     date         times

                int events = 0;
                int days = 0;
                foreach (string dt in arr_dtimes)
                {
                    if (dt.Length >= 10)
                    {
                        string date = dt.Substring(0, 10);
                        int len_time = 9;//+00:00:01
                        int iteration = Convert.ToInt32(dt.Substring(10).Length / len_time);
                        string times = dt.Substring(10);//+00:00:01-00:07:39+16:19:00
                        string[] time = new string[iteration];
                        string time_tooltip = string.Empty;
                        for (int i = 0; i < iteration; i++)
                        {
                            time[i] = times.Substring(i*len_time, len_time);
                            time_tooltip += time[i].Substring(1) + " " + ((time[i].Substring(0,1)=="+") ? "ВКЛ" : "ОТКЛ") + Environment.NewLine;
                            events++;
                        }

                        TreeNode[] tnc = new TreeNode[iteration];//времена
                        for (int i = 0; i < iteration; i++)
                        {
                            TreeNode tnt = new TreeNode();
                            tnt.Name = time[i];
                            tnt.Text = time[i];
                            tnt.SelectedImageIndex = 1;
                            tnt.ImageIndex = 1;
                            tnt.Tag = "TIME";
                            tnc[i] = tnt;
                        }

                        if (!treeView.Nodes.ContainsKey(date))//как в контроллере, только первое вхождение
                        {
                            TreeNode tn = new TreeNode();
                            tn.Name = date;
                            tn.Text = date;
                            tn.SelectedImageIndex = 0;
                            tn.ImageIndex = 0;
                            tn.Tag = "DATE";
                            tn.ToolTipText = string.Format("Событий: {0}." + Environment.NewLine + "---------------------------" + Environment.NewLine + time_tooltip, iteration);

                            tn.Nodes.AddRange(tnc);
                            treeView.Nodes.Add(tn);
                            toolStripStatusLabelInfo.Text = string.Format("Загружено дней: {0}, событий: {1}.", ++days, events);

                        }
                        else
                        {
                            treeView.Nodes[date].Nodes.AddRange(tnc);
                            toolStripStatusLabelInfo.Text = string.Format("Загружено дней: {0}, событий: {1}.", days, events);
                        }
                        Application.DoEvents();
                    }
                }
                //
            }
            treeView.EndUpdate();
        }

        /// <summary>
        /// Новое дерево
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void newToolStripButton_Click(object sender, EventArgs e)
        {
            ClearAllControls();
        }

        /// <summary>
        /// Сортировка A-Z
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void toolStripButtonSort_Click(object sender, EventArgs e)
        {
            treeView.BeginUpdate();
            treeView.Sort();
            treeView.EndUpdate();
        }

        /// <summary>
        /// Свернуть дерево
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void toolStripButtonDown_Click(object sender, EventArgs e)
        {
            treeView.BeginUpdate();
            treeView.CollapseAll();
            treeView.EndUpdate();
        }

        /// <summary>
        /// Развернуть дерево
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void toolStripButtonUp_Click(object sender, EventArgs e)
        {
            treeView.BeginUpdate();
            treeView.ExpandAll();
            treeView.EndUpdate();
        }
    }
}