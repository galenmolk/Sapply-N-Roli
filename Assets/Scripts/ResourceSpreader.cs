using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpreader : MonoBehaviour
{
    [SerializeField] private Resource water;
    [SerializeField] private Resource sunlight;

    [SerializeField] private int amountPerResource;

    [SerializeField] private Vector2 topLeft;
    [SerializeField] private Vector2 bottomRight;

    private void Start() 
    {
        int max = amountPerResource * 2;

        for (int i = 0; i < max ; i++)
        {
            Instantiate(water, GetPos(), Quaternion.identity, transform);
            Instantiate(sunlight, GetPos(), Quaternion.identity, transform);
        }
    }

    private Vector2 GetPos()
    {
        float x = Random.Range(topLeft.x, bottomRight.x);
        float y = Random.Range(topLeft.y, bottomRight.y);

        return new Vector2(x, y);
    }
}
