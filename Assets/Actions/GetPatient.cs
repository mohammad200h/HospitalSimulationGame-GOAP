﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : GAction
{
    GameObject resource ;
    public override bool PrePerform()
    {
        
        target = GWorld.Instance.GetQueue("patients").RemoveResource();
        if(target ==null) return false;

        resource = GWorld.Instance.GetQueue("cubicles").RemoveResource();

        if(resource !=null){
            inventory.AddItem(resource);
        }else{
            //release the patient becasue the resource is not avilable
            GWorld.Instance.GetQueue("patients").AddResource(target);
            target = null;
            return false;
        }
    
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle",-1);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Waiting",-1);
        if(target){   
            //the nurse passes cubicle resource to patient
            target.GetComponent<GAgent>().inventory.AddItem(resource);
        }
        
        return true;
    }
}
