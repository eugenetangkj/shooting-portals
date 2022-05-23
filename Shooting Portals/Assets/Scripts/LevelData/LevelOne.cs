using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour
{
    private static float[,] spawnPositions = new float[,]
        {
            {-9.542f, 2.519f}, //Checkpoint 1 {-9.542f, 2.519f} {47.72f, -6.435f}, 
            {16.52484f, 4.135397f}, //Checkpoint 2
            {39f, 5.491889f} //Checkpoint 3
        };

    public static float[,] getSpawnPositions()
    {
        return spawnPositions;
    }
}
