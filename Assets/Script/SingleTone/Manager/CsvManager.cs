using UnityEngine;
using System.Collections.Generic;
public class CsvInfo
{
    public readonly string CsvFileName;
    public List<List<string>> csvData;
    public List<ItemInfo> itemInfo;

    public CsvInfo(string CsvFileName)
    {
        this.CsvFileName = CsvFileName;
        csvData = new List<List<string>>();
        itemInfo = new List<ItemInfo>();
    }
}

public class ItemInfo
{
    public int itemNumber;
}

public class QuestInfo
{

}




public class CsvManager : Singleton<CsvManager>
{
    

    // ��ũ��Ʈ���� ����
    public CsvInfo csvItemInfo {  get; private set; }
    public List<List<int>> itemInfo;
    public CsvInfo csvQuestInfo { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        // ������ ���� �о����

        csvItemInfo = new CsvInfo("Item");
        CsvProcess(csvItemInfo);
        itemInfo = CsvProcessor.Instance.csvIntoInteager(csvItemInfo);
        CsvProcessor.Instance.CheckCsv(csvItemInfo.CsvFileName, itemInfo);

        // ����Ʈ ���� �о����
        csvQuestInfo = new CsvInfo("Quest");
        CsvProcess(csvQuestInfo);

    }

    private void CsvProcess(CsvInfo csvInfo)
    {
        TextAsset csvFile = Resources.Load<TextAsset>(csvInfo.CsvFileName);
        CsvProcessor.Instance.CsvLoading(csvFile, csvInfo.csvData);
        //CsvProcessor.Instance.CheckCsv(csvInfo.CsvFileName, csvInfo.csvData);
    }

    public CsvInfo GetCsvInfo(string CsvName)
    {
        if(CsvName == csvItemInfo.CsvFileName)
        {
            return csvItemInfo;
        }
        else if (CsvName == csvQuestInfo.CsvFileName)
        {
            return csvQuestInfo;
        }
        return null;
    }

    
}


