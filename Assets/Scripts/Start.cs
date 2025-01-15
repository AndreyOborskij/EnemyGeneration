using UnityEngine;

public class Start : MonoBehaviour
{
    private Vector3 _portalPosition;

    private void Awake()
    {
        _portalPosition = transform.position;
    }

    public Vector3 PortalPosition => _portalPosition;
}
