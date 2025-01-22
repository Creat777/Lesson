using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CsvProcessor : Singleton<CsvProcessor>
{

    void Start()
    {
        
    }
    public virtual void CsvLoading(TextAsset csvFile, List<List<string>> CsvData)
    {
        if (csvFile != null)
        {
            // csv파일을 \n 문자를 기준으로 분할
            string[] rows = csvFile.text.Split('\n');

            int rowNumber = 0;
            foreach (string row in rows) 
            {
                // 첫행은 데이터 버리기
                if (rowNumber++ == 0) continue;

                // 각 행을 쉽표(을 기준으로 분할
                string[] fileds = row.Split(',');
                
                // 첫번째 열, 세번째 열만 데이터 읽기
                if (fileds.Length >= 3)
                {
                    List<string> rowData = new List<string>();
                    rowData.Add(fileds[0]);
                    rowData.Add(fileds[2]);
                    CsvData.Add(rowData);
                }
                else
                {
                    Debug.Log($"쓰레기 데이터 제거 : {fileds[0]}");
                }
            }
        }
        else
        {
            Debug.Log("csv파일 Load실패");
        }
    }

    public List<List<int>> csvIntoInteager(CsvInfo csvinfo)
    {
        List<List<int>> returnValue = new List<List<int>>();

        List<List<string>> csvData = csvinfo.csvData;
        for (int i = 0; i < csvData.Count; i++)
        {
            // 행 시작
            List<int> rowInt = new List<int>();
            for (int j = 0; j < csvData[i].Count; j++)
            {
                rowInt.Add(int.Parse(csvData[i][j]));
            }

            // 행 종료
            returnValue.Add(rowInt);
        }

        return returnValue;

    }

    public virtual void CheckCsv(string csvFileName, List<List<string>> CsvData)
    {
        int row_num = 0;
        Debug.Log(csvFileName + " : ");
        foreach (var row in CsvData)
        {
            
            Debug.Log($"[ {++row_num} ]행");
            int field_num = 0;
            foreach (var field in row)
            {
                Debug.Log($"{++field_num}열 " + field);
            }
        }
    }

    public virtual void CheckCsv(string csvFileName, List<List<int>> CsvData)
    {
        int row_num = 0;
        Debug.Log(csvFileName + " : ");
        foreach (var row in CsvData)
        {

            Debug.Log($"[ {++row_num} ]행");
            int field_num = 0;
            foreach (var field in row)
            {
                Debug.Log($"{++field_num}열 " + field);
            }
        }
    }

    public CsvInfo FindCsvInfo(string CsvName, List<CsvInfo> csvInfos)
    {
        foreach (var csvInfo in csvInfos)
        {
            // ex) Interactive_Bed

            // 이름이 같으면 해당하는 csvinfo를 찾은것임
            if (csvInfo.CsvFileName == CsvName)
            {
                return csvInfo;
            }
        }
        return null;
    }
}
