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
    // DOTO -> �� �κ��丮�� ����ִ� ������ ����
    // DOTO -> ���� �ؾ��� ����Ʈ ����
    // DOTO -> �� ĳ���Ϳ� ���� ���� ����

    eScene currentScene = eScene.LOBBY;

    // Lobby�� ������ �ִ� �˾� UI
    public GameObject inventoryPopUp;
    public GameObject questPopUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�̱��濡�� DonDestroyOnLoad �����
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
        
        // csv���� �Ŵ������� ��������
        CsvInfo ItemCsvInfo = CsvManager.Instance.GetCsvInfo("Item");

        // PlayerPrefs���� ���� ������ ������ ���� ��������

        // ���� ������ �������� csv������ ����

        // UI �������˾� �����ϱ�
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
