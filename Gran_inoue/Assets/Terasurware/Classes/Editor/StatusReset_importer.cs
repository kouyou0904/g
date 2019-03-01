using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class StatusReset_importer : AssetPostprocessor
{
    private static readonly string filePath = "Assets/Resources/Date2/StatusReset.xlsx";
    private static readonly string[] sheetNames = { "StatusReset", };
    
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets)
        {
            if (!filePath.Equals(asset))
                continue;

            using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
				IWorkbook book = null;
				if (Path.GetExtension (filePath) == ".xls") {
					book = new HSSFWorkbook(stream);
				} else {
					book = new XSSFWorkbook(stream);
				}

                foreach (string sheetName in sheetNames)
                {
                    var exportPath = "Assets/Resources/Date2/" + sheetName + ".asset";
                    
                    // check scriptable object
                    var data = (Entity_StatusReset)AssetDatabase.LoadAssetAtPath(exportPath, typeof(Entity_StatusReset));
                    if (data == null)
                    {
                        data = ScriptableObject.CreateInstance<Entity_StatusReset>();
                        AssetDatabase.CreateAsset((ScriptableObject)data, exportPath);
                        data.hideFlags = HideFlags.NotEditable;
                    }
                    data.param.Clear();

					// check sheet
                    var sheet = book.GetSheet(sheetName);
                    if (sheet == null)
                    {
                        Debug.LogError("[QuestData] sheet not found:" + sheetName);
                        continue;
                    }

                	// add infomation
                    for (int i=1; i<= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        ICell cell = null;
                        
                        var p = new Entity_StatusReset.Param();
			
					cell = row.GetCell(0); p.ID = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(1); p.NAME = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.HP = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(3); p.Att = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(4); p.Def = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(5); p.Matt = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.Mdef = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(7); p.Imap = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(8); p.Wei = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(9); p.Tec = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(10); p.Avo = (int)(cell == null ? 0 : cell.NumericCellValue);

                        data.param.Add(p);
                    }
                    
                    // save scriptable object
                    ScriptableObject obj = AssetDatabase.LoadAssetAtPath(exportPath, typeof(ScriptableObject)) as ScriptableObject;
                    EditorUtility.SetDirty(obj);
                }
            }

        }
    }
}
