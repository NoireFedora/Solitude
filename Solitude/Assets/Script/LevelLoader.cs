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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            _laptopController = GameObject.FindObjectOfType<LaptopController>();
            bool isOpen = _laptopController.InteractedWithLaptop();
            // float laptopSFX = _laptopController.getLaptopSFXTime();
            
            if (isOpen) {
                LoadNextLevel();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1) {
            _scene2Controller = GameObject.FindObjectOfType<Scene2Controller>();
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
