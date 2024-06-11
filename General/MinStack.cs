namespace General;

/// <summary>
/// https://leetcode.com/problems/min-stack/
/// </summary>
public class MinStack
{
    private int _prevMin;
    private int _minValue;
    private readonly LinkedList _linkedList;

    public MinStack()
    {
        _minValue = int.MaxValue;
        _linkedList = new LinkedList();
    }

    public void Push(int val)
    {
        var min = _linkedList.GetMin();
        
        _linkedList.AddFront(val, Math.Min(val, min));
    }

    public void Pop()
    {
        _linkedList.RemoveFront();
    }

    public int Top()
    {
        return _linkedList.FrontValue();
    }

    public int GetMin()
    {
        return _linkedList.GetMin();
    }

    private class LinkedList
    {
        private Node _root;

        public LinkedList()
        {
        }

        public int GetMin() => _root?.Min ?? int.MaxValue;
        
        public void AddFront(int val, int min)
        {
            if (_root is null)
            {
                _root = new Node { Val = val, Min = min };
                return;
            }

            _root = new Node
            {
                Val = val,
                Min = min,
                Prev = _root
            };
        }

        public void RemoveFront()
        {
            _root = _root.Prev;
        }

        class Node
        {
            public int Min { get; set; }
            public int Val { get; set; }
            public Node? Prev { get; set; }
        }

        public int FrontValue()
        {
            return _root.Val;
        }
    }
}