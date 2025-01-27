﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public float X;
    public float Y;

    public float Sensitivity;

    public Vector3 euler;

    void Start()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.y, transform.eulerAngles.x, 0);
        euler = transform.rotation.eulerAngles;
        X = euler.x;
        Y = euler.y;
        Cursor.visible = false;
    }

    void Awake()
    {
        euler = transform.rotation.eulerAngles;
        X = euler.x;
        Y = euler.y;
    }

    void Update()
    {
        const float MIN_X = 0.0f;
        const float MAX_X = 360.0f;
        const float MIN_Y = -90.0f;
        const float MAX_Y = 90.0f;

        X += Input.GetAxis("Mouse X") * (Sensitivity * Time.deltaTime);
        if (X < MIN_X) X += MAX_X;
        else if (X > MAX_X) X -= MAX_X;
        Y -= Input.GetAxis("Mouse Y") * (Sensitivity * Time.deltaTime);
        if (Y < MIN_Y) Y = MIN_Y;
        else if (Y > MAX_Y) Y = MAX_Y;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Y, X, 0.0f), Time.deltaTime * 5);
    }
}
