using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {


	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	private GameObject scoreText;

	private int score;


	void Start () {
		
		this.gameoverText = GameObject.Find ("GameOverText");

		this.scoreText = GameObject.Find ("ScoreText");

		this.score = 0;

		SetScore ();

	}

	void SetScore()
	{
		this.scoreText.GetComponent<Text> ().text = "Score:"+score;
	}


	void Update () {
		
		if (this.transform.position.z < this.visiblePosZ) {
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "LargeStarTag") {
			this.score += 5;
			SetScore ();
		} else if (col.gameObject.tag == "SmallCloudTag") {
			this.score += 20;
			SetScore ();
		} else if (col.gameObject.tag == "LargeCloudTag") {
			this.score += 50;
			SetScore ();
		} else if (col.gameObject.tag == "SmallStarTag") {
			this.score += 10;
			SetScore ();
		}
}
}