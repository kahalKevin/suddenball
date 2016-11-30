using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour 
{
	// Use this for initialization
	//Object Background
	public Image spriteBG;

    //Scoring
    public int Score = 0;
    public int BallPoint = 1000;
    public int RangeMax = 500;
    public int CountScore = 0;
    public int TempScore;

	//Color
	Color [] colors = new Color[6];

	//Time
	public float ChangeColorTime = 2f;
	public float StartChangeColor = 0.5f;

	//Image Button Cermin
	public Transform Ball;

	//Time for Generate Ball
	float TimeGenerateBall;
	float CountTimeGenerateBall = 0;

	//Time for Change Background
	float TimeChangeBG;
	float CountTimeChangeBG = 0;

	//Menggambar Energy
	public Slider Energy;
	private float Kecepatan = 0.1f;

    //ScoreBoard
    public Text ScoreBoard;
    public Text FinalScore;

    //Jumlah Bola
    public int JumlahBola = 0;

    //DialogGameOver
    public GameObject Dialog_LevelCleared;
    public bool StatusGameOver = false;

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
		ChangeBackground ();

        Dialog_LevelCleared.SetActive(false);

        //Set Score
        TempScore = PlayerPrefs.GetInt("PlayerScore");
        
	}


	// Update is called once per frame
	void Update () 
	{
        if (!StatusGameOver)
        {
            //Cetak Score
            ScoreBoard.text = Score.ToString();

            //LevelCheck
            CheckLevel();

            if (Energy.value <= 0)
            {
                GameOver();
                StatusGameOver = true;
            }

            Energy.value -= Kecepatan;
            //Generate New Ball
            CountTimeGenerateBall += 1f;

            if (CountTimeGenerateBall == TimeGenerateBall)
            {
                GenerateBall();
                CountTimeGenerateBall = 0;
            }

            //Change Background
            CountTimeChangeBG += 1f;

            if (CountTimeChangeBG == TimeChangeBG)
            {
                ChangeBackground();
                CountTimeChangeBG = 0f;
            }

            //Check JumlahBola < MinBola
            if (JumlahBola < 4)
            {
                for (int i = 1; i <= 5; i++)
                {
                    GenerateBall();
                }
            }
        }
        else
        {
            if (CountScore <= Score)
            {
				if((Score - CountScore) >= 1000)
				{
					CountScore += 1000;
				}
				else
				{
					CountScore += Score % 1000;
				}
				FinalScore.text = CountScore.ToString();
            }
        }
        
	}

	void ChangeBackground()
	{
		TimeChangeBG = Random.Range (80, 150);

        spriteBG.color = colors[Random.Range(0, colors.Length)];
        //spriteBG.color = colors[5];
	}

	void GenerateBall()
	{
        JumlahBola++;
        TimeGenerateBall = Random.Range(100, RangeMax);
		var NewBall = Instantiate(Ball) as Transform;
        NewBall.SetParent(GameObject.Find("BallCollection").transform);
        NewBall.gameObject.GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];

        NewBall.position = GameObject.Find("GameManager").transform.position;
	}

    void CheckLevel()
    {
        if (Score > 10000)
        {
            BallPoint = 1128;
            Kecepatan = 0.15f;
            RangeMax = 400;
        }
        else if (Score > 25000)
        {
            BallPoint = 4121;
            Kecepatan = 0.2f;
        }
        else if (Score > 50000)
        {
            BallPoint = 8363;
            Kecepatan = 0.25f;
            RangeMax = 370;
        }
        else if (Score > 110000)
        {
            BallPoint = 15362;
            Kecepatan = 0.29f;
            RangeMax = 300;
        }
        else if (Score > 410000)
        {
            BallPoint = 17523;
            Kecepatan = 0.32f;
            RangeMax = 200;
        }
        else if (Score > 750000)
        {
            BallPoint = 21159;
            Kecepatan = 0.36f;
        }
        else if (Score > 1000000)
        {
            BallPoint = 32716;
            Kecepatan = 0.4f;
            RangeMax = 180;
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        Dialog_LevelCleared.SetActive(true);

        if (Score > TempScore)
        {
            PlayerPrefs.SetInt("PlayerScore", Score);
        }
    }

    public void Replay()
    {
        Application.LoadLevel("GamePlay");
        StatusGameOver = true;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.LoadLevel("MenuUtama");
        Time.timeScale = 1;
    }
}
