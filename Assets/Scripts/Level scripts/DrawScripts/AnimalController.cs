using System;
using UnityEngine;

/// <summary>
/// This class controls drawings and moving of an animal, also checks for the right food for animal
/// </summary>
[RequireComponent(typeof(DrawWithMouse))] 
public class AnimalController : MonoBehaviour
{
    public event Action OnAnimalGotRightFood;
    public event Action OnAnimalGotRightWrong;

    [Header("Check for food settings")]
    [SerializeField] private FoodType _prefferedFood;

    [Tooltip("Radius of a circle at the end of the path")]
    [SerializeField] private float _checkCircleRadius;
    [SerializeField] private LayerMask _layerMask;


    [Header("Move along line settings")]
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
            StopMoving();
            CheckForFood();
        }
    }

    public void StartMoving()
    {
        try
        {
            if (_amountOfVertices.Length == 0)
            {
                return;
            }

            if (_moveIndex > _amountOfVertices.Length - 1)
            {
                return;
            }

            _allowedToMove = true;
        } catch
        {
            Console.WriteLine("Draw a path firstly");
        }
    }

    public void StopMoving() => _allowedToMove = false;

    private void CheckForFood()
    {
        var food = Physics2D.OverlapCircle(gameObject.transform.position, _checkCircleRadius, _layerMask);

        if(food == null)
        {
            GameManager.Instance.OnExeptionIncome($"{gameObject.name}  didn't get a food");
            return;
        }

        Food foodScript = food.GetComponent<Food>();

        if(foodScript != null)
        {
            if(foodScript.GetFoodType() == _prefferedFood)
            {
                GameManager.Instance.OnAnimalAteRightFood();
            } else
            {
                GameManager.Instance.OnExeptionIncome($"{gameObject.name}  don't like {foodScript.name}");
            }
        }
    }
}
