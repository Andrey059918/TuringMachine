namespace TuringMachine
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._MenuFileImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this._MenuFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._MenuSimulation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._MenuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this._DescriptionPanel = new System.Windows.Forms.RichTextBox();
            this._DescriptionLabel = new System.Windows.Forms.Label();
            this._TapePanel = new System.Windows.Forms.FlowLayoutPanel();
            this._TapeLabel = new System.Windows.Forms.Label();
            this._ProgPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._ProgLabel = new System.Windows.Forms.Label();
            this._TapePageLeft = new System.Windows.Forms.Button();
            this._TapeCellLeft = new System.Windows.Forms.Button();
            this._TapePageRight = new System.Windows.Forms.Button();
            this._TapeCellRight = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._ToolsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this._ProgTimer = new System.Windows.Forms.Timer(this.components);
            this.ResizerTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveTimer = new System.Windows.Forms.Timer(this.components);
            this._MenuFileCreate = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuFileReload = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuFileImportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuFileImportPolyakov = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuFileExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuSimulationStart = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuSimulationStop = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuSimulationStep = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuSimulationDelay = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuSimulationDelay0 = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuSimulationDelay100 = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuSimulationDelay250 = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuSimulationDelay500 = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuSimulationDelay1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._MenuSimulationDelayCustom = new System.Windows.Forms.ToolStripMenuItem();
            this._MenuSimulationDelayValue = new System.Windows.Forms.ToolStripTextBox();
            this.машинаТьюрингаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаВЭмулятореToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuFile,
            this._MenuSimulation,
            this._MenuInfo});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1131, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Menu";
            // 
            // _MenuFile
            // 
            this._MenuFile.AutoSize = false;
            this._MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuFileCreate,
            this.toolStripSeparator3,
            this._MenuFileOpen,
            this._MenuFileReload,
            this._MenuFileImport,
            this.toolStripSeparator5,
            this._MenuFileSave,
            this._MenuFileSaveAs,
            this._MenuFileExport,
            this.toolStripSeparator4,
            this._MenuFileExit});
            this._MenuFile.Name = "_MenuFile";
            this._MenuFile.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._MenuFile.Size = new System.Drawing.Size(60, 20);
            this._MenuFile.Text = "Файл";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(234, 6);
            // 
            // _MenuFileImport
            // 
            this._MenuFileImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuFileImportExcel,
            this._MenuFileImportPolyakov});
            this._MenuFileImport.Name = "_MenuFileImport";
            this._MenuFileImport.Padding = new System.Windows.Forms.Padding(0);
            this._MenuFileImport.ShowShortcutKeys = false;
            this._MenuFileImport.Size = new System.Drawing.Size(237, 20);
            this._MenuFileImport.Text = "Импорт";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(234, 6);
            // 
            // _MenuFileExport
            // 
            this._MenuFileExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuFileExportExcel});
            this._MenuFileExport.Name = "_MenuFileExport";
            this._MenuFileExport.Padding = new System.Windows.Forms.Padding(0);
            this._MenuFileExport.ShowShortcutKeys = false;
            this._MenuFileExport.Size = new System.Drawing.Size(237, 20);
            this._MenuFileExport.Text = "Экспорт";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(234, 6);
            // 
            // _MenuSimulation
            // 
            this._MenuSimulation.AutoSize = false;
            this._MenuSimulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuSimulationStart,
            this._MenuSimulationStop,
            this._MenuSimulationStep,
            this.toolStripSeparator1,
            this._MenuSimulationDelay});
            this._MenuSimulation.Name = "_MenuSimulation";
            this._MenuSimulation.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._MenuSimulation.Size = new System.Drawing.Size(122, 20);
            this._MenuSimulation.Text = "Выполнение";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // _MenuInfo
            // 
            this._MenuInfo.AutoSize = false;
            this._MenuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.машинаТьюрингаToolStripMenuItem,
            this.работаВЭмулятореToolStripMenuItem,
            this.toolStripSeparator6,
            this.оПрограммеToolStripMenuItem});
            this._MenuInfo.Name = "_MenuInfo";
            this._MenuInfo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this._MenuInfo.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this._MenuInfo.Size = new System.Drawing.Size(80, 20);
            this._MenuInfo.Text = "Помощь";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(180, 6);
            // 
            // _DescriptionPanel
            // 
            this._DescriptionPanel.AcceptsTab = true;
            this._DescriptionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._DescriptionPanel.DetectUrls = false;
            this._DescriptionPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._DescriptionPanel.Location = new System.Drawing.Point(10, 50);
            this._DescriptionPanel.Margin = new System.Windows.Forms.Padding(0);
            this._DescriptionPanel.Name = "_DescriptionPanel";
            this._DescriptionPanel.Size = new System.Drawing.Size(988, 150);
            this._DescriptionPanel.TabIndex = 1;
            this._DescriptionPanel.TabStop = false;
            this._DescriptionPanel.Text = "";
            // 
            // _DescriptionLabel
            // 
            this._DescriptionLabel.AutoSize = true;
            this._DescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._DescriptionLabel.Location = new System.Drawing.Point(10, 30);
            this._DescriptionLabel.Name = "_DescriptionLabel";
            this._DescriptionLabel.Size = new System.Drawing.Size(79, 20);
            this._DescriptionLabel.TabIndex = 2;
            this._DescriptionLabel.Text = "Описание";
            // 
            // _TapePanel
            // 
            this._TapePanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._TapePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._TapePanel.Location = new System.Drawing.Point(80, 240);
            this._TapePanel.Margin = new System.Windows.Forms.Padding(0);
            this._TapePanel.Name = "_TapePanel";
            this._TapePanel.Size = new System.Drawing.Size(883, 42);
            this._TapePanel.TabIndex = 3;
            this._TapePanel.WrapContents = false;
            // 
            // _TapeLabel
            // 
            this._TapeLabel.AutoSize = true;
            this._TapeLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._TapeLabel.Location = new System.Drawing.Point(10, 220);
            this._TapeLabel.Name = "_TapeLabel";
            this._TapeLabel.Size = new System.Drawing.Size(50, 20);
            this._TapeLabel.TabIndex = 4;
            this._TapeLabel.Text = "Лента";
            // 
            // _ProgPanel
            // 
            this._ProgPanel.AutoScroll = true;
            this._ProgPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._ProgPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ProgPanel.Location = new System.Drawing.Point(154, 320);
            this._ProgPanel.Margin = new System.Windows.Forms.Padding(0);
            this._ProgPanel.Name = "_ProgPanel";
            this._ProgPanel.Size = new System.Drawing.Size(846, 247);
            this._ProgPanel.TabIndex = 5;
            this._ProgPanel.WrapContents = false;
            // 
            // _ProgLabel
            // 
            this._ProgLabel.AutoSize = true;
            this._ProgLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._ProgLabel.Location = new System.Drawing.Point(10, 300);
            this._ProgLabel.Name = "_ProgLabel";
            this._ProgLabel.Size = new System.Drawing.Size(91, 20);
            this._ProgLabel.TabIndex = 6;
            this._ProgLabel.Text = "Программа";
            // 
            // _TapePageLeft
            // 
            this._TapePageLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._TapePageLeft.Location = new System.Drawing.Point(10, 240);
            this._TapePageLeft.Name = "_TapePageLeft";
            this._TapePageLeft.Size = new System.Drawing.Size(40, 42);
            this._TapePageLeft.TabIndex = 7;
            this._TapePageLeft.Text = "-10";
            this._TapePageLeft.UseVisualStyleBackColor = true;
            // 
            // _TapeCellLeft
            // 
            this._TapeCellLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._TapeCellLeft.Location = new System.Drawing.Point(49, 240);
            this._TapeCellLeft.Name = "_TapeCellLeft";
            this._TapeCellLeft.Size = new System.Drawing.Size(30, 42);
            this._TapeCellLeft.TabIndex = 8;
            this._TapeCellLeft.Text = "-1";
            this._TapeCellLeft.UseVisualStyleBackColor = true;
            // 
            // _TapePageRight
            // 
            this._TapePageRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._TapePageRight.Location = new System.Drawing.Point(998, 240);
            this._TapePageRight.Name = "_TapePageRight";
            this._TapePageRight.Size = new System.Drawing.Size(40, 42);
            this._TapePageRight.TabIndex = 10;
            this._TapePageRight.Text = "+10";
            this._TapePageRight.UseVisualStyleBackColor = true;
            // 
            // _TapeCellRight
            // 
            this._TapeCellRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._TapeCellRight.Location = new System.Drawing.Point(968, 240);
            this._TapeCellRight.Name = "_TapeCellRight";
            this._TapeCellRight.Size = new System.Drawing.Size(30, 42);
            this._TapeCellRight.TabIndex = 9;
            this._TapeCellRight.Text = "+1";
            this._TapeCellRight.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 591);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1131, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _ToolsStatus
            // 
            this._ToolsStatus.Name = "_ToolsStatus";
            this._ToolsStatus.Size = new System.Drawing.Size(118, 17);
            this._ToolsStatus.Text = "toolStripStatusLabel1";
            // 
            // ResizerTimer
            // 
            this.ResizerTimer.Interval = 50;
            // 
            // MoveTimer
            // 
            this.MoveTimer.Interval = 250;
            // 
            // _MenuFileCreate
            // 
            this._MenuFileCreate.Image = global::TuringMachine.Properties.Resources.Create;
            this._MenuFileCreate.Name = "_MenuFileCreate";
            this._MenuFileCreate.Padding = new System.Windows.Forms.Padding(0);
            this._MenuFileCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._MenuFileCreate.Size = new System.Drawing.Size(237, 20);
            this._MenuFileCreate.Text = "Создать";
            // 
            // _MenuFileOpen
            // 
            this._MenuFileOpen.Image = global::TuringMachine.Properties.Resources.LoadFile;
            this._MenuFileOpen.Name = "_MenuFileOpen";
            this._MenuFileOpen.Padding = new System.Windows.Forms.Padding(0);
            this._MenuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._MenuFileOpen.Size = new System.Drawing.Size(237, 20);
            this._MenuFileOpen.Text = "Открыть";
            // 
            // _MenuFileReload
            // 
            this._MenuFileReload.Image = global::TuringMachine.Properties.Resources.Refresh20;
            this._MenuFileReload.Name = "_MenuFileReload";
            this._MenuFileReload.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this._MenuFileReload.Size = new System.Drawing.Size(237, 22);
            this._MenuFileReload.Text = "Восстановить";
            // 
            // _MenuFileImportExcel
            // 
            this._MenuFileImportExcel.Image = global::TuringMachine.Properties.Resources.Excel24;
            this._MenuFileImportExcel.Name = "_MenuFileImportExcel";
            this._MenuFileImportExcel.Size = new System.Drawing.Size(164, 22);
            this._MenuFileImportExcel.Text = "Excel table (.xlsx)";
            // 
            // _MenuFileImportPolyakov
            // 
            this._MenuFileImportPolyakov.Image = global::TuringMachine.Properties.Resources.TuringMachine;
            this._MenuFileImportPolyakov.Name = "_MenuFileImportPolyakov";
            this._MenuFileImportPolyakov.Size = new System.Drawing.Size(164, 22);
            this._MenuFileImportPolyakov.Text = "К. Поляков (.tur)";
            // 
            // _MenuFileSave
            // 
            this._MenuFileSave.Image = global::TuringMachine.Properties.Resources.SaveFile;
            this._MenuFileSave.Name = "_MenuFileSave";
            this._MenuFileSave.Padding = new System.Windows.Forms.Padding(0);
            this._MenuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._MenuFileSave.Size = new System.Drawing.Size(237, 20);
            this._MenuFileSave.Text = "Сохранить";
            // 
            // _MenuFileSaveAs
            // 
            this._MenuFileSaveAs.Image = global::TuringMachine.Properties.Resources.SaveAs;
            this._MenuFileSaveAs.Name = "_MenuFileSaveAs";
            this._MenuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this._MenuFileSaveAs.Size = new System.Drawing.Size(237, 22);
            this._MenuFileSaveAs.Text = "Сохранить как    ";
            // 
            // _MenuFileExportExcel
            // 
            this._MenuFileExportExcel.Image = global::TuringMachine.Properties.Resources.Excel24;
            this._MenuFileExportExcel.Name = "_MenuFileExportExcel";
            this._MenuFileExportExcel.Size = new System.Drawing.Size(161, 22);
            this._MenuFileExportExcel.Text = "Excel table (.xlsx)";
            // 
            // _MenuFileExit
            // 
            this._MenuFileExit.Image = global::TuringMachine.Properties.Resources.Cross24;
            this._MenuFileExit.Name = "_MenuFileExit";
            this._MenuFileExit.Padding = new System.Windows.Forms.Padding(0);
            this._MenuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this._MenuFileExit.Size = new System.Drawing.Size(237, 20);
            this._MenuFileExit.Text = "Выход";
            // 
            // _MenuSimulationStart
            // 
            this._MenuSimulationStart.Image = global::TuringMachine.Properties.Resources.Play;
            this._MenuSimulationStart.Name = "_MenuSimulationStart";
            this._MenuSimulationStart.Padding = new System.Windows.Forms.Padding(0);
            this._MenuSimulationStart.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._MenuSimulationStart.Size = new System.Drawing.Size(165, 28);
            this._MenuSimulationStart.Text = "Выполнить";
            // 
            // _MenuSimulationStop
            // 
            this._MenuSimulationStop.Image = global::TuringMachine.Properties.Resources.Stop;
            this._MenuSimulationStop.Name = "_MenuSimulationStop";
            this._MenuSimulationStop.Padding = new System.Windows.Forms.Padding(0);
            this._MenuSimulationStop.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this._MenuSimulationStop.Size = new System.Drawing.Size(165, 28);
            this._MenuSimulationStop.Text = "Остановить";
            // 
            // _MenuSimulationStep
            // 
            this._MenuSimulationStep.Image = global::TuringMachine.Properties.Resources.Step;
            this._MenuSimulationStep.Name = "_MenuSimulationStep";
            this._MenuSimulationStep.Padding = new System.Windows.Forms.Padding(0);
            this._MenuSimulationStep.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this._MenuSimulationStep.Size = new System.Drawing.Size(165, 28);
            this._MenuSimulationStep.Text = "Один шаг";
            // 
            // _MenuSimulationDelay
            // 
            this._MenuSimulationDelay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._MenuSimulationDelay0,
            this._MenuSimulationDelay100,
            this._MenuSimulationDelay250,
            this._MenuSimulationDelay500,
            this._MenuSimulationDelay1000,
            this.toolStripSeparator2,
            this._MenuSimulationDelayCustom,
            this._MenuSimulationDelayValue});
            this._MenuSimulationDelay.Image = global::TuringMachine.Properties.Resources.Timer20;
            this._MenuSimulationDelay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._MenuSimulationDelay.Name = "_MenuSimulationDelay";
            this._MenuSimulationDelay.Padding = new System.Windows.Forms.Padding(0);
            this._MenuSimulationDelay.Size = new System.Drawing.Size(165, 28);
            this._MenuSimulationDelay.Text = "Задержка (ms):";
            // 
            // _MenuSimulationDelay0
            // 
            this._MenuSimulationDelay0.Name = "_MenuSimulationDelay0";
            this._MenuSimulationDelay0.Size = new System.Drawing.Size(162, 22);
            this._MenuSimulationDelay0.Text = "Без задержки";
            // 
            // _MenuSimulationDelay100
            // 
            this._MenuSimulationDelay100.Name = "_MenuSimulationDelay100";
            this._MenuSimulationDelay100.Size = new System.Drawing.Size(162, 22);
            this._MenuSimulationDelay100.Text = "100 ms";
            // 
            // _MenuSimulationDelay250
            // 
            this._MenuSimulationDelay250.Name = "_MenuSimulationDelay250";
            this._MenuSimulationDelay250.Size = new System.Drawing.Size(162, 22);
            this._MenuSimulationDelay250.Text = "250 ms";
            // 
            // _MenuSimulationDelay500
            // 
            this._MenuSimulationDelay500.Name = "_MenuSimulationDelay500";
            this._MenuSimulationDelay500.Size = new System.Drawing.Size(162, 22);
            this._MenuSimulationDelay500.Text = "500 ms";
            // 
            // _MenuSimulationDelay1000
            // 
            this._MenuSimulationDelay1000.Name = "_MenuSimulationDelay1000";
            this._MenuSimulationDelay1000.Size = new System.Drawing.Size(162, 22);
            this._MenuSimulationDelay1000.Text = "1000 ms";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // _MenuSimulationDelayCustom
            // 
            this._MenuSimulationDelayCustom.Name = "_MenuSimulationDelayCustom";
            this._MenuSimulationDelayCustom.Size = new System.Drawing.Size(162, 22);
            this._MenuSimulationDelayCustom.Text = "Настраиваемая:";
            // 
            // _MenuSimulationDelayValue
            // 
            this._MenuSimulationDelayValue.Name = "_MenuSimulationDelayValue";
            this._MenuSimulationDelayValue.Size = new System.Drawing.Size(100, 23);
            // 
            // машинаТьюрингаToolStripMenuItem
            // 
            this.машинаТьюрингаToolStripMenuItem.Image = global::TuringMachine.Properties.Resources.HelpFile24;
            this.машинаТьюрингаToolStripMenuItem.Name = "машинаТьюрингаToolStripMenuItem";
            this.машинаТьюрингаToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.машинаТьюрингаToolStripMenuItem.Text = "Машина Тьюринга";
            // 
            // работаВЭмулятореToolStripMenuItem
            // 
            this.работаВЭмулятореToolStripMenuItem.Image = global::TuringMachine.Properties.Resources.AppHelp;
            this.работаВЭмулятореToolStripMenuItem.Name = "работаВЭмулятореToolStripMenuItem";
            this.работаВЭмулятореToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.работаВЭмулятореToolStripMenuItem.Text = "Работа в эмуляторе";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Image = global::TuringMachine.Properties.Resources.Info24;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1131, 613);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._TapePageRight);
            this.Controls.Add(this._TapeCellRight);
            this.Controls.Add(this._TapeCellLeft);
            this.Controls.Add(this._TapePageLeft);
            this.Controls.Add(this._ProgLabel);
            this.Controls.Add(this._ProgPanel);
            this.Controls.Add(this._TapeLabel);
            this.Controls.Add(this._TapePanel);
            this.Controls.Add(this._DescriptionLabel);
            this.Controls.Add(this._DescriptionPanel);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _MenuFile;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulation;
        private System.Windows.Forms.ToolStripMenuItem _MenuInfo;
        private System.Windows.Forms.RichTextBox _DescriptionPanel;
        private System.Windows.Forms.Label _DescriptionLabel;
        private System.Windows.Forms.FlowLayoutPanel _TapePanel;
        private System.Windows.Forms.Label _TapeLabel;
        private System.Windows.Forms.FlowLayoutPanel _ProgPanel;
        private System.Windows.Forms.Label _ProgLabel;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileCreate;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileSave;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulationStart;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulationStop;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulationStep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulationDelay;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulationDelay0;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulationDelay100;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulationDelay250;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulationDelay500;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulationDelay1000;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _MenuSimulationDelayCustom;
        private System.Windows.Forms.ToolStripTextBox _MenuSimulationDelayValue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileImport;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileExit;
        private System.Windows.Forms.Button _TapePageLeft;
        private System.Windows.Forms.Button _TapeCellLeft;
        private System.Windows.Forms.Button _TapePageRight;
        private System.Windows.Forms.Button _TapeCellRight;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _ToolsStatus;
        private System.Windows.Forms.Timer _ProgTimer;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileExportExcel;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileImportExcel;
        private System.Windows.Forms.Timer ResizerTimer;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileImportPolyakov;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem _MenuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem машинаТьюрингаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаВЭмулятореToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Timer MoveTimer;
    }
}

