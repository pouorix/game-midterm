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

        Vector3 vector3 = new Vector3();
        vector3.x = UnityEngine.Random.Range(-2.5f, 2.5f);
        vector3.y = player.transform.position.y + 3.5f;
        GameObject go = Instantiate(ground);
        go.transform.position = vector3;
        go.transform.parent = groundParents.transform;
        go.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}