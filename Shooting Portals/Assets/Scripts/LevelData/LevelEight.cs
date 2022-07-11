using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

