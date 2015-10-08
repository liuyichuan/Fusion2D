using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadScore {

	public static List<int> savedScores = new List<int>();

	//it's static so we can call it from anywhere
	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/score.sc"); //you can call it anything you want
		bf.Serialize(file, SaveLoadScore.savedScores);

		file.Close();
	}	
	
	public static void Load() {
		if (File.Exists (Application.persistentDataPath + "/score.sc")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/score.sc", FileMode.Open);
			
			SaveLoadScore.savedScores = (List<int>)bf.Deserialize (file);
			file.Close ();
		}
	}

	public static void AddSort (int a) {
		//loads it in case it haven't loaded once
		//then add and sort it to highest to lowest by Sort and Reverse
		SaveLoadScore.Load();
		SaveLoadScore.savedScores.Add(a);
		SaveLoadScore.savedScores.Sort();
		SaveLoadScore.savedScores.Reverse();

		//if there's more than 10 scores, deletes the 11th score
		//assuming there's no way to get 12 scores at this point
		if (SaveLoadScore.savedScores.Count > 10)
			SaveLoadScore.savedScores.RemoveAt (10);

		//then saves
		SaveLoadScore.Save ();
	}
}