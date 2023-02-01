using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class test : MonoBehaviour
{
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        Destroy((args.interactableObject.colliders[0].gameObject));
    }
}