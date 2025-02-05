using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class InputX : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    public float inputX;
    void Update()
    {
        if (joystick) inputX = joystick.Horizontal;
    }
}
