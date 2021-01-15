using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	public Sprite[] HeartsSprites;
	public Image HeartUI;
	private Player player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void Update()
	{
		HeartUI.sprite = HeartsSprites[player.curHealth];
	}


}
