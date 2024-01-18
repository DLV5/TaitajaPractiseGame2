using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(DrawWithMouse))]  
public class AnimalController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private DrawWithMouse _drawWithMouse;
    private Vector2 _initialPosition;
    private int _attempsToDraw;  //This variable was used to limit drawing attempts to one
    private bool _allowedToMove;

    //Variables used for animal's movement
    private Vector3[] _amountOfVertices;
    private int _moveIndex;

    private void Awake()
    {
        _initialPosition = transform.position;
        _drawWithMouse = GetComponent<DrawWithMouse>();
        _attempsToDraw = 0;
    }
    private void OnMouseDown()
    {
        if (_attempsToDraw != 0)
            return;
        _drawWithMouse.StartLine(_initialPosition);
        Debug.Log(_attempsToDraw);
    }
    private void OnMouseDrag()
    {
        if (_attempsToDraw != 0)
            return;
        _drawWithMouse.UpdateLine();
    }
    private void OnMouseUp()
    {
        _attempsToDraw++;
        _amountOfVertices = new Vector3[_drawWithMouse.LineRenderer.positionCount];
        _drawWithMouse.LineRenderer.GetPositions(_amountOfVertices);
        _allowedToMove = true;
    }
    private void Update()
    {
        if (!_allowedToMove)
            return;
        //Animal moves
        Vector2 nextPosition = _amountOfVertices[_moveIndex];
        transform.position = Vector2.MoveTowards(transform.position, nextPosition, _speed * Time.deltaTime);
        float distanceUntilDestination = Vector2.Distance(nextPosition, transform.position);

        //Animal rotates
        Vector2 direction = nextPosition - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.normalized.y, direction.normalized.x);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg + 90f), _speed);

        if(distanceUntilDestination <= 0.07f)
        {
            _moveIndex++;
        }
        if(_moveIndex > _amountOfVertices.Length - 1)
        {
            _allowedToMove=false;
        }
    }
}
