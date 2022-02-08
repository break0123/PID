using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSensor : MonoBehaviour
{
    public Collider MMCol;
    public Collider MRCol;
    public Collider MLCol;
    public Collider OMCol;
    public Collider ORCol;
    public Collider OLCol;
    public Collider UMCol;
    public Collider URCol;
    public Collider ULCol;

    public List<int> obstacleDetection;

    private void Start()
    {
        obstacleDetection = new List<int>();
    }

}
