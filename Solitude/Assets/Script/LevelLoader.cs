using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    private int _transitionTime = 6;

    private Scene1LaptopController _scene1LaptopController;
    private Scene4LaptopController _scene4LaptopController;
    private Scene2Controller _scene2Controller;
    private Scene4Controller _scene4Controller;
    private Scene5Controller _scene5Controller;

    // Start is called before the first frame update
    void Start()
    {
        _scene1LaptopController = GameObject.FindObjectOfType<Scene1LaptopController>();
        _scene4LaptopController = GameObject.FindObjectOfType<Scene4LaptopController>();
        _scene2Controller = GameObject.FindObjectOfType<Scene2Controller>();
        _scene4Controller = GameObject.FindObjectOfType<Scene4Controller>();
        _scene5Controller = GameObject.FindObjectOfType<Scene5Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2) {
            // int hasInteracted = _scene1LaptopController.InteractedWithLaptop();
            bool isLaptopOpen = _scene1LaptopController.IsLaptopOpen();
            // if (hasInteracted > 0) {
            //     LoadNextLevel();
            // }
    
            if (isLaptopOpen) {
                SetTransitionTime(4);
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 3) {
            bool goNext = _scene2Controller.CanGoNext();
            
            if (goNext) {
                SetTransitionTime(2);
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            GameObject mainChar = GameObject.Find("GameChar");
            if (mainChar && mainChar.transform.position.y < -8)
            {
                SetTransitionTime(1);
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            int hasInteracted = _scene4LaptopController.InteractedWithLaptop();
            // bool checkLights = _scene4Controller.CheckLights();

            // if (hasInteracted > 0 && checkLights) {
            //     LoadNextLevel();
            // }

            if (hasInteracted > 0) {
                SetTransitionTime(4);
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 6) {
            bool goNext = _scene5Controller.CanGoNext();
            
            if (goNext) {
                SetTransitionTime(2);
                LoadNextLevel();
            }
        }

    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }


    private void SetTransitionTime(int tTime) {
        _transitionTime = tTime;
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
