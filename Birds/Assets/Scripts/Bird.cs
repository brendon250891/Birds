using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Vector2 _initialPosition;

    private Rigidbody2D _rigidBody;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _launchForceModifier = 500f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {        
        _initialPosition = _rigidBody.position;
        _rigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }

    private void OnMouseUp()
    {
        var currentPosition = _rigidBody.position;
        var direction = _initialPosition - currentPosition;
        direction.Normalize();

        _rigidBody.isKinematic = false;
        _rigidBody.AddForce(direction * _launchForceModifier);
        _spriteRenderer.color = Color.white;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }
}
