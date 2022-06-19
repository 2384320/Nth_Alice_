using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public AudioClip Coll;
    public bool bam = false;
    public float bamTime;
    SpriteRenderer spriteRenderer;

    AudioSource aud;
    float distance = 10;


    private void Start()
    {
        this.aud = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (bam == true) {
            bamTime += (Time.deltaTime*2);
            
            if (Mathf.Round(bamTime) % 2 == 0) {
                spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            } else {
                spriteRenderer.color = new Color(1, 1, 1, 0.8f);
            }

            if (bamTime > 6.0f) {
                bam = false;
                bamTime = 0;
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }
        }  
    }

    void OnMouseDrag() {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Screen.height/1.5f, distance); 
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); 
        transform.position = objPosition;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position); 
        if (pos.x < 0f) pos.x = 0f; 
        if (pos.x > 1f) pos.x = 1f; 
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    // 플레이어와 하우스 오브젝트의 충돌 -> 하우스 오브젝트 삭제
    private void OnTriggerEnter2D(Collider2D other) {
        if (bam == false) {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            bam = true;
            if (other.transform.tag == "House") {
                Destroy(other.gameObject);
            } else if (other.transform.tag == "Arrow") {
                Destroy(other.gameObject);
            }
            this.aud.PlayOneShot(this.Coll);
        }
    }
}
