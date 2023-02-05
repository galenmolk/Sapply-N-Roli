using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GGJ
{
    public class ResourceSpreader : MonoBehaviour
    {
        [Serializable]
        public class SpawnPhase
        {
            public int threshold;

            public float minDelay;
            public float maxDelay;

            public int minAmount;
            public int maxAmount;
        }

        public Collider2D boundsCollider;

        public SpawnPhase[] spawnPhases;

        public bool isSpawning = true;

        private SpawnPhase currentSpawnPhase;
        private int spawnPhaseIndex;

        [SerializeField] private Resource water;
        [SerializeField] private Resource sunlight;

        public Collider2D[] resourceAreas;

        public float saplyZoneSize = 3f;
        public Transform saplyGraphicTransform;
        public Collider2D saplyBounds;

        private void Start() 
        {
            currentSpawnPhase = spawnPhases[0];

            StartCoroutine(ContinuouslySpawnResources());
        }

        private IEnumerator ContinuouslySpawnResources()
        {
            while (isSpawning)
            {
                Spawn();
                yield return GetDelay();

                TryProgressPhase();
            }
        }

        private void TryProgressPhase()
        {
            if (spawnPhaseIndex == spawnPhases.Length - 1)
            {
                return;
            }

            SpawnPhase nextPhase = spawnPhases[spawnPhaseIndex + 1];

            if (Saply.Instance.sequenceIndex == nextPhase.threshold)
            {
                currentSpawnPhase = nextPhase;
                spawnPhaseIndex++;
            }
        }

        private void Spawn()
        {
            int amount = Random(currentSpawnPhase.minAmount, currentSpawnPhase.maxAmount);

            foreach (Collider2D coll in resourceAreas)
            {
                for (int i = 0; i < amount ; i++)
                {
                    Instantiate(water, GetPosWithinBounds(coll), Quaternion.identity, transform);
                    Instantiate(sunlight, GetPosWithinBounds(coll), Quaternion.identity, transform);
                }
            }
        }

        private int Random(int min, int max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        private float Random(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        private WaitForSeconds GetDelay()
        {
            float delay = Random(currentSpawnPhase.minDelay, currentSpawnPhase.maxDelay);
            return new WaitForSeconds(delay);
        }

        private Vector2 GetPosWithinBounds(Collider2D coll)
        {
            Bounds bounds = coll.bounds;
            // Vector3 point = saplyGraphicTransform.position;

            // while (saplyBounds.bounds.Contains(point))
            // {
            //     point = new Vector3(
            //         Random(bounds.min.x, bounds.max.x),
            //         Random(bounds.min.y, bounds.max.y), 0f
            //     );
            // }

            return new Vector2(Random(bounds.min.x, bounds.max.x), Random(bounds.min.y, bounds.max.y));
        }
    }
}
