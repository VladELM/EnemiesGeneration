using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;
    
    private bool _isAllowMove;

    private void Awake()
    {
        _isAllowMove = false;
    }

    private void Update()
    {
        if (_isAllowMove)
        {
            transform.LookAt(_direction);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }

    public void Initialize(Vector3 startPosition, Vector3 direction)
    {
        transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z);
        _direction = direction;
        _isAllowMove = true;
    }
}
