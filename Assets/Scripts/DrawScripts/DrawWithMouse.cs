using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    [SerializeField] private float _minDistance = 0.1f;

    private LineRenderer _lineRenderer;
    private Vector3 _previousPosition;
    private bool _isDrawing;
 
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _previousPosition = transform.position;
        _isDrawing = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDrawing = !_isDrawing;
        }
        if(_isDrawing)
        {
            Draw();
        }
    }
    private void Draw()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 0f;

        if (Vector3.Distance(currentPosition, _previousPosition) > _minDistance)
        {
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, currentPosition);
            _previousPosition = currentPosition;
        }
    }
}
