using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        gameObject.transform.Translate(1, 1, 1);
        gameObject.transform.position = Vector3.down;
        gameObject.transform.position = new Vector3(1, 1, 1);
        transform.position.Set(1, 1, 1);
    }
}
