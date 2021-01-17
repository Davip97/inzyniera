using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameMaster : MonoBehaviour
{
	public int points;
	public Text pointsText;
	public Text InputText;

	void Start()
	{
		if(PlayerPrefs.HasKey("Points"))
		{
			if (Application.loadedLevel == 1)
			{
				PlayerPrefs.DeleteKey("Points");
				points = 0;
			}
			else
			{
				points = PlayerPrefs.GetInt("Points");
			}
		}
	}
    
    void Update()
    {
    	pointsText.text= ("Bits:" + points);

       
    }
}
