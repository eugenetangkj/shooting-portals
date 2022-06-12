using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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