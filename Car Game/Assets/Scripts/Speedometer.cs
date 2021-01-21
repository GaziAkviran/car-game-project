using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    public UnityStandardAssets.Vehicles.Car.CarController carcont;
       private const float MIN_SPEED_ANG = 187f;
    private const float MAX_SPEED_ANG = -80f;

    private Transform needleTransform;

    private float maxSpeed;
    public float speed;

    public GameObject needle;

    private void Awake()
    {
        needleTransform = needle.transform;
        maxSpeed = carcont.MaxSpeed;
        speed = 0f;
    }

    private void FixedUpdate()
    {
        speed = carcont.CurrentSpeed;

        if (speed > maxSpeed) speed = maxSpeed;

        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

    private float GetSpeedRotation()
    {
        float totalAngelSize = MIN_SPEED_ANG - MAX_SPEED_ANG;
        float speedNormalized = speed / maxSpeed;

        return MIN_SPEED_ANG - speedNormalized * totalAngelSize;
    }
}
