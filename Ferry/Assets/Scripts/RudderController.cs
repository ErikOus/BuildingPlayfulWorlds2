using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderController : MonoBehaviour
{

    public Camera MainCamera;
    public float torque;
    public float touchpower;

    private Collider RudderCollider;
    public Collider middleCollider;
    public Rigidbody RudderRB;
    private Ray Mousepoint;
    public float touchpos;

    public GameObject Boat;
    BoatMotor BoatMotorScript;

    static float t = 0.0f;

    // Use this for initialization
    void Start()
    {
        RudderCollider = GetComponent<Collider>();
        BoatMotorScript = Boat.GetComponent<BoatMotor>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == RudderCollider)
                {
                    print("Rudder Hit!");
                    RudderRB.AddTorque(transform.up * torque * touchpos);
                    BoatMotorScript.speed = 0.04f;
                    BoatMotorScript.turnspeed = 0.01f;
                }

                
            }
        }

        if (Input.mousePosition.x < (Screen.width / 2))
            {
                touchpos = -touchpower;
            }

        if (Input.mousePosition.x > (Screen.width / 2))
            {
                touchpos = touchpower;
            }
            



            Debug.Log (touchpos);

       

    }

}