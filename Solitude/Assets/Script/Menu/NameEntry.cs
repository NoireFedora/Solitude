using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameEntry : MonoBehaviour
{
    static string playerName;
    
    private GameObject nameInput;
    
    void Start()
    {
        nameInput = GameObject.Find("NameInput");
    }

    void Update()
    {
        playerName = nameInput.GetComponent<TMP_InputField>().text;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

}
