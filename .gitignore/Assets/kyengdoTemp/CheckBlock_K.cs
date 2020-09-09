using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlock_K : MonoBehaviour{

    PlayerMove_K PlayerMove;

    Transform tr;
    Rigidbody rb;
    public GameObject player;
    RaycastHit hit;

    bool isChecked = false;
    float timer = 0;



    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.DrawRay(new Vector3(this.tr.position.x, this.tr.position.y, this.tr.position.z), -transform.right * 3f, Color.red);
        if (this.tr.tag != "isHolding"){
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else{
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(this.tr.name == "First" && collision.transform.name == "Second")
        {
            if (Physics.Raycast(new Vector3(this.tr.position.x, this.tr.position.y, this.tr.position.z), -transform.right, out hit, 3f))
            {
                if(hit.transform.name != "First")
                {
                    if (hit.transform.name == "Second" && hit.transform.tag != "isHolding")
                    {
                        hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, this.tr.position.z);
                        Debug.Log("Right Connection");
                    }
                }
            }
        }
    }
}