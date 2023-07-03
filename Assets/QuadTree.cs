using System.Collections.Generic;
using UnityEngine;

public class QuadTree
{

    private Rect _area = new Rect(0, 0, 0, 0);
    private int _capacity = 0;
    private List<Vector2> _points = new List<Vector2>();

    private QuadTree _northWest = null;
    private QuadTree _northEast = null;
    private QuadTree _southWest = null;
    private QuadTree _southEast = null;
    private bool _divided = false;
    public QuadTree(Rect area, int capacity)
    {
        _area = area;
        _capacity = capacity;
    }

    private void subdivide()
    {
        float x = _area.x;
        float y = _area.y;
        float w = _area.width;
        float h = _area.height;
        Rect ne = new Rect(x + w / 2, y + h / 2, w / 2, h / 2);
        _northEast = new QuadTree(ne, _capacity);
        Rect nw = new Rect(x, y + h / 2, w / 2, h / 2);
        _northWest = new QuadTree(nw, _capacity);
        Rect se = new Rect(x + w / 2, y, w / 2, h / 2);
        _southEast = new QuadTree(se, _capacity);
        Rect sw = new Rect(x, y, w / 2, h / 2);
        _southWest = new QuadTree(sw, _capacity);

        _divided = true;

        foreach (Vector2 point in _points)
        {
            _northEast.insert(point);
            _northWest.insert(point);
            _southEast.insert(point);
            _southWest.insert(point);
        }
        _points.Clear();
    }

    public void insert(Vector2 point)
    {
        if (!_area.Contains(point))
            return;
        if (_points.Count < _capacity && !_divided) {
            _points.Add(point);
            return;
        }
        if (!_divided) {
            subdivide();
            _divided = true;
        }
        _northEast.insert(point);
        _northWest.insert(point);
        _southEast.insert(point);
        _southWest.insert(point);
    }

    public void draw()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_area.center, _area.size);
        foreach (Vector2 point in _points)
        {
            Gizmos.DrawSphere(point, 0.05f);
        }
        if (_divided)
        {
            _northEast.draw();
            _northWest.draw();
            _southEast.draw();
            _southWest.draw();
        }
    }

    public void clear()
    {
        _points.Clear();
        if (_divided)
        {
            _northEast.clear();
            _northWest.clear();
            _southEast.clear();
            _southWest.clear();
            _northEast = null;
            _northWest = null;
            _southEast = null;
            _southWest = null;
            _divided = false;
        }
    }
}
