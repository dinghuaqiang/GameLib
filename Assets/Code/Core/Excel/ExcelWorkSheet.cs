using System.IO;
using UnityEditor;
using UnityEngine;

namespace GameLib.Core.Excel
{
    /// <summary>
    /// 整合excel结构，用二维数组来读取
    /// </summary>
    public class ExcelWorkSheet 
    {
        public Cells Cells;

        public ExcelWorkSheet(string excelPath, string sheetName = "sheet1")
        {
            Cells = new Cells(excelPath);
        }

        public int GetLength(int dimension)
        {
            if (Cells == null)
                return 0;
            return Cells.GetLength(dimension);
        }

        public void Append(int column, string value)
        {
            int row = GetLength(0);
            Cells[row, column] = value;
        }

        public void Append(string value)
        {
            int row = GetLength(0);
            int column = GetLength(1);
            Cells[row, column] = value;
        }

        public void Clear()
        {
            if (Cells != null)
                Cells.Clear();
        }

        public void Save()
        {
            Cells.Save();
        }

        public static void TestReadExcel()
        {
            ExcelWorkSheet sheet = new ExcelWorkSheet(@"H:\7shanmen\Gamedata\Config\achievement.xlsx");
            UnityEngine.Debug.Log("   " + sheet.Cells[5, 8]);
        }

        static void Main()
        {
            ExcelWorkSheet sheet = new ExcelWorkSheet(@"I:\7shanmen_trunk\Gamedata\Config\task.xlsx");
            UnityEngine.Debug.Log("   " + sheet.Cells[5, 8]);
        }
    }

    public class TestWindow : UnityEditor.EditorWindow
    {
        [UnityEditor.MenuItem("Test/ExcelSheetTest")]
        public static void Open()
        {
            TestWindow window = GetWindow<TestWindow>(true, "excel");
            window.minSize = new UnityEngine.Vector2(400, 400);
            window.Show();
        }

        private int _row;
        private int _collumn;
        private string _value;
        private string _excelPath;

        ExcelWorkSheet _excel;

        void OnGUI()
        {
            GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label("ExcelPath:");
            _excelPath = EditorGUILayout.TextField(_excelPath);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label("Row:");
            _row = EditorGUILayout.IntField(_row);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label("Column:");
            _collumn = EditorGUILayout.IntField(_collumn);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            UnityEngine.GUILayout.Label("Result:");
            _value = EditorGUILayout.TextField(_value);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Load excel"))
            {
                if (File.Exists(_excelPath))
                {
                    _excel = new ExcelWorkSheet(_excelPath);
                }
                else
                    UnityEngine.Debug.LogError("File not found: " + _excelPath);
            }

            if(GUILayout.Button("查询"))
            {
                _value = _excel.Cells[_row, _collumn];
            }

            if (GUILayout.Button("Clear"))
            {
                _excel.Clear();
            }

            if (GUILayout.Button("保存"))
            {
                _excel.Cells[_row, _collumn] = _value;
                _excel.Save();

                //UnityEngine.Debug.Log("" + (CreateCollumWord(int.Parse(_value))));
            }
            GUILayout.EndHorizontal();
        }

        private static string CreateCollumWord(int collum)
        {
            int normal = 'Z' - 'A' + 1;
            int num = collum / normal;
            int more = collum % normal;
            string value = "";
            value = "" + (char)('A' + more);
            while (num > 0)
            {
                more = num % normal;

                if (num <= normal)
                {
                    value = "" + (char)('A' + num - 1) + value;
                    break;
                }
                else
                    value = "" + (char)('A' + more - 1) + value;
                num = num / normal;
            }

            return value;
        }
    }
}
