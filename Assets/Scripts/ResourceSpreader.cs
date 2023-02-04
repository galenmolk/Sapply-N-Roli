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

            public Vector2 topLeft;
            public Vector2 bottomRight;
        }

        public SpawnPhase[] spawnPhases;
        private SpawnPhase currentSpawnPhase;
        private int spawnPhaseIndex;

        [SerializeField] private Resource water;
        [SerializeField] private Resource sunlight;

        [SerializeField] private int amountPerResource;

        [SerializeField] private Vector2 topLeft;
        [SerializeField] private Vector2 bottomRight;

        private void Start() 
        {
            currentSpawnPhase = spawnPhases[0];

            StartCoroutine(ContinuouslySpawnResources());
        }

        private IEnumerator ContinuouslySpawnResources()
        {
            Spawn();
            yield return GetDelay();

            TryProgressPhase();
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

            for (int i = 0; i < amount ; i++)
            {
                Instantiate(water, GetPos(), Quaternion.identity, transform);
                Instantiate(sunlight, GetPos(), Quaternion.identity, transform);
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

        private Vector2 GetPos()
        {
            float x = UnityEngine.Random.Range(currentSpawnPhase.topLeft.x, currentSpawnPhase.bottomRight.x);
            float y = UnityEngine.Random.Range(currentSpawnPhase.topLeft.y, currentSpawnPhase.bottomRight.y);

            return new Vector2(x, y);
        }
    }

}
