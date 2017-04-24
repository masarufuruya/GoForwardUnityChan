using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {
	//キューブのPrefab
	public GameObject cubePrefab;
	//時間計測用の変数
	float delta = 0;
	//キューブの生成間隔
	float span = 1.0f;
	//キューブの生成位置: x座標
	float getPosX = 12;

	//キューブの生成位置オフセット
	float offsetY = 0.3f;
	//キューブの縦方向の間隔
	float spaceY = 6.9f;

	//キューブの生成位置オフセット
	float offsetX = 0.5f;
	//キューブの横方向の間隔
	float spaceX = 0.4f;

	//キューブの生成個数の上限
	int maxBlockNum = 3;

	void Update() {
		//フレームごとにフレーム間の時間差を足していき経過時間を計測する
		this.delta += Time.deltaTime;

		//キューブの生成の間隔を超えたらキューブを作成する
		if (this.delta > this.span) {
			//経過時間を元に戻す
			this.delta = 0;
			//生成するキューブ数をランダムに決める
			//int型の引数のRandom.Rangeはmax値を含まないので+1している
			int n = Random.Range(1, maxBlockNum+1);

			//ブロックの生成
			for (int i = 0; i < n; i++) {
				GameObject go = Instantiate(cubePrefab) as GameObject;
				go.transform.position = new Vector2 (this.getPosX, this.offsetY + i * this.spaceY);
			}
			//次のキューブまでの生成時間を決める
			this.span = this.offsetX + this.spaceY * n;
		}
	}
}
