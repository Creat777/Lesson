using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGamePlay : MonoBehaviour
{
    public void StartPlay()
    {
        // TODO -> stage���� �˾� �߰�

        SceneManager.LoadScene("InGame");
    }

}
