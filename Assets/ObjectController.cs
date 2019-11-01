using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Transform body;
    bool minimalan;
    void Start()
    {
        body = this.GetComponent<Transform>();
        minimalan = false;
    }

    public void Update()
    {
        if(Input.GetKey("i"))
        {
            this.scale(3 * Time.deltaTime);
        }

        if (Input.GetKey("o"))
        {
            this.scale(-3 * Time.deltaTime);
        }

        if(Input.GetKey("d"))
        {
            this.rotate(70 * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            this.rotate(-70 * Time.deltaTime);
        }
    }

    public void rotate(float value)
    {
        body.Rotate(0, value, 0);
    }

    public void scale(float value)
    {
        if ((body.localScale.x > 0.01 && value<0) || (body.localScale.x < 0.9 && value > 0))
        {
            body.localPosition += new Vector3(0, value/2, 0);
            body.localScale += new Vector3(value, value, value);
        }
    }

}
