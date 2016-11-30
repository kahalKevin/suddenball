using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour 
{
	// Use this for initialization
	//Object Background
	public Image spriteBG;

	//Color
	Color [] colors = new Color[6];

	//Image Button Cermin
	public Transform Ball;

    //DialogGameOver
    public GameObject Dialog_LevelCleared;

    //Text Score
    public Text Score;

    //Help
    public GameObject help1;

    //Animation for Help Screen
    public Animator ScreenAnim;

	void Start () 
	{
		colors [0] = new Color (0f, 0.72f, 0.83f, 1f); //Cyan
        colors [1] = new Color (0.41f, 0.94f, 0.68f, 1f); //Light Green
        colors [2] = new Color (0.97f, 0.65f, 0.14f, 1f); //Orange
        colors [3] = new Color (1f, 0.09f, 0.26f, 1f); //Red
        colors [4] = new Color (0.14f, 0.65f, 0.6f, 1f); //Green
        colors [5] = new Color (1f, 1f, 0f, 1f); //Yellow

        for (int i = 1; i <= 8; i++)
        {
            GenerateBall();
        }

        Score.text = PlayerPrefs.GetInt("PlayerScore").ToString();

        help1.SetActive(false);
	}


	// Update is called once per frame
	void Update () 
	{

	}

	void GenerateBall()
	{
		var NewBall = Instantiate(Ball) as Transform;
        NewBall.SetParent(GameObject.Find("BallCollection").transform);
        NewBall.gameObject.GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];

        NewBall.position = GameObject.Find("GameManager").transform.position;
	}

    public void Play()
    {
        Application.LoadLevel("GamePlay");
    }

    public void OpenHelp()
    {
        help1.SetActive(true);
    }

    public void Close()
    {
        help1.SetActive(false);
    }
}
