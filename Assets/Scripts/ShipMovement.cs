using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float rotationSpeed = 25f;
    private Movement movement;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }
    // Update is called once per frame
    void Update()
    {
        movement.Move(moveSpeed, Input.GetAxis("Vertical"));
        Rotate();
    }
    void Rotate()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
