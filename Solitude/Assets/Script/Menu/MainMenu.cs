using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using Trail;
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

public class MainMenu : MonoBehaviour
{
    private int sceneToContinue;
<<<<<<< HEAD
    private RuntimePlatform [] players;
    private string _url;

    void Start() {
        players = new RuntimePlatform[] {RuntimePlatform.WindowsPlayer, RuntimePlatform.OSXPlayer, RuntimePlatform.LinuxPlayer};
    }
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

<<<<<<< HEAD
    public void InGameQuit() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        if (System.Array.Exists(players, player => player == Application.platform))Application.Quit();

        if (SDK.IsInitialized && Application.platform == RuntimePlatform.WebGLPlayer) SDK.ExitGame();

        if (!SDK.IsInitialized && Application.platform == RuntimePlatform.WebGLPlayer) Application.OpenURL(Application.absoluteURL);

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
=======
    public void QuitGame()
    {
        Application.Quit();
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

}
