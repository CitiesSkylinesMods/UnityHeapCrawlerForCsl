using ICities;
using UnityEngine;
using UnityHeapCrawler;

namespace UnityHeapDumpForCsl
{
    public class Mod : LoadingExtensionBase, IUserMod
    {
        private GameObject? _gameObject;
        private HeapSnapshotCollector? _heapSnapshotCollector;

        public string Name => "UnityHeapDumpForCsl";
        public string Description => "Creates a heap dump on ctrl + h press.";

        public void OnEnabled()
        {
            InstallMod();
        }

        public void OnDisabled()
        {
            UninstallMod();
        }

        private void InstallMod()
        {
            _gameObject = new GameObject(Name);
            var keyTriggerBehaviour = _gameObject.AddComponent<KeyTriggerBehavior>();
            GameObject.DontDestroyOnLoad(_gameObject);

            _heapSnapshotCollector = new HeapSnapshotCollector
            {
                DifferentialMode = true
            };

            keyTriggerBehaviour.KeysPressed += () => _heapSnapshotCollector.Start();
        }

        private void UninstallMod()
        {
            GameObject.Destroy(_gameObject);

            _heapSnapshotCollector = null;
        }
    }
}
