using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Touch touch;
    public float rotationSpeed = 70;
    public float scalingSpeed = 3;
    public float maxVelicina;
    public float minVelicina;

    private Transform body;

    private void Start()
    {
        body = this.GetComponent<Transform>();
    }

    private void Update()
    {

        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotacijax = touch.deltaPosition.x * rotationSpeed * Mathf.Deg2Rad;
                float rotacijay = touch.deltaPosition.y * rotationSpeed * Mathf.Deg2Rad;
                transform.Rotate(rotacijay, -rotacijax, 0, Space.World);
                //transform.Rotate(Vector3.right, rotacijay);
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 stariTouch1 = touch1.position - touch1.deltaPosition;
            Vector2 stariTouch2 = touch2.position - touch2.deltaPosition;

            float staraUdaljenost = (stariTouch1 - stariTouch2).magnitude;
            float sadasnjaUdaljenost = (touch1.position - touch2.position).magnitude;

            float razlika = sadasnjaUdaljenost - staraUdaljenost;

            Scale(razlika * 0.1f);
        }

    }

    public void Scale(float value)
    {
        if ((body.localScale.x > minVelicina && value < 0) || (body.localScale.x < maxVelicina && value > 0))
        {
            body.localPosition += new Vector3(0, value / 2 * Time.deltaTime, 0);
            body.localScale += new Vector3(value * Time.deltaTime, value * Time.deltaTime, value * Time.deltaTime);
        }
    }

}
