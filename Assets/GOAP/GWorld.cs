using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ResourceQueue{
    public Queue<GameObject> que = new Queue<GameObject>();
    public string tag;
    public string modState;

    public ResourceQueue(string t,string ms,WorldStates w){
        tag = t;
        modState = ms;
        if(tag !=""){
            GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);
            foreach(GameObject r in resources){
                que.Enqueue(r);
            }
        }
        if(ms!=""){
            w.ModifyState(modState,que.Count);
        }
    }
    public void AddResource(GameObject o){
        que.Enqueue(o);
    }
    public GameObject RemoveResource(){
        if(que.Count==0) return null;
        return que.Dequeue();
        
    } 

    public void RemoveResource(GameObject o){
        que = new Queue<GameObject>(que.Where(p=>p!=o));
    }
}



public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static ResourceQueue patients;
    private static ResourceQueue cubicles;
    private static ResourceQueue offices;
    private static ResourceQueue toiletes;
    private static ResourceQueue puddles;
    public static Dictionary<string,ResourceQueue> resources = new Dictionary<string,ResourceQueue>();
    

    static GWorld()
    {
        world = new WorldStates();
        patients = new ResourceQueue("","",world) ;
        cubicles = new ResourceQueue("Cubicle","FreeCubicle",world) ;
        offices  = new ResourceQueue("Office","FreeOffice",world) ;
        toiletes = new ResourceQueue("Toilet","FreeToilet",world) ;
        puddles = new ResourceQueue("Puddle","FreePuddle",world) ;
        resources.Add("patients",patients);
        resources.Add("cubicles",cubicles);
        resources.Add("offices",offices);
        resources.Add("toiletes",toiletes);
        resources.Add("puddles",puddles);
        
    }
    
    public ResourceQueue GetQueue(string type){
        return resources[type];
    }

    private GWorld()
    {
    }
    
    

    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
