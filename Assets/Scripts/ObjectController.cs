using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObjectController : MonoBehaviour
{

    public float rotationSpeed = 70;
    public float scalingSpeed = 3;

    private Transform body;

    private void Start()
    {
        body = this.GetComponent<Transform>();
    }

    private void Update()
    {

        if(Input.GetKey("i"))
        {
            this.Scale(scalingSpeed );
        }

        if (Input.GetKey("o"))
        {
            this.Scale(-scalingSpeed );
        }

        if(Input.GetKey("d"))
        {
            this.Rotate(rotationSpeed );
        }

        if (Input.GetKey("a"))
        {
            this.Rotate(-rotationSpeed );
        }

    }

    public void Rotate(float value)
    {
        body.Rotate(0, value * Time.deltaTime, 0);
    }

    public void Scale(float value)
    {
        if ((body.localScale.x > 0.01 && value<0) || (body.localScale.x < 0.9 && value > 0))
        {
            body.localPosition += new Vector3(0, value/2*Time.deltaTime, 0);
            body.localScale += new Vector3(value * Time.deltaTime, value*Time.deltaTime, value * Time.deltaTime);
        }
    }

}
