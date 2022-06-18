using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
	public float scrollSpeed = 0.5f;
	public float newOffsetY;
	public bool gameOver = false;
	Material myMaterial;

	void Start()
	{
		myMaterial = GetComponent<Renderer>().material;
	}

	void Update()
	{
		if (gameOver == false) {
			this.newOffsetY = myMaterial.mainTextureOffset.y - scrollSpeed * Time.deltaTime;
			Vector2 newOffset = new Vector2(0, newOffsetY);
			myMaterial.mainTextureOffset = newOffset;
		}
	}

	public void StopBackground() {
		gameOver = true;
	}
}
