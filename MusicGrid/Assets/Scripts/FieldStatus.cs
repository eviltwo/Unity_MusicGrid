using UnityEngine;
using System.Collections;

public class FieldStatus : MonoBehaviour {

	public Vector2 FieldScale = new Vector2 (7,7);
	public int GridValue = 32;

	int[,] posr = new int[,]{{0,1,1},{1,1,0},{0,0,1},{0,0,0}};	// 位置用　右から反時計回り
	int[,] arw = new int[,]{{-1,0},{0,-1},{1,0},{0,1}};			// 内側方向用　右から反時計回り

	public SpawnData getSpawnData(){
		SpawnData data = new SpawnData ();
		int ranarw = Random.Range (0,4);
		int rantmg = Random.Range (0, GridValue);
		Vector2 pos = Vector2.zero;
		pos [posr [ranarw, 0]] = FieldScale [posr [ranarw, 0]] * posr [ranarw, 1];
		pos [posr [ranarw, 2]] = FieldScale [posr [ranarw, 2]] * ((float)rantmg / (float)GridValue);
		data.Position = pos;
		Vector2 vec = Vector2.zero;
		vec.x = arw [ranarw, 0];
		vec.y = arw [ranarw, 1];
		data.FwdVec = vec;
		return data;
	}
}
