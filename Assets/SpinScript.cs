using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
    private Transform reset;

    public float startX;
    public float currentX;
    public float rotationSensitivity = 0.2f;
    public float smoothTime = 1;

    public float startMINcurrent;

    void Start()
    {
        reset = this.transform;  

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            startX = Input.mousePosition.x;

        }
        if(Input.GetMouseButton(0)){
            currentX = Input.mousePosition.x;
            startMINcurrent = Mathf.Clamp((startX - currentX) * rotationSensitivity, -180, 180);
            transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(transform.eulerAngles.y, startMINcurrent, Time.deltaTime * smoothTime), 0);

        }
        else{
            transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(transform.eulerAngles.y, 0, Time.deltaTime * smoothTime), 0);

        }
        if(Input.GetMouseButtonUp(0)){
            startX = 0;
            currentX = 0;
            startMINcurrent = 0;
        }
        

    }
}
