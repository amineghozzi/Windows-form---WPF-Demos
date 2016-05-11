using System;
using System.Collections.Generic;
using System.Text;

namespace AnyParser
{
    internal class Leaf<T> : List<Node<T>>
    {
        #region Private Fields
        T _obj;
        #endregion

        #region Public Properties
        public T Object
        {
            get { return this._obj; }
            set { this._obj = value; }
        }
        #endregion
    }

    internal class Node<T> : Leaf<T>
    {
        #region Private Fields
        Node<T> _subNode;
        #endregion

        #region Public Constructor
        public Node()
        {
            // deprecated
            this._subNode = null;
        }
        #endregion

        #region Public Properties
        // deprecated
        public Node<T> SubNode
        {
            get
            {
                if (this._subNode == null)
                    this._subNode = new Node<T>();
                return this._subNode;
            }
        }
        #endregion
    }

    internal class Tree<T>
    {
        #region Private Fields
        Stack<Node<T>> _parents;
        Node<T> _root;
        Node<T> _current;
        Node<T> _lastNode;
        #endregion

        #region Public Constructor
        public Tree()
        {
            this._parents = new Stack<Node<T>>();
            this._root = new Node<T>();
            this._current = this._root;
        }
        #endregion

        #region Public Methods
        public List<Node<T>>.Enumerator GetEnumerator()
        {
            return this._root.GetEnumerator();
        }

        public Node<T> Current
        {
            get { return this._current; }
        }

        public Node<T> Root
        {
            get { return this._root; }
        }

        public Node<T> this[int index]
        {
            get { return this._current[index]; }
        }

        public void SetCurrent(Node<T> current)
        {
            this._current = current;
            this._lastNode = current;
        }

        public void Add(T obj)
        {
            Node<T> node = new Node<T>();
            node.Object = obj;
            this._lastNode = node;
            this._current.Add(node);
        }

        public void Push()
        {
            this._parents.Push(this._current);
            this._current = this._lastNode;
            this._lastNode = null;
        }

        public void Pop()
        {
            this._current = this._parents.Pop();
        }
        #endregion
    }
}
