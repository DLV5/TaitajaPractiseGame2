using UnityEngine;
/// <summary>
/// Used for drawing Line using LineRenderer 
/// </summary>
public class DrawWithMouse : MonoBehaviour
{
    [SerializeField] private float _minDistance = 0.1f;
    public LineRenderer LineRenderer { get; private set; }
    private Vector3 _previousPosition;
    private bool _isDrawing;
 
    public void StartLine(Vector2 initialPosition)
    {
        LineRenderer = GetComponent<LineRenderer>();
        _previousPosition = initialPosition;
        _isDrawing = false;
    }
    public void UpdateLine()
    {
         DrawLine();
    }
    private void DrawLine()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 0f;

        if (Vector3.Distance(currentPosition, _previousPosition) > _minDistance)
        {
            LineRenderer.positionCount++;
            LineRenderer.SetPosition(LineRenderer.positionCount - 1, currentPosition);
            _previousPosition = currentPosition;
        }
    }
}
