using UnityEngine;

public class CanvasHelper : MonoBehaviour
{

    public void StartGame()
    {
        SceneManagerScript.Instance.StartGame();
    }

    public void QuitGame()
    {
        SceneManagerScript.Instance.QuitGame();
    }
}
