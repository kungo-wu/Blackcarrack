using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   private Rigidbody rb;
    private float distance = 10;

    public Transform cameraTrans;
    private float cameraToObjZ;

    private Vector3 objectPosition;
    private void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    //private void Update()
    //{
    //    cameraToObjZ = gameObject.transform.position.z - cameraTrans.position.z;
    //}
    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
       // transform.position = objectPosition;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(objectPosition);
    }
}
