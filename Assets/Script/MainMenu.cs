using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
    public Text Score;
	// Use this for initialization
	void Start () 
    {
        Score.text = PlayerPrefs.GetInt("PlayerScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        Application.LoadLevel("GamePlay");
    }
}
