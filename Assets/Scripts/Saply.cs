using BramblyMead;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace GGJ
{
    public class Saply : Singleton<Saply>
    {
        [Header("Start Sequence")]
        [SerializeField] private UnityEvent[] sequence;

        [SerializeField] private GamePhase[] phases;

        [SerializeField] private SaplyLimb[] limbs;
        [SerializeField] private GamePhase startPhase;

        private int sequenceIndex;
        private GamePhase currentPhase;

        private bool startSequenceComplete;

        public void Progress()
        {
            if (startSequenceComplete)
            {
                Grow();
            }

            if (sequenceIndex >= sequence.Length)
            {
                startSequenceComplete = true;
                return;
            }

            AdvanceStartSequence();
        }

        private void Grow()
        {
            List<SaplyLimb> growingLimbs = GetLimbs();
            Debug.Log($"Selected {growingLimbs.Count} to grow.");
        }

        private void AdvanceStartSequence()
        {
            UnityEvent e = sequence[sequenceIndex];
            e?.Invoke();
            sequenceIndex++;
        }

        private List<SaplyLimb> GetLimbs()
        {
            int count = GetLimbCount();

            List<SaplyLimb> growing = new List<SaplyLimb>();

            while (growing.Count < count)
            {
                int randomIndex = Random.Range(0, count);

                SaplyLimb limb = limbs[randomIndex];

                if (!growing.Contains(limb))
                {
                    growing.Add(limb);
                }
            }

            return growing;
        }

        private int GetLimbCount()
        {
            int count = Random.Range(1, Mathf.Min(limbs.Length, currentPhase.Cap));
            Debug.Log("Limb count: " + count);
            return count;
        }

        private void Start() 
        {
            currentPhase = startPhase;
        }
    }
}
