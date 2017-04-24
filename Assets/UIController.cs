using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	//ゲームオーバーテキスト
	GameObject gameOverText;
	//走行距離テキスト
	GameObject runLengthText;
	//走った距離
	float len = 0;
	//走る速度
	float speed = 0.03f;
	//ゲームオーバーの測定
	bool isGameOver = false;

	void Awake() {
		this.gameOverText = GameObject.Find ("GameOver");
		this.runLengthText = GameObject.Find ("RunLength");
	}

	// Update is called once per frame
	void Update () {
		if (this.isGameOver == false) {
			//走った距離を更新する
			this.len += this.speed;
			//走った距離を表示する(文字列変換する時にF2で四捨五入して小数点第2までにする)
			this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m";
		}

		//ゲームオーバーになった時
		if (this.isGameOver) {
			//クリックされたら元のシーンに戻る
			if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene ("GameScene");
			}
		}
	}

	public void GameOver() {
		//ゲームオーバーになった時に画面上にゲームオーバーを表示する
		this.gameOverText.GetComponent<Text>().text = "GameOver";
		this.isGameOver = true;
	}
}
