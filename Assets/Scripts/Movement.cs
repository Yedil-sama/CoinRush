using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    public float forwardSpeed;
    [SerializeField] private InputX Input;
    [SerializeField] private float sideSpeed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.inputX * sideSpeed * Time.deltaTime, rb.velocity.y, forwardSpeed * Time.deltaTime);
    }
}
