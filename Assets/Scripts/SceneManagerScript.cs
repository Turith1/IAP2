using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    private static SceneManagerScript _instance;

    public static SceneManagerScript Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("IAP2");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
