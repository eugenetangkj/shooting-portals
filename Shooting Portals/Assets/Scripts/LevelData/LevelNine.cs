using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNine : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {16.08846f, 2.572913f}, //Checkpoint 1  {-9.93f, 0.572883f}
            {16.08846f, 2.572913f} //Checkpoint 2
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
