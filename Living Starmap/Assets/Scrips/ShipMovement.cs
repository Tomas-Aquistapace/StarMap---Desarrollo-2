using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    [HideInInspector]
    public Rigidbody rig;
    private float moveInput;
    private float turnInput;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Vector3 movementFront = transform.forward * moveInput * speed * Time.deltaTime;
        rig.MovePosition(rig.position + movementFront);

        float turnInputPos = turnInput;
        if (turnInputPos < 0) { turnInputPos *= -1; }

        Vector3 movementSide = transform.forward * turnInputPos * (speed / 10) * Time.deltaTime;
        rig.MovePosition(rig.position + movementSide);

        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rig.MoveRotation(rig.rotation * turnRotation);
    }
}
