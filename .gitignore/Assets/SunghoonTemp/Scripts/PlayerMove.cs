using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float h;
    float v;
    public bool isHolding = false;
    public bool stopCr = false;
    public bool canCtl = true;
    bool playOnce = true;
    public GameObject holding;
    public GameObject temp;
    public ParticleSystem smoke;
    public AudioSource win;

    private void Update()
    {
        if(canCtl)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        if(!canCtl && playOnce)
        {
            stopCr = true;
            this.transform.position = new Vector3(-54.4f, 8.5f, 30f);
            win.Play();
            playOnce = false;
        }
    }

    void FixedUpdate()
    {
        if(playOnce)
            transform.Translate(new Vector3(v, 0, -h) * 30 * Time.deltaTime);
        if (isHolding)
        {
            if(Input.GetKeyUp(KeyCode.H) && canCtl)
            {
                stopCr = true;
                //holding.transform.tag = "Untagged";
            }
            else
            {
                holding.transform.tag = "isHolding";
                holding.transform.position = new Vector3(this.transform.position.x + 12, holding.transform.position.y, this.transform.position.z);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!isHolding && collision.transform.name != "LowpolyTerrain")
        {
            holding = collision.gameObject;
            StartCoroutine(Hold());
        }   
    }
    
    IEnumerator Hold()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.H))
            {
                isHolding = true;
            }
            else
                isHolding = false;

            if (stopCr)
            {
                holding.transform.tag = "Untagged";
                holding = temp;
                stopCr = false;
                break;
            }
            yield return null;
        }
    }
}
