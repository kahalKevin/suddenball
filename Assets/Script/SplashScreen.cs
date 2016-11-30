using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour 
{
    public float Time = 3f;
    public string LevelToLoad = "MenuUtama";
	// Use this for initialization
	void Start () 
    {
        StartCoroutine("DisplayMainMenu");
	}

    IEnumerator DisplayMainMenu()
    {
        yield return new WaitForSeconds(Time);

        Application.LoadLevel(LevelToLoad);
    }
}
