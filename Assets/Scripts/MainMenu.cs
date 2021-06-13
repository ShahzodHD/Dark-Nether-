using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioListener audioListener;
    public void PlayGame()
    {
        SceneManager.LoadScene("level1");
    }
    public void Arena()
    {
        SceneManager.LoadScene("level4 Arena");
    }
}
