using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script um den Würfel schweben zu lassen

public class CubeThruster : MonoBehaviour
{

    //Die thrust-Variable wird vom Altitude-PID kontinuierlich angepasst 
    public float thrust = 0;
    public float maxThrust = 5;
    private Rigidbody mRigidbody;

    public GameObject prop1;
    public GameObject prop2;
    public GameObject prop3;
    public GameObject prop4;

    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }

    //FixedUpdate ist für Physics-Berechnungen, werden dann nur in einem bestimmten Intervall gemacht
    void FixedUpdate()
    {
        //Auf den Würfel wirkt eine Kraft ein, welche ihn auf der Y-Achse nach oben drückt
        mRigidbody.AddForce(new Vector3(0, thrust, 0), ForceMode.Impulse);
        //Die Beschleunigung wird auf den Wert von maxThrust begrenzt
        mRigidbody.velocity = Vector3.ClampMagnitude(mRigidbody.velocity, maxThrust);
    }

    private void Update()
    {
        //die Propeller drehen mit einem Vielfachen der Geschwindigkeit von thrust
        float rotorspeed = 7 * thrust;

        prop1.transform.Rotate(new Vector3(0, 0, rotorspeed));
        prop2.transform.Rotate(new Vector3(0, 0, -rotorspeed));
        prop3.transform.Rotate(new Vector3(0, 0, rotorspeed));
        prop4.transform.Rotate(new Vector3(0, 0, -rotorspeed));
        
    }
}
