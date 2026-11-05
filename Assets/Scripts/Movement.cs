using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 0f;
    [SerializeField] public float rotationSpeed = 0f;
    [SerializeField] private bool requiresInput = false;
    public void Move(float movespeed, float getaxis)
    {
        transform.position = transform.position + transform.forward * movespeed * getaxis * Time.deltaTime;

    }
    private void Update()
    {
        if (requiresInput)
        {
                Move(moveSpeed, Input.GetAxis("Vertical"));
                Rotate();
        }
        else
        {
            Move(moveSpeed, 1);
        }
    }
    void Rotate()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
