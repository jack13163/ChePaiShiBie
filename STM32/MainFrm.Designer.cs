namespace STM32
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnLocation = new System.Windows.Forms.Button();
            this.pbToRec = new System.Windows.Forms.PictureBox();
            this.btnSmoothing = new System.Windows.Forms.Button();
            this.btnGraying = new System.Windows.Forms.Button();
            this.btnMeaning = new System.Windows.Forms.Button();
            this.btnCutCharacter = new System.Windows.Forms.Button();
            this.btnBinary = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOstu = new System.Windows.Forms.Button();
            this.btnEdging = new System.Windows.Forms.Button();
            this.btnGuass = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInnerPointCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLineCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPointCount = new System.Windows.Forms.TextBox();
            this.btnDilation = new System.Windows.Forms.Button();
            this.btnErosion = new System.Windows.Forms.Button();
            this.btnGrayReverse = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnResize = new System.Windows.Forms.Button();
            this.btnVertical = new System.Windows.Forms.Button();
            this.btnHorizel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbLocationResult = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pbCutPart2 = new System.Windows.Forms.PictureBox();
            this.pbCutPart1 = new System.Windows.Forms.PictureBox();
            this.pbCutPart6 = new System.Windows.Forms.PictureBox();
            this.pbCutPart7 = new System.Windows.Forms.PictureBox();
            this.pbCutPart4 = new System.Windows.Forms.PictureBox();
            this.pbCutPart5 = new System.Windows.Forms.PictureBox();
            this.pbCutPart3 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pbJZResult = new System.Windows.Forms.PictureBox();
            this.pbHorizelJZ = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStepWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKCount = new System.Windows.Forms.TextBox();
            this.btnRec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbToRec)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocationResult)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJZResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorizelJZ)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(1257, 35);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(90, 30);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "打开图片";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(876, 23);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(90, 30);
            this.btnLocation.TabIndex = 1;
            this.btnLocation.Text = "车牌定位";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // pbToRec
            // 
            this.pbToRec.Location = new System.Drawing.Point(8, 20);
            this.pbToRec.Name = "pbToRec";
            this.pbToRec.Size = new System.Drawing.Size(964, 541);
            this.pbToRec.TabIndex = 2;
            this.pbToRec.TabStop = false;
            // 
            // btnSmoothing
            // 
            this.btnSmoothing.Location = new System.Drawing.Point(8, 24);
            this.btnSmoothing.Name = "btnSmoothing";
            this.btnSmoothing.Size = new System.Drawing.Size(90, 30);
            this.btnSmoothing.TabIndex = 3;
            this.btnSmoothing.Text = "均值滤波";
            this.btnSmoothing.UseVisualStyleBackColor = true;
            this.btnSmoothing.Click += new System.EventHandler(this.btnSmoothing_Click);
            // 
            // btnGraying
            // 
            this.btnGraying.Location = new System.Drawing.Point(8, 23);
            this.btnGraying.Name = "btnGraying";
            this.btnGraying.Size = new System.Drawing.Size(90, 30);
            this.btnGraying.TabIndex = 4;
            this.btnGraying.Text = "灰度化";
            this.btnGraying.UseVisualStyleBackColor = true;
            this.btnGraying.Click += new System.EventHandler(this.btnGraying_Click);
            // 
            // btnMeaning
            // 
            this.btnMeaning.Location = new System.Drawing.Point(138, 24);
            this.btnMeaning.Name = "btnMeaning";
            this.btnMeaning.Size = new System.Drawing.Size(134, 30);
            this.btnMeaning.TabIndex = 5;
            this.btnMeaning.Text = "直方图均值化";
            this.btnMeaning.UseVisualStyleBackColor = true;
            this.btnMeaning.Click += new System.EventHandler(this.btnMeaning_Click);
            // 
            // btnCutCharacter
            // 
            this.btnCutCharacter.Location = new System.Drawing.Point(232, 24);
            this.btnCutCharacter.Name = "btnCutCharacter";
            this.btnCutCharacter.Size = new System.Drawing.Size(90, 30);
            this.btnCutCharacter.TabIndex = 6;
            this.btnCutCharacter.Text = "字符分割";
            this.btnCutCharacter.UseVisualStyleBackColor = true;
            this.btnCutCharacter.Click += new System.EventHandler(this.btnCutCharacter_Click);
            // 
            // btnBinary
            // 
            this.btnBinary.Location = new System.Drawing.Point(752, 24);
            this.btnBinary.Name = "btnBinary";
            this.btnBinary.Size = new System.Drawing.Size(100, 30);
            this.btnBinary.TabIndex = 7;
            this.btnBinary.Text = "图像二值化";
            this.btnBinary.UseVisualStyleBackColor = true;
            this.btnBinary.Click += new System.EventHandler(this.btnBinary_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOstu);
            this.groupBox1.Controls.Add(this.btnEdging);
            this.groupBox1.Controls.Add(this.btnGuass);
            this.groupBox1.Controls.Add(this.btnLocation);
            this.groupBox1.Controls.Add(this.btnGraying);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 68);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "车牌定位";
            // 
            // btnOstu
            // 
            this.btnOstu.Location = new System.Drawing.Point(344, 23);
            this.btnOstu.Name = "btnOstu";
            this.btnOstu.Size = new System.Drawing.Size(104, 30);
            this.btnOstu.TabIndex = 13;
            this.btnOstu.Text = "OSTU二值化";
            this.btnOstu.UseVisualStyleBackColor = true;
            this.btnOstu.Click += new System.EventHandler(this.btnOstu_Click);
            // 
            // btnEdging
            // 
            this.btnEdging.Location = new System.Drawing.Point(234, 23);
            this.btnEdging.Name = "btnEdging";
            this.btnEdging.Size = new System.Drawing.Size(90, 30);
            this.btnEdging.TabIndex = 11;
            this.btnEdging.Text = "边缘检测";
            this.btnEdging.UseVisualStyleBackColor = true;
            this.btnEdging.Click += new System.EventHandler(this.btnEdging_Click);
            // 
            // btnGuass
            // 
            this.btnGuass.Location = new System.Drawing.Point(120, 23);
            this.btnGuass.Name = "btnGuass";
            this.btnGuass.Size = new System.Drawing.Size(90, 30);
            this.btnGuass.TabIndex = 1;
            this.btnGuass.Text = "高斯滤波";
            this.btnGuass.UseVisualStyleBackColor = true;
            this.btnGuass.Click += new System.EventHandler(this.btnGuass_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "框内跳变点数：";
            // 
            // txtInnerPointCount
            // 
            this.txtInnerPointCount.Location = new System.Drawing.Point(145, 99);
            this.txtInnerPointCount.Name = "txtInnerPointCount";
            this.txtInnerPointCount.Size = new System.Drawing.Size(47, 25);
            this.txtInnerPointCount.TabIndex = 19;
            this.txtInnerPointCount.Text = "150";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "连续行数：";
            // 
            // txtLineCount
            // 
            this.txtLineCount.Location = new System.Drawing.Point(145, 62);
            this.txtLineCount.Name = "txtLineCount";
            this.txtLineCount.Size = new System.Drawing.Size(47, 25);
            this.txtLineCount.TabIndex = 17;
            this.txtLineCount.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "行跳变点：";
            // 
            // txtPointCount
            // 
            this.txtPointCount.Location = new System.Drawing.Point(145, 25);
            this.txtPointCount.Name = "txtPointCount";
            this.txtPointCount.Size = new System.Drawing.Size(47, 25);
            this.txtPointCount.TabIndex = 15;
            this.txtPointCount.Text = "30";
            // 
            // btnDilation
            // 
            this.btnDilation.Location = new System.Drawing.Point(296, 24);
            this.btnDilation.Name = "btnDilation";
            this.btnDilation.Size = new System.Drawing.Size(90, 30);
            this.btnDilation.TabIndex = 10;
            this.btnDilation.Text = "图像膨胀";
            this.btnDilation.UseVisualStyleBackColor = true;
            this.btnDilation.Click += new System.EventHandler(this.btnDilation_Click);
            // 
            // btnErosion
            // 
            this.btnErosion.Location = new System.Drawing.Point(410, 24);
            this.btnErosion.Name = "btnErosion";
            this.btnErosion.Size = new System.Drawing.Size(90, 30);
            this.btnErosion.TabIndex = 9;
            this.btnErosion.Text = "图像腐蚀";
            this.btnErosion.UseVisualStyleBackColor = true;
            this.btnErosion.Click += new System.EventHandler(this.btnErosion_Click);
            // 
            // btnGrayReverse
            // 
            this.btnGrayReverse.Location = new System.Drawing.Point(876, 24);
            this.btnGrayReverse.Name = "btnGrayReverse";
            this.btnGrayReverse.Size = new System.Drawing.Size(90, 30);
            this.btnGrayReverse.TabIndex = 8;
            this.btnGrayReverse.Text = "灰度反转";
            this.btnGrayReverse.UseVisualStyleBackColor = true;
            this.btnGrayReverse.Click += new System.EventHandler(this.btnGrayReverse_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRec);
            this.groupBox3.Controls.Add(this.btnResize);
            this.groupBox3.Controls.Add(this.btnVertical);
            this.groupBox3.Controls.Add(this.btnHorizel);
            this.groupBox3.Controls.Add(this.btnCutCharacter);
            this.groupBox3.Location = new System.Drawing.Point(21, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(984, 67);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "字符分割与识别";
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(344, 24);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(77, 30);
            this.btnResize.TabIndex = 12;
            this.btnResize.Text = "归一化";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnVertical
            // 
            this.btnVertical.Location = new System.Drawing.Point(120, 24);
            this.btnVertical.Name = "btnVertical";
            this.btnVertical.Size = new System.Drawing.Size(90, 30);
            this.btnVertical.TabIndex = 11;
            this.btnVertical.Text = "竖直矫正";
            this.btnVertical.UseVisualStyleBackColor = true;
            this.btnVertical.Click += new System.EventHandler(this.btnVertical_Click);
            // 
            // btnHorizel
            // 
            this.btnHorizel.Location = new System.Drawing.Point(8, 24);
            this.btnHorizel.Name = "btnHorizel";
            this.btnHorizel.Size = new System.Drawing.Size(90, 30);
            this.btnHorizel.TabIndex = 11;
            this.btnHorizel.Text = "水平矫正";
            this.btnHorizel.UseVisualStyleBackColor = true;
            this.btnHorizel.Click += new System.EventHandler(this.btnQXJZ_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pbToRec);
            this.groupBox4.Location = new System.Drawing.Point(21, 244);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(984, 587);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "识别过程";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1257, 89);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "保存图片";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Location = new System.Drawing.Point(524, 24);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(90, 30);
            this.btnRectangle.TabIndex = 12;
            this.btnRectangle.Text = "开运算";
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(638, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "闭运算";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbLocationResult
            // 
            this.pbLocationResult.Location = new System.Drawing.Point(126, 24);
            this.pbLocationResult.Name = "pbLocationResult";
            this.pbLocationResult.Size = new System.Drawing.Size(228, 80);
            this.pbLocationResult.TabIndex = 16;
            this.pbLocationResult.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblResult);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.pbCutPart2);
            this.groupBox2.Controls.Add(this.pbCutPart1);
            this.groupBox2.Controls.Add(this.pbCutPart6);
            this.groupBox2.Controls.Add(this.pbCutPart7);
            this.groupBox2.Controls.Add(this.pbCutPart4);
            this.groupBox2.Controls.Add(this.pbCutPart5);
            this.groupBox2.Controls.Add(this.pbCutPart3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.pbJZResult);
            this.groupBox2.Controls.Add(this.pbHorizelJZ);
            this.groupBox2.Controls.Add(this.pbLocationResult);
            this.groupBox2.Location = new System.Drawing.Point(1011, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 593);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "识别结果";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(142, 480);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 15);
            this.lblResult.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 480);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "识别结果：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "分割结果：";
            // 
            // pbCutPart2
            // 
            this.pbCutPart2.Location = new System.Drawing.Point(196, 284);
            this.pbCutPart2.Name = "pbCutPart2";
            this.pbCutPart2.Size = new System.Drawing.Size(46, 69);
            this.pbCutPart2.TabIndex = 26;
            this.pbCutPart2.TabStop = false;
            // 
            // pbCutPart1
            // 
            this.pbCutPart1.Location = new System.Drawing.Point(126, 284);
            this.pbCutPart1.Name = "pbCutPart1";
            this.pbCutPart1.Size = new System.Drawing.Size(46, 69);
            this.pbCutPart1.TabIndex = 25;
            this.pbCutPart1.TabStop = false;
            // 
            // pbCutPart6
            // 
            this.pbCutPart6.Location = new System.Drawing.Point(233, 376);
            this.pbCutPart6.Name = "pbCutPart6";
            this.pbCutPart6.Size = new System.Drawing.Size(46, 69);
            this.pbCutPart6.TabIndex = 24;
            this.pbCutPart6.TabStop = false;
            // 
            // pbCutPart7
            // 
            this.pbCutPart7.Location = new System.Drawing.Point(299, 376);
            this.pbCutPart7.Name = "pbCutPart7";
            this.pbCutPart7.Size = new System.Drawing.Size(46, 69);
            this.pbCutPart7.TabIndex = 23;
            this.pbCutPart7.TabStop = false;
            // 
            // pbCutPart4
            // 
            this.pbCutPart4.Location = new System.Drawing.Point(101, 376);
            this.pbCutPart4.Name = "pbCutPart4";
            this.pbCutPart4.Size = new System.Drawing.Size(46, 69);
            this.pbCutPart4.TabIndex = 24;
            this.pbCutPart4.TabStop = false;
            // 
            // pbCutPart5
            // 
            this.pbCutPart5.Location = new System.Drawing.Point(167, 376);
            this.pbCutPart5.Name = "pbCutPart5";
            this.pbCutPart5.Size = new System.Drawing.Size(46, 69);
            this.pbCutPart5.TabIndex = 23;
            this.pbCutPart5.TabStop = false;
            // 
            // pbCutPart3
            // 
            this.pbCutPart3.Location = new System.Drawing.Point(35, 376);
            this.pbCutPart3.Name = "pbCutPart3";
            this.pbCutPart3.Size = new System.Drawing.Size(46, 69);
            this.pbCutPart3.TabIndex = 22;
            this.pbCutPart3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "左右边界矫正：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "上下边界矫正：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "定位结果：";
            // 
            // pbJZResult
            // 
            this.pbJZResult.Location = new System.Drawing.Point(126, 201);
            this.pbJZResult.Name = "pbJZResult";
            this.pbJZResult.Size = new System.Drawing.Size(228, 52);
            this.pbJZResult.TabIndex = 18;
            this.pbJZResult.TabStop = false;
            // 
            // pbHorizelJZ
            // 
            this.pbHorizelJZ.Location = new System.Drawing.Point(126, 125);
            this.pbHorizelJZ.Name = "pbHorizelJZ";
            this.pbHorizelJZ.Size = new System.Drawing.Size(228, 52);
            this.pbHorizelJZ.TabIndex = 17;
            this.pbHorizelJZ.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSmoothing);
            this.groupBox5.Controls.Add(this.btnBinary);
            this.groupBox5.Controls.Add(this.btnMeaning);
            this.groupBox5.Controls.Add(this.btnGrayReverse);
            this.groupBox5.Controls.Add(this.btnErosion);
            this.groupBox5.Controls.Add(this.btnDilation);
            this.groupBox5.Controls.Add(this.btnClose);
            this.groupBox5.Controls.Add(this.btnRectangle);
            this.groupBox5.Location = new System.Drawing.Point(21, 89);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(984, 76);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "图像处理";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.txtStepWidth);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.txtKCount);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.txtInnerPointCount);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.txtPointCount);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.txtLineCount);
            this.groupBox6.Location = new System.Drawing.Point(1011, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(212, 226);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "车牌定位阀值配置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "框的移动步长：";
            // 
            // txtStepWidth
            // 
            this.txtStepWidth.Location = new System.Drawing.Point(145, 173);
            this.txtStepWidth.Name = "txtStepWidth";
            this.txtStepWidth.Size = new System.Drawing.Size(47, 25);
            this.txtStepWidth.TabIndex = 23;
            this.txtStepWidth.Text = "40";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "连续框数：";
            // 
            // txtKCount
            // 
            this.txtKCount.Location = new System.Drawing.Point(145, 136);
            this.txtKCount.Name = "txtKCount";
            this.txtKCount.Size = new System.Drawing.Size(47, 25);
            this.txtKCount.TabIndex = 21;
            this.txtKCount.Text = "30";
            // 
            // btnRec
            // 
            this.btnRec.Location = new System.Drawing.Point(450, 24);
            this.btnRec.Name = "btnRec";
            this.btnRec.Size = new System.Drawing.Size(93, 30);
            this.btnRec.TabIndex = 13;
            this.btnRec.Text = "模板识别";
            this.btnRec.UseVisualStyleBackColor = true;
            this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 843);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.Text = "车牌识别系统";
            ((System.ComponentModel.ISupportInitialize)(this.pbToRec)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLocationResult)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCutPart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJZResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHorizelJZ)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.PictureBox pbToRec;
        private System.Windows.Forms.Button btnSmoothing;
        private System.Windows.Forms.Button btnGraying;
        private System.Windows.Forms.Button btnMeaning;
        private System.Windows.Forms.Button btnCutCharacter;
        private System.Windows.Forms.Button btnBinary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGuass;
        private System.Windows.Forms.Button btnGrayReverse;
        private System.Windows.Forms.Button btnDilation;
        private System.Windows.Forms.Button btnErosion;
        private System.Windows.Forms.Button btnEdging;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnOstu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbLocationResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPointCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLineCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInnerPointCount;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnHorizel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStepWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKCount;
        private System.Windows.Forms.PictureBox pbHorizelJZ;
        private System.Windows.Forms.PictureBox pbJZResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVertical;
        private System.Windows.Forms.PictureBox pbCutPart2;
        private System.Windows.Forms.PictureBox pbCutPart1;
        private System.Windows.Forms.PictureBox pbCutPart6;
        private System.Windows.Forms.PictureBox pbCutPart7;
        private System.Windows.Forms.PictureBox pbCutPart4;
        private System.Windows.Forms.PictureBox pbCutPart5;
        private System.Windows.Forms.PictureBox pbCutPart3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Button btnRec;
    }
}

