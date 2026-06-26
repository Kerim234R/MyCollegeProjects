namespace LibraryDataBase
{
    partial class FormBDchitat
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
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            textBoxInvChit = new TextBox();
            label7 = new Label();
            dateTimePicker1 = new DateTimePicker();
            buttonChist = new Button();
            buttonAddbook = new Button();
            label10 = new Label();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            label9 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            label11 = new Label();
            buttonDelAll = new Button();
            buttonDeleteOne = new Button();
            buttonFind = new Button();
            textBoxFind = new TextBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(825, 300);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(textBoxInvChit);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(buttonChist);
            panel2.Controls.Add(buttonAddbook);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(843, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(473, 428);
            panel2.TabIndex = 4;
            // 
            // textBoxInvChit
            // 
            textBoxInvChit.Location = new Point(195, 47);
            textBoxInvChit.Name = "textBoxInvChit";
            textBoxInvChit.Size = new Size(271, 27);
            textBoxInvChit.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 50);
            label7.Name = "label7";
            label7.Size = new Size(174, 20);
            label7.TabIndex = 21;
            label7.Text = "Номер билета читателя";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(195, 279);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(271, 27);
            dateTimePicker1.TabIndex = 20;
            // 
            // buttonChist
            // 
            buttonChist.Location = new Point(318, 7);
            buttonChist.Name = "buttonChist";
            buttonChist.Size = new Size(148, 29);
            buttonChist.TabIndex = 6;
            buttonChist.Text = "Очистить поля";
            buttonChist.UseVisualStyleBackColor = true;
            buttonChist.Click += buttonChist_Click;
            // 
            // buttonAddbook
            // 
            buttonAddbook.Location = new Point(12, 372);
            buttonAddbook.Name = "buttonAddbook";
            buttonAddbook.Size = new Size(454, 29);
            buttonAddbook.TabIndex = 19;
            buttonAddbook.Text = "Добавить запись";
            buttonAddbook.UseVisualStyleBackColor = true;
            buttonAddbook.Click += buttonAddbook_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 8.25F);
            label10.Location = new Point(12, 218);
            label10.Name = "label10";
            label10.Size = new Size(110, 17);
            label10.TabIndex = 18;
            label10.Text = "ФИО Родителя";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(195, 246);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(271, 27);
            textBox6.TabIndex = 17;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(195, 213);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(271, 27);
            textBox5.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 284);
            label9.Name = "label9";
            label9.Size = new Size(134, 20);
            label9.TabIndex = 13;
            label9.Text = "Дата регистрации";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 249);
            label6.Name = "label6";
            label6.Size = new Size(137, 20);
            label6.TabIndex = 10;
            label6.Text = "Телефон Родителя";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 183);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 9;
            label5.Text = "Телефон";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 148);
            label4.Name = "label4";
            label4.Size = new Size(177, 20);
            label4.TabIndex = 8;
            label4.Text = "Классный руководитель";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(195, 180);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(271, 27);
            textBox4.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(195, 145);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(271, 27);
            textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(195, 112);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(271, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(195, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(271, 27);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 2;
            label3.Text = "Класс";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 82);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 1;
            label2.Text = "ФИО читателя";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(213, 23);
            label1.TabIndex = 0;
            label1.Text = "Данные для заполнения";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label11);
            panel1.Controls.Add(buttonDelAll);
            panel1.Controls.Add(buttonDeleteOne);
            panel1.Controls.Add(buttonFind);
            panel1.Controls.Add(textBoxFind);
            panel1.Location = new Point(12, 315);
            panel1.Name = "panel1";
            panel1.Size = new Size(825, 125);
            panel1.TabIndex = 5;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label11.Location = new Point(152, 16);
            label11.Name = "label11";
            label11.Size = new Size(17, 23);
            label11.TabIndex = 7;
            label11.Text = "-";
            // 
            // buttonDelAll
            // 
            buttonDelAll.Location = new Point(665, 51);
            buttonDelAll.Name = "buttonDelAll";
            buttonDelAll.Size = new Size(141, 29);
            buttonDelAll.TabIndex = 5;
            buttonDelAll.Text = "Очистить всё";
            buttonDelAll.UseVisualStyleBackColor = true;
            buttonDelAll.Click += buttonDelAll_Click;
            // 
            // buttonDeleteOne
            // 
            buttonDeleteOne.Location = new Point(665, 16);
            buttonDeleteOne.Name = "buttonDeleteOne";
            buttonDeleteOne.Size = new Size(141, 29);
            buttonDeleteOne.TabIndex = 4;
            buttonDeleteOne.Text = "Удалить запись";
            buttonDeleteOne.UseVisualStyleBackColor = true;
            buttonDeleteOne.Click += buttonDeleteOne_Click;
            // 
            // buttonFind
            // 
            buttonFind.Location = new Point(16, 15);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(141, 29);
            buttonFind.TabIndex = 3;
            buttonFind.Text = "Поиск";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // textBoxFind
            // 
            textBoxFind.Location = new Point(163, 16);
            textBoxFind.Name = "textBoxFind";
            textBoxFind.Size = new Size(496, 27);
            textBoxFind.TabIndex = 2;
            // 
            // FormBDchitat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 465);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(dataGridView1);
            Name = "FormBDchitat";
            Text = "База данных читателей";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel2;
        private Button buttonAddbook;
        private Label label10;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label label9;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Panel panel1;
        private Label label11;
        private Button buttonChist;
        private Button buttonDelAll;
        private Button buttonDeleteOne;
        private Button buttonFind;
        private TextBox textBoxFind;
        private ToolTip toolTip1;
        private TextBox textBoxInvChit;
        private Label label7;
    }
}