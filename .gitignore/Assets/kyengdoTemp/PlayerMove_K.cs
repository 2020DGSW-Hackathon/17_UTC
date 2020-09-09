using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMove_K : MonoBehaviour
{
    float h;
    float v;
    bool isHolding = false;

    GameObject holding;
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.H) && isHolding)
        {
            holding.transform.tag = "Untagged";
            isHolding = false;
        }
    }
    
    void FixedUpdate()
    {
        transform.Translate(new Vector3(-h, 0, -v) * 30f * Time.deltaTime);
        if(isHolding)
        {
            holding.transform.tag = "isHolding";
            holding.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 5);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!isHolding && collision.transform.name != "default")
        {
            holding = collision.gameObject;
            
            isHolding = true;
        }
    }
}