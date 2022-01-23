using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-0.2f, 0, 0), Space.Self);
        }
        else if(Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(0.2f, 0, 0), Space.Self);
            }

        transform.LookAt(target.transform);
    }
}
