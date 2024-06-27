using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPlayer : MonoBehaviour
{
    public static VFXPlayer instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlayVFX(GameObject vfx, Vector3 position, Quaternion rotation)
    {
        Instantiate(vfx, position, rotation);
    }
}
