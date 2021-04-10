using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Trail;

public class MainMenu : MonoBehaviour
{
    private int sceneToContinue;
    private RuntimePlatform [] players;
    private string _url;

    void Start() {
        players = new RuntimePlatform[] {RuntimePlatform.WindowsPlayer, RuntimePlatform.OSXPlayer, RuntimePlatform.LinuxPlayer};
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

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
    }

}
