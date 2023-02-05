using BramblyMead;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using DG;
using DG.Tweening;

namespace GGJ
{
    public class Saply : Singleton<Saply>
    {
        private const string HAPPY_TRIGGER = "Happy";

        [Header("Start Sequence")]
        [SerializeField] private UnityEvent[] sequence;

        [SerializeField] private GamePhase[] phases;

        [SerializeField] private SaplyLimb[] limbs;
        [SerializeField] private SaplyLimb sproutLimb;
        [SerializeField] private Animator animator;

        public Vector3 addScale;
        public float scaleDuration;

        public int sequenceIndex;
        public int winIndex = 19;
        private GamePhase currentPhase;
        private int phaseIndex;

        private bool startSequenceComplete;

        public void Progress()
        {
            SoundEffects.Instance.Grow();
            TryProgressPhase();

            if (startSequenceComplete)
            {
                Grow();
            }
            else
            {
                AdvanceStartSequence();
            }
        }

        private void TryProgressPhase()
        {
            if (phaseIndex == phases.Length - 1)
            {
                return;
            }

            GamePhase nextPhase = phases[phaseIndex + 1];

            if (sequenceIndex == nextPhase.Threshold)
            {
                currentPhase = nextPhase;
                phaseIndex++;
            }
        }

        private void Grow()
        {
            sequenceIndex++;

            animator.SetTrigger(HAPPY_TRIGGER);
            List<SaplyLimb> growingLimbs = GetLimbs();
            List<SaplyLimb> requestingLimbs = GetNewRequestLimbs(growingLimbs);

            foreach (SaplyLimb limb in growingLimbs)
            {
                if (!limb.hasRequest && requestingLimbs.Contains(limb))
                {
                    RequestData request = GetRandomRequest();
                    limb.Grow(request);
                }
                else
                {
                    limb.Grow();
                }
            }

            sproutLimb.Grow();
            transform.DOScale(transform.localScale + addScale, scaleDuration);

            if (sequenceIndex >= winIndex)
            {
                EndGame.Instance.EndTheGame();
            }
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

        private RequestData GetRandomRequest()
        {
            int length = currentPhase.possibleRequests.Length;
            return currentPhase.possibleRequests[Random.Range(0, length)];
        }

        private List<SaplyLimb> GetLimbs()
        {
            int count = GetLimbCount();

            List<SaplyLimb> growing = new List<SaplyLimb>();

            while (growing.Count < count)
            {
                int randomIndex = Random.Range(0, limbs.Length);

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
            int count = Random.Range(1, currentPhase.Cap + 1);
            return count;
        }

        private List<SaplyLimb> GetNewRequestLimbs(List<SaplyLimb> growing)
        {
            int limbCount = growing.Count;
            int requestingCount = GetRequestingCount(limbCount);

            List<SaplyLimb> requesting = new List<SaplyLimb>();

            while (requesting.Count < requestingCount)
            {
                int randomIndex = Random.Range(0, limbCount);

                SaplyLimb limb = growing[randomIndex];

                if (!requesting.Contains(limb))
                {
                    requesting.Add(limb);
                }
            }

            return requesting;
        }

        private int GetRequestingCount(int max)
        {
            return Random.Range(1, max);
        }

        private void Start() 
        {
            currentPhase = phases[0];
        }
    }
}
