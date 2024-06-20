using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.GetChild(0).Rotate(-Input.GetAxis("Mouse Y") * 1.2f, Input.GetAxis("Mouse X") * 1.2f, 0);
            transform.GetChild(0).eulerAngles = new Vector3(transform.GetChild(0).eulerAngles.x, transform.GetChild(0).eulerAngles.y, 0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.GetChild(0).localEulerAngles = Vector3.zero;
        }
    }
}
