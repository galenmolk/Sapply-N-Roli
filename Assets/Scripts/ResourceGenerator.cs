using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class ResourceGenerator : MonoBehaviour
    {
        [SerializeField] private Resource resourcePrefab;

        [SerializeField] private float delay;

        private Resource resource;

        private IEnumerator Start() 
        {
            while (true)
            {
                if (resource == null)
                {
                    resource = Instantiate(resourcePrefab, transform.position, Quaternion.identity, transform);
                }

                yield return new WaitForSeconds(delay);
            }
        }
    }
}
