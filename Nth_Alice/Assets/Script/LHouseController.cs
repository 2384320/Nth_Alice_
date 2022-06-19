using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHouseController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 0.05f, 0);

        if (transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }
    }
}
