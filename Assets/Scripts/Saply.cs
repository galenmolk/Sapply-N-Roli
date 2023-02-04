using BramblyMead;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace GGJ
{
    public class Saply : Singleton<Saply>
    {
        private const string HAPPY_TRIGGER = "Happy";

        [Header("Start Sequence")]
        [SerializeField] private UnityEvent[] sequence;

        [SerializeField] private GamePhase[] phases;

        [SerializeField] private SaplyLimb[] limbs;
        [SerializeField] private GamePhase startPhase;
        [SerializeField] private Animator animator;

        private int sequenceIndex;
        private GamePhase currentPhase;

        private bool startSequenceComplete;

        public void Progress()
        {
            if (startSequenceComplete)
            {
                Grow();
            }
            else
            {
                AdvanceStartSequence();
            }
        }

        private void Grow()
        {
            animator.SetTrigger(HAPPY_TRIGGER);
            List<SaplyLimb> growingLimbs = GetLimbs();
            Debug.Log($"Selected {growingLimbs.Count} to grow.");
        }

        private void AdvanceStartSequence()
        {
            UnityEvent e = sequence[sequenceIndex];
            e?.Invoke();
            sequenceIndex++;

            if (sequenceIndex >= sequence.Length)
            {
                startSequenceComplete = true;
            }
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
