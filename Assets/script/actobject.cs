using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actobject : MonoBehaviour
{
    public static bool talkflag_1 = false;//对话先决条件，判断是否在对话范围内
    public static bool talkflag_2 = false;//判定是否为可互动选项
    public static bool talkflag_3 = false;//判定对话框开启

    public bool moveflag_1 = false;//判断npc是否在行走
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("1:"+talkflag_1);
        //Debug.Log("2:"+talkflag_2);
       // Debug.Log("3:"+talkflag_3);

        if(moveflag_1&&talkflag_2)
        {
            playertalk.des = this.transform;
        }


    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
        {
            if (this.tag == "actobject")
            {
                playertalk.des = this.transform;
                talkflag_2 = true;
            }
            else talkflag_2 = false;
        }
    }
}
