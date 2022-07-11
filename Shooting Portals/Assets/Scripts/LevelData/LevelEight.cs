using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEight : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {81.61f, -61.49f}, //Checkpoint 1 {81.61f, -61.49f}
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}

