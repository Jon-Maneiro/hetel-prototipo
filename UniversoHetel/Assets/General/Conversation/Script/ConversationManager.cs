using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{

    [SerializeField] private GameObject[] conversation;
    private int current =0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }
    
    public void Back()
    {
        if ((current-1) >= 0)
        {
            current--;
            HideAll();
            conversation[current].SetActive(true);
        }
    }
    
    public void Next()
    {
        Debug.Log("dasfasdf");
        if ((current+1) < conversation.Length)
        {
            current++;
            HideAll();
            conversation[current].SetActive(true);
        }
    }
    
    public void Restart()
    {
        current = 0;
        HideAll();
        conversation[current].SetActive(true);
    }

    public void HideAll()
    {
        for (int i = 0; i < conversation.Length; i++)
        {
            conversation[i].SetActive(false);
        }
    }
}