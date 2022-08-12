using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToToilet: GAction
{
    public override bool PrePerform(){
        target = GWorld.Instance.GetQueue("toiletes").RemoveResource();
        if(target==null){
            return false;
        }
        
        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeToilet",-1);

        return true;
        
    }

    public override bool PostPerform(){
        inventory.RemoveItem(target);
        GWorld.Instance.GetQueue("toiletes").AddResource(target);
        GWorld.Instance.GetWorld().ModifyState("FreeToilet",1);
        beliefs.RemoveState("relief");
        return true;
    }
}
