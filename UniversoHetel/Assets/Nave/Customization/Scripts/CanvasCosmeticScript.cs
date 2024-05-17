using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasCosmeticScript : MonoBehaviour
{
    public void MenuPrincipal()
    {
        Time.timeScale = 1;
        LoadingData.SceneToLoad = "Menu";
        SceneManager.LoadScene("LoadingScreen");
    }
}
