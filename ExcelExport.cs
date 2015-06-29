using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace FileExplorer
{
    class ExcelExport
    {
        public ExcelExport()
        {
        }

        public static void Export(DataTable table)
        {
            //object misValue = System.Reflection.Missing.Value;
           
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWb;
            Excel.Worksheet excelWs;

            excelWb = excelApp.Workbooks.Add();
            excelWs = (Excel.Worksheet)excelWb.ActiveSheet;

            // Insert Headings
            excelWs.get_Range("A1", "B1").Font.Bold = true;
            excelWs.get_Range("A1", "B1").Font.Size = 16;
            excelWs.get_Range("A1", "B1").Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble;
            excelWs.get_Range("A1", "B1").Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlThick;
            excelWs.get_Range("A1", "B1").Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            for (int i = 0; i < table.Columns.Count; i++)
                excelWs.Cells[1, (i + 1)] = table.Columns[i].ColumnName;
            // Root Heading
            excelWs.get_Range("A1", "B1").Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            excelWs.get_Range("A2", "B2").Font.Bold = true;
            excelWs.get_Range("A2", "B2").Font.Size = 16;
            excelWs.get_Range("A2", "B2").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
            excelWs.get_Range("A2", "B2").Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThick;
            excelWs.get_Range("A2", "B2").Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin;
            excelWs.Cells[2, 1] = table.Rows[0][0];

            // Insert Data
            for (int i = 1; i < table.Rows.Count; i++)
            {
                if (!table.Rows[i][0].Equals(""))
                {
                    //excelWs.Range[excelWs.Cells[i + 2, 1], excelWs.Cells[i + 2, 2]].Merge();
                    excelWs.Range[excelWs.Cells[i + 2, 1], excelWs.Cells[i + 2, 2]].Font.Bold = true;
                    excelWs.Range[excelWs.Cells[i + 2, 1], excelWs.Cells[i + 2, 2]].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThick;
                    excelWs.Range[excelWs.Cells[i + 2, 1], excelWs.Cells[i + 2, 2]].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;
                }
                for (int j = 0; j < table.Columns.Count; j++)
                    excelWs.Cells[(i + 2), (j + 1)] = table.Rows[i][j];
            }

            // AutoFit Colums
            excelWs.Columns[1].AutoFit();
            excelWs.Columns[2].AutoFit();

            excelApp.Visible = true;

        }
    }
}