using UnityEngine;

namespace Interactables.Interfaces
{
    public interface IInteractable
    {
        void Setup(bool lucky, bool unlucky);
        void Interact(GameObject interactor);
        void Sacrifice(GameObject sacrificer);
    }
}