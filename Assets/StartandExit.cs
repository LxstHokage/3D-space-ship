
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartandExit : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    public void ExitGame() {
        Application.Quit();
    }
}
