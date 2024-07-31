using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float xAngle, yAngle, zAngle;

    private GameObject cube1;

    // Start is called before the first frame update
    void Start()
    {
       cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(0.75f, 0.0f, 0.0f);
        cube1.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        cube1.GetComponent<Renderer>().material.color = Color.red;
        cube1.name = "Self";
 
    }

    public void Update()
    {
        cube1.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log(Input.mousePosition);
        }
    }


}
