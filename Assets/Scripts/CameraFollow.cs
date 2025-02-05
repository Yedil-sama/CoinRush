using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 1f;
    private Vector3 offset;
    private void Awake()
    {
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z + offset.z);
    }
}
