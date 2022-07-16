using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the spawn positions for the player in Level 5.
public class LevelFive : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {294.1f, 0.55f}, //Checkpoint 1  {294.1f, 0.55f}
            {319.29f, 0.572919f}, //Checkpoint 2
            {345.9956f, 0.5729033f}, //Checkpoint 3
            {370.3756f, 0.5729201f}, //Checkpoint 4
            {397.47f, 0.58f}, //Checkpoint 5
            {417.396f, 5.574f}, //Checkpoint 6
            {448.23f, -2.425f}, //Checkpoint 7
            {474.1357f, -2.427094f}, //Checkpoint 8
            {500.1538f,  -2.423f}, //Checkpoint 9
            {526.6071f, 5.54f} //Checkpoint 10
        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}

