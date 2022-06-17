using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFour : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-34.43053f, 0.61f}, //Checkpoint 1
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
