using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
	public float scrollSpeed = 0.5f;

	Material myMaterial;



	// Use this for initialization

	void Start()
	{
		myMaterial = GetComponent<Renderer>().material;
	}



	// Update is called once per frame

	void Update()

	{

		float newOffsetY = myMaterial.mainTextureOffset.y - scrollSpeed * Time.deltaTime;

		Vector2 newOffset = new Vector2(0, newOffsetY);



		myMaterial.mainTextureOffset = newOffset;



	}
}
