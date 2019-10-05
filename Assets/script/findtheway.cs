using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class findtheway : MonoBehaviour
{
    Transform targettr=null;
    public actobject act_object=null;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)&&actobject.talkflag_3==false)
        {
            
            var mpos = Input.mousePosition;
            mpos.z = 1000;
            var ray = Camera.main.ScreenPointToRay(mpos);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                GetComponent<NavMeshAgent>().destination = hit.point;
                targettr = hit.transform.GetComponent<Transform>();//获取所选取的物体的位置
                act_object = hit.transform.GetComponent<actobject>();//获取选取物体的互动信息
                Debug.Log(act_object.name);
            }
        }
        if(actobject.talkflag_2 == true)
        {
             if(act_object.moveflag_1==true)//判定选取物体正在移动
             {
                GetComponent<NavMeshAgent>().destination = targettr.transform.position;
             }
        }
       
    }
    

   

}
