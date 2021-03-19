using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class levelUp:Player //繼承Player
{
   private int level;
   private Playerstate loadData;

	void Start()
	{
		StreamReader file = new StreamReader (System.IO.Path.Combine(Application.streamingAssetsPath,"myState.json")); 
		string loadJson = file.ReadToEnd ();
		file.Close ();
		loadData = new Playerstate();
		loadData = JsonUtility.FromJson<Playerstate> (loadJson);
	}
	public void LevelUpbtn()
	{
	    Playerstate myState = new Playerstate ();
		level = loadData.level;
		level++;
		loadData.level = level;
		Debug.Log (loadData.level);
		string saveString = JsonUtility.ToJson (loadData); //將MyState轉換成Json格式的字串
		//Application.streamingAssetsPath檔案路徑
		StreamWriter file2=new StreamWriter(System.IO.Path.Combine(Application.streamingAssetsPath,"myState.json"));//將字串存到硬碟
		file2.Write (saveString);
		file2.Close ();
	}
}
