using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, ISInteractable
{   
    private GameObject gameChar;
<<<<<<< HEAD
    private AudioSource torchRIP;
    public GameObject torch1;
    public GameObject torch2;
    public GameObject torch3;
    public Transform torchPosition;
=======
    public GameObject torch1;
    public GameObject torch2;
    public GameObject torch3;
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8

    // Start is called before the first frame update
    void Start()
    {
        gameChar = GameObject.Find("GameChar");
<<<<<<< HEAD
        torchRIP = GetComponent<AudioSource>();
        torchPosition = GetComponent<Transform>();
=======
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD

=======
        
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
    }

    void ISInteractable.interact()
    {   
<<<<<<< HEAD
        gameChar.GetComponent<Transform>().position = new Vector3(torchPosition.position.x + 0.1567f, gameChar.GetComponent<Transform>().position.y, -33.12299f);
        gameChar.GetComponent<CharControl>()._withTorch = true;
        gameChar.GetComponent<Animator>().SetBool("WithTorch", true);
        gameChar.GetComponent<CharControl>().startListening();
        torchRIP.Play();
=======
        gameChar.GetComponent<Transform>().position = new Vector3(gameChar.GetComponent<Transform>().position.x, gameChar.GetComponent<Transform>().position.y, -33.12299f);
        gameChar.GetComponent<CharControl>()._withTorch = true;
        gameChar.GetComponent<Animator>().SetBool("WithTorch", true);
        gameObject.GetComponent<Renderer>().enabled = false;
        gameChar.GetComponent<CharControl>().startListening();
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
        StopAllCoroutines();
        StartCoroutine(TakeTorch());
        torch1.SetActive(false);
        torch2.SetActive(false);
        torch3.SetActive(false);
    }

    private IEnumerator TakeTorch()
    {   
<<<<<<< HEAD
        yield return new WaitForSeconds(0.8f);
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(0.8f);
=======
        yield return new WaitForSeconds(1.6f);
>>>>>>> a35e160d6f8dec8b418298d0593ab442797338e8
        gameChar.GetComponent<CharControl>().endListening();
    }
}
