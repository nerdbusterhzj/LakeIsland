using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertalk : MonoBehaviour
{
    public static Transform des;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(actobject.talkflag_2)
        {
            if (Vector3.Distance(this.transform.position,des.position)<=2.0f)
            {
                actobject.talkflag_1 = true;
            }
            else actobject.talkflag_1 = false;
      
            if(actobject.talkflag_1&& actobject.talkflag_2)
            {
                actobject.talkflag_3 = true;
            }
        }
    }    
}
