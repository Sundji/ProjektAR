using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Transform body;
    public float rotationSpeed;
    public float scalingspeed;

    void Start()
    {
        body = this.GetComponent<Transform>();
        rotationSpeed = 70;
        scalingspeed = 3;
    }

    public void Update()
    {
        if(Input.GetKey("i"))
        {
            this.scale(scalingspeed );
        }

        if (Input.GetKey("o"))
        {
            this.scale(-scalingspeed );
        }

        if(Input.GetKey("d"))
        {
            this.rotate(rotationSpeed );
        }

        if (Input.GetKey("a"))
        {
            this.rotate(-rotationSpeed );
        }
    }

    public void rotate(float value)
    {
        body.Rotate(0, value * Time.deltaTime, 0);
    }

    public void scale(float value)
    {
        if ((body.localScale.x > 0.01 && value<0) || (body.localScale.x < 0.9 && value > 0))
        {
            body.localPosition += new Vector3(0, value/2*Time.deltaTime, 0);
            body.localScale += new Vector3(value * Time.deltaTime, value*Time.deltaTime, value * Time.deltaTime);
        }
    }

}
