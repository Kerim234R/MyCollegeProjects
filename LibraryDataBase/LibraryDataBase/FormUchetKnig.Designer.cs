namespace LibraryDataBase
{
    partial class FormUchetKnig
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            бДКнигToolStripMenuItem = new ToolStripMenuItem();
            бДЧитателейToolStripMenuItem = new ToolStripMenuItem();
            генераторОтчётовToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            открытьZnaniumToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            buttonGiveBook = new Button();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            buttonTakeBack = new Button();
            buttonFind = new Button();
            buttonClear = new Button();
            buttonStory = new Button();
            toolTip1 = new ToolTip(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Highlight;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, открытьToolStripMenuItem, справкаToolStripMenuItem, открытьZnaniumToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1319, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(136, 26);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { бДКнигToolStripMenuItem, бДЧитателейToolStripMenuItem, генераторОтчётовToolStripMenuItem });
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(81, 24);
            открытьToolStripMenuItem.Text = "Открыть";
            // 
            // бДКнигToolStripMenuItem
            // 
            бДКнигToolStripMenuItem.Name = "бДКнигToolStripMenuItem";
            бДКнигToolStripMenuItem.Size = new Size(223, 26);
            бДКнигToolStripMenuItem.Text = "БД Книг";
            бДКнигToolStripMenuItem.Click += бДКнигToolStripMenuItem_Click;
            // 
            // бДЧитателейToolStripMenuItem
            // 
            бДЧитателейToolStripMenuItem.Name = "бДЧитателейToolStripMenuItem";
            бДЧитателейToolStripMenuItem.Size = new Size(223, 26);
            бДЧитателейToolStripMenuItem.Text = "БД Читателей";
            бДЧитателейToolStripMenuItem.Click += бДЧитателейToolStripMenuItem_Click;
            // 
            // генераторОтчётовToolStripMenuItem
            // 
            генераторОтчётовToolStripMenuItem.Name = "генераторОтчётовToolStripMenuItem";
            генераторОтчётовToolStripMenuItem.Size = new Size(223, 26);
            генераторОтчётовToolStripMenuItem.Text = "Генератор отчётов";
            генераторОтчётовToolStripMenuItem.Click += генераторОтчётовToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { оПрограммеToolStripMenuItem });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(81, 24);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(187, 26);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // открытьZnaniumToolStripMenuItem
            // 
            открытьZnaniumToolStripMenuItem.Name = "открытьZnaniumToolStripMenuItem";
            открытьZnaniumToolStripMenuItem.Size = new Size(143, 24);
            открытьZnaniumToolStripMenuItem.Text = "Открыть Znanium";
            открытьZnaniumToolStripMenuItem.Click += открытьZnaniumToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(968, 516);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(buttonGiveBook);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(986, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(321, 373);
            panel1.TabIndex = 3;
            // 
            // buttonGiveBook
            // 
            buttonGiveBook.Location = new Point(17, 325);
            buttonGiveBook.Name = "buttonGiveBook";
            buttonGiveBook.Size = new Size(284, 29);
            buttonGiveBook.TabIndex = 9;
            buttonGiveBook.Text = "Оформить выдачу";
            buttonGiveBook.UseVisualStyleBackColor = true;
            buttonGiveBook.Click += buttonGiveBook_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(17, 255);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(284, 27);
            dateTimePicker1.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 223);
            label6.Name = "label6";
            label6.Size = new Size(229, 20);
            label6.TabIndex = 7;
            label6.Text = "Предполагаемая дата возврата";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 193);
            label4.Name = "label4";
            label4.Size = new Size(285, 20);
            label4.TabIndex = 6;
            label4.Text = "______________________________________________";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(17, 163);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(284, 27);
            textBox2.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 140);
            label5.Name = "label5";
            label5.Size = new Size(212, 20);
            label5.TabIndex = 4;
            label5.Text = "Номер читательского билета";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 108);
            label3.Name = "label3";
            label3.Size = new Size(285, 20);
            label3.TabIndex = 3;
            label3.Text = "______________________________________________";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 78);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(284, 27);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 55);
            label2.Name = "label2";
            label2.Size = new Size(200, 20);
            label2.TabIndex = 1;
            label2.Text = "Инвентарный номер книги";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(32, 11);
            label1.Name = "label1";
            label1.Size = new Size(259, 28);
            label1.TabIndex = 0;
            label1.Text = "Оформить выдачу книги";
            // 
            // buttonTakeBack
            // 
            buttonTakeBack.Location = new Point(986, 420);
            buttonTakeBack.Name = "buttonTakeBack";
            buttonTakeBack.Size = new Size(321, 29);
            buttonTakeBack.TabIndex = 4;
            buttonTakeBack.Text = "Оформить возврат";
            buttonTakeBack.UseVisualStyleBackColor = true;
            buttonTakeBack.Click += buttonTakeBack_Click;
            // 
            // buttonFind
            // 
            buttonFind.Location = new Point(986, 490);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(321, 29);
            buttonFind.TabIndex = 5;
            buttonFind.Text = "Найти запись о...";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(986, 455);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(321, 29);
            buttonClear.TabIndex = 6;
            buttonClear.Text = "Удалить запись";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonStory
            // 
            buttonStory.Location = new Point(986, 525);
            buttonStory.Name = "buttonStory";
            buttonStory.Size = new Size(321, 29);
            buttonStory.TabIndex = 7;
            buttonStory.Text = "История возвратов";
            buttonStory.UseVisualStyleBackColor = true;
            buttonStory.Click += buttonStory_Click;
            // 
            // FormUchetKnig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1319, 569);
            Controls.Add(buttonStory);
            Controls.Add(buttonClear);
            Controls.Add(buttonFind);
            Controls.Add(buttonTakeBack);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            Name = "FormUchetKnig";
            Text = "База данных библиотеки";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem бДЧитателейToolStripMenuItem;
        private ToolStripMenuItem генераторОтчётовToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem бДКнигToolStripMenuItem;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private Button buttonGiveBook;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private Button buttonTakeBack;
        private Button buttonFind;
        private Button buttonClear;
        private Button buttonStory;
        private ToolTip toolTip1;
        private ToolStripMenuItem открытьZnaniumToolStripMenuItem;
    }
}