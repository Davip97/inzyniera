﻿using System.Collections;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	private Player player;

	void Start()
	{
		player = gameObject.GetComponentInParent<Player>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		player.ground = true;

	}
	void OnTriggerStay2D(Collider2D collision)
	{
		player.ground = true;

	}
	void OnTriggerExit2D(Collider2D collision)
	{
		player.ground = false;
	}


}
