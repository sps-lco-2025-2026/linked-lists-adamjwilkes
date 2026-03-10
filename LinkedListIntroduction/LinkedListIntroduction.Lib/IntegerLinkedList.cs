using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace LinkedListIntroduction.Lib;

public class IntegerLinkedList
{
    IntegerNode _head;
   
    public IntegerLinkedList()
    {
        _head = null;
    }

    public IntegerLinkedList(int v)
    {
        _head = new IntegerNode(v);
    }

    public int Count => _head == null ? 0 : _head.Count;
    public int Sum => _head == null ? 0 : _head.Sum;

    public void Append(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
            _head.Append(v);

    }

    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }

    public void Prepend(int v)
    {
        IntegerNode newnode= new IntegerNode(
            v);
        newnode.setnext(_head);
        _head = newnode;
    }
    public bool deleteitem(int v)
    {
        if (_head == null)
        {
            return false;
        }
        else if (_head.Value == v)
        {
            _head = _head.Next;
            return true;
        }
        return _head.deleteitem(v);
    }
    public bool Insert(int v, int index)
    {
        if (index == 0)
        {
            Prepend(v);
            return true;
        }
        if (_head == null)
        {
            return false;
        }
        return _head.Insert(v, index -1);
    }
    public void Join(IntegerLinkedList secondlist)
    {
        if (secondlist == null)
        {
            return;
        }
        if (_head == null)
        {
            _head = secondlist._head;
        }
        else
        {
            _head.Join(secondlist._head);
        }
    }
    public bool contains(int v)
    {
        if (_head == null)
        {
            return false;
        }
        if (_head.Value == v)
        {
            return true;
        }
        return _head.contains(v);
    }
    public void removeduplicate()
    {
        if (_head == null)
        {
            return;
        }
        _head.removeduplicates();
    }
    public void Merge(IntegerLinkedList secondlist)
    {
        if (secondlist._head == null)
        {
            return;
        }
        if (_head == null)
        {
            _head = secondlist._head;
        }
        else
        {
            _head.Merge(secondlist._head);
        }
        secondlist._head = null;
        
    }
    public void reverse()
    {
        if (_head == null)
        {
            return;
        }
        _head = _head.reverse(null);
    }

}


public class IntegerNode
{
    int _value;
    IntegerNode? _next;
    internal int Value => _value;
    internal IntegerNode? Next
    {
        get => _next;
        set => _next = value;
    }

    internal int Count => _next == null ? 1 : 1 + _next.Count;
            
    internal int Sum => _next == null ? _value : _value + _next.Sum;


    internal IntegerNode(int v)
    {
        _value = v;
        _next = null;
    }

    internal void Append(int v)
    {
        if (_next == null)
            _next = new IntegerNode(v);
        else
            _next.Append(v);
    }

    public override string ToString()
    {
        return _next == null ? _value.ToString() : $"{_value}, {_next}";
    }
    internal void setnext(IntegerNode nextnode)
    {
        _next = nextnode;
    }
    internal bool deleteitem(int v)
    {
        if (_next == null)
        {
            return false;
        }
        if (_next.Value == v)
        {
            _next = _next.Next;
            return true;
        }
        return _next.deleteitem(v);
    }
    internal bool Insert(int v, int index)
    {
        if (index == 0)
        {
            IntegerNode newNode = new IntegerNode(v);
            newNode.setnext(_next);
            _next = newNode;
            return true;
        }
        if (_next == null)
        {
            return false;
        }
        return _next.Insert(v, index - 1);
    }
    internal void Join(IntegerNode secondlisthead)
    {
        if (_next == null)
        {
            _next = secondlisthead;
        }
        else
        {
            _next.Join(secondlisthead);
        }
    }
    internal bool contains(int v)
    {
        if (_next == null)
        {
            return false;
        }
        if (_next.Value == v)
        {
            return true;
        }
        return _next.contains(v);
    }
    internal void removeduplicates()
    {
        if (_next == null)
        {
            return;
        }
        while (_next != null && _next.contains(_value))
        {
            this.deleteitem(_value);
        }
        if (_next != null)
        {
            _next.removeduplicates();
        }
    }
    internal void Merge(IntegerNode second)
    {
        if (second == null)
        {
            return;
        }
        IntegerNode nextinlist = _next;
        IntegerNode secondtail = second.Next;
        _next = second;
        if (nextinlist!=null)
        {
            second.Next = nextinlist;
            nextinlist.Merge(secondtail);
        }
        else
        {
            second.Next = secondtail;
        }

    }
    internal IntegerNode reverse(IntegerNode previous)
    {
        IntegerNode originalnext = _next;
        _next = previous;
        if (originalnext == null)
        {
            return this;
        }
        return originalnext.reverse(this);
    }
    internal void sortedinsert(int v)
    {
        if (_next == null)
        {
            IntegerNode newnode = new IntegerNode(v);
            _next = newnode;
            return;
        }
        if (_next.Value > v)
        {
            IntegerNode newnode = new IntegerNode(v);
            newnode.Next = _next;
            _next = newnode;
            return;
            
        }
        _next.sortedinsert(v);
    }

}
public class SortedIntegerLinkedList
{
    private IntegerNode _head;
    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }

    public void sortedinsert(int v)
    {
        if (_head == null)
        {
            _head = new IntegerNode(v);
        }
        else if (_head.Value > v)
        {

            IntegerNode newnode = new IntegerNode(v);
            
            newnode.Next = _head;
            _head = newnode;
            
        }
        else
        {
            _head.sortedinsert(v);
        }
    }
}
