using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;


public class HSScreenText : MonoBehaviour
{
   
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

            return (int)highScoreData.highScore;
        }
        else
        {
            return 0;
        }
    }

    
}
