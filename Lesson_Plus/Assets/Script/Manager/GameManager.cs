using UnityEngine;
using System.Collections.Generic;

public enum eScene
{
    LOBBY,
    INGAME,
}

class InventoryItemInfo
{

}

class MyCharState
{
    int Level;
    int Exp;
}

public class GameManager : MonoBehaviour
{
    // �� �κ��丮�� ��� �ִ� ������ ����
    // ���� �ؾ� �� ����Ʈ ����
    // �� ĳ���� ���� ����

    public CSVLoadManager csvloadManager;
    public PlayerPrefsManager prefsManager;

    eScene currenScene = eScene.LOBBY;

    List<ItemInfo> iteminfoList = new List<ItemInfo>();

    // Lobby �� ������ �ִ� �˾� UI
    GameObject inventoryPopup;
    GameObject questPopup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if(currenScene == eScene.LOBBY)
        {
            inventoryPopup = GameObject.Find("InventoryPopup").gameObject;
            inventoryPopup.SetActive(false);

            Debug.Log("current Scene Lobby");
           


        }
        else if(currenScene == eScene.INGAME)
        {
            Debug.Log("current Scene Ingame");
        }

    }

    public void InventoryPopupOpen()
    {
        // csv���� �Ŵ������� ��������
        List<ItemInfo> itemList = csvloadManager.GetItemList();

        foreach (ItemInfo info in itemList)
        {
            Debug.Log("item_number : " + info.item_number +" ability : "+ info.ability);
        }

        // playerPrefs�� ���� ������ ������ ���� ��������
        prefsManager.GetItemListInfo();

        // ���� ������ �������� csv������ ����

        // UI ������ �˾� �����ϱ�

        inventoryPopup.SetActive(true);
    }

    public void AddItem(GameObject item)
    {
        // PlayerPrefs�� ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
