using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the spawn positions for the player in Level 8.
public class LevelEight : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {88.09f, -87.417f}, //Checkpoint 1 {88.09f, -87.417f}
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}

