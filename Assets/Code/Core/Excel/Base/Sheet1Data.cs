using System.Collections.Generic;
using System.Xml;

namespace GameLib.Core.Excel
{
    /// <summary>
    /// sheet1.xml
    /// </summary>
    public class Sheet1Data
    {
        //Sheet1.xml
        private XmlDocument _document = null;
        private XmlElement _rowRoot = null;
        private List<Sheet1RowData> _rowDataArray = null;
        //sharedStrings.xml的数据
        private Sheet1SharedData _shareData = null;

        public Sheet1Data(Sheet1SharedData shareData)
        {
            _shareData = shareData;
        }

        internal void Clear()
        {
            if(_rowRoot != null)
            {
                _rowRoot.RemoveAll();
            }

            if(_shareData != null)
            {
                _shareData.Clear();
            }
            if (_rowDataArray != null)
                _rowDataArray.Clear();
        }

        public void Parse(XmlDocument document)
        {
            _document = document;
            _rowRoot = _document.DocumentElement["sheetData"];
            var nodeList = _rowRoot.GetElementsByTagName("row");
            _rowDataArray = new List<Sheet1RowData>();

            int lastRow = 0;
            for (int i =0; i < nodeList.Count; ++i)
            {
                XmlElement rowNode = nodeList[i] as XmlElement;
                Sheet1RowData rowData = new Sheet1RowData(_shareData);
                rowData.ParseRowNode(rowNode);
                if (lastRow + 1 < rowData.Row)
                {
                    //如果中间有空行,那么就填充一些空行数据
                    for (int lr = lastRow + 1; lr < rowData.Row; lr++)
                    {
                        _rowDataArray.Add(Sheet1RowData.CreateData(lr, 0, _shareData, new string[0]));
                        //UnityEngine.Debug.LogError("Row:::"+lr+";;; empty");
                    }
                }
                _rowDataArray.Add(rowData);
                
                lastRow = rowData.Row;
                //UnityEngine.Debug.LogError("Row:::" + lastRow + ";;;" + rowNode.OuterXml);
            }
            
        }

        public void AddRow(string[] dataArray)
        {
            var rowData = Sheet1RowData.CreateData(_rowDataArray.Count + 1, dataArray.Length, _shareData, dataArray);
            _rowDataArray.Add(rowData);

            XmlElement rowNode = Sheet1RowData.ToXmlElement(_document, rowData);
            _rowRoot.AppendChild(rowNode);
        }

        public XmlDocument ToXmlDocument()
        {
            var attrs = _rowRoot.Attributes;
            _rowRoot.RemoveAll();

            for (int i = 0; i < _rowDataArray.Count; ++i)
            {
                if (_rowDataArray[i] == null)
                    continue;

                XmlElement rowNode = Sheet1RowData.ToXmlElement(_document, _rowDataArray[i]);
                _rowRoot.AppendChild(rowNode);
            }
            return _document;
        }

        public List<Sheet1RowData> GetAllData()
        {
            return _rowDataArray;
        }
    }
}
