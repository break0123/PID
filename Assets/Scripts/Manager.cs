using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    GameObject cube;
    public GameObject follower;

    //Hier wird das Prefab des Wegpunkts eingefügt, welcher später erzeugt wird
    public GameObject waypoint;

    //Layermask, damit nur der Boden angeklickt werden kann und die Wegpunkte und der Würfel ignoriert werden
    public LayerMask clickMask;

    WaypointManager wM;

    void Awake()
    {
        cube = GameObject.FindGameObjectWithTag("Cube");

        //Würfel wird inaktiv gesetzt, und mit Invoke nach 1 Sekunde wieder aktiv, damit die PIDs erst anfangen zu rechnen, wenn alles andere geladen wurde (sonst schießt der Würfel immer übers Ziel hinaus)
        cube.SetActive(false);
        follower.SetActive(false);
    }

    void Start()
    {
        wM = cube.GetComponent<WaypointManager>();

        Invoke("StartCube", 1);
    }

    //Hilfsmethode für Invoke, da mit Invoke keine Parameter übergeben werden können
    void StartCube()
    {
        cube.SetActive(true);
        follower.SetActive(true);
    }

    void Update()
    {
        //Hier wird die Position ermittelt, wo auf dem Boden geklickt wurde. Dann wird an dieser Stelle ein Wegpunkt mit Instantiate erzeugt.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPos = -Vector3.one;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast (ray, out hit, 100f, clickMask))
            {
                clickPos = hit.point;
            }

            GameObject lastWaypoint = Instantiate(waypoint, new Vector3(clickPos.x, 6.25f, clickPos.z), new Quaternion(0,0,0,0));

            //Der erzeugte Wegpunkt wird an letzter Stelle in die Liste im WaypointManager eingefügt
            wM.waypoints.Add(lastWaypoint);
        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    StartCube();
        //}


    }
}
