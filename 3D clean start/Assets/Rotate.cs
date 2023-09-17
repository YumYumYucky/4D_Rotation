using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCube : MonoBehaviour
{
    public Vector3 RotateDirection; 
    //public InputAction CubeControls;
    //public InputAction CubeControl1;
    //public InputAction CubeControl2;
    //public InputAction CubeControl3;
    public float rotateSpeed=100f;
    //private float x;
    //private float y;
    //private float z;

    // Start is called before the first frame update
    
    private void onEnable()
    {
        //CubeControls.Enable();
        //CubeControl1.Enable();
        //CubeControl2.Enable();
        //CubeControl3.Enable();
    }
    private void onDisable()
    {
        //CubeControls.Disable();
        //CubeControl1.Disable();
        //CubeControl2.Disable();
        //CubeControl3.Disable();
    }

    public void Update()
    {
        //float x=CubeControl1.ReadValue<float>()* rotateSpeed;
        //float y=CubeControl2.ReadValue<float>()* rotateSpeed;
        //float z=CubeControl3.ReadValue<float>()* rotateSpeed;
        //RotateDirection.x=(float)CubeControl1.ReadValue<float>();
        //RotateDirection.y=(float)CubeControl2.ReadValue<float>();
        //RotateDirection.z=(float)CubeControl3.ReadValue<float>();

        //Quaternion temp=transform.rotation;
        //temp.x=x;
        //temp.y=y;
        //temp.z=z;
        //transform.Rotate(temp);
        //transform.rotation = Quaternion.Euler(x, y, z);


        //Vector3 temp=new Vector3(x,y,z);
        //RotateDirection=temp;
        
        //RotateDirection.x+=x;
        //RotateDirection.y+=y;
        //RotateDirection.z+=z;
        if (Input.GetKey(KeyCode.W))  RotateDirection +=Vector3.right;
        if (Input.GetKey(KeyCode.S))  RotateDirection +=Vector3.left;
        if (Input.GetKey(KeyCode.A))  RotateDirection +=Vector3.up;
        if (Input.GetKey(KeyCode.D))  RotateDirection +=Vector3.down;
        if (Input.GetKey(KeyCode.Q))  RotateDirection +=Vector3.forward;
        if (Input.GetKey(KeyCode.E))  RotateDirection +=Vector3.back;

        transform.Rotate(RotateDirection * rotateSpeed * Time.deltaTime,Space.Self);
        RotateDirection=Vector3.zero;
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        //transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        //RotationDirection=CubeControls.ReadValue<Vector3>();
        
        //Debug.Log(x);
        //Debug.Log(y);
        //Debug.Log(z);

        //transform.Rotate(x,y,x);
        //transform.Rotate(RotateDirection, 30,Space.Self);
        //RotateDirection.x+=1;
    
        
        //transform.Rotate(x  * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }

}