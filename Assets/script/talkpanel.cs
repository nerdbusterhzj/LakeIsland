using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkpanel : MonoBehaviour
{
    CanvasGroup talk_panel;

    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
        talk_panel = GetComponent<CanvasGroup>();
        exit = GetComponentInChildren<Button>();
        exit.onClick.AddListener(exit_talk);
    }

    // Update is called once per frame
    void Update()
    {
        if(actobject.talkflag_3==true)
        {
            talk_panel.alpha = 1;
            talk_panel.blocksRaycasts = true;
            talk_panel.interactable = true;
        }
        else
        {
            talk_panel.alpha = 0;
            talk_panel.blocksRaycasts = false;
            talk_panel.interactable = false;
        }
        
    }

    void exit_talk()
    {
        if(actobject.talkflag_3==true)
        {
            actobject.talkflag_3 = false;
            actobject.talkflag_2 = false;
        }
    }
}
