using System.Linq;
using DefaultNamespace;
using Interactables.Interfaces;
using UnityEngine;

namespace Interactables
{
    public class Sounder : MonoBehaviour, IInteractable
    {
        private AudioClip _clip;
        private string _name;
        
        private bool _lucky;
        private bool _unlucky;
        
        private readonly string _audioFolder = "Audio/Sounders/";
        
        private LevelGenerator _levelGenerator;
        
        private void OnAwake()
        {
            _levelGenerator = FindAnyObjectByType<LevelGenerator>();
        }

        public void Setup(bool lucky, bool unlucky)
        {
            while (true)
            {
                _lucky = lucky;
                _unlucky = unlucky;
                if (lucky)
                {
                    _clip = Resources.Load<AudioClip>(_audioFolder + "lucky.wav");
                    _levelGenerator.levelSetupData.Add(_clip.name);
                }
                else if (unlucky)
                {
                    _clip = Resources.Load<AudioClip>(_audioFolder + "unlucky.wav");
                    _levelGenerator.levelSetupData.Add(_clip.name);
                }
                else
                {
                    var clipsInFolder = Resources.LoadAll<AudioClip>(_audioFolder);
                    if (clipsInFolder.Length == 0)
                    {
                        Debug.LogError($"No audio clips found in folder: {_audioFolder}");
                        return;
                    }

                    var randomIndex = Random.Range(0, clipsInFolder.Length);
                    _clip = clipsInFolder[randomIndex];
                    if (_clip && _levelGenerator.levelSetupData.All(s => s != _clip.name) && _clip.name != "lucky" && _clip.name != "unlucky")
                    {
                        _levelGenerator.levelSetupData.Add(_clip.name);
                        Debug.Log($"Assigned clip: {_clip.name} to {transform.name}");
                    }
                    else
                    {
                        Debug.LogWarning($"Clip {_clip.name} already used or not assigned properly.");
                        continue;
                    }

                    break;
                }
            }
        }

        public Sounder(AudioClip clip)
        {
            _clip = clip;
        }

        public void Interact(GameObject interactor)
        {
            AudioManager.Instance.PlaySound(_clip);
            Debug.Log($"Playing sound: {_clip.name} from {transform.name}");
        }

        public void Sacrifice(GameObject sacrificer)
        {
            Debug.Log($"Sacrificed {transform.name}");
        }
    }
}