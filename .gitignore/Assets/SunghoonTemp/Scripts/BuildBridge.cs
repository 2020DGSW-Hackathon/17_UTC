using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BuildBridge : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject part4;
    public GameObject part5;
    public GameObject part6;
    public AudioSource water;
    public GameObject player;
    public GameObject board;
    public GameObject camera;
    public float timer = 0;
    public float timer2 = 0;
    public bool startMove = false;
    PlayerMove pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    void Update()
    {
        if(startMove)
        {
            timer2 += Time.deltaTime;
        }
        if(timer2 > 10)
        {
            player.SetActive(false);
        }
        if(!pm.canCtl)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 1)
        {
            if(!part1.activeSelf)
            {
                part1.SetActive(true);
                water.Play();
            }
        }
        if (timer >= 2)
        {
            if (!part2.activeSelf)
            {
                part2.SetActive(true);
                water.Play();
            }
        }
        if (timer >= 3)
        {
            if (!part3.activeSelf)
            {
                part3.SetActive(true);
                water.Play();
            }
        }
        if (timer >= 4)
        {
            if (!part4.activeSelf)
            {
                part4.SetActive(true);
                water.Play();
            }
        }
        if (timer >= 5)
        {
            if (!part5.activeSelf)
            {
                part5.SetActive(true);
                water.Play();
            }
        }
        if (timer >= 6)
        {
            if (!part6.activeSelf)
            {
                part6.SetActive(true);
                water.Play();
            }
            player.transform.Translate(new Vector3(1, 0, 0) * 10 * Time.deltaTime);
            board.SetActive(false);
            camera.transform.eulerAngles = new Vector3(0, 90, 0);
            startMove = true;
        }
    }
}
