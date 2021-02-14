using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 3f;

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
            GameObject mainChar = GameObject.Find("MainChar 3D");
            if (mainChar.transform.position.y < -10)
            {
                LoadNextLevel();
            }
        }
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
