using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public Vector3 point1;
    public Vector3 point2;
    public Collider box;
    public Collider sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    //void OnCollisionStay(Collider other)
    //{
    
    //    if( other.gameObject.tag == "Collision Sphere" )
    //    {

    //    }

   // }

    //void OnCollisionStay(Collision collisionInfo, Vector3 lineX)
    //{
        // Debug-draw all contact points and normals
        //foreach (ContactPoint contact in collisionInfo.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
        //}
        //Vector3 closestPoint = sphere.ClosestPointOnBounds();
    //}


    // Update is called once per frame
    void Update()
    {
        
    }
}
