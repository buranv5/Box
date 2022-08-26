using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraStationar : MonoBehaviour
{
    [SerializeField] private Transform transform;

    private void Update()
    {
        transform.eulerAngles = Vector3.zero;
    }
}
