using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float targetAltitude = 10;
    public float targetDistance = 1;
    public PIDController altitudePID;
    public PIDController distancePID;

    float maxThrust;
    float maxSpeed;

    bool enoughWaypoints = false;

    GameObject curWaypoint;
    private WaypointManager wM;
    CubeThruster cT;
    CubeMover cM;

    void Start()
    {
        cT = GetComponent<CubeThruster>();
        cM = GetComponent<CubeMover>();
        wM = GetComponent<WaypointManager>();

        maxThrust = cT.maxThrust;
        maxSpeed = cM.maxSpeed;
    }

    void Update()
    {
        if (wM.waypoints.Count == 10)
        {
            enoughWaypoints = true;
        }

        //Altitute Control ----------------------------------------------------
        float curAltitude = transform.position.y;

        float altErr = targetAltitude - curAltitude;
        float curAltValue = altitudePID.Update(altErr);

        //Der Ausgabe-Wert des Altitude-PID wird auf den Bereich von 0 bis Maxthrust (im Moment 3.5) begrenzt
        if (curAltValue <= -maxThrust)
        {
            curAltValue = -maxThrust;
        }
        else if (curAltValue >= maxThrust)
        {
            curAltValue = maxThrust;
        }

        cT.thrust = curAltValue;
        //---------------------------------------------------------------------

        //Distance Control-----------------------------------------------------
        if (wM.waypoints.Count > 0)
        {
            if (enoughWaypoints)
            {
                curWaypoint = wM.waypoints.First();

                //Aktuelle Distanz und Richtung vom Würfel zum nächsten Wegpunkt wird berechnet
                float curWaypointDist = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(curWaypoint.transform.position.x, 0, curWaypoint.transform.position.z));
                Vector3 curWaypointDir = (transform.position - curWaypoint.transform.position).normalized;

                float disErr = targetDistance - curWaypointDist;

                float curDisValue = distancePID.Update(disErr);

                //Der Ausgabe-Wert des Distance-PID wird auf den Bereich von +MaxSpeed bis -MaxSpeed (im Moment 2) begrenzt
                if (curDisValue <= -maxSpeed)
                {
                    curDisValue = -maxSpeed;
                }
                else if (curDisValue >= maxSpeed)
                {
                    curDisValue = maxSpeed;
                }

                cM.direction = curWaypointDir;
                cM.speed = curDisValue;



                if (curWaypointDist <= 0.25 && wM.waypoints.Count != 1)
                {
                    wM.waypoints.Remove(curWaypoint);
                }
                else if (curWaypointDist > 0.5)
                {
                    //Rotiert die Drohne, sodass sie immer ihr Target anschaut
                    transform.LookAt(new Vector3(curWaypoint.transform.position.x, transform.position.y, curWaypoint.transform.position.z));
                    //Quaternion toRotation = Quaternion.FromToRotation(transform.forward, new Vector3(curWaypointDir.x, 0, curWaypointDir.z));
                    //transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 2 * Time.time);
                }
            }
            //---------------------------------------------------------------------

        }



    }
}
