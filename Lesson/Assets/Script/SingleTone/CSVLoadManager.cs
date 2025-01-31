using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ItemInfo
{
    public int item_number;
    public int ability;
}

public class QuestInfo
{

}

public class CSVLoadManager : Singleton<CSVLoadManager>
{
    // 아이템 정보
    private List<List<string>> csvItemData = new List<List<string>>();
    private List<ItemInfo> itemInfo = new List<ItemInfo>();

    // 퀘스트 정보
    private List<List<string>> csvQuestData = new List<List<string>>();
    private List<QuestInfo> questInfo = new List<QuestInfo>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        base.Awake();
        // 아이템 정보 읽어오기
        LoadItemCsv();
        // 퀘스트 정보 읽어오기
        LoadQuestCsv();
        
    }

    public List<ItemInfo> GetItemList()
    {
        return itemInfo;
    }

    void LoadItemCsv()
    {
        TextAsset csvFile = Resources.Load<TextAsset>("Item");
        if (csvFile != null)
        {
            Debug.Log("파일이 존재합니다.");

            string[] rows = csvFile.text.Split('\n');

            foreach (string row in rows)
            {
                string[] fields = row.Split(',');
                List<string> rowData = new List<string>(fields);
                csvItemData.Add(rowData);
            }

            int row_num = 0;
            foreach (List<string> row in csvItemData)
            {
                if(row_num == 0)
                {
                    row_num++;
                    continue;
                }

                Debug.Log("[" + row_num + "]");
                ItemInfo info = new ItemInfo();

                int field_num = 0;
                foreach (string field in row)
                {
                    Debug.Log("field : " + field);
                    switch (field_num)
                    {
                        case 0: info.item_number = int.Parse(field); break;
                        case 1: break; //이름
                        case 2: info.ability = int.Parse(field); break;

                    }
                    field_num++;
                }

                itemInfo.Add(info);
                row_num++;
            }
        }
        else
        {
            Debug.Log("파일이 존재하지 않습니다.");
        }
    }

    void LoadQuestCsv()
    {

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
