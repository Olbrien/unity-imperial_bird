using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager
{

    public static void SavePlayerInt(PlayerController playerController)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "//playerInt.sav", FileMode.Create);

        PlayerDataInt data = new PlayerDataInt(playerController);

        bf.Serialize(stream, data);
        stream.Close();
    }


    public static int[] LoadPlayerInt()
    {
        if (File.Exists(Application.persistentDataPath + "//playerInt.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "//playerInt.sav", FileMode.Open);

            PlayerDataInt data = bf.Deserialize(stream) as PlayerDataInt;
            stream.Close();
            return data.stats;
        }

        else
        {
            var standard = new int[7];
            standard[0] = 0; // playerController.levelOneDeaths;
            standard[1] = 0; // playerController.levelTwoDeaths;
            standard[2] = 0; // playerController.levelThreeDeaths;

            standard[3] = 0; // playerController.levelOneCompletedDeaths;
            standard[4] = 0; // playerController.levelTwoCompletedDeaths;
            standard[5] = 0; // playerController.levelThreeCompletedDeaths;

            standard[6] = 0; // playerController.adsWatched;

            //Debug.Log("No Loading File.");
            return standard;
        }
    }





    public static void SavePlayerFloat(PlayerController playerController)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "//playerFloat.sav", FileMode.Create);

        PlayerDataFloat data = new PlayerDataFloat(playerController);

        bf.Serialize(stream, data);
        stream.Close();
    }


    public static float[] LoadPlayerFloat()
    {
        if (File.Exists(Application.persistentDataPath + "//playerFloat.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "//playerFloat.sav", FileMode.Open);

            PlayerDataFloat data = bf.Deserialize(stream) as PlayerDataFloat;
            stream.Close();
            return data.stats;
        }

        else
        {
            var standard = new float[5];
            standard[0] = 0; // playerController.levelOneCompletePercentage;
            standard[1] = 0; // playerController.levelTwoCompletePercentage;
            standard[2] = 0; // playerController.levelThreeCompletePercentage;

            standard[3] = 1; // playerController.musicVolume;
            standard[4] = 1; // playerController.soundVolume;

            //Debug.Log("No Loading File.");
            return standard;
        }
    }




    public static void SavePlayerBool(PlayerController playerController)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "//playerBool.sav", FileMode.Create);

        PlayerDataBool data = new PlayerDataBool(playerController);

        bf.Serialize(stream, data);
        stream.Close();
    }


    public static bool[] LoadPlayerBool()
    {
        if (File.Exists(Application.persistentDataPath + "//playerBool.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "//playerBool.sav", FileMode.Open);

            PlayerDataBool data = bf.Deserialize(stream) as PlayerDataBool;
            stream.Close();
            return data.stats;
        }

        else
        {
            var standard = new bool[6];

            standard[0] = false; // playerController.levelOneComplete;
            standard[1] = false; // playerController.levelTwoComplete;
            standard[2] = false; // playerController.levelThreeComplete;        

            standard[3] = false; // playerController.healthFour;
            standard[4] = false; // playerController.healthFive;
            standard[5] = false; // playerController.healthSix;  


            //Debug.Log("No Loading File.");
            return standard;
        }
    }
}

[Serializable]
public class PlayerDataInt
{

    public int[] stats;

    public PlayerDataInt(PlayerController playerController)
    {
        stats = new int[7];
        stats[0] = playerController.levelOneDeaths;
        stats[1] = playerController.levelTwoDeaths;
        stats[2] = playerController.levelThreeDeaths;

        stats[3] = playerController.levelOneCompletedDeaths;
        stats[4] = playerController.levelTwoCompletedDeaths;
        stats[5] = playerController.levelThreeCompletedDeaths;

        stats[6] = playerController.adsWatched;
    }
}


[Serializable]
public class PlayerDataFloat
{

    public float[] stats;

    public PlayerDataFloat(PlayerController playerController)
    {
        stats = new float[5];
        stats[0] = playerController.levelOneCompletePercentage;
        stats[1] = playerController.levelTwoCompletePercentage;
        stats[2] = playerController.levelThreeCompletePercentage;

        stats[3] = playerController.musicVolume;
        stats[4] = playerController.soundVolume;
    }

}

[Serializable]
public class PlayerDataBool
{

    public bool[] stats;

    public PlayerDataBool(PlayerController playerController)
    {
        stats = new bool[6];
        stats[0] = playerController.levelOneComplete;
        stats[1] = playerController.levelTwoComplete;
        stats[2] = playerController.levelThreeComplete;

        stats[3] = playerController.healthFour;
        stats[4] = playerController.healthFive;
        stats[5] = playerController.healthSix;
    }

}
