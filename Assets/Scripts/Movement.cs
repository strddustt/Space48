using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void Move(float movespeed, float getaxis)
    {

        transform.position = transform.position + transform.forward * movespeed * getaxis * Time.deltaTime;

    }
}
