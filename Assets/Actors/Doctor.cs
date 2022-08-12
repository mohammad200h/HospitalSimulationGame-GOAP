using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : GAgent
{
    // Start is called before the first frame update
    void Start()
    {
        
        base.Start(); 
        SubGoal s1 = new SubGoal("rested",1,false);
        goals.Add(s1,2);
        Invoke("GetTired",Random.Range(10,20));

        SubGoal s2 = new SubGoal("research",1,false);
        goals.Add(s2,1);

        SubGoal s3 = new SubGoal("reliefed",1,false);
        goals.Add(s3,3);
        Invoke("GetPissy",Random.Range(5,10));

    }
    void GetTired(){
        beliefs.ModifyState("exhausted",0);
        Invoke("GetTired",Random.Range(10,20));
    }
    void GetPissy(){
        beliefs.ModifyState("relief",0);
        Invoke("GetPissy",Random.Range(5,10));
    }

    
}
