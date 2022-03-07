using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTag : XRSocketInteractor
{
    [SerializeField] string targetTag;

    [SerializeField] private XRSocketInteractor socketInteractor;
    private GameObject mag;

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.transform.CompareTag(targetTag);
        
    }

    private void EjectMag(){
    }

    public void StartEject(){
        StartCoroutine(ToggleSocket());
    }

    IEnumerator ToggleSocket(){
        mag = socketInteractor.GetOldestInteractableSelected().transform.gameObject;
        allowSelect = false;
        mag.GetComponent<Rigidbody>().AddForce(0,0,1 * 10, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        allowSelect = true;
    }
}
