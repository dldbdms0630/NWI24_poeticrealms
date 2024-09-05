using UnityEngine;

public class ObjectConverter : MonoBehaviour
{
    public GameObject originalObject; // The object to be converted
    public GameObject targetObject; // The prefab of the object to convert into
    public bool destroyOriginal = true; // Optional: set a flag to destroy the original object

    public void Convert()
    {
        if (originalObject != null && targetObject != null)
        {
            targetObject.SetActive(true);
            
            // Store the original object's position, rotation, velocity, and angular velocity
            Vector3 position = originalObject.transform.position;
            Quaternion rotation = originalObject.transform.rotation;

            Rigidbody originalRb = originalObject.GetComponent<Rigidbody>();
            Vector3 velocity = Vector3.zero;
            Vector3 angularVelocity = Vector3.zero;

            if (originalRb != null)
            {
                velocity = originalRb.velocity;
                angularVelocity = originalRb.angularVelocity;
            }

            targetObject.transform.position = position;
            targetObject.transform.rotation = rotation;

            // Instantiate the target object at the original object's position and rotation
            //GameObject newObject = Instantiate(targetObjectPrefab, position, rotation);

            // If the new object has a Rigidbody, apply the stored velocity and angular velocity
            Rigidbody newRb = targetObject.GetComponent<Rigidbody>();
            if (newRb != null)
            {
                newRb.velocity = velocity;
                newRb.angularVelocity = angularVelocity;
            }

            // If required, destroy the original object
            if (destroyOriginal)
            {
                Destroy(originalObject);
                //Destroy(targetObjectPrefab);
                //targetObject.SetActive(false);
                originalObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("Original object or target object prefab is not set!");
        }
    }
}