using System.Collections;
using System.Collections.Generic;
using Engine4;
using static Engine4.Transform4;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;
using System.Numerics;


public class RotateCube : MonoBehaviour4
{
    public Euler4 RotateDirection; //6D vector with rotation information
    public Matrix4 TotalRotationMatrix; //4x4 matrix with rotation information
    public Euler4 TotalRotation;
    public float rotateSpeed=1f;
    private Transform4 myTransform;
    public const float PI = 3.1415926535897931f;
    Euler4 pos_X=new Euler4 (1,0,0,0,0,0);
    Euler4 neg_X=new Euler4 (-1,0,0,0,0,0);
    Euler4 pos_Y=new Euler4 (0,1,0,0,0,0);
    Euler4 neg_Y=new Euler4 (0,-1,0,0,0,0);
    Euler4 pos_Z=new Euler4 (0,0,1,0,0,0);
    Euler4 neg_Z=new Euler4 (0,0,-1,0,0,0);
    Euler4 pos_T=new Euler4 (0,0,0,1,0,0);
    Euler4 neg_T=new Euler4 (0,0,0,-1,0,0);
    Euler4 pos_U=new Euler4 (0,0,0,0,1,0);
    Euler4 neg_U=new Euler4 (0,0,0,0,-1,0);
    Euler4 pos_V=new Euler4 (0,0,0,0,0,1);
    Euler4 neg_V=new Euler4 (0,0,0,0,0,-1);




    void Start()
    {
        //sets rotations equal to zero
        myTransform = GetComponent<Transform4>();
        TotalRotation=new Euler4(0,0,0,0,0,0);
        TotalRotationMatrix=new Matrix4(1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1);
    }


    public void Update()
    {
        //sets rotations equal to zero
        Euler4 zeros=new Euler4(0,0,0,0,0,0);
        Matrix4 idenityMatrix=new Matrix4(1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1);
        RotateDirection=new Euler4(0,0,0,0,0,0);
            
        //When a button is pressed add that rotation to RotateDirection
        if (Input.GetKey(KeyCode.W))  RotateDirection +=pos_X;
        if (Input.GetKey(KeyCode.S))  RotateDirection +=neg_X;
        if (Input.GetKey(KeyCode.A))  RotateDirection +=neg_Y;
        if (Input.GetKey(KeyCode.D))  RotateDirection +=pos_Y;
        if (Input.GetKey(KeyCode.Q))  RotateDirection +=neg_Z;
        if (Input.GetKey(KeyCode.E))  RotateDirection +=pos_Z;
        if (Input.GetKey(KeyCode.U))  RotateDirection +=neg_U;
        if (Input.GetKey(KeyCode.J))  RotateDirection +=pos_U;
        if (Input.GetKey(KeyCode.H))  RotateDirection +=neg_T;
        if (Input.GetKey(KeyCode.K))  RotateDirection +=pos_T;
        if (Input.GetKey(KeyCode.Y))  RotateDirection +=pos_V;
        if (Input.GetKey(KeyCode.I))  RotateDirection +=neg_V;
        //Only when V is pressed zeroRotation
        if (Input.GetKey(KeyCode.V) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.U) && !Input.GetKey(KeyCode.H) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.Y))  zeroRotation();
       
        //rotate hypercube visually by RotateDirection 
        transform4.Rotate(RotateDirection  * rotateSpeed * Time.deltaTime, Space4.Self);
        //converts RotateDirection to matrix4 and adds rotation to TotalRotation so the rotation can be compared with the reference hypercube.
        Matrix4 temp=Matrix4.Euler(RotateDirection*Time.deltaTime*(180f/PI)*1.747f);
        TotalRotationMatrix=TotalRotationMatrix*temp;
        
    }

    public void zeroRotation()
    {
        //sets the visual and mathmatical rotation to zero (The identity matrix)
        transform4.rotation=new Matrix4(1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1);
        TotalRotationMatrix=new Matrix4(1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1);
    }


    public float[] Rotates()
    {
        //sends rotation information for rotation cube to Distance. Done in an array because Matrix4 cannot be returned.
        Engine4.Vector4 rowX=TotalRotationMatrix.ex;
        Engine4.Vector4 rowY=TotalRotationMatrix.ey;
        Engine4.Vector4 rowZ=TotalRotationMatrix.ez;
        Engine4.Vector4 rowW=TotalRotationMatrix.ew;
        float[] rot={rowX.x,rowX.y,rowX.z,rowX.w,rowY.x,rowY.y,rowY.z,rowY.w,rowZ.x,rowZ.y,rowZ.z,rowZ.w,rowW.x,rowW.y,rowW.z,rowW.w,};
        return rot;
    }

}