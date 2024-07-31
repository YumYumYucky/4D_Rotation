using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomRotation : MonoBehaviour
{
    //Reference cube
    public GameObject Ref;
    //random 3D vector
    private Vector3 rand;
    // Start is called before the first frame update
    void Start()
    { 
        //calls NewRotation when program starts
        NewRotation();
    }

    public void NewRotation()
    {
        //gets current rotation and resets it
        Vector3 unRotate = transform.rotation.eulerAngles;
        Ref.transform.Rotate(-unRotate);
        //gets random 3d vector and rotates cube 
        rand=new Vector3(UnityEngine.Random.Range(-180f,180f),UnityEngine.Random.Range(-180f,180f),UnityEngine.Random.Range(-180f,180f));
        Ref.transform.Rotate(rand);
    }

}
