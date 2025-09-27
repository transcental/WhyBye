using UnityEngine;

namespace Interactables.Interfaces
{
    public interface IInteractable
    {
        void Interact(GameObject interactor);
        void Sacrifice(GameObject sacrificer);
    }
}