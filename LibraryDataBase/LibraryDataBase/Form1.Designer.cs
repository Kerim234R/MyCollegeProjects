namespace LibraryDataBase
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            файлToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            бДЧитателейToolStripMenuItem = new ToolStripMenuItem();
            генераторОтчётовToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            panel1 = new Panel();
            button_clearFindFilter = new Button();
            button_clearFindPole = new Button();
            label11 = new Label();
            buttonDelAll = new Button();
            buttonDeleteOne = new Button();
            buttonFind = new Button();
            textBoxFind = new TextBox();
            buttonChist = new Button();
            panel2 = new Panel();
            buttonAddbook = new Button();
            label10 = new Label();
            textBox6 = new TextBox();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            textBox5 = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            бДКнигToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(32, 19);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(32, 19);
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(32, 19);
            // 
            // бДЧитателейToolStripMenuItem
            // 
            бДЧитателейToolStripMenuItem.Name = "бДЧитателейToolStripMenuItem";
            бДЧитателейToolStripMenuItem.Size = new Size(32, 19);
            // 
            // генераторОтчётовToolStripMenuItem
            // 
            генераторОтчётовToolStripMenuItem.Name = "генераторОтчётовToolStripMenuItem";
            генераторОтчётовToolStripMenuItem.Size = new Size(32, 19);
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(32, 19);
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(32, 19);
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(button_clearFindFilter);
            panel1.Controls.Add(button_clearFindPole);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(buttonDelAll);
            panel1.Controls.Add(buttonDeleteOne);
            panel1.Controls.Add(buttonFind);
            panel1.Controls.Add(textBoxFind);
            panel1.Location = new Point(12, 492);
            panel1.Name = "panel1";
            panel1.Size = new Size(1156, 125);
            panel1.TabIndex = 2;
            // 
            // button_clearFindFilter
            // 
            button_clearFindFilter.Location = new Point(13, 48);
            button_clearFindFilter.Name = "button_clearFindFilter";
            button_clearFindFilter.Size = new Size(141, 29);
            button_clearFindFilter.TabIndex = 9;
            button_clearFindFilter.Text = "Сбросить поиск";
            button_clearFindFilter.UseVisualStyleBackColor = true;
            button_clearFindFilter.Click += button_clearFindFilter_Click;
            // 
            // button_clearFindPole
            // 
            button_clearFindPole.Location = new Point(13, 83);
            button_clearFindPole.Name = "button_clearFindPole";
            button_clearFindPole.Size = new Size(141, 29);
            button_clearFindPole.TabIndex = 8;
            button_clearFindPole.Text = "Очистить поиск";
            button_clearFindPole.UseVisualStyleBackColor = true;
            button_clearFindPole.Click += button_clearFindPole_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label11.Location = new Point(160, 19);
            label11.Name = "label11";
            label11.Size = new Size(17, 23);
            label11.TabIndex = 7;
            label11.Text = "-";
            // 
            // buttonDelAll
            // 
            buttonDelAll.Location = new Point(850, 48);
            buttonDelAll.Name = "buttonDelAll";
            buttonDelAll.Size = new Size(288, 29);
            buttonDelAll.TabIndex = 5;
            buttonDelAll.Text = "Очистить всё";
            buttonDelAll.UseVisualStyleBackColor = true;
            buttonDelAll.Click += buttonDelAll_Click;
            // 
            // buttonDeleteOne
            // 
            buttonDeleteOne.Location = new Point(850, 14);
            buttonDeleteOne.Name = "buttonDeleteOne";
            buttonDeleteOne.Size = new Size(288, 29);
            buttonDeleteOne.TabIndex = 4;
            buttonDeleteOne.Text = "Удалить запись";
            buttonDeleteOne.UseVisualStyleBackColor = true;
            buttonDeleteOne.Click += buttonDeleteOne_Click;
            // 
            // buttonFind
            // 
            buttonFind.Location = new Point(13, 13);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(141, 29);
            buttonFind.TabIndex = 3;
            buttonFind.Text = "Поиск";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // textBoxFind
            // 
            textBoxFind.Location = new Point(183, 15);
            textBoxFind.Name = "textBoxFind";
            textBoxFind.Size = new Size(650, 27);
            textBoxFind.TabIndex = 2;
            // 
            // buttonChist
            // 
            buttonChist.Location = new Point(174, 353);
            buttonChist.Name = "buttonChist";
            buttonChist.Size = new Size(233, 29);
            buttonChist.TabIndex = 6;
            buttonChist.Text = "Очистить поля";
            buttonChist.UseVisualStyleBackColor = true;
            buttonChist.Click += buttonChist_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(buttonAddbook);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(buttonChist);
            panel2.Controls.Add(numericUpDown2);
            panel2.Controls.Add(numericUpDown1);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(1174, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(424, 575);
            panel2.TabIndex = 3;
            // 
            // buttonAddbook
            // 
            buttonAddbook.Location = new Point(12, 530);
            buttonAddbook.Name = "buttonAddbook";
            buttonAddbook.Size = new Size(395, 29);
            buttonAddbook.TabIndex = 19;
            buttonAddbook.Text = "Добавить запись";
            buttonAddbook.UseVisualStyleBackColor = true;
            buttonAddbook.Click += buttonAddbook_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 8.25F);
            label10.Location = new Point(12, 194);
            label10.Name = "label10";
            label10.Size = new Size(100, 17);
            label10.TabIndex = 18;
            label10.Text = "Издательство";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(174, 254);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(233, 27);
            textBox6.TabIndex = 17;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(174, 320);
            numericUpDown2.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.RightToLeft = RightToLeft.No;
            numericUpDown2.Size = new Size(233, 27);
            numericUpDown2.TabIndex = 16;
            numericUpDown2.TextAlign = HorizontalAlignment.Right;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(174, 287);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.RightToLeft = RightToLeft.No;
            numericUpDown1.Size = new Size(233, 27);
            numericUpDown1.TabIndex = 15;
            numericUpDown1.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(174, 222);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(233, 27);
            textBox5.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 257);
            label9.Name = "label9";
            label9.Size = new Size(123, 20);
            label9.TabIndex = 13;
            label9.Text = "Место хранения";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 322);
            label8.Name = "label8";
            label8.Size = new Size(75, 20);
            label8.TabIndex = 12;
            label8.Text = "Доступно";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 290);
            label7.Name = "label7";
            label7.Size = new Size(90, 20);
            label7.TabIndex = 11;
            label7.Text = "Количество";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 225);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 10;
            label6.Text = "Жанр";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 161);
            label5.Name = "label5";
            label5.Size = new Size(95, 20);
            label5.TabIndex = 9;
            label5.Text = "Год издания";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 126);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 8;
            label4.Text = "Автор";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(174, 156);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(233, 27);
            dateTimePicker1.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(174, 189);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(233, 27);
            textBox4.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(174, 123);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(233, 27);
            textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(174, 90);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(233, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(174, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(233, 27);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 93);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 2;
            label3.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(156, 20);
            label2.TabIndex = 1;
            label2.Text = "Инвентарный номер";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(105, 9);
            label1.Name = "label1";
            label1.Size = new Size(213, 23);
            label1.TabIndex = 0;
            label1.Text = "Данные для заполнения";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1156, 444);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // бДКнигToolStripMenuItem
            // 
            бДКнигToolStripMenuItem.Name = "бДКнигToolStripMenuItem";
            бДКнигToolStripMenuItem.Size = new Size(32, 19);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1610, 629);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "База данных книг в библиотеке";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolTip toolTip1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem бДЧитателейToolStripMenuItem;
        private ToolStripMenuItem генераторОтчётовToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private Button buttonDelAll;
        private Button buttonDeleteOne;
        private Button buttonFind;
        private TextBox textBoxFind;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private TextBox textBox5;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label10;
        private TextBox textBox6;
        private Button buttonAddbook;
        private Button buttonChist;
        private Label label11;
        private Button button_clearFindPole;
        private Button button_clearFindFilter;
        private DataGridView dataGridView1;
        private ToolStripMenuItem бДКнигToolStripMenuItem;
    }
}
