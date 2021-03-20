using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationTrigger : MonoBehaviour
{   
    public Conversation conversation;

    public bool blockMove = true;

    public void TriggerConversation()
    {
        FindObjectOfType<ConversationManager>().StartConversation(conversation,blockMove);
    }

    public bool ContinueConversation()
    {
        bool isEnded = FindObjectOfType<ConversationManager>().DisplayNextSentence();
        return isEnded;
    }

}
