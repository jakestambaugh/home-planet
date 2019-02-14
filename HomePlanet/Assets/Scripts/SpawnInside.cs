using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // array.Sum()

public class SpawnInside : MonoBehaviour
{
    // Possible items that can be spawned by this script.
    [SerializeField] GameObject[] spawnableObjects = null;
    [SerializeField] int[] spawnableObjectWeights = null;
    private CircleCollider2D[] justSpawned = null;

    // Max number of objects to spawn
    [SerializeField] int maxNumber = 0;
    [SerializeField] bool allowCollision = false;

    // Start is called before the first frame update
    void Start()
    {
        // Don't know if there is a way to sync them in the editor
        if(spawnableObjectWeights.Length != spawnableObjects.Length)
            throw new System.Exception("Parallel array lengths are mismatched!");
        justSpawned = new CircleCollider2D[maxNumber];
        // Get half of parent size so -x to x and -y to y are within parent
        (float x, float y) = GetParentExtents();

        for(int i = 0; i < maxNumber; i++)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-x,x),Random.Range(-y,y),0);
            spawnLocation = this.transform.TransformPoint(spawnLocation);
            GameObject spawnItem = spawnableObjects[GetWeightedRandomIndex()];

            // If you do not allow collisions and do not give enough space for objects,
            // this can loop forever
            if(allowCollision == false)
            {
                bool intersects = false;
                // Use spawnItem for it's CircleCollider2D because it's already there
                spawnItem.transform.position = spawnLocation;
                CircleCollider2D newCollider = spawnItem.GetComponent<CircleCollider2D>();
                // Check if about to be spawned item will collide with any previously made one
                for(int j = 0; j < i; j++)
                {
                    CircleCollider2D c = justSpawned[j];
                    if(Intersects(c,newCollider))
                    {
                        intersects = true;
                        break;
                    }
                }
                // Restart loop before we actually instantiate the object and try again
                if(intersects)
                {
                    i--;
                    continue;
                }
            }

            var newObj = Instantiate(spawnItem, this.transform);
            newObj.transform.position = spawnLocation;
            justSpawned[i] = newObj.GetComponent<CircleCollider2D>();
        }

        // Free up memory
        justSpawned = null;
    }

    (float x, float y) GetParentExtents()
    {
        Vector3 bounds = this.gameObject.GetComponent<BoxCollider>().size / 2;
        return (bounds.x, bounds.y);
    }

    int GetWeightedRandomIndex()
    {
        // Get random number from 0 to total of weights array
        int r = Random.Range(0, spawnableObjectWeights.Sum()+1);
        // Subtract weighted values from r until zero
        int i = 0;
        while (r > spawnableObjectWeights[i])
            r -= spawnableObjectWeights[i++];

        return i;
    }

    // Normally you could use Physics2D.OverlapCircle(), but colliders don't work until after update has been called
    // atleast once. So roll our own collision detection because Unity is balls.
    // This should tell if two circle colliders intersect or if one is perfectly contained within another.
    // Use CircleCollider2D's as arguments because then I can assume a radius value
    // NOTE: Due to this, two prefabs with this script will not be able to check collisions.
    bool Intersects(CircleCollider2D a, CircleCollider2D b)
    {
        Vector2 delta = a.transform.position - b.transform.position;
        // Square X and Y components
        delta.x *= delta.x;
        delta.y *= delta.y;
        // Square radius
        float radiusTotal = a.radius + b.radius;
        radiusTotal *= radiusTotal;

        return (delta.x + delta.y) <= radiusTotal;
    }
}
