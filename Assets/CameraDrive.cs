using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrive : MonoBehaviour
{   Camera cam;
    public float speed = 10.0f;
    public float rotationSpeed = 20.0f; 
    // Start is called before the first frame update
    void Start()
    {
       cam = this.GetComponentInChildren<Camera>();
       cam.gameObject.transform.LookAt(this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float translation  = Input.GetAxis("Vertical")*speed*Time.deltaTime;
        float translation2 = Input.GetAxis("Horizontal")*speed*Time.deltaTime;

        this.transform.Translate(0,0,translation2);
        this.transform.Translate(-translation,0,0);

        if(Input.GetKey(KeyCode.Z)){
            this.transform.Rotate(0,-rotationSpeed*Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.X)){
            this.transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
        }

        float camDist = cam.gameObject.transform.position.y;

        if(Input.GetKey(KeyCode.F) && camDist>5){
            cam.gameObject.transform.Translate(0,0,speed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.V) && camDist<45 ){
            cam.gameObject.transform.Translate(0,0,-speed*Time.deltaTime);
        }

        float angle = Vector3.Angle(cam.gameObject.transform.forward,Vector3.up);

        if(Input.GetKey(KeyCode.G)&& angle<175){
            cam.gameObject.transform.Translate(Vector3.up);
            cam.gameObject.transform.LookAt(this.transform.position);
        }
        if(Input.GetKey(KeyCode.B)&& angle >90 ){
            cam.gameObject.transform.Translate(-Vector3.up);
            cam.gameObject.transform.LookAt(this.transform.position);
    
        }

    }
}
