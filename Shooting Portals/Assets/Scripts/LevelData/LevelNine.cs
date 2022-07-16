using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the spawn positions for the player in Level 9.
public class LevelNine : LevelData
{
    private float[,] spawnPositions = new float[,]
        {
            {-9.93f, 0.572883f}, //Checkpoint 1  {-9.93f, 0.572883f}
            {16.08846f, 2.572913f}, //Checkpoint 2
            {41.4574f, -13.42709f}, //Checkpoint 3
            {67.17723f, -9.4271f}, //Checkpoint 4
            {92.56f, 3.58f}, //Checkpoint 5
            {118.69f, 3.572922f}, //Checkpoint 6
            {144.2f, 3.58f}, //Checkpoint 7
            {169.8103f, 3.572895f}, //Checkpoint 8
            {170.66f, 3.58f} //Checkpoint 9

        };

    public override float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
