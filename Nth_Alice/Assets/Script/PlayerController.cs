using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public bool gameOver = false;

    float distance = 10;

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
        if (gameOver == false) {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            if (other.transform.tag == "House") {
                Destroy(other.gameObject);
            } else if (other.transform.tag == "Arrow") {
                Destroy(other.gameObject);
            }
        }
    }

    public void StopTrigger() {
        gameOver = true;
    }
}
