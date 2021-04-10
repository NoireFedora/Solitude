using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, ISInteractable
{   
    private GameObject gameChar;
    private AudioSource torchRIP;
    public GameObject torch1;
    public GameObject torch2;
    public GameObject torch3;
    public Transform torchPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameChar = GameObject.Find("GameChar");
        torchRIP = GetComponent<AudioSource>();
        torchPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ISInteractable.interact()
    {   
        gameChar.GetComponent<Transform>().position = new Vector3(torchPosition.position.x + 0.1567f, gameChar.GetComponent<Transform>().position.y, -33.12299f);
        gameChar.GetComponent<CharControl>()._withTorch = true;
        gameChar.GetComponent<Animator>().SetBool("WithTorch", true);
        gameChar.GetComponent<CharControl>().startListening();
        torchRIP.Play();
        StopAllCoroutines();
        StartCoroutine(TakeTorch());
        torch1.SetActive(false);
        torch2.SetActive(false);
        torch3.SetActive(false);
    }

    private IEnumerator TakeTorch()
    {   
        yield return new WaitForSeconds(0.8f);
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(0.8f);
        gameChar.GetComponent<CharControl>().endListening();
    }
}
