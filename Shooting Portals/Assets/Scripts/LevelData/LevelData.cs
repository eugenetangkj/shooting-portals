using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is an abstract class whose child classes would contain the coordinates for player spawn positions.
public abstract class LevelData : MonoBehaviour
{
    public abstract float[,] getSpawnPositions();

}
