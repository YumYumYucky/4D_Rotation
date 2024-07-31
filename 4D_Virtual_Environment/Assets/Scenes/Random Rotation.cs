using System;
using System.Collections;
using System.Collections.Generic;
using Engine4;
using UnityEngine;


public class RandomRotation : MonoBehaviour
{
    //random 6D eurler vector, random 4X4 matrix, instance of transform4
    private Euler4 rand_vect;
    private Matrix4 rand_matrix;
    private Transform4 myTransform1;


    
    void Start()
    { 
        //instance transform4 and gets random rotation
        myTransform1 = GetComponent<Transform4>();
        newRotation();
    }

    public void newRotation()
    {
        //recenters hypercube
        Matrix4 unRotate=myTransform1.rotation;
        myTransform1.Rotate(Matrix4.Transpose(unRotate), Space4.Self);
        
        //rotates hypercube to a random 4D rotation
        rand_vect=new Euler4 (UnityEngine.Random.Range(-180f,180f),UnityEngine.Random.Range(-180f,180f),UnityEngine.Random.Range(-180f,180f),UnityEngine.Random.Range(-180f,180f),UnityEngine.Random.Range(-180f,180f),UnityEngine.Random.Range(-180f,180f));
        rand_matrix=Matrix4.Euler(rand_vect);
        myTransform1.Rotate(rand_matrix,Space4.Self);
    }
    public float[] Rotates()
    {
        //sends rotation information for reference cube to Distance. Done in an array because Matrix4 cannot be returned.
        Engine4.Vector4 rowX=rand_matrix.ex;
        Engine4.Vector4 rowY=rand_matrix.ey;
        Engine4.Vector4 rowZ=rand_matrix.ez;
        Engine4.Vector4 rowW=rand_matrix.ew;
        float[] rot={rowX.x,rowX.y,rowX.z,rowX.w,rowY.x,rowY.y,rowY.z,rowY.w,rowZ.x,rowZ.y,rowZ.z,rowZ.w,rowW.x,rowW.y,rowW.z,rowW.w,};
        return rot;
    }
}
