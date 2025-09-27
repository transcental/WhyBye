using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    [Serializable]
    public class LevelData
    {
        public string levelName;
        public int baseDifficulty;
        public GameObject levelPrefab;
        public int amount = 5;
    }

    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private LevelData[] levels;
        [SerializeField] private GameObject player;
        private int _currentLevelIndex = 0;
        private int _currentDifficulty = 0;
        private List<GameObject> _objectsInLevel;
        private int _radius = 10;
        
        private void Start()
        {
            _objectsInLevel = new List<GameObject>();
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            if (_currentLevelIndex >= levels.Length)
            {
                Debug.Log("All levels completed!");
                return;
            }

            var currentLevel = levels[_currentLevelIndex];
            _currentDifficulty += currentLevel.baseDifficulty;

            // Instantiate level prefabs in a circle around the player
            
            for (var i = 0; i < currentLevel.amount; i++)
            {
                var angle = i * Mathf.PI * 2 / currentLevel.amount;
                var position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * _radius;
                position += player.transform.position;
                var obj = Instantiate(currentLevel.levelPrefab, position, Quaternion.identity);
                _objectsInLevel.Add(obj);
            }
            
            Debug.Log($"Generated Level: {currentLevel.levelName} with Difficulty: {_currentDifficulty}");
        }
    }
}