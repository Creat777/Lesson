using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : Singleton<PlayerPrefsManager>
{
    private const string ItemsKey = "SavedItems";

    // �Ѱ��� ���� �������� �����ȣ�� �����
    HashSet<int> item_IDsHash;

    protected override void Awake()
    {
        base.Awake();
        item_IDsHash = new HashSet<int>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public int LastSvaedItemCheck()
    {
        int lastItemID = GetLastItemNumber();
        return (lastItemID + 1);
    }

    public void SaveItem(int itemID)
    {
        HashSet<int> savedItems = Load_Item_IDs();

        if(savedItems.Contains(itemID))
        {
            Debug.Log($"Item {itemID} is already saved.");
            return;
        }
        else
        {
            savedItems.Add(itemID);
        }

        PlayerPrefs.SetString(ItemsKey, string.Join(",", savedItems) );
        PlayerPrefs.Save();

        Debug.Log($"Item {itemID} saved successfully");
    }

    public HashSet<int> GetItemListInfo()
    {
        if(item_IDsHash.Count == 0)
        {
            Load_Item_IDs();
        }

        foreach (var item in item_IDsHash)
        {
            Debug.Log($"saved itemID_int : {item}");
        }

        return item_IDsHash;
    }

    // HashSet<int> -> int���� �ߺ��� ������ ���� �����ϴ� �ڷᱸ��
    HashSet<int> Load_Item_IDs()
    {
        string savedData = PlayerPrefs.GetString(ItemsKey, string.Empty);

        if(string.IsNullOrEmpty(savedData))
        {
            return new HashSet<int>();
        }

        string[] itemStrings = savedData.Split(',');

        // �ʱ�ȭ�ϰ� �����͸� �Է�
        item_IDsHash.Clear();
        foreach (string itemID_string in itemStrings)
        {
            Debug.Log($"saved itemID_int : {itemID_string}");

            // ������ ��ȯ�� �� ������ itemID���� �޾Ƴ��� ���θ� ����
            if (int.TryParse(itemID_string, out int itemID_int))
            {
                item_IDsHash.Add(itemID_int);
            }
        }

        return item_IDsHash;
    }

    // ���������� ����� ������ ��ȣ ��ȯ
    public int GetLastItemNumber()
    {
        HashSet<int> savedItems = Load_Item_IDs();
        if(savedItems.Count == 0)
        {
            Debug.LogWarning("No items are saved");
            return -1; // 
        }

        int maxItemNumber = int.MinValue;

        foreach(int itemID in savedItems)
        {
            if(itemID > maxItemNumber)
            {
                maxItemNumber = itemID;
            }
        }

        Debug.Log($"Last saved itemID_string number : {maxItemNumber}");
        return maxItemNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
