using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BallBehaviour : MonoBehaviour {

    float ballSpeed = 20000f;

	// Use this for initialization
	void Start () 
    {
		GoBall ();
	}
	
	// Update is called once per frame
	void Update () 
	{
        
	}

	void GoBall()
	{
		var randomNumber = Random.Range (0, 2);

		var randomY = Random.Range (-1000, 1000);

		if (randomNumber <= 0.5) 
		{
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (ballSpeed, randomY));
		} 
		else 
		{
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (-ballSpeed, randomY));
		}
	}

    public void TouchBall()
    {
        Color ColorBall = this.gameObject.GetComponent<Image>().color;

        Color ColorBG = GameObject.Find("Background").gameObject.GetComponent<Image>().color;
        Slider Time = GameObject.Find("Time").gameObject.GetComponent<Slider>();
        GamePlayManager GM = GameObject.Find("GameManager").gameObject.GetComponent<GamePlayManager>();

        if (ColorBG == ColorBall)
        {
            Destroy(this.gameObject);
            Time.value = 100;
            GM.JumlahBola--;

            //Scoring
            GM.Score += GM.BallPoint;
        }
        else
        {
            Time.value -= 10;
        }
    }
}
