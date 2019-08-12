using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class HSSurvivalLoad : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = LoadScoreToBeat().ToString();
    }


    public int LoadScoreToBeat()
    {
        if (File.Exists(Application.persistentDataPath + "/highscore.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highscore.dat", FileMode.Open);

            GameController.HighScoreData highScoreData = (GameController.HighScoreData)bf.Deserialize(file);

            file.Close();

            return (int)highScoreData.highScoreSurvival;
        }
        else
        {
            return 0;
        }
    }
}
