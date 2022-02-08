using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastObstacleSensor : MonoBehaviour
{
    public LayerMask obstacleLayer;

    public List<int> obstacles;

    //int frameCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        obstacles = new List<int>();
        obstacles.Add(0);
        obstacles.Add(0);
        obstacles.Add(0);
        obstacles.Add(0);
        obstacles.Add(0);

    }

    // Update is called once per frame
    void Update()
    {
        RaycastSensor();
        //foreach (int i in obstacles)
        //{
        //    Debug.Log("Frame " + frameCounter + ": " + i);
        //}
        //frameCounter++;
        
    }

    private void RaycastSensor()
    {
        //MM
        Debug.DrawRay(transform.position, transform.forward *5, Color.red, 0.1f);
        if (Physics.Raycast(transform.position, transform.forward, 5f, obstacleLayer))
        {
            obstacles[0] = 1;
        }
        else
        {
            obstacles[0] = 0;
        }
        //OM
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0, 3f, 10)).normalized * 5, Color.red, 0.1f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0, 3f, 10)).normalized, 5f, obstacleLayer))
        {
            obstacles[1] = 1;
        }
        else
        {
            obstacles[1] = 0;
        }
        //UM
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0, -3f, 10)).normalized * 5, Color.red, 0.1f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0, -3f, 10)).normalized, 5f, obstacleLayer))
        {
            obstacles[2] = 1;
        }
        else
        {
            obstacles[2] = 0;
        }
        //MR
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(4.5f, 0, 10)).normalized * 6, Color.red, 0.1f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(4.5f, 0, 10)).normalized, 6f, obstacleLayer))
        {
            obstacles[3] = 1;
        }
        else
        {
            obstacles[3] = 0;
        }
        //ML
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(-4.5f, 0, 10)).normalized * 6, Color.red, 0.1f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(-4.5f, 0, 10)).normalized, 6f, obstacleLayer))
        {
            obstacles[4] = 1;
        }
        else
        {
            obstacles[4] = 0;
        }

    }
}
