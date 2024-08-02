using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class RayInteractorHandler : MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    public XRInteractorLineVisual lineVisual;
    public TeleportationProvider teleportationProvider;
    private InputData inputData;

    private void Start()
    {
        inputData = GetComponent<InputData>();
    }

    void Update()
    {
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            if (triggerValue > 0.1f)
            {
                rayInteractor.gameObject.SetActive(true);
                lineVisual.enabled = true;
            }
            else
            {
                if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
                {
                    TeleportRequest request = new TeleportRequest()
                    {
                        destinationPosition = hit.point
                    };
                    teleportationProvider.QueueTeleportRequest(request);
                }
                rayInteractor.gameObject.SetActive(false);
                lineVisual.enabled = false;
            }
        }
    }
}
