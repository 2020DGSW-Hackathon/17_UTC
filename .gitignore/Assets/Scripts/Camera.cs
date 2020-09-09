using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    public GameObject player2;
    float dist = 20f;
    float height = 45f;
    float playerX = 0;
    float playerY = 0;
    float PlayerZ = 0;
    bool move = true;
    private Transform tr;
    PlayerMove pm;
    BuildBridge bb;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        pm = GameObject.Find("Player").GetComponent<PlayerMove>();
        bb = GameObject.Find("BildBridge").GetComponent<BuildBridge>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = pm.canCtl;
        if(!move)
        {
            this.transform.position = new Vector3(-60, 25f, 25.6f);
            this.tr.eulerAngles = new Vector3(45f, 90, 0);
            if(bb.startMove)
            {
                tr.LookAt(Player.transform.position);
            }
        }
        if(player2.activeSelf == true && move)
        {
            playerX = Player.transform.position.x;
            playerY = Player.transform.position.y;
            PlayerZ = Player.transform.position.z;
            tr.position = new Vector3(playerX - dist, playerY + height, PlayerZ);
            tr.LookAt(Player);
        }
    }
}
