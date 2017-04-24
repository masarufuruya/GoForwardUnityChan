using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
	Animator animator;
	UIController UIController;

	//Unityちゃんを移動させるコンポーネント
	Rigidbody2D rigid2D;

	//地面の位置
	float groundLevel = -3.0f;

	//ジャンプ速度の減衰
	float dump = 0.8f;

	//ジャンプの速度
	float jumpVelocity = 20;

	//ゲームオーバーになる位置
	float deadLine = -9;

	void Awake() {
		this.animator = GetComponent<Animator> ();
		this.rigid2D = GetComponent<Rigidbody2D> ();
		this.UIController = GameObject.Find ("Canvas").GetComponent<UIController> ();
	}

	void Update() {
		//アニメーションのMove Rightに移行させる
		this.animator.SetFloat ("Horizontal", 1);

		//着地しているかどうかを調べる
		bool isGround = (transform.position.y > this.groundLevel) ? false : true;
		//yポジションの値に応じてジャンプと着地を切り替える
		this.animator.SetBool ("isGround", isGround);

		//ジャンプ状態の時には足音を鳴らさない
		this.GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

		//着地状態でクリックされた場合
		if (Input.GetMouseButtonDown (0) && isGround) {
			this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);
		}

		//クリックをやめたら上方向への速度を減衰する
		if (Input.GetMouseButton (0) == false) {
			if (this.rigid2D.velocity.y > 0) {
				this.rigid2D.velocity *= this.dump;
			}
		}

		if (this.transform.position.x < this.deadLine) {
			//ゲームオーバーを表示する
			this.UIController.GameOver ();
			//ユニティちゃんを破棄
			Destroy(this.gameObject);
		}
	}
}
