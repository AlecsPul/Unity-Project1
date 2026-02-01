using UnityEngine;
public class CameraFollow2D : MonoBehaviour
{
   public Transform target;
   public Vector3 offset = new Vector3(0, 2, -10);
   public float smoothTime = 0.25f;
   private Vector3 velocity = Vector3.zero;
   void LateUpdate()
   {
       Vector3 targetPosition = target.position + offset;
       transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
   }
}