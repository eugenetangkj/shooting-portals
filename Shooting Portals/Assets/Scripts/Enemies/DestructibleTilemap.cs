using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTilemap : MonoBehaviour
{
    private Tilemap destructableTilemap;


    private void Start()
    {
        destructableTilemap = this.GetComponent<Tilemap>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Stomper"))
        {
            Debug.Log("REACHED!");
            Vector3 stomperHitPosition = Vector3.zero;
            //Get position of hit
            foreach(ContactPoint2D hit in collision.contacts)
            {
                stomperHitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                stomperHitPosition.y = hit.point.y - 0.01f * hit.normal.y;
            }
            destructableTilemap.SetTile(destructableTilemap.WorldToCell(stomperHitPosition), null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
