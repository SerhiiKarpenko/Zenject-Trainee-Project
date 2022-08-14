using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerController : MonoBehaviour, IMoveable
{
    [SerializeField] private float _speed = 1f;
    private Camera _camera;
    private Vector3 _positionOfMouseClick = Vector3.zero;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        _camera = Camera.main;
        _positionOfMouseClick = transform.position;
        _playerHealth.OnPlayerDeath += SetCameraParentOnNullOnPlayerDeath;
    }

    private void Update()
    {
        GetPositionOfMouseClick();
        Move();
    }

    public void Move()
    { 
        float dis = Vector3.Distance(gameObject.transform.position, _positionOfMouseClick);
        if (dis == 0) return;
        _positionOfMouseClick.y = transform.position.y;
        Vector3 moveDirection = (_positionOfMouseClick - gameObject.transform.position).normalized;
        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }

    private void GetPositionOfMouseClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray rayFromMouse = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(rayFromMouse, out raycastHit))
            {
                _positionOfMouseClick = raycastHit.point;

            }
        }
    }

    private void SetCameraParentOnNullOnPlayerDeath()
    {
        _camera.transform.parent = null;
        _playerHealth.OnPlayerDeath -= SetCameraParentOnNullOnPlayerDeath;
    }
}
