using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThree : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {41.19f, 7.56f}, //Checkpoint 1  {-9.93f, 0.572883f}
            {16.13479f, 0.5729172f}, //Checkpoint 2
            {41.19f, 7.56f}, //Checkpoint 3
            {30.295f, -5.43f}, //Checkpoint 4
            {56.07f, -11.45832f} //Checkpoint 5
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
