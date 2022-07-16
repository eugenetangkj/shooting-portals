using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class contains the spawn positions for the player in the Start Screen.
public class StartScreen : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-2.494f, 7.452f}, //Checkpoint 1
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}