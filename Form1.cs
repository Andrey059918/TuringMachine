using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;
using OfficeOpenXml;
using System.IO;
using System.Xml;


namespace TuringMachine
{
    public partial class Form1 : Form
    {
        private List<ToolStripMenuItem> GroupedDelayItems;
        private PrivateFontCollection collection = new PrivateFontCollection();
        private String FilePath;

        private List<Int32> ResizeSteps;
        private Int32 MoveFrom;
        private Boolean MoveStart=true;
                
        private TapeData _MyTape;
        private ProgramData _MyProgram;


        //General Form
        public Form1()
        {
            InitializeComponent();
            string fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, Properties.Resources.MSSERegular);
            collection.AddFontFile(fileName);
            fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, Properties.Resources.MSSEBold);
            collection.AddFontFile(fileName);

            GroupControls();
            SetEvents();
            CorrectLayout();
            FileNew();
            CreateTape();
        }
        private void SetEvents()
        {
            //Form
            SizeChanged += (sender, args) => { CorrectLayout(); CreateTape(); };
            MoveTimer.Tick += (sender, args) =>
            {
                MoveStart = true;
                MoveTimer.Stop();
            };
            ResizerTimer.Tick += (sender, args) =>
              {
                  _ProgPanel.Controls.Last().Width += (ResizeSteps.FindIndex(b => Cursor.Position.X < b) - 4) * 5;
                  _ProgPanel.Controls.Last().Controls[0].Width += (ResizeSteps.FindIndex(b => Cursor.Position.X < b) - 4) * 5;
                  _ProgPanel.Controls.Last().Controls.ForEach(a => a.Width = _ProgPanel.Controls.Last().Controls[0].Width, 1);
              };
            
            //MenuFile
            _MenuFileCreate.Click += (sender, args) => FileNew();
            _MenuFileOpen.Click += (sender, args) =>
            {
                OpenFileDialog dialog = new OpenFileDialog()
                {
                    Filter = "Turing Machine (*.turma)|*.turma"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileOpen(dialog.FileName);
                }
            };
            _MenuFileReload.Click += (sender, args) =>
            {
                if (FilePath != null)
                {
                    FileOpen(FilePath);
                }
                else {
                    _MenuFileOpen.PerformClick();
                }
            };
            _MenuFileSaveAs.Click += (sender, args) => 
            {
                SaveFileDialog dialog = new SaveFileDialog()
                {
                    FileName = "SavedData",
                    AddExtension = false,
                    Filter = "Все файлы (*.*)|*.*"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileSave(dialog.FileName + ".turma");
                }
            };
            _MenuFileSave.Click += (sender, args) =>
            {
                if (FilePath != null)
                {
                    FileSave(FilePath);
                }
                else
                {
                    _MenuFileSaveAs.PerformClick();
                }
            };
            _MenuFileImportPolyakov.Click += (sender, args) => FileImportPolyakov();
            _MenuFileExit.Click += (sender, args) =>  Application.Exit();

            //MenuSimulation
            GroupedDelayItems.ForEach(a => a.Click += (sender, args) =>
            {
                GroupedDelayItems.ForEach(b => b.Checked = (b == sender as ToolStripMenuItem) ? (true) : (false));
                switch (GroupedDelayItems.FindIndex(b => b.Checked))
                {
                    case 1: _ProgTimer.Interval = 100; break;
                    case 2: _ProgTimer.Interval = 250; break;
                    case 3: _ProgTimer.Interval = 500; break;
                    case 4: _ProgTimer.Interval = 1000; break;
                    case 5: _ProgTimer.Interval = _MenuSimulationDelayValue.Text.Int(); break;
                }
            }, EndShift: 1);
            _MenuSimulationDelayValue.KeyPress += (sender, args) =>
            {
                if (Char.IsDigit(args.KeyChar) && (_MenuSimulationDelayValue.Text + args.KeyChar).Int() < 10000 && (_MenuSimulationDelayValue.Text + args.KeyChar).Int() > 0)
                {
                    GroupedDelayItems.ForEach(a => a.Checked = false);
                    _MenuSimulationDelayCustom.Checked = true;
                }
                else if (args.KeyChar == 8)
                {
                    if (_MenuSimulationDelayValue.Text.Length == 1)
                    {
                        _MenuSimulationDelay250.PerformClick();
                    }
                }
                else
                {
                    args.Handled = true;
                }
            };
            _MenuSimulationStep.Click += (sender, args) => DoStep();
            _MenuSimulationStart.Click += (sender, args) => StartSim();
            _MenuSimulationStop.Click += (sender, args) => StopSim();
            _ProgTimer.Tick += (sender, args) => TickSim();


            //Tape
            _TapeCellLeft.Click += (sender, args) => RedrawTape(-1);
            _TapeCellRight.Click += (sender, args) => RedrawTape(1);
            _TapePageLeft.Click += (sender, args) => RedrawTape(-10);
            _TapePageRight.Click += (sender, args) => RedrawTape(10);
        }
        private void GroupControls()
        {
            GroupedDelayItems = new List<ToolStripMenuItem>() {
                _MenuSimulationDelay0, _MenuSimulationDelay100,
                _MenuSimulationDelay250, _MenuSimulationDelay500,
                _MenuSimulationDelay1000,_MenuSimulationDelayCustom
            };
        }
        private void CorrectLayout()
        {
            _ProgPanel.AutoScroll = false;
            _ProgPanel.Width = Width - 36;
            _TapePanel.Width = Width - 176;
            _DescriptionPanel.Width = Width - 36;
            _ToolsStatus.Width = Width - 36;
            if (Height > 800)
            {
                _DescriptionPanel.Height = 150;
                _TapeLabel.Location = new Point(10, 220);
                _TapePageLeft.Location = new Point(10, 240);
                _TapeCellLeft.Location = new Point(50, 240);
                _TapePanel.Location = new Point(80, 240);
                _TapeCellRight.Location = new Point(Size.Width - 96, 240);
                _TapePageRight.Location = new Point(Size.Width - 66, 240);
                _ProgLabel.Location = new Point(10, 300);
                _ProgPanel.Location = new Point(10, 320);
            }
            else
            {
                _DescriptionPanel.Height = 75;
                _TapeLabel.Location = new Point(10, 145);
                _TapePageLeft.Location = new Point(10, 165);
                _TapeCellLeft.Location = new Point(50, 165);
                _TapePanel.Location = new Point(80, 165);
                _TapeCellRight.Location = new Point(Size.Width - 96, 165);
                _TapePageRight.Location = new Point(Size.Width - 66, 165);
                _ProgLabel.Location = new Point(10, 225);
                _ProgPanel.Location = new Point(10, 245);
            }
            _ProgPanel.Height = Height - _ProgPanel.Location.Y - 70;
            _ProgPanel.AutoScroll = true;
        }


        //MenuButtons
        private void FileNew()
        {
            FilePath = null;
            _DescriptionPanel.Text = "";
            _MenuSimulationDelayValue.Text = "";
            _MenuSimulationDelay250.PerformClick();
            Text = "Turing Machine";

            _MyTape = new TapeData();
            RedrawTape();

            _MyProgram = new ProgramData(true);
            CreateProgram();
            RedrawProgram();
        }
        private void FileOpen(String path)
        {
            LoaderDialog loader = new LoaderDialog();
            if (loader.ShowDialog() == DialogResult.OK && loader.Boxes.Count(a => a.Checked) > 0)
            {
				//Основное
				XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(new StreamReader(path));
				//Настройки
				XmlNode appSettings = xmlDocument.FirstChild.ChildNodes[0];
                XmlNode delaySettings = appSettings.ChildNodes[0];
                foreach (XmlNode item in delaySettings.ChildNodes)
                {
                    if (GroupedDelayItems.Count(a => a.Name == item.Attributes[0].Value) == 1)
                    {
                        GroupedDelayItems.Single(a => a.Name == item.Attributes[0].Value).Checked = Convert.ToBoolean(item.Attributes[1].Value);
                    }
                    else { _MenuSimulationDelayValue.Text = item.Attributes[1].Value; }
                    GroupedDelayItems.ForEach(a => { if (a.Checked) { a.PerformClick(); } }, EndShift: 1);
                }
                //Описание
                if (loader.Boxes[0].Checked)
                {
                    XmlNode machineDescription = xmlDocument.FirstChild.ChildNodes[1];
                    _DescriptionPanel.Text = String.Join("\n", (machineDescription.ChildNodes.Cast<XmlNode>()).Select(a => a.Attributes[0].Value));
                }
                //Лента
                if (loader.Boxes[1].Checked)
                {
                    _MyTape = new TapeData();
                    XmlNode machineTape = xmlDocument.FirstChild.ChildNodes[2];
                    XmlNode tapeParams = machineTape.ChildNodes[0];
                    _MyTape._IndexDisplayed = tapeParams.Attributes[0].Value.Int();
                    _MyTape._IndexSelected = tapeParams.Attributes[1].Value.Int();
                    XmlNode tapeNegative = machineTape.ChildNodes[1];
                    Int32 Shift = tapeNegative.Attributes[0].Value.Int();
                    tapeNegative.InnerText.Split('→').Where(a => a != "").ForEach((item, index) => _MyTape[-Shift - index - 1] = item[0]);
                    XmlNode tapePositive = machineTape.ChildNodes[2];
                    Shift = tapePositive.Attributes[0].Value.Int();
                    tapePositive.InnerText.Split('→').Where(a => a != "").ForEach((item, index) => _MyTape[Shift + index] = item[0]);
                    RedrawTape();
                }
                //Программа
                if (loader.Boxes[2].Checked)
                {
                    _MyProgram = new ProgramData();
                    XmlNode machineProgram = xmlDocument.FirstChild.ChildNodes[3];
                    _MyProgram.SelectedState = machineProgram.Attributes[0].Value.Int();
                    XmlNode programCells = machineProgram.ChildNodes[0];
                    for (int i = 0; i < programCells.Attributes[1].Value.Int(); i++)
                    {
                        _MyProgram.AddRow();
                        _MyProgram.SetComment(i, machineProgram.ChildNodes[1].ChildNodes[i].Attributes[0].Value);
                    }
                    for (int i = 0; i < programCells.ChildNodes.Count; i++)
                    {
                        _MyProgram.AddColumn();
                        _MyProgram.SetHeader(i, programCells.ChildNodes[i].Attributes[0].Value);
                        for (int j = 0; j < programCells.ChildNodes[i].ChildNodes.Count; j++)
                        {
                            _MyProgram[i, j].Symbol = programCells.ChildNodes[i].ChildNodes[j].Attributes[0].Value.Int();
                            _MyProgram[i, j].Direction = programCells.ChildNodes[i].ChildNodes[j].Attributes[1].Value.Int();
                            _MyProgram[i, j].State = programCells.ChildNodes[i].ChildNodes[j].Attributes[2].Value.Int();
                        }
                    }
                    CreateProgram();
                    RedrawProgram();
                }
                FilePath = path;
                Text = "Turing Machine - " + FilePath;
			}
        }
        private void FileSave(String path)
        {
            //Создание структуры
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement xmlRoot = xmlDocument.CreateElement("Data");
            xmlDocument.AppendChild(xmlRoot);
            //Настройки
            XmlElement appSettings =xmlDocument.CreateElement("Settings");
            xmlRoot.AppendChild(appSettings);
            XmlElement delaySettings = xmlDocument.CreateElement("Delays");
            appSettings.AppendChild(delaySettings);
            XmlElement delayMenuItem;
            foreach (var item in GroupedDelayItems)
            {
                delayMenuItem = xmlDocument.CreateElement("Parameter");
                delayMenuItem.SetAttribute("name", item.Name);
                delayMenuItem.SetAttribute("value", item.Checked.ToString());
                delaySettings.AppendChild(delayMenuItem);
            }
            delayMenuItem = xmlDocument.CreateElement("Parameter");
            delayMenuItem.SetAttribute("name", _MenuSimulationDelayValue.Name);
            delayMenuItem.SetAttribute("value", _MenuSimulationDelayValue.Text);
            delaySettings.AppendChild(delayMenuItem);
            //Описание
            XmlElement machineDescription= xmlDocument.CreateElement("Description");
            xmlRoot.AppendChild(machineDescription);
            foreach (string item in _DescriptionPanel.Text.Split('\n'))
            {
                XmlElement descriptionLine = xmlDocument.CreateElement("Line");
                descriptionLine.SetAttribute("text",item);
                machineDescription.AppendChild(descriptionLine);
            }
            //Лента
            XmlElement machineTape = xmlDocument.CreateElement("Tape");
            xmlRoot.AppendChild(machineTape);
            XmlElement tapeParams = xmlDocument.CreateElement("Parameters");
            tapeParams.SetAttribute("displayed", _MyTape._IndexDisplayed.ToString());
            tapeParams.SetAttribute("selected", _MyTape._IndexSelected.ToString());
            machineTape.AppendChild(tapeParams);
            XmlElement tapeNegative = xmlDocument.CreateElement("Negative");
            tapeNegative.SetAttribute("shift", _MyTape.GetTapeShift("-").ToString());
            tapeNegative.InnerText = _MyTape["-"];
            machineTape.AppendChild(tapeNegative);
            XmlElement tapePositive = xmlDocument.CreateElement("Positive");
            tapePositive.SetAttribute("shift", _MyTape.GetTapeShift("+").ToString());
            tapePositive.InnerText = _MyTape["+"];
            machineTape.AppendChild(tapePositive);
            //Программа
            XmlElement machineProgram = xmlDocument.CreateElement("Program");
            machineProgram.SetAttribute("selected", _MyProgram.SelectedState.ToString());
            xmlRoot.AppendChild(machineProgram);
            XmlElement programCells = xmlDocument.CreateElement("Cells");
            programCells.SetAttribute("columns", _MyProgram.ColumnCount.ToString());
            programCells.SetAttribute("rows", _MyProgram.RowCount.ToString());
            machineProgram.AppendChild(programCells);
            for (int i = 0; i < _MyProgram.ColumnCount; i++) {
                XmlElement programColumn = xmlDocument.CreateElement("Column");
                programColumn.SetAttribute("header", _MyProgram.GetHeader(i));
                programCells.AppendChild(programColumn);
                for (int j = 0; j < _MyProgram.RowCount; j++)
                {
                    XmlElement programCell = xmlDocument.CreateElement("Cell");
                    programCell.SetAttribute("symbol", _MyProgram[i, j].Symbol.ToString());
                    programCell.SetAttribute("direction", _MyProgram[i, j].Direction.ToString());
                    programCell.SetAttribute("state", _MyProgram[i, j].State.ToString());
                    programColumn.AppendChild(programCell);
                }
            }
            XmlElement programComments = xmlDocument.CreateElement("Comments");
            machineProgram.AppendChild(programComments);
            for (int j = 0; j < _MyProgram.RowCount; j++)
            {
                XmlElement programComment = xmlDocument.CreateElement("Comment");
                programComment.SetAttribute("text",_MyProgram.GetComment(j));
                programComments.AppendChild(programComment);
            }
            //Сохранение
            xmlDocument.Save(path);
            FilePath = path;
            Text = "Turing Machine - " + FilePath;
        }
        private void FileImportPolyakov()
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Turing Machine (*.tur)|*.tur"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string NormalSymbols = "[]{}()'\"&/+-*=?,.<>^:%;$#№@!\n\r\t _0123456789" +
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" +
                    "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                var text = File.ReadAllText(dialog.FileName,Encoding.Default).Skip(4);
                var DescriptionStrings = text.TakeWhile(a =>NormalSymbols.Contains(a));
                text = text.SkipWhile(a => NormalSymbols.Contains(a)).SkipWhile(a => a!='Q');
                var ProgramText = text.TakeWhile(a => NormalSymbols.Contains(a)).EndSkipWhile(a=>a!='\r',true);
                text = text.SkipWhile(a => NormalSymbols.Contains(a));
                //var CommentText = text.SkipWhile(a => a != 'Q').TakeWhile(a => NormalSymbols.Contains(a));
                var TapeText = text.EndTakeWhile(a => NormalSymbols.Contains(a));
                LoaderDialog loader = new LoaderDialog();
                if (loader.ShowDialog() == DialogResult.OK)
                {
                    CreateProgram();
                    if (loader.Boxes[0].Checked) {
                        _DescriptionPanel.Text = new String(DescriptionStrings.ToArray());
                    }
                    if (loader.Boxes[1].Checked)
                    {
                        _MyTape = new TapeData();
                        for (int i = 0; i < TapeText.Count(); i++)
                        {
                            _MyTape[i] = TapeText.ElementAt(i);
                        }
                        _MyTape._IndexDisplayed = Math.Min(-5,-(_TapePanel.Controls.Count-TapeText.Count())/2);
                        RedrawTape();
                    }
                    if (loader.Boxes[2].Checked) {
                        _MyProgram = new ProgramData();
                        var ProgRows = new String(ProgramText.ToArray()).Split('\n');
                        var CommentRows = new String(text.ToArray()).Split('Q').Where(a=>Char.IsDigit(a[0]));
                        for (int i = 0; i < ProgRows[0].Split('\t').Where(a => a.Contains('Q')).Count();i++) {
                            _MyProgram.AddRow();
                            _MyProgram.SetComment(i, new String(CommentRows.FirstOrDefault(a => new String(a.TakeWhile(b => Char.IsDigit(b)).ToArray()).Int() == i+1)?.SkipWhile(a=>!Char.IsLetter(a)).TakeWhile(a=>a!='\r'&&NormalSymbols.Contains(a)).ToArray()));
                        }
                        if (ProgRows.Last()[0] != ' ') { ProgRows[ProgRows.Count()-1] = " " + ProgRows.Last().Substring(1); }
                        for (int i = 1; i < ProgRows.Count(); i++) {
                            var Columns= new String(ProgRows[i].Where(a => a != '\r').ToArray()).Split('\t');
                            if (_MyProgram.HeaderNumber(Columns[0]) == -1) {
                                _MyProgram.AddColumn();
                                _MyProgram.SetHeader(_MyProgram.ColumnCount - 1, Columns[0]);
                            }
                            for (int j = 1; j < Columns.Count(); j++) {
                                if (Columns[j].Length > 0)
                                {
                                    if (Columns[j][0] == '_') { _MyProgram[_MyProgram.HeaderNumber(Columns[0]), j - 1].Symbol = ' '; }
                                    else { _MyProgram[_MyProgram.HeaderNumber(Columns[0]), j - 1].Symbol = Columns[j][0]; }
                                }
                                if (Columns[j].Length > 1)
                                {
                                    _MyProgram[_MyProgram.HeaderNumber(Columns[0]), j - 1].Direction = 202+"<.>".IndexOf(Columns[j][1]);
                                }
                                if (Columns[j].Length > 2)
                                {
                                    _MyProgram[_MyProgram.HeaderNumber(Columns[0]), j - 1].State = Columns[j].Substring(2).Int();
                                }
                            }
                        }
                        RedrawProgram();
                    }
                }
            }
        }
        private void FileImportExcel()
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Turing Machine (*.tur)|*.tur"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string NormalSymbols = "[]{}()'\"&/+-*=?,.<>^:%;$#№@!\n\r\t _0123456789" +
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" +
                    "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                var text = File.ReadAllText(dialog.FileName, Encoding.Default).Skip(4);
                var DescriptionStrings = text.TakeWhile(a => NormalSymbols.Contains(a));
                text = text.SkipWhile(a => NormalSymbols.Contains(a)).SkipWhile(a => a != 'Q');
                var ProgramText = text.TakeWhile(a => NormalSymbols.Contains(a)).EndSkipWhile(a => a != '\r', true);
                text = text.SkipWhile(a => NormalSymbols.Contains(a));
                //var CommentText = text.SkipWhile(a => a != 'Q').TakeWhile(a => NormalSymbols.Contains(a));
                var TapeText = text.EndTakeWhile(a => NormalSymbols.Contains(a));
                LoaderDialog loader = new LoaderDialog();
                if (loader.ShowDialog() == DialogResult.OK)
                {
                    CreateProgram();
                    if (loader.Boxes[0].Checked)
                    {
                        _DescriptionPanel.Text = new String(DescriptionStrings.ToArray());
                    }
                    if (loader.Boxes[1].Checked)
                    {
                        _MyTape = new TapeData();
                        for (int i = 0; i < TapeText.Count(); i++)
                        {
                            _MyTape[i] = TapeText.ElementAt(i);
                        }
                        _MyTape._IndexDisplayed = Math.Min(-5, -(_TapePanel.Controls.Count - TapeText.Count()) / 2);
                        RedrawTape();
                    }
                    if (loader.Boxes[2].Checked)
                    {
                        _MyProgram = new ProgramData();
                        var ProgRows = new String(ProgramText.ToArray()).Split('\n');
                        var CommentRows = new String(text.ToArray()).Split('Q').Where(a => Char.IsDigit(a[0]));
                        for (int i = 0; i < ProgRows[0].Split('\t').Where(a => a.Contains('Q')).Count(); i++)
                        {
                            _MyProgram.AddRow();
                            _MyProgram.SetComment(i, new String(CommentRows.FirstOrDefault(a => new String(a.TakeWhile(b => Char.IsDigit(b)).ToArray()).Int() == i + 1)?.SkipWhile(a => !Char.IsLetter(a)).ToArray()));
                        }
                        if (ProgRows.Last()[0] != ' ') { ProgRows[ProgRows.Count() - 1] = " " + ProgRows.Last().Substring(1); }
                        for (int i = 1; i < ProgRows.Count(); i++)
                        {
                            var Columns = new String(ProgRows[i].Where(a => a != '\r').ToArray()).Split('\t');
                            if (_MyProgram.HeaderNumber(Columns[0]) == -1)
                            {
                                _MyProgram.AddColumn();
                                _MyProgram.SetHeader(_MyProgram.ColumnCount - 1, Columns[0]);
                            }
                            for (int j = 1; j < Columns.Count(); j++)
                            {
                                if (Columns[j].Length > 0)
                                {
                                    if (Columns[j][0] == '_') { _MyProgram[_MyProgram.HeaderNumber(Columns[0]), j - 1].Symbol = ' '; }
                                    else { _MyProgram[_MyProgram.HeaderNumber(Columns[0]), j - 1].Symbol = Columns[j][0]; }
                                }
                                if (Columns[j].Length > 1)
                                {
                                    _MyProgram[_MyProgram.HeaderNumber(Columns[0]), j - 1].Direction = 202 + "<.>".IndexOf(Columns[j][1]);
                                }
                                if (Columns[j].Length > 2)
                                {
                                    _MyProgram[_MyProgram.HeaderNumber(Columns[0]), j - 1].State = Columns[j].Substring(2).Int();
                                }
                            }
                        }
                        RedrawProgram();
                    }
                }
            }
        }

        private void StartSim()
        {
            if (GroupedDelayItems[0].Checked)
            {
                while (DoStep(false)) { }
                RedrawTape();
                RedrawProgram();
            }
            else {
                _ProgTimer.Start();
            }
        }
        private void StopSim()
        {
            _ProgTimer.Stop();

        }
        private void TickSim()
        {
            if (!DoStep()) { _ProgTimer.Stop(); }
        }
        private Boolean DoStep(bool ShowInfo = true)
        {
            Int32 Col = _MyProgram.HeaderNumber(_MyTape[_MyTape._IndexSelected].ToString());
            Int32 Row = _MyProgram.SelectedState;
            if (Col >= 0 && Row > 0)
            {
                if (_MyProgram[Col, Row - 1].Symbol >= 0)
                {
                    _MyTape[_MyTape._IndexSelected] = (char)_MyProgram[Col, Row - 1].Symbol;
                }
                if (_MyProgram[Col, Row - 1].Direction > 0)
                {
                    _MyTape._IndexSelected += _MyProgram[Col, Row - 1].Direction - 203;
                    _MyTape._IndexDisplayed += _MyProgram[Col, Row - 1].Direction - 203;
                }
                if (_MyProgram[Col, Row - 1].State > 0)
                {
                    _MyProgram.SelectedState = _MyProgram[Col, Row - 1].State;
                }
                else if (_MyProgram[Col, Row - 1].State == 0)
                {
                    _MyProgram.SelectedState = 0;
                    return false;
                }
                if (ShowInfo)
                {
                    RedrawTape();
                    RedrawProgram();
                }
                return true;
            }
            return false;
        }


        //Tape
        private void CreateTape()
        {
            while (_TapePanel.PreferredSize.Width < _TapePanel.Width)
            {
                _TapePanel.Controls.Add(CreateTapeButton());

            }
            if (_TapePanel.PreferredSize.Width > _TapePanel.Width + _Settings._TapeWidth)
            {
                _TapePanel.PopLast();
            }
            RedrawTape();
        }
        private Button CreateTapeButton()
        {
            Int32 Index = _TapePanel.Controls.Count;
            Button button = new Button()
            {
                Size = new Size(_Settings._TapeWidth, _Settings._TapeHeight),
                Margin = Padding.Empty,
                Text = "",
                FlatStyle = 0,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            button.MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    if (MoveStart)
                    {
                        MoveStart = false;
                        MoveTimer.Start();
                    }
                    else
                    {
                        _MyTape._IndexSelected = _MyTape._IndexDisplayed + Index;
                        RedrawTape();
                    }
                }
            };
            button.KeyPress += (sender, args) =>
            {
                if (_MyProgram.HeaderNumber(args.KeyChar.ToString())!=-1)
                {
                    _MyTape[Index + _MyTape._IndexDisplayed] = args.KeyChar;
                    _TapePanel.Focus();
                    RedrawTape();
                }
            };
            return button;
        }
        private void RedrawTape(Int32 shift = 0)
        {
            Button ctrl;
            _MyTape._IndexDisplayed += shift;
            for (int i = 0; i < _TapePanel.Controls.Count; i++)
            {
                ctrl = _TapePanel.Controls[i] as Button;
                ctrl.Text = _MyTape[_MyTape._IndexDisplayed + i].ToString();
                if (_MyTape._IndexDisplayed + i == _MyTape._IndexSelected)
                {
                    ctrl.BackColor = Color.FromArgb(220, 255, 220);
                }
                else
                {
                    ctrl.BackColor = SystemColors.ButtonHighlight;
                }
            }
        }


        //Program
        private void CreateProgram()
        {
            _ProgPanel.Controls.Clear();
            //Панели
            for (int i = 0; i < 3; i++)
            {
                _ProgPanel.Controls.Add(new FlowLayoutPanel()
                {
                    AutoSize = true,
                    Margin = Padding.Empty,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    MinimumSize = new Size(6, 0)
                });
            }
            //Столбец состояний
            _ProgPanel.Controls[0].Controls.Add(new Button
            {
                Size = new Size(80, 42),
                Image = Properties.Resources.TabliDiagonal,
                ImageAlign = ContentAlignment.MiddleCenter,
                Margin = Padding.Empty,
                FlatStyle = FlatStyle.Flat
            });
            _ProgPanel.Controls[0].Controls[0].Click += (sender, args) =>
            {
                _MyProgram = new ProgramData(true);
                CreateProgram();
                RedrawProgram();
            };
            _ProgPanel.Controls[0].Controls.Add(new Button()
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 32),
                Text = "Q+",
                Margin = Padding.Empty,
                Font = new Font(collection.Families[0], 12, FontStyle.Bold),
                BackColor = SystemColors.ControlLight,
                ForeColor = SystemColors.ControlDark
            });
            (_ProgPanel.Controls[0].Controls[1] as Button).FlatAppearance.BorderColor = Color.Black;
            _ProgPanel.Controls[0].Controls[1].Click += (sender, args) =>
            {
                _MyProgram.AddRow();
                RedrawProgram();
            };
            //Добавочный столбец
            _ProgPanel.Controls[1].Controls.Add(new Button
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 42),
                Text = "S+",
                Margin = Padding.Empty,
                Font = new Font(collection.Families[0], 12, FontStyle.Bold),
                BackColor = SystemColors.ControlLight,
                ForeColor = SystemColors.ControlDark
            });
            (_ProgPanel.Controls[1].Controls[0] as Button).FlatAppearance.BorderColor = Color.Black;
            _ProgPanel.Controls[1].Controls[0].Click += (sender, args) =>
            {
                _MyProgram.AddColumn();
                RedrawProgram();
            };
            _ProgPanel.Controls[1].Controls.Add(new Button
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 32),
                Text = "",
                Margin = Padding.Empty,
                Font = new Font(collection.Families[0], 12, FontStyle.Bold),
                BackColor = SystemColors.ControlLight,
                ForeColor = SystemColors.ControlDark
            });
            (_ProgPanel.Controls[1].Controls[1] as Button).FlatAppearance.BorderColor = Color.Black;
            _ProgPanel.Controls[1].Controls[1].Click += (sender, args) =>
            {
                _MyProgram.AddColumn();
                _MyProgram.AddRow();
                RedrawProgram();
            };
            //Столбец комментариев
            _ProgPanel.Controls[2].Controls.Add(new Button
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(_ProgPanel.Width - _ProgPanel.PreferredSize.Width, 42),
                MinimumSize = new Size(6, 0),
                Text = "Комментарий",
                Margin = Padding.Empty,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            });
            _ProgPanel.Controls[2].Controls[0].MouseDown += (sender, args) =>
            {
                ResizeSteps = new List<int>();
                for (int i = 1; i < 5; i++)
                {
                    ResizeSteps.Add(Cursor.Position.X / 5 * i);
                }
                for (int i = 1; i < 5; i++)
                {
                    ResizeSteps.Add((Screen.FromHandle(Handle).Bounds.Width - Cursor.Position.X) / 5 * i + Cursor.Position.X);
                }
                ResizeSteps.Add(Screen.FromHandle(Handle).Bounds.Width);
                _ProgPanel.Controls.Last().AutoSize = false;
                _ProgPanel.Controls.Last().Size = _ProgPanel.Controls.Last().PreferredSize;
                ResizerTimer.Start();
            };
            _ProgPanel.Controls[2].Controls[0].MouseUp += (sender, args) =>
            {
                _ProgPanel.Controls.Last().AutoSize = true;
                _ProgPanel.Controls.Last().Controls.ForEach(a => a.Visible = true, 1);
                ResizerTimer.Stop();
            };
            _ProgPanel.Controls[2].Controls.Add(new Button()
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(_ProgPanel.Controls[2].Controls[0].Width,32),
                Text = "",
                Margin = Padding.Empty,
                Font = new Font(collection.Families[0], 12, FontStyle.Bold),
                BackColor = SystemColors.ControlLight,
                ForeColor = SystemColors.ControlDark
            });
            (_ProgPanel.Controls[2].Controls[1] as Button).FlatAppearance.BorderColor = Color.Black;
            _ProgPanel.Controls[2].Controls[1].Click += (sender, args) =>
            {
                _MyProgram.AddRow();
                RedrawProgram();
            };
        }
        private void RedrawProgram()
        {
            //Удаление лишних столбцов
            while (_ProgPanel.Controls.Count > _MyProgram.ColumnCount + 3) {
                _ProgPanel.PopLast(2);
            }
            for (int i = 0; i < _MyProgram.ColumnCount+3; i++)
            {
                //Заполнение столбца состояний
                if (i == 0)
                {
                    for (int j = 0; j < _MyProgram.RowCount; j++)
                    {
                        if (j == _ProgPanel.Controls[i].Controls.Count - 2 && _ProgPanel.Controls[i].Controls.Count - 2 < _MyProgram.RowCount)
                        {
                            _ProgPanel.Controls[0].Controls.Add(CreateStateButton(j + 1));
                            _ProgPanel.Controls[0].Controls.SetChildIndex(_ProgPanel.Controls[0].Controls[j + 2], j + 1);
                        }
                        _ProgPanel.Controls[0].Controls[j + 1].BackColor = (_MyProgram.SelectedState == j + 1) ? Color.FromArgb(220, 255, 220) : SystemColors.ButtonHighlight;
                    }
                }
                else if (i < _MyProgram.ColumnCount + 1)
                {
                    //Добавление недостающих столбцов
                    if (i == _ProgPanel.Controls.Count - 2 && _MyProgram.ColumnCount > _ProgPanel.Controls.Count - 3)
                    {
                        _ProgPanel.Controls.Add(new FlowLayoutPanel()
                        {
                            AutoSize = true,
                            Margin = Padding.Empty,
                            FlowDirection = FlowDirection.TopDown,
                            WrapContents = false
                        });
                        _ProgPanel.Controls.SetChildIndex(_ProgPanel.Controls[i + 2], i);
                        _ProgPanel.Controls[i].Controls.Add(CreateHeaderButton(i - 1));
                        _ProgPanel.Controls[i].Controls.Add(new Button()
                        {
                            FlatStyle = FlatStyle.Flat,
                            Size = new Size(80, 32),
                            Text = "",
                            Margin = Padding.Empty,
                            Font = new Font(collection.Families[0], 12, FontStyle.Bold),
                            BackColor = SystemColors.ControlLight,
                            ForeColor = SystemColors.ControlDark
                        });
                        (_ProgPanel.Controls[i].Controls[1] as Button).FlatAppearance.BorderColor = Color.Black;
                        _ProgPanel.Controls[i].Controls[1].Click += (sender, args) =>
                        {
                            _MyProgram.AddRow();
                            RedrawProgram();
                        };
                    }
                    _ProgPanel.Controls[i].Controls[0].Text = _MyProgram.GetHeader(i - 1);
                    _ProgPanel.Controls[i].Controls[0].BackColor = (_MyProgram.GetHeader(i - 1) == "") ? Color.FromArgb(255, 220, 220) : SystemColors.ButtonHighlight;
                    //Добавление недостающих ячеек
                    for (int j = 0; j < _MyProgram.RowCount; j++)
                    {
                        if (j == _ProgPanel.Controls[i].Controls.Count - 2 && _ProgPanel.Controls[i].Controls.Count - 2 < _MyProgram.RowCount)
                        {
                            _ProgPanel.Controls[i].Controls.Add(CreateCellButton(i - 1, j));
                            _ProgPanel.Controls[i].Controls.SetChildIndex(_ProgPanel.Controls[i].Controls[j + 2], j + 1);
                        }
                        _ProgPanel.Controls[i].Controls[j + 1].Text = _MyProgram.FormattedCellValue(i - 1, j);
                    }
                }
                //Ячейки добавления столбца
                else if (i == _ProgPanel.Controls.Count - 2)
                {
                    for (int j = _ProgPanel.Controls[i].Controls.Count - 1; j < _MyProgram.RowCount + 1; j++)
                    {
                        _ProgPanel.Controls[i].Controls.Add(new Button()
                        {
                            FlatStyle = FlatStyle.Flat,
                            Size = new Size(80, 32),
                            Text = "",
                            Margin = Padding.Empty,
                            Font = new Font(collection.Families[0], 12, FontStyle.Bold),
                            BackColor = SystemColors.ControlLight,
                            ForeColor = SystemColors.ControlDark
                        });
                        _ProgPanel.Controls[i].Controls.SetChildIndex(_ProgPanel.Controls[i].Controls[j + 1], j);
                        (_ProgPanel.Controls[i].Controls[j] as Button).FlatAppearance.BorderColor = Color.Black;
                        _ProgPanel.Controls[i].Controls[j].Click += (sender, args) =>
                        {
                            _MyProgram.AddColumn();
                            RedrawProgram();
                        };
                    }
                }
                //Комментарии
                else if (i == _ProgPanel.Controls.Count - 1)
                {
                    for (int j = 0; j < _MyProgram.RowCount; j++)
                    {
                        if (j == _ProgPanel.Controls[i].Controls.Count - 2 && _ProgPanel.Controls[i].Controls.Count - 2 < _MyProgram.RowCount)
                        {
                            _ProgPanel.Controls[i].Controls.Add(CreateStateTextBox(j));
                            _ProgPanel.Controls[i].Controls.SetChildIndex(_ProgPanel.Controls[i].Controls[j + 2], j + 1);
                        }
                        _ProgPanel.Controls[i].Controls[j + 1].Text = _MyProgram.GetComment(j);
                    }
                }
                //Удаление лищних строк
               while (_ProgPanel.Controls[i].Controls.Count > _MyProgram.RowCount + 2)
                {
                    _ProgPanel.Controls[i].PopLast(1);
                }
            }
        }
        private Button CreateStateButton(Int32 Index) {
            Button button = new Button()
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 32),
                Text = "Q" + Index.SString(),
                Margin = Padding.Empty,
                Font = new Font(collection.Families[0], 12, FontStyle.Bold)
            };
            button.MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    if (MoveStart)
                    {
                        MoveFrom = _ProgPanel.Controls[0].Controls.GetChildIndex(button) - 1;
                        MoveStart = false;
                        MoveTimer.Start();
                    }
                    else
                    {
                        _MyProgram.SelectedState = Index;
                        RedrawProgram();
                    }
                }
            };
            button.MouseUp += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left && MoveStart)
                {
                    _MyProgram.MoveRow(MoveFrom, Math.Min(Math.Max(0, (Cursor.Position.Y - PointToScreen(_ProgPanel.Location).Y-button.Parent.Location.Y - 42) / 32), _ProgPanel.Controls[0].Controls.Count - 2));
                    RedrawProgram();
                }
                else if (args.Button == MouseButtons.Right)
                {
                    _MyProgram.RemoveRow(Index-1);
                    RedrawProgram();
                }
            };
            return button;
        }
        private TextBox CreateStateTextBox(Int32 Index)
        {
            TextBox tbox = new TextBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Left,
                Margin = Padding.Empty,
                Width = _ProgPanel.Controls[_ProgPanel.Controls.Count - 1].Controls[0].Width,
                Multiline = true,
                Height = 32,
                Text=_MyProgram.GetComment(Index)
            };
            tbox.TextChanged += (sender, args) =>
            {
                _MyProgram.SetComment(Index, tbox.Text);
            };
            return tbox;
        }
        private Button CreateHeaderButton(Int32 Index) {
            Button btn = new Button
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 42),
                Text = _MyProgram.GetHeader(Index),
                Margin = Padding.Empty,
                Font = new Font(collection.Families[0], 12, FontStyle.Bold)
            };
            if (btn.Text != " ")
            {
                btn.KeyPress += (e1, e2) =>
                {
                    if ((Char.IsLetterOrDigit(e2.KeyChar)|| "-+=*/?!%".Contains(e2.KeyChar))&& _MyProgram.HeaderNumber(e2.KeyChar.ToString())==-1)
                    {
                        _MyProgram.SetHeader(Index, e2.KeyChar.ToString());
                    }
                    _ProgPanel.Focus();
                    RedrawProgram();
                };
            }
            btn.MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    MoveFrom = _ProgPanel.Controls.GetChildIndex(btn.Parent)-1;
                    MoveStart = false;
                    MoveTimer.Start();
                }
            };
            btn.MouseUp += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left && MoveStart)
                {
                    _MyProgram.MoveColumn(MoveFrom, Math.Min(Math.Max(0, (Cursor.Position.X - PointToScreen(_ProgPanel.Location).X- 80) / 80), _ProgPanel.Controls.Count - 3));
                    RedrawProgram();
                }
                else if (args.Button == MouseButtons.Right) {
                    _MyProgram.RemoveColumn(Index);
                    RedrawProgram();
                }
            };
            return btn;
        }
        private Button CreateCellButton(Int32 Col, Int32 Row)
        {
            Button button = new Button()
            {
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 32),
                Text = _MyProgram.FormattedCellValue(Col, Row),
                Margin = Padding.Empty,
                Font = new Font(collection.Families[0], 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft
            };
            button.PreviewKeyDown += (sender, args) =>
            {
                args.IsInputKey = true;
                if (args.KeyValue > 36 && args.KeyValue < 41)
                {
                    Point directions = new Point(0, 0);
                    switch (args.KeyCode)
                    {
                        case Keys.Left: directions.X = -1; break;
                        case Keys.Right: directions.X = 1; break;
                        case Keys.Up: directions.Y = -1; break;
                        case Keys.Down: directions.Y = 1; break;
                        default: break;
                    }
                    if (args.Shift)
                    {
                        _ProgPanel.Controls[Col + 1 + directions.X].Controls[Math.Min(Row + 1 + directions.Y, _ProgPanel.Controls[0].Controls.Count - 1)].Focus();
                    }
                    else
                    {
                        _MyProgram[Col, Row].Direction = directions.X + 203;
                    }
                }
                RedrawProgram();
            };
            button.KeyPress += (e1, e2) =>
            {
                if (e2.KeyChar == 8)
                {
                    if (_MyProgram[Col, Row].State > 9) { _MyProgram[Col, Row].State /= 10; }
                    else if (_MyProgram[Col, Row].State >= 0) { _MyProgram[Col, Row].State = -1; }
                    else if (_MyProgram[Col, Row].Symbol > -1) { _MyProgram[Col, Row].Symbol = -1; }
                }
                else if (_MyProgram[Col, Row].Symbol < 0)
                {
                    if (_MyProgram.HeaderNumber(e2.KeyChar.ToString()) != -1)
                    {
                        _MyProgram[Col, Row].Symbol = e2.KeyChar;
                    }
                }
                else if (Char.IsDigit(e2.KeyChar) && _MyProgram[Col, Row].State * 10 + e2.KeyChar - 48 <= _MyProgram.RowCount)
                {
                    _MyProgram[Col, Row].State = (_MyProgram[Col, Row].State > 0).Int() * _MyProgram[Col, Row].State * 10 + e2.KeyChar - 48;
                }
                RedrawProgram();
            };
            return button;
        }
        
    }
    public class TapeData
    {
        //Fields
        private List<char> _Positive;
        private List<char> _Negative;
        
        //Properties
        public Int32 _TapeLength => _Positive.Count + _Negative.Count;
        public Int32 _IndexMinimum => -_Negative.Count;
        public Int32 _IndexMaximum => _Positive.Count - 1;
        public Int32 _IndexDisplayed { get; set; } = 0;
        public Int32 _IndexSelected { get; set; } = 0;
        
        //Constructor
        public TapeData()
        {
            _Positive = new List<char>();
            _Negative = new List<char>();
            _IndexDisplayed = 0;
            _IndexSelected = 0;
        }
        
        //Indexers
        public Char this[int index]
        {
            get {
                if (index >= 0)
                {
                    return (_Positive.Count > index ? _Positive[index] : ' ');
                }
                else
                {
                    return (_Negative.Count >= -index ? _Negative[-index - 1] : ' ');
                }
            }
            set {
                if (index >= 0)
                {
                    while (index >= _Positive.Count)
                    {
                        _Positive.Add(' ');
                    }
                    _Positive[index] = value;
                }
                else if (index < 0)
                {
                    while (-index - 1 >= _Negative.Count)
                    {
                        _Negative.Add(' ');
                    }
                    _Negative[-index - 1] = value;
                }
            }
        }
        public String this[String dir]
        {
            get {
                if (dir == "+")
                {
                    return String.Join("→", _Positive.SkipWhile(a => a == ' ').EndSkipWhile(a => a == ' '));
                }
                else if (dir == "-")
                {
                    return String.Join("→", _Negative.SkipWhile(a => a == ' ').EndSkipWhile(a => a == ' '));
                }
                else return "";
            }
        }


        //Methods
        public void ForEach(Action<Char, Int32> action)
        {
            for (int i = _IndexMinimum; i < _IndexMaximum + 1; i++)
            {
                action(this[i], i);
            }
        }
        public Int32 GetTapeShift(String dir) {
            if (dir == "+")
            {
                return _Positive.TakeWhile(a => a == ' ').Count();
            }
            else if (dir == "-")
            {
                return _Negative.TakeWhile(a => a == ' ').Count();
            }
            else return -1;
        }
    }
    public class ProgramCellData {
        public Int32 Symbol { get; set; }
        public Int32 Direction { get; set; }
        public Int32 State { get; set; }
        public ProgramCellData() {
            Symbol = -1;
            Direction = -1;
            State = -1;
        }
    }
    public class ProgramData
    {
        //Fields
        private List<List<ProgramCellData>> TableCells;
        private List<String> TableComments;
        private List<String> TableHeaders;
        
        //Properties
        public Int32 ColumnCount => TableHeaders.Count;
        public Int32 RowCount => TableComments.Count;
        public Int32 SelectedState = 1;
        
        //Constructor
        public ProgramData(bool create=false) {
            TableCells = new List<List<ProgramCellData>>();
            TableHeaders = new List<String>();
            if (create)
            {
                TableHeaders.Add(" ");
                TableCells.Add(new List<ProgramCellData>());
            }
            TableComments = new List<String>();
        }
        
        //Indexers
        public ProgramCellData this[Int32 Col, Int32 Row]
        {
            get {
                return TableCells[Col][Row];
            }
            set {
                while (Col >= ColumnCount) {
                    AddColumn();
                }
                while (Row > RowCount) {
                    AddRow();
                }
                TableCells[Col][Row] = value;
            }
        }
        
        //Methods
        public void AddColumn() {
            TableHeaders.Add("");
            TableCells.Add(new List<ProgramCellData>());
            for (int i = 0; i < RowCount; i++) {
                TableCells.Last().Add(new ProgramCellData());
            }
        }
        public void RemoveColumn(Int32 Index) {
            TableHeaders.RemoveAt(Index);
            TableCells.RemoveAt(Index);
        }
        public void AddRow() {
            TableComments.Add("");
            for (int i = 0; i < ColumnCount; i++) {
                TableCells[i].Add(new ProgramCellData());
            }
        }
        public void RemoveRow(Int32 Index)
        {
            if (SelectedState == RowCount) { SelectedState--; }
            TableComments.RemoveAt(Index);
            foreach (List<ProgramCellData> list in TableCells) {
                list.RemoveAt(Index);
            }
        }
        public String GetComment(Int32 Row) => TableComments[Row];
        public String GetHeader(Int32 Col)
        {
            return TableHeaders[Col];
        }

        public void SetComment(Int32 Row, String Comment) => TableComments[Row]=Comment;
        public void SetHeader(Int32 Col,String Header) => TableHeaders[Col]=Header;
        public Int32 HeaderNumber(String Header) => TableHeaders.IndexOf(Header);
        public String FormattedCellValue(Int32 Col, Int32 Row) {
            String str = (TableCells[Col][Row].Symbol > 0) ? ((char)TableCells[Col][Row].Symbol).ToString() : "";
            if (TableCells[Col][Row].Direction > 0) { str += (char)TableCells[Col][Row].Direction; }
            if (TableCells[Col][Row].State > 0) { str += "Q" + TableCells[Col][Row].State.SString(); }
            else if (TableCells[Col][Row].State == 0) { str += (char)201; }
            return str;
        }
        public void MoveColumn(Int32 MoveFrom, Int32 MoveTo) {
            List<ProgramCellData> temp = TableCells[MoveFrom];
            TableCells.RemoveAt(MoveFrom);
            TableCells.Insert(MoveTo, temp);
            String s = TableHeaders[MoveFrom];
            TableHeaders.RemoveAt(MoveFrom);
            TableHeaders.Insert(MoveTo, s);
        }
        public void MoveRow(Int32 MoveFrom, Int32 MoveTo)
        {
            foreach (var col in TableCells)
            {
                ProgramCellData temp = col[MoveFrom];
                col.RemoveAt(MoveFrom);
                col.Insert(MoveTo, temp);
            }
            String s = TableComments[MoveFrom];
            TableComments.RemoveAt(MoveFrom);
            TableComments.Insert(MoveTo, s);
            foreach (var col in TableCells) {
                foreach (var cell in col)
                {
                    if (cell.State == MoveFrom+1) { cell.State = MoveTo + 1; }
                    else if (cell.State > MoveFrom + 1 && cell.State < MoveTo + 2) { cell.State--; }
                    else if (cell.State > MoveTo && cell.State < MoveFrom+1) { cell.State++; }
                }
            }
        }
    }
    public static class _Settings
    {

        public static Int32 _TapeWidth = 30;
        public static Int32 _TapeHeight = 40;
    }
    public static class Extensions
    {
        //Enumerables
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action, Int32 StartShift = 0, Int32 EndShift = 0)
        {
            for (int i = StartShift; i < list.Count() - EndShift; i++)
            {
                action(list.ElementAt(i));
            }
        }
        public static void ForEach<T>(this IEnumerable<T> list, Action<T,Int32> action, Int32 StartShift = 0, Int32 EndShift = 0)
        {
            for (int i = StartShift; i < list.Count() - EndShift; i++)
            {
                action(list.ElementAt(i),i);
            }
        }
        public static IEnumerable<T> Take<T>(this IEnumerable<T> enumerable, Int32 StartShift=0,Int32 EndShift=0) {
            for (int i = StartShift; i < enumerable.Count() - EndShift;i++) {
                yield return enumerable.ElementAt(i);
            }
        }
        public static IEnumerable<T> EndTakeWhile<T>(this IEnumerable<T> enumerable, Predicate<T> predicate,Boolean TakeCrossElement=false) {
            Int32 start=0;
            for (int i = enumerable.Count(); i > 0; i--) {
                if (!predicate(enumerable.ElementAt(i - 1))) {
                    start = i;
                    break;
                }
            }
            if (TakeCrossElement) { start--; }
            for (int i = start; i < enumerable.Count(); i++)
            {
                yield return enumerable.ElementAt(i);
            }
        }
        public static IEnumerable<T> EndSkipWhile<T>(this IEnumerable<T> enumerable, Predicate<T> predicate,Boolean SkipCrossElement=false)
        {
            Int32 stop = 0;
            for (int i = enumerable.Count(); i > 0; i--)
            {
                if (!predicate(enumerable.ElementAt(i - 1)))
                {
                    stop = i;
                    break;
                }
            }
            if (SkipCrossElement) { stop--; }
            for (int i = 0; i < stop; i++)
            {
                yield return enumerable.ElementAt(i);
            }
        }
        
        //Controls
        public static void PopLast(this Control ConCol, Int32 EndShift = 0)
        {
            if (ConCol.Controls.Count > EndShift)
            {
                ConCol.Controls.RemoveAt(ConCol.Controls.Count - 1 - EndShift);
            }
        }
        public static Control Last(this Control.ControlCollection coll)
        {
            return coll[coll.Count - 1];
        }
        public static void ForEach(this Control.ControlCollection ConCol, Action<Control> Action, Int32 StartShift = 0, Int32 EndShift = 0)
        {
            for (int i = StartShift; i < ConCol.Count - EndShift; i++)
            {
                Action(ConCol[i]);
            }
        }

        //Other
        public static Size Div(this Size a, Int32 b)
        {
            return new Size(a.Width / b, a.Height / b);
        }
        public static Size Add(this Size size, Int32 addnum) {
            return new Size(size.Width +addnum, size.Height +addnum);
        }
        public static Int32 Int(this String a)
        {
            return Convert.ToInt32(a);
        }
        public static Int32 Int(this object a)
        {
            return Convert.ToInt32(a);
        }
        public static String SString(this Int32 a) {
            String str = "";
            foreach (char c in a.ToString())
            {
                if (c > 47 && c < 58)
                {
                    str += (char)(c + 143);
                }
                else str += c;
            }
            return str;
        }
    }
}