using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCubeController : MonoBehaviour
{
    public float targetAltitude = 10;
    public float targetDistance = 3;
    public PIDController altitudePID;
    public PIDController distancePID;

    float maxThrust;
    float maxSpeed;

    public GameObject curTarget;
    FollowerCubeThruster fCT;
    FollowerCubeMover fCM;

    void Start()
    {
        fCT = GetComponent<FollowerCubeThruster>();
        fCM = GetComponent<FollowerCubeMover>();

        maxThrust = fCT.maxThrust;
        maxSpeed = fCM.maxSpeed;
    }

    void Update()
    {
        //Altitute Control ----------------------------------------------------
        targetAltitude = curTarget.GetComponent<CubeController>().targetAltitude;

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

        fCT.thrust = curAltValue;
        //---------------------------------------------------------------------

        //Distance Control-----------------------------------------------------

        //Aktuelle Distanz und Richtung vom Würfel zum Target wird berechnet
        float curTargetDist = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(curTarget.transform.position.x, 0, curTarget.transform.position.z));
        Vector3 curTargetDir = (transform.position - curTarget.transform.position).normalized;

        float disErr = targetDistance - curTargetDist;

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

        fCM.direction = curTargetDir;
        fCM.speed = curDisValue;
        //---------------------------------------------------------------------

        //Rotiert die Drohne, sodass sie immer ihr Target anschaut
        transform.LookAt(new Vector3(curTarget.transform.position.x, transform.position.y, curTarget.transform.position.z));
    }
}
