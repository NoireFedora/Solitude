using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    private const int _TRANSITIONTIME = 6;

    private LaptopController _laptopController;
    private Scene2Controller _scene2Controller;
    private Scene4Controller _scene4Controller;

    // Start is called before the first frame update
    void Start()
    {
        _laptopController = GameObject.FindObjectOfType<LaptopController>();
        _scene2Controller = GameObject.FindObjectOfType<Scene2Controller>();
        _scene4Controller = GameObject.FindObjectOfType<Scene4Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            int hasInteracted = _laptopController.InteractedWithLaptop();
            
            if (hasInteracted > 0) {
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1) {
            bool goNext = _scene2Controller.CanGoNext();
            
            if (goNext) {
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject mainChar = GameObject.Find("GameChar");
            if (mainChar.transform.position.y < -8)
            {
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            int hasInteracted = _laptopController.InteractedWithLaptop();
            bool checkLights = _scene4Controller.CheckLights();

            if (hasInteracted > 0 && checkLights) {
                LoadNextLevel();
            }
        }
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(_TRANSITIONTIME);
        SceneManager.LoadScene(levelIndex);
    }
}
