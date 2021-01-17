using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class door : MonoBehaviour
{
	public int levelToLoad;
	private gameMaster gm;

	void Start()
	{
		gm=GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			SaveScore();
			gm.InputText.text= (" [E] TO ENTER");
		}

	}
	void OnTriggerStay2D(Collider2D col)
	{
		if(Input.GetKeyDown("e"))
		{
			SaveScore();
			Application.LoadLevel(levelToLoad);
		}
		
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
		gm.InputText.text= (" ");
	}
		
	}
	void SaveScore()
	{
		PlayerPrefs.SetInt("Points",gm.points);
	}
   
    
}
