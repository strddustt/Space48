using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 500;
    Movement movement;
    // Start is called before the first frame update
    void Start()
    {
       movement = GetComponent<Movement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        movement.Move(moveSpeed, 1);
    }
}
