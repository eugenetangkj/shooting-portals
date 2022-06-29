using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNine : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-9.93f, 0.572883f}, //Checkpoint 1  {-9.93f, 0.572883f}
            {16.08846f, 2.572913f}, //Checkpoint 2
            {41.4574f, -13.42709f}
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
