using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabVelocityTracked : XRGrabInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        SetParentToXRRig();
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        SetParentToWorld();
        base.OnSelectExited(args);
    }

    public void SetParentToXRRig()
    {
        // Get the first interactor in the list of interactorsSelecting
        if (interactorsSelecting.Count > 0)
        {
            Transform interactorTransform = interactorsSelecting[0].transform;
            transform.SetParent(interactorTransform);
        }
    }

    public void SetParentToWorld()
    {
        transform.SetParent(null);
    }
}
