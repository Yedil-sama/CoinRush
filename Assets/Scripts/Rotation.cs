using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationXSpeed = 0;
    [SerializeField] private float rotationYSpeed = 0;
    [SerializeField] private float rotationZSpeed = 0;
    private void FixedUpdate()
    {
        transform.Rotate(rotationXSpeed * Time.deltaTime, rotationYSpeed * Time.deltaTime, rotationZSpeed * Time.deltaTime);
    }
}
