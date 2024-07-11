using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Testing");
    }
/*
    public void levelSelect1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void levelSelect2()
    {
        SceneManager.LoadScene("Level_2");
    }
   */

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Salir()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPaused = true;
#endif

    }
}
