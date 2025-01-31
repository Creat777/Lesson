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
    // 내 인벤토리에 들어 있는 아이템 정보
    // 내가 해야 할 퀘스트 정보
    // 내 캐릭터 현재 정보

    public CSVLoadManager csvloadManager;
    public PlayerPrefsManager playerPrefsManager;

    eScene currenScene = eScene.LOBBY;

    List<ItemInfo> iteminfoList;

    // Lobby 에 가지고 있는 팝업 UI
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
        // csv정보 매니저에서 가져오기
        List<ItemInfo> itemList = csvloadManager.GetItemList();

        // playerPrefs에 내가 소유한 아이템 정보 가져오기
        HashSet<int> ItemHash= new HashSet<int>();
        ItemHash = playerPrefsManager.GetItemListInfo();

        // 내가 소유한 아이템을 csv정보로 셋팅
        // 아이템 종류에 따라 저장된 생산번호만큼 아이템을 화면에 표시

        // UI 아이템 팝업 연동하기

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
