using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    public GameObject fsBox;
    public GameObject midBox;
    public GameObject ltBox;
    bool checkFs = false;
    bool checkSc = false;
    Transform tr;
    RaycastHit hit;

    PlayerMove pm;

    void Start()
    {
        tr = GetComponent<Transform>();
        pm = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(this.transform.position, Vector3.forward, out hit, 20))
        {
            if(hit.transform.name == "First")
            {
                checkFs = true;
            }
            else
            {
                checkFs = false;
            }
        }
        else
        {
            checkFs = false;
        }
        if(Physics.Raycast(this.transform.position, -Vector3.forward, out hit, 20))
        {
            if (hit.transform.name == "Third" && hit.transform.tag != "isHolding")  
            {
                checkSc = true;
            }
            else
            {
                checkSc = false;
            }
        }
        else
        {
            checkSc = false;
        }
        if (checkFs && checkSc)
        {
            Debug.Log("Success");
            pm.canCtl = false;
        }
    }
}
