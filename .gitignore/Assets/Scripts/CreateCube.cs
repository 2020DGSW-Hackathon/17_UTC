using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    Vector3 SpawnPosition;
    public GameObject Cube;
    float curTime = 0;
    float CubeTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPosition = new Vector3(9.5f, 0, 8.0f);
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime >= CubeTime)
        {
            SpawnPosition.x += 1.0f;
            Instantiate(Cube, SpawnPosition, Quaternion.identity);
            curTime = 0;
        }
    }


}
