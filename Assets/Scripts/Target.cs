using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector3 GetRandomDirection(float yPosition)
    {
        float x = Random.Range(-10f, 10f);
        float y = yPosition;
        float z = Random.Range(-10f, 10f);

        return new Vector3(x, y, z);
    }
}
