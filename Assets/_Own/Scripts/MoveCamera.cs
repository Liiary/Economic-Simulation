using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        var xMovement = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        var zMovement = Input.GetAxis("Vertical") * Time.deltaTime * Speed;

        transform.position += new Vector3(xMovement, 0.0f, 0.0f);
        transform.position +=  new Vector3(0.0f, 0.0f, zMovement);
    }
}
