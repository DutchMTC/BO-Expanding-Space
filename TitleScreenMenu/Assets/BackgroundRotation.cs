using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class BackgroundRotation : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    
    void Update()
    {
        rotationSpeed = 5f;
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationSpeed));
    }
}
