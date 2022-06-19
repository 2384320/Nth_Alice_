using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 0.07f, 0);

        if (transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }
        
    }
}
