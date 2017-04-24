using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
	//スクロール速度
	float scrollSpeed = -0.015f;
	//背景終了位置
	float deadLine = -16;
	//背景開始位置
	float startLine = 15.8f;

	void Update() {
		//背景を左側へ移動する
		this.transform.Translate(this.scrollSpeed, 0, 0);

		//背景画像が画面外に出たら画面右端に移動して同じ背景画像が続くようにする
		if (this.transform.position.x < this.deadLine) {
			this.transform.position = new Vector2 (this.startLine, 0);
		}
	}

}
