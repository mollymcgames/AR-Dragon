using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private FixedJoystick fixedJoystick;
    private Rigidbody rb;

    private void OnEnable()
    {
        fixedJoystick = FindFirstObjectByType<FixedJoystick>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float xValue = fixedJoystick.Horizontal;
        float yValue = fixedJoystick.Vertical;

        Vector3 direction = new Vector3(xValue, 0, yValue); //convert to 3D
        rb.velocity = direction * speed;

        if(xValue != 0 && yValue != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xValue, yValue) * Mathf.Rad2Deg, transform.eulerAngles.z); //dragon rotates around x axis
        }
    }
}
