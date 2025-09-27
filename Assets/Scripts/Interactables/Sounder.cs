using Interactables.Interfaces;
using UnityEngine;

namespace Interactables
{
    public class Sounder : MonoBehaviour, IInteractable
    {
        private readonly AudioClip _clip;
        private string _name;

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