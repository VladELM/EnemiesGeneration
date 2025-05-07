using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private bool _isAllowMove;

    private void Awake()
    {
        _isAllowMove = false;
    }

    private void Update()
    {
        if (_isAllowMove)
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void Initialize(Vector3 startPosition, int rotationAngle)
    {
        transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z);
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotationAngle, transform.rotation.z);
        _isAllowMove = true;
    }
}
