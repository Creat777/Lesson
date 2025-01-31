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
    // 내 인벤토리에 들어 있는 아이템 정보
    // 내가 해야 할 퀘스트 정보
    // 내 캐릭터 현재 정보

    public CSVLoadManager csvloadManager;
    public PlayerPrefsManager prefsManager;

    eScene currenScene = eScene.LOBBY;

    List<ItemInfo> iteminfoList = new List<ItemInfo>();

    // Lobby 에 가지고 있는 팝업 UI
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
        // csv정보 매니저에서 가져오기
        List<ItemInfo> itemList = csvloadManager.GetItemList();

        foreach (ItemInfo info in itemList)
        {
            Debug.Log("item_number : " + info.item_number +" ability : "+ info.ability);
        }

        // playerPrefs에 내가 소유한 아이템 정보 가져오기
        prefsManager.GetItemListInfo();

        // 내가 소유한 아이템을 csv정보로 셋팅

        // UI 아이템 팝업 연동하기

        inventoryPopup.SetActive(true);
    }

    public void AddItem(GameObject item)
    {
        // PlayerPrefs에 아이템 저장
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
