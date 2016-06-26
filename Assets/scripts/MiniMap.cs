using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour
{
    public Transform Target;

    //zorgt dat de minimap camera de positite van de target volgt.

    public Vector2 TransformPosition(Vector3 position)
    {
        Vector3 offset = position - Target.position;
        Vector2 newPosition = new Vector2(offset.x, offset.z    );
        return newPosition;
    }
}
