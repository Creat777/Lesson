using UnityEngine;
using System.Collections.Generic;

enum eScene
{
    LOBBY,
    INGAME
}

class InvectoryItemInfo
{
    InvectoryItemInfo()
    {

    }
}

class MyCharState
{
    public int level;
    public int exp;
    MyCharState()
    {

    }
}

public class GameManager : Singleton<GameManager>
{
    // DOTO -> 내 인벤토리에 들어있는 아이템 정보
    // DOTO -> 내가 해야할 퀘스트 정보
    // DOTO -> 내 캐릭터에 대한 현재 정보

    eScene currentScene = eScene.LOBBY;

    // Lobby에 가지고 있는 팝업 UI
    public GameObject inventoryPopUp;
    public GameObject questPopUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //싱글톤에서 DonDestroyOnLoad 적용됨
    }

    private void OnEnable()
    {
        if(currentScene == eScene.LOBBY)
        {
            Debug.Log("currentScene == LOBBY");
        }
        else if(currentScene == eScene.INGAME)
        {
            Debug.Log("currentScene == INGAME");
        }
    }

    public void AddItem(GameObject item)
    {

    }

    public void InventoryPopUpOpen()
    {
        inventoryPopUp = GameObject.Find("InventoryPopUp");
        inventoryPopUp.SetActive(true);
        
        // csv정보 매니저에서 가져오기
        CsvInfo ItemCsvInfo = CsvManager.Instance.GetCsvInfo("Item");

        // PlayerPrefs에서 내가 소유한 아이템 정보 가져오기

        // 내가 소유한 아이템을 csv정보로 세팅

        // UI 아이템팝업 연동하기
    }

    public void InventoryPopUpClose()
    {
        inventoryPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
