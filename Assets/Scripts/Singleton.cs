using UnityEngine;

namespace BramblyMead
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        private static bool isQuitting;
        private static readonly object LockObject = new();

        [SerializeField] private bool persistent = false;

        public static T Instance
        {
            get
            {
                if (isQuitting)
                {
                    Debug.LogWarning($"[{typeof(T)}] Instance will not be returned because the application is quitting.");
                    return null;
                }
                lock (LockObject)
                {
                    if (instance == null)
                        FindAndSetInstance();

                    return instance;
                }
            }
        }

        /// <summary>
        /// Meant to be overridden in the child classes as an init.
        /// </summary>
        protected virtual void OnAwake() { }

        protected virtual void OnApplicationQuit()
        {
            isQuitting = true;
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Debug.LogWarning($"[{typeof(T)}] Instance was already set and is not this. Destroying this component on {gameObject.name}.");
                DestroySelf();
            }
            else
            {
                FindAndSetInstance();

                if (persistent)
                    DontDestroyOnLoad(gameObject);

                OnAwake();
            }
        }

        private void DestroySelf()
        {
            if (Application.isEditor)
                DestroyImmediate(this);
            else
                Destroy(this);
        }

        private static void FindAndSetInstance()
        {
            if (instance != null)
                return;

            var allInstances = FindObjectsOfType<T>();
            var instanceCount = allInstances.Length;
            
            switch (instanceCount)
            {
                case <= 0:
                    Debug.LogWarning($"[{typeof(T)}] There were no instances of type {0} in the scene.");
                    return;
                case > 1:
                {
                    Debug.LogWarning($"[{typeof(T)}] There should never be more than one Singleton of type {typeof(T)} in the scene, but {instanceCount} were found. The first " + "instance found will be used and all others will be destroyed.");
                    for (var i = 1; i < instanceCount; i++)
                        Destroy(allInstances[i]);
                    break;
                }
            }

            lock (LockObject)
                instance = allInstances[0];
        }
    }
}
