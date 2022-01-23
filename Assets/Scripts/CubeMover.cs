using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script um den Würfel in Richtung der Wegpunkte zu bewegen

public class CubeMover : MonoBehaviour
{
    private Rigidbody mRigidbody;

    //Die speed-Variable wird vom Distance-PID kontinuierlich angepasst
    public float speed = 0;
    public float maxSpeed = 5;

    //Die direction-Variable ist der Richtungsvektor vom Würfel zum nächsten Wegpunkt und wird im CubeController berechnet
    public Vector3 direction = Vector3.zero;
    

    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        //Auf den Würfel wird eine Kraft, welche ihn auf der x und z Achse in Richtung des Wegpunkts schiebt
        mRigidbody.AddForce(new Vector3(direction.x, 0, direction.z) * speed, ForceMode.Impulse);
        //Die Beschleunigung wird auf den Wert von maxSpeed begrenzt
        mRigidbody.velocity = Vector3.ClampMagnitude(mRigidbody.velocity, maxSpeed);
    }
}
