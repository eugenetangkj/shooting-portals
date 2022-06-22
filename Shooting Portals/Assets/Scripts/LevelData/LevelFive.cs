using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFive : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {474.1357f, -2.427094f}, //Checkpoint 1  {294.1f, 0.55f}
            {319.29f, 0.572919f}, //Checkpoint 2
            {345.9956f, 0.5729033f}, //Checkpoint 3
            {370.3756f, 0.5729201f}, //Checkpoint 4
            {397.47f, 0.58f}, //Checkpoint 5
            {417.396f, 5.574f}, //Checkpoint 6
            {448.23f, -2.425f}, //Checkpoint 7
            {474.1357f, -2.427094f} //Checkpoint 8
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}

