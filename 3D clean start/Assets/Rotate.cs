using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCube : MonoBehaviour
{
    public Vector3 RotateDirection; 
    public float rotateSpeed=75f;

    public void Update()
    {
        //when a button is pressed add the correct rotation to Rotate Direction
        RotateDirection =Vector3.zero;
        if (Input.GetKey(KeyCode.W))  RotateDirection +=Vector3.right;
        if (Input.GetKey(KeyCode.S))  RotateDirection +=Vector3.left;
        if (Input.GetKey(KeyCode.A))  RotateDirection +=Vector3.up;
        if (Input.GetKey(KeyCode.D))  RotateDirection +=Vector3.down;
        if (Input.GetKey(KeyCode.Q))  RotateDirection +=Vector3.forward;
        if (Input.GetKey(KeyCode.E))  RotateDirection +=Vector3.back;
        //Only when V is pressed rotation is reset
        if (Input.GetKey(KeyCode.V) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))  ZeroRotation();
        //rotates the cube by RotateDirection and zeros RotateDirection for the next frame.
        transform.Rotate(RotateDirection * rotateSpeed * Time.deltaTime,Space.Self);
        RotateDirection=Vector3.zero;
    }

    public void ZeroRotation(){
        //gets the opposite of the rotation
        Vector3 unRotate = -(transform.rotation.eulerAngles);
        //when opposite of the rotation is not zero then it gets the opposite of the rotation and rotates by that amount
        //this is done multiple time to make sure the rotation is zeroed.
        while (unRotate!=Vector3.zero){
            unRotate = -(transform.rotation.eulerAngles);
            transform.Rotate(unRotate);
        }
        
    }
}