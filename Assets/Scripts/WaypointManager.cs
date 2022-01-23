using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script welches eine Liste für die Wegpunkte erzeugt, ist am Würfel angehängt und wird vom Manager gefüllt

public class WaypointManager : MonoBehaviour
{
    public List<GameObject> waypoints;

    void Start()
    {
        waypoints = new List<GameObject>();
    }

    void Update()
    {
        //Gibt in der Konsole aus wie viele Wegpunkte aktuell vorhanden sind
        //Debug.Log(waypoints.Count);
    }
}
