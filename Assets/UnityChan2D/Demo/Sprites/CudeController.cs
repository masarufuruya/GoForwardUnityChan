using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CudeController : MonoBehaviour {
	//キューブの移動速度
	float speed = -0.2f;
	//消滅位置
	float deadLine = -10;
	//ブロック音
	AudioSource audioSource;

	void Awake() {
		this.audioSource = this.GetComponent<AudioSource> ();
	}

	void Update() {
		//x,y,zへ移動させるので、左向きに移動する
		this.transform.Translate (this.speed, 0, 0);

		//画面外に出たら破棄する
		if (this.transform.position.x < this.deadLine) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		string tag = col.gameObject.tag;
		//地面か別のキューブにあたった時に効果音を再生する
		if (tag == "Cube" || tag == "Ground") {
			this.audioSource.Play ();
		}
	}
}
