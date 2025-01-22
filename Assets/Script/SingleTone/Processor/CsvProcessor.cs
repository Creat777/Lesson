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
            // csv������ \n ���ڸ� �������� ����
            string[] rows = csvFile.text.Split('\n');

            int rowNumber = 0;
            foreach (string row in rows) 
            {
                // ù���� ������ ������
                if (rowNumber++ == 0) continue;

                // �� ���� ��ǥ(�� �������� ����
                string[] fileds = row.Split(',');
                
                // ù��° ��, ����° ���� ������ �б�
                if (fileds.Length >= 3)
                {
                    List<string> rowData = new List<string>();
                    rowData.Add(fileds[0]);
                    rowData.Add(fileds[2]);
                    CsvData.Add(rowData);
                }
                else
                {
                    Debug.Log($"������ ������ ���� : {fileds[0]}");
                }
            }
        }
        else
        {
            Debug.Log("csv���� Load����");
        }
    }

    public List<List<int>> csvIntoInteager(CsvInfo csvinfo)
    {
        List<List<int>> returnValue = new List<List<int>>();

        List<List<string>> csvData = csvinfo.csvData;
        for (int i = 0; i < csvData.Count; i++)
        {
            // �� ����
            List<int> rowInt = new List<int>();
            for (int j = 0; j < csvData[i].Count; j++)
            {
                rowInt.Add(int.Parse(csvData[i][j]));
            }

            // �� ����
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
            
            Debug.Log($"[ {++row_num} ]��");
            int field_num = 0;
            foreach (var field in row)
            {
                Debug.Log($"{++field_num}�� " + field);
            }
        }
    }

    public virtual void CheckCsv(string csvFileName, List<List<int>> CsvData)
    {
        int row_num = 0;
        Debug.Log(csvFileName + " : ");
        foreach (var row in CsvData)
        {

            Debug.Log($"[ {++row_num} ]��");
            int field_num = 0;
            foreach (var field in row)
            {
                Debug.Log($"{++field_num}�� " + field);
            }
        }
    }

    public CsvInfo FindCsvInfo(string CsvName, List<CsvInfo> csvInfos)
    {
        foreach (var csvInfo in csvInfos)
        {
            // ex) Interactive_Bed

            // �̸��� ������ �ش��ϴ� csvinfo�� ã������
            if (csvInfo.CsvFileName == CsvName)
            {
                return csvInfo;
            }
        }
        return null;
    }
}
