using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float inputSensitivity;

    private Transform parent;


    private void Start()
    {
        parent = transform.parent;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float inputX = Input.GetAxis("Horizontal") * inputSensitivity * Time.deltaTime;

        parent.Rotate(Vector3.up, inputX);
    }
}
