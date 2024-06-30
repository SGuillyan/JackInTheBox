using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    private float _speed = 60f;

    void Update()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);
    }
}