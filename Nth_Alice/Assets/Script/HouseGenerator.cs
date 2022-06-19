using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGenerator : MonoBehaviour
{
    public GameObject housePrefab;
    float span = 2.0f;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(housePrefab) as GameObject;
            int px = Random.Range(-30, -7);
            go.transform.position = new Vector3(1.72f, px, 0);
        }
    }
}
