using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMotor : MonoBehaviour {

    GameObject RudderCollider;

    public float speed;
    public float downspeed;
    public float upspeed;
    public float turnspeed = 5f;
    public float SinkForce;

    public Collider middleCollider;
    public Rigidbody rudderRB;
    public GameObject rudderobject;

    public float hoverForce = 65f;
    public float hoverHeight = 0.5f;

    private float powerInput;
    private float turnInput;
    private Rigidbody boatRB;

    private float touchpos;


    void Awake() {
        boatRB = GetComponent<Rigidbody>();
    }

    void Update()

    {
        powerInput = speed;
        turnInput = (rudderRB.angularVelocity.magnitude * touchpos);

        if (Input.GetMouseButtonUp(0))
        { speed = downspeed;}

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < (Screen.width / 2))
            {
                touchpos = -20f;
            }

            if (Input.mousePosition.x > (Screen.width / 2))
            {
                touchpos = 20f;
            }
            
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider == middleCollider)
                    {
                        print("Speed UP!");
                        boatRB.AddForce(-transform.up * SinkForce);
                        speed = upspeed;
                    }

                }
            }
        }
            void FixedUpdate(){
                Ray ray = new Ray(transform.position, -transform.up);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, hoverHeight))
                {
                    float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
                    Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
                    boatRB.AddForce(appliedHoverForce, ForceMode.Acceleration);

                }

                boatRB.AddRelativeForce(0f, 0f, powerInput);
                boatRB.AddRelativeTorque(0f, turnInput * turnspeed, 0f);

            }

        }
 
