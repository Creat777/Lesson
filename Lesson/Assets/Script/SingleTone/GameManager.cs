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

public class GameManager : Singleton<GameManager>
{
    // �� �κ��丮�� ��� �ִ� ������ ����
    // ���� �ؾ� �� ����Ʈ ����
    // �� ĳ���� ���� ����

    public CSVLoadManager csvloadManager;
    public PlayerPrefsManager playerPrefsManager;

    eScene currenScene = eScene.LOBBY;

    List<ItemInfo> iteminfoList;

    // Lobby �� ������ �ִ� �˾� UI
    GameObject inventoryPopup;
    GameObject questPopup;

    protected override void Awake()
    {
        base.Awake();
        iteminfoList = new List<ItemInfo>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

        // playerPrefs�� ���� ������ ������ ���� ��������
        HashSet<int> ItemHash= new HashSet<int>();
        ItemHash = playerPrefsManager.GetItemListInfo();

        // ���� ������ �������� csv������ ����
        // ������ ������ ���� ����� �����ȣ��ŭ �������� ȭ�鿡 ǥ��

        // UI ������ �˾� �����ϱ�

        inventoryPopup.SetActive(true);
    }

    public void AddItem(GameObject item)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
