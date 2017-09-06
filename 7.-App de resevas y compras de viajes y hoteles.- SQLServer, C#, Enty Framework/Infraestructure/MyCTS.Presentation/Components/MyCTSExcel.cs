using System;
using System.Collections.Generic;
using System.Text;
using oExcel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace MyCTS.Presentation.Components
{
    public class MyCTSExcel : IDisposable
    {
        #region Variables and Properties

        private oExcel.Application oApp = null;
        private oExcel._Workbook oWorkbook = null;
        private oExcel._Worksheet oWorksheet = null;
        private oExcel.Range oRange = null;
        private bool _isObjectCreated;
        private int _workSheetIndex = -1;
        private System.Globalization.CultureInfo oldCI;
        private int defaultWidth = -1;

        /// <summary>
        /// Indica si el objeto fue creado correctamente
        /// </summary>
        public bool IsObjectCreated
        {
            get { return _isObjectCreated; }
            set { _isObjectCreated = value; }
        }

        /// <summary>
        /// Obtiene o asigne el índice de la hoja actual 
        /// (libro excel)
        /// </summary>
        public int WorkSheetIndex
        {
            get { return _workSheetIndex; }
            set { _workSheetIndex = value; }
        }

        /// <summary>
        /// Alineación del texto
        /// </summary>
        public enum Alignment
        {
            TopLeft = 1,
            /// <summary>
            /// Arriba a la derecha
            /// </summary>
            TopRight = 2,
            /// <summary>
            /// Arriba en el centro
            /// </summary>
            TopCenter = 3,
            /// <summary>
            /// En medio izquierda
            /// </summary>
            MiddleLeft = 4,
            /// <summary>
            /// En medio a la derecha
            /// </summary>
            MiddleRight = 5,
            /// <summary>
            /// En medio en el centro
            /// </summary>
            MiddleCenter = 6,
            /// <summary>
            /// Abajo a la izquierda
            /// </summary>
            BottomLeft = 7,
            /// <summary>
            /// Abajo a la derecha
            /// </summary>
            BottomRight = 8,
            /// <summary>
            /// Abajo en el centro
            /// </summary>
            BottomCenter = 9
        }

        #endregion

        #region Cell Class
        public class Cell
        {
            private Color m_fontColor;
            private int m_row;
            private int m_col;
            private string m_title;
            private bool m_bold;
            private bool m_wrapText;
            private int m_fontsize;
            private Color m_borderColor;
            private Alignment m_alignment;
            private decimal m_columnWidth;
            private Color m_backColor;
            private int m_wide;
            private bool m_showBorder;

            /// <summary>
            /// Escribe en la celda determinada el texto con formato
            /// </summary>
            /// <param name="row">Fila</param>
            /// <param name="col">Columna</param>
            /// <param name="title">Texto que va en la celda</param>
            public Cell(int row, int col, string title)
            {
                m_row = row;
                m_col = col;
                m_title = title;
                m_fontColor = Color.Black;
                m_bold = false;
                m_wrapText = false;
                m_fontsize = 10;
                m_borderColor = Color.Black;
                m_alignment = Alignment.MiddleLeft;
                m_columnWidth = -1;
                m_wide = 0;
                m_backColor = Color.White;

                m_showBorder = true;
            }
            /// <summary>
            /// Color de la letra
            /// </summary>
            public Color FontColor
            {
                get
                {
                    return m_fontColor;
                }
                set
                {
                    m_fontColor = value;
                }
            }

            /// <summary>
            /// Fila
            /// </summary>
            public int Row
            {
                get
                {
                    return m_row;
                }
                set
                {
                    m_row = value;
                }
            }

            /// <summary>
            /// Columna
            /// </summary>
            public int Col
            {
                get
                {
                    return m_col;
                }
                set
                {
                    m_col = value;
                }
            }

            /// <summary>
            /// Texto que se muestra en la celda
            /// </summary>
            public string Title
            {
                get
                {
                    return m_title;
                }
                set
                {
                    m_title = value;
                }
            }

            /// <summary>
            /// Indica si el texto lleva negritas
            /// </summary>
            public bool Bold
            {
                get
                {
                    return m_bold;
                }
                set
                {
                    m_bold = value;
                }
            }

            /// <summary>
            /// Indica si el texto se ajusta al ancho de la columna o si toma el tamaño del texto completo
            /// </summary>
            public bool WrapText
            {
                get
                {
                    return m_wrapText;
                }
                set
                {
                    m_wrapText = value;
                }
            }

            /// <summary>
            /// Indica el tamaño de letra
            /// </summary>
            public int FontSize
            {
                get
                {
                    return m_fontsize;
                }
                set
                {
                    m_fontsize = value;
                }
            }

            /// <summary>
            /// Indica el color de los bordes
            /// </summary>
            public Color BorderColor
            {
                get
                {
                    return m_borderColor;
                }
                set
                {
                    m_borderColor = value;
                }
            }

            /// <summary>
            /// Indica la alineación del texto
            /// </summary>
            public Alignment Alignment
            {
                get
                {
                    return m_alignment;
                }
                set
                {
                    m_alignment = value;
                }
            }

            /// <summary>
            /// Indica el ancho que lleva la columna
            /// </summary>
            public decimal ColumnWidth
            {
                get
                {
                    return m_columnWidth;
                }
                set
                {
                    m_columnWidth = value;
                }
            }

            /// <summary>
            /// Color fondo de celda
            /// </summary>
            public Color BackColor
            {
                get
                {
                    return m_backColor;
                }
                set
                {
                    m_backColor = value;
                }
            }

            /// <summary>
            /// Largo
            /// </summary>
            public int Wide
            {
                get
                {
                    return m_wide;
                }
                set
                {
                    m_wide = value;
                }
            }

            /// <summary>
            /// Muestra borde sobre la celda
            /// </summary>
            public bool ShowBorder
            {
                get { return m_showBorder; }
                set { m_showBorder = value; }
            }
        }
        #endregion

        #region Constructor

        public MyCTSExcel()
        {
            oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Crea objeto Excel
        /// </summary>
        /// <param name="workSheetName">Nombre de hoja</param>
        public void CreateExcelObject(string workSheetName)
        {
            CreateExcelObject(workSheetName, false);
        }

        /// <summary>
        /// Crea objeto Excel
        /// </summary>
        /// <param name="workSheetName">Nombre de hoja</param>
        /// <param name="isVisible">True = es visible para el usuario la creación del documento</param>
        public void CreateExcelObject(string workSheetName, bool isVisible)
        {
            try
            {
                oApp = new oExcel.Application();
                oApp.Visible = isVisible;
                try
                {
                    oWorkbook = (oExcel._Workbook)(oApp.Workbooks.Add(Missing.Value));
                }
                catch
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture =
                        new System.Globalization.CultureInfo("en-US");
                    oWorkbook = (oExcel._Workbook)(oApp.Workbooks.Add(Missing.Value));
                }

                oWorksheet = (oExcel._Worksheet)oWorkbook.ActiveSheet;
                oApp.DisplayAlerts = false;
                oWorksheet.Name = workSheetName;
                IsObjectCreated = true;
            }
            catch
            {
                IsObjectCreated = false;
            }
        }

        /// <summary>
        /// Crea objeto Excel con varias hojas
        /// </summary>
        /// <param name="workSheetNames">Arreglo con el nombre de las hojas</param>
        public void CreateExcelObject(string[] workSheetNames)
        {
            CreateExcelObject(workSheetNames, false);
        }

        /// <summary>
        /// Crea objeto Excel con varias hojas
        /// </summary>
        /// <param name="workSheetNames">Arreglo con el nombre de las hojas</param>
        /// <param name="isVisible"></param>
        /// <param name="isVisible">True = es visible para el usuario la creación del documento</param>
        public void CreateExcelObject(string[] workSheetNames, bool isVisible)
        {
            try
            {
                oApp = new oExcel.Application();
                oApp.Visible = isVisible;
                oWorkbook = (oExcel._Workbook)(oApp.Workbooks.Add(Missing.Value));

                foreach (string w in workSheetNames)
                {
                    oExcel._Worksheet workSheet = (oExcel._Worksheet)oWorkbook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    workSheet.Name = w;
                }
                oApp.DisplayAlerts = false;
                IsObjectCreated = true;
            }
            catch
            {
                IsObjectCreated = false;
            }
        }

        /// <summary>
        /// Escribe en la celda determinada el texto con formato
        /// </summary>
        /// <param name="c">Objeto de tipo celda</param>
        public void CreateCell(Cell c)
        {
            if (WorkSheetIndex.Equals(-1))
                oWorksheet = (oExcel._Worksheet)oWorkbook.ActiveSheet;
            else
                oWorksheet = (oExcel._Worksheet)oWorkbook.Worksheets[WorkSheetIndex];

            string cell = string.Empty;

            if (c.Col > 26 && c.Col < 53)
                cell = string.Concat('A', ((char)(c.Col - 26 + 64)), c.Row.ToString());
            else if (c.Col > 52 && c.Col < 79)            
                cell = string.Concat('B', ((char)(c.Col - 52 + 64)), c.Row.ToString());
            else 
                cell = ((char)(c.Col + 64)) + c.Row.ToString();

            oWorksheet.Cells[c.Row, c.Col] = c.Title;
            oRange = oWorksheet.get_Range(cell, cell);

            if (c.WrapText)
                oRange.WrapText = c.WrapText;
            else
                oWorksheet.get_Range(cell, cell).EntireColumn.AutoFit();

            if (c.ColumnWidth != defaultWidth)
                oWorksheet.get_Range(cell, cell).EntireColumn.ColumnWidth = c.ColumnWidth;
            
            if (c.Wide > 0)
            {
                oRange = oWorksheet.get_Range(oWorksheet.Cells[c.Row, c.Col], oWorksheet.Cells[c.Row, c.Col + c.Wide]);
                oRange.Merge(true);
            }

            switch (c.Alignment)
            {
                case Alignment.TopLeft:
                    oWorksheet.get_Range(cell, cell).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    oWorksheet.get_Range(cell, cell).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    break;
                case Alignment.TopCenter:
                    oWorksheet.get_Range(cell, cell).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    oWorksheet.get_Range(cell, cell).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    break;
                case Alignment.TopRight:
                    oWorksheet.get_Range(cell, cell).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    oWorksheet.get_Range(cell, cell).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    break;
                case Alignment.BottomLeft:
                    oWorksheet.get_Range(cell, cell).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    oWorksheet.get_Range(cell, cell).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    break;
                case Alignment.BottomCenter:
                    oWorksheet.get_Range(cell, cell).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    oWorksheet.get_Range(cell, cell).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    break;
                case Alignment.BottomRight:
                    oWorksheet.get_Range(cell, cell).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    oWorksheet.get_Range(cell, cell).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    break;
                case Alignment.MiddleLeft:
                    oWorksheet.get_Range(cell, cell).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    oWorksheet.get_Range(cell, cell).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    break;
                case Alignment.MiddleCenter:
                    oWorksheet.get_Range(cell, cell).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    oWorksheet.get_Range(cell, cell).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    break;
                case Alignment.MiddleRight:
                    oWorksheet.get_Range(cell, cell).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    oWorksheet.get_Range(cell, cell).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    break;
            }

            oRange.Font.Bold = c.Bold;
            oRange.Font.Size = c.FontSize;
            oRange.Font.Color = System.Drawing.ColorTranslator.ToWin32(c.FontColor);

            if (c.ShowBorder)
                oRange.Borders.Color = System.Drawing.ColorTranslator.ToWin32(c.BorderColor);

            if (!c.BackColor.Equals(Color.White))
                oRange.Interior.Color = System.Drawing.ColorTranslator.ToWin32(c.BackColor);
        }           

        /// <summary>
        /// Salva el archivo Excel
        /// </summary>
        /// <param name="fileName">Ruta y nombre del archivo</param>
        public void SaveFile(string fileName)
        {
            object missing = Type.Missing;
            oWorkbook.SaveAs(fileName, oExcel.XlFileFormat.xlWorkbookNormal,
                 missing, missing, false, false, oExcel.XlSaveAsAccessMode.xlNoChange, false, false, missing, missing, missing);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (oApp != null)
            {
                try
                {
                    oApp.Workbooks.Close();
                }
                catch { }
                oApp.Quit();
            }

            if (oRange != null) Marshal.ReleaseComObject(oRange);
            if (oWorksheet != null) Marshal.ReleaseComObject(oWorksheet);
            if (oWorkbook != null) Marshal.ReleaseComObject(oWorkbook);
            if (oApp != null) Marshal.ReleaseComObject(oApp);

            oWorksheet = null;
            oWorkbook = null;
            oApp = null;

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

            GC.Collect();
        }

        #endregion

        //todo:Ejemplo MyCTSExcel2
        /*
         * using (MyCTSExcel objExcel = new MyCTSExcel())
            {
                objExcel.CreateExcelObject("MyCTS");

                if (objExcel.IsObjectCreated)
                {
                    int row = 2;
                    MyCTSExcel.Cell cell = null;

                    cell = new MyCTSExcel.Cell(row, 1, "$132432429.34");
                    cell.FontColor = Color.Fuchsia;
                    cell.BackColor = Color.Orange;
                    cell.BorderColor = Color.Yellow;                    
                    cell.WrapText = false;
                    cell.Alignment = MyCTSExcel.Alignment.TopLeft;
                    objExcel.CreateCell(cell);

                    cell = new MyCTSExcel.Cell(row, 2, "INDICE_COPORATIVO" + "\n" + "VS" + "\n" + "ALGO_MAS");
                    cell.Bold = true;
                    cell.Alignment = MyCTSExcel.Alignment.MiddleCenter;
                    cell.ColumnWidth = 35;
                    objExcel.CreateCell(cell);

                    cell = new MyCTSExcel.Cell(row+1, 2, "El texto que va dentro de indice coporativo medio largo");
                    cell.WrapText = true;
                    objExcel.CreateCell(cell);

                    cell = new MyCTSExcel.Cell(row, 10, "INDICE ME SIGO CON EL TEXTO COPORATIVO");
                    cell.WrapText = false;
                    cell.Bold  =true;
                    cell.BorderColor = Color.White;
                    cell.FontColor = Color.Green;
                    objExcel.CreateCell(cell);

                    objExcel.SaveFile(fileName);
                }
            }
         */

    }
}
