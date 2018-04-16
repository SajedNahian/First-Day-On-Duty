using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    public static void UpdateDeath ()
    {
        if (PlayerPrefs.HasKey("deathCount"))
        {
            PlayerPrefs.SetInt("deathCount", PlayerPrefs.GetInt("deathCount") + 1);
            if (PlayerPrefs.GetInt("deathCount") == 4)
            {
                ShowAd();
                PlayerPrefs.SetInt("deathCount", 0);
            }
        } else
        {
            PlayerPrefs.SetInt("deathCount", 1);
        }
    }
}
