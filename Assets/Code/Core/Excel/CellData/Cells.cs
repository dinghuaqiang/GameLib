using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace GameLib.Core.Excel
{
    /// <summary>
    /// 所有表格数据
    /// </summary>
    public class Cells : XmlReadExcel
    {
        private Sheet1Data _datas;

        public Cells(string excelPath)
        {
            Parse(excelPath);
            _datas = _sheetData;
        }


        public string this[int i, int j]
        {
            get
            {
                var rowDatas = _datas.GetAllData();
                if (rowDatas == null || i >= rowDatas.Count)
                    return null;

                var rows = rowDatas[i];
                if (rows == null) return null;
                var columns = rows.GetCollumDatas();
                if (j >= columns.Count || columns[j] == null)
                    return null;
                return columns[j].ShareValue;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;
                TryExpandSheet(i, j);

                var allDatas = _datas.GetAllData();
                var rowData = allDatas[i];
                rowData.AddValue(value, j);
            }
        }

        public int GetLength(int dimension)
        {
            var allData = _datas.GetAllData();
            if (dimension == 0)
            {
                return allData.Count;
            }
            else
                return allData[0].GetCollumnCount();
        }

        //某一行的有效数据列数
        public int GetColumnNum(int row)
        {
            var allData = _datas.GetAllData();
            if (row >= 0 && row < allData.Count)
                return allData[row].GetCollumnCount();

            return 0;
        }

        internal void Clear()
        {
            if(_sheetData != null)
            {
                _sheetData.Clear();
            }
        }

        //尝试扩展表格，如果row或者collumn比存放的索引更大，则需要扩充
        private void TryExpandSheet(int row, int collumn)
        {
            var rowDatas = _datas.GetAllData();
            int spans = 0;
            if (row >= rowDatas.Count)
            {
                if(rowDatas.Count > 0)
                    spans = rowDatas[rowDatas.Count - 1].GetCollumnCount();
                int deltaRow = row - rowDatas.Count + 1;
                for(int i = 0; i < deltaRow; ++i)
                {
                    rowDatas.Add(null);
                }
            }

            if (rowDatas[row] == null)
            {
                rowDatas[row] = new Sheet1RowData(_shareData);
                rowDatas[row].Row = row + 1;
                rowDatas[row].SpansMax = spans;
            }

            var curRowData = rowDatas[row];

            curRowData.TryExpandCollumn(collumn);
        }
    }
}
