using UnityEngine;

/// <summary>
/// Класс, отвечающий за передвижение кубика.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _forceValue = 300;

    private Rigidbody _rigidbody;
    private Vector3 _startPosition = Vector3.zero;
    private Vector3 _target;
    private Camera _camera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            _rigidbody.velocity = Vector3.zero;

            MoveTowardsSelectedPoint(hitInfo);
        }
    }

    private void MoveTowardsSelectedPoint(RaycastHit hitInfo)
    {
        var direction = (hitInfo.point - transform.position).normalized;

        _rigidbody.AddForce(new Vector3(direction.x, 0, direction.z) * _forceValue);
    }
}