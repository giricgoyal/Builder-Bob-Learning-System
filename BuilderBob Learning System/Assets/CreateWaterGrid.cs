using UnityEngine;
using System.Collections;

public class CreateWaterGrid : MonoBehaviour {
	public int xdim;
	public int ydim;
	// Use this for initialization
	void Start () {
		xdim = 50;
		ydim = 50;
		GameObject waterAll = GameObject.FindGameObjectWithTag("WaterAdv");
		for(int i = 0; i<xdim; i++){
			for(int j=0; j < ydim ; j++){
				GameObject waterTile = GameObject.FindGameObjectWithTag ("Tile");
				Vector3 localpos =new Vector3(0,0,0);
				float a = 0.0f;
				GameObject cloneTile = (GameObject)Instantiate(waterTile);
				//cloneTile.tag = "tile"+i.ToString()+j.ToString();
				cloneTile.transform.parent = waterAll.transform;
				//cloneTile.transform.position = localpos;
				Vector3 pos  = cloneTile.transform.position;
				pos.x = i*40;
				pos.z = j*40;
				pos.y = 0;
				cloneTile.transform.position = pos;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
