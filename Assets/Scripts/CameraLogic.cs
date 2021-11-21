using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public GameObject character;
   // public EventSystemCustomLogic eventSystem;

    private bool isNewSpawn;
    // Start is called before the first frame update
    void Start()
    {
        isNewSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < character.transform.position.y  )
        {
            transform.position =
                new Vector3(transform.position.x, character.transform.position.y, transform.position.z);
            if (isNewSpawn)
            {
                //eventSystem.OnGroundTouch.Invoke();
                isNewSpawn = false;
            }
        }
        else
        {
            isNewSpawn = true;
        }
    }
}
