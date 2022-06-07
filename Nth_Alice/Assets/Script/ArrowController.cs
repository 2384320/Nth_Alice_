using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject alice;

    // Start is called before the first frame update
    void Start()
    {
        this.alice = GameObject.Find("alice");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.05f, 0);

        if(transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = this.alice.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.2f;
        float r2 = 0.21f;

        if(d < r1 + r2)
        {

            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(gameObject);
        }
    }
}
