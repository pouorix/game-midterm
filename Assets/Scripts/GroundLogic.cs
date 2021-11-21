using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GroundLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ground;
    public GameObject groundParents;
    public EventSystemCustomLogic eventSystem;
    public GameObject player;

    void Start()
    {
        eventSystem.OnGroundTouch.AddListener(spawnGround);
    }

    private void spawnGround()
    {

        Vector3 vector3_1 = new Vector3();
        vector3_1.x = UnityEngine.Random.Range(-2.5f, 2.5f);
        vector3_1.y = player.transform.position.y + 3.5f;
        GameObject go = Instantiate(ground);
        go.transform.position = vector3_1;
        go.transform.parent = groundParents.transform;
        go.transform.localScale = new Vector3(1, 1, 1);

        Vector3 vector3_2 = new Vector3();
        vector3_2.x = UnityEngine.Random.Range(-2.5f, 2.5f);
        vector3_2.y = player.transform.position.y + 4.5f;
        GameObject go2 = Instantiate(ground);
        go2.transform.position = vector3_2;
        go2.transform.parent = groundParents.transform;
        go2.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}