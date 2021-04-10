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
    private DoorController _doorController;
    private Scene7LaptopController _scene7LaptopController;

    // Start is called before the first frame update
    void Start()
    {
        _scene1LaptopController = GameObject.FindObjectOfType<Scene1LaptopController>();
        _scene4LaptopController = GameObject.FindObjectOfType<Scene4LaptopController>();
        _scene2Controller = GameObject.FindObjectOfType<Scene2Controller>();
        _scene4Controller = GameObject.FindObjectOfType<Scene4Controller>();
        _scene5Controller = GameObject.FindObjectOfType<Scene5Controller>();
        _doorController = GameObject.FindObjectOfType<DoorController>();
        _scene7LaptopController = GameObject.FindObjectOfType<Scene7LaptopController>();
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
<<<<<<< HEAD

=======
    
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
            if (isLaptopOpen) {
                SetTransitionTime(4);
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 3) {
            bool goNext = _scene2Controller.CanGoNext();
<<<<<<< HEAD

=======
            
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
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
<<<<<<< HEAD

=======
            
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
            if (goNext) {
                SetTransitionTime(2);
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 7) {
            bool doorOpened = _doorController.checkDoor();
<<<<<<< HEAD

=======
            
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
            if (doorOpened) {
                SetTransitionTime(4);
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 8) {
            bool checkLaptop = _scene7LaptopController.InteractedWithLaptop();
<<<<<<< HEAD

=======
            
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
            if (checkLaptop) {
                SetTransitionTime(4);
                LoadNextLevel();
            }
        }

<<<<<<< HEAD
        if (SceneManager.GetActiveScene().buildIndex == 9) {
            SetTransitionTime(10);
            MenuLevel();
        }

    }

    private void SetTransitionTime(int tTime) {
        _transitionTime = tTime;
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

<<<<<<< HEAD
    public void LoadMenuLevel() {
        StartCoroutine(LoadLevel(0));
=======

    private void SetTransitionTime(int tTime) {
        _transitionTime = tTime;
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
<<<<<<< HEAD

    public void MenuLevel() {
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu() {
        yield return new WaitForSeconds(43);
        LoadMenuLevel();
    }
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
}
