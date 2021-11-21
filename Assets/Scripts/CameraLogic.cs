using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < character.transform.position.y  )
        {
            transform.position =
                new Vector3(transform.position.x, character.transform.position.y, transform.position.z);
        }
    }
}
