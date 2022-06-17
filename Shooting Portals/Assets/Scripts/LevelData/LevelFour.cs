using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFour : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {172.6218f, -24.42709f}, //Checkpoint 1 {96.49f, -24.45f}
            {121.1546f, -24.45f}, //Checkpoint 2
            {153.059f, -24.413f}, //Checkpoint 3
            {172.6218f, -24.42709f} //Checkpoint 4
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
