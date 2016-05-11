using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace AnyParser
{
    public interface ILanguageParser
    {
        string LoadFile(string fileName);
        Recognized Parse(string text);
    }

    internal enum NodeType
    {
        Character,
        SeparatorPlus,
        SeparatorStar,
        RegularExp,
        Group
    }

    internal class Node
    {
        #region Private Fields
        private int executionPosition;
        private char character;
        private string groupName;
        private Node nextNode;
        private string id;
        private NodeType type;
        private bool isMultiple;
        private Regex regularExp;
        #endregion

        #region Public Constructor
        public Node(string id, int executionPosition, char character)
        {
            this.type = NodeType.Character;
            this.id = id;
            this.executionPosition = executionPosition;
            this.character = character;
            this.groupName = "";
            this.isMultiple = false;
        }

        public Node(string id, int executionPosition, string name)
        {
            this.id = id;
            this.executionPosition = executionPosition;
            this.type = NodeType.Group;
            this.groupName = name;
            this.isMultiple = false;
        }

        public Node(string id, int executionPosition, NodeType type)
        {
            this.id = id;
            this.executionPosition = executionPosition;
            this.type = type;
            this.groupName = "";
            this.isMultiple = false;
        }

        public Node(string id, int executionPosition, Regex exp)
        {
            this.id = id;
            this.executionPosition = executionPosition;
            this.type = NodeType.RegularExp;
            this.groupName = "";
            this.isMultiple = false;
            this.regularExp = exp;
        }
        #endregion

        #region Public Properties
        public Regex RegularExpression
        {
            get { return this.regularExp; }
        }

        public string GroupName
        {
            get { return this.groupName; }
        }

        public bool IsMultiple
        {
            get { return this.isMultiple; }
            set { this.isMultiple = value; }
        }

        public char Character
        {
            get { return this.character; }
        }

        public NodeType Type
        {
            get { return this.type; }
        }

        public string ID
        {
            get { return this.id; }
        }

        public Node NextNode
        {
            get { return this.nextNode; }
            set { this.nextNode = value; }
        }
        #endregion
    }

    internal static class Error
    {
        private static int maxPosition;
        private static string expected;

        public static int Position
        {
            get { return Error.maxPosition; }
        }

        public static string ExpectedValue
        {
            get { return Error.expected; }
        }

        private static void Expected(Node<Node> node)
        {
            bool first = true;
            Error.expected += "(";
            foreach (Node<Node> sub in node)
            {
                if (sub.Object.Type == NodeType.Character)
                {
                    if (!first) { Error.expected += "|"; } else { first = false; }
                    Error.expected += sub.Object.Character;
                    Error.Expected(sub);
                }
                else if (sub.Object.Type == NodeType.Group)
                {
                    if (!first) { Error.expected += "|"; } else { first = false; }
                    Error.expected += "<" + sub.Object.GroupName + ">";
                    Error.Expected(sub);
                }
                else if (sub.Object.Type == NodeType.RegularExp)
                {
                    if (!first) { Error.expected += "|"; } else { first = false; }
                    Error.expected += "\\e()";
                    Error.Expected(sub);
                }
                else if (sub.Object.Type == NodeType.SeparatorPlus)
                {
                    if (!first) { Error.expected += "|"; } else { first = false; }
                    Error.expected += "\\S+";
                    Error.Expected(sub);
                }
                else if (sub.Object.Type == NodeType.SeparatorStar)
                {
                    if (!first) { Error.expected += "|"; } else { first = false; }
                    Error.expected += "\\S*";
                    Error.Expected(sub);
                }
            }
            Error.expected += ")";
        }

        public static void SetError(State etat)
        {
            if (maxPosition <= etat.Position)
            {
                maxPosition = etat.Position;
                Error.expected = "";
                Error.Expected(etat.CurrentNode);
            }
        }

        public static void Start()
        {
            Error.maxPosition = 0;
        }
    }

    public class Recognized
    {
        #region Private Fields
        private List<Recognized> subNodes;
        private string value;
        private Recognized parent;
        #endregion

        #region Public Constructor
        public Recognized(string value)
        {
            this.subNodes = new List<Recognized>();
            this.value = value;
        }
        #endregion

        #region Public Properties
        public Recognized Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        public List<Recognized> SubNodes
        {
            get { return this.subNodes; }
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        #endregion

        #region Public Methods
        public void Add(Recognized sub)
        {
            this.subNodes.Add(sub);
        }

        public Recognized Push()
        {
            if (this.subNodes.Count > 0)
                return this.subNodes[this.subNodes.Count - 1];
            else
                throw new Exception("Pas de sous-noeud");
        }

        public Recognized Pop()
        {
            return this.parent;
        }

        public Recognized Clone(Recognized currentCopied, Recognized currentParent, ref Recognized current)
        {
            Recognized cloned = new Recognized(this.value);
            cloned.Parent = currentParent;
            if (this == currentCopied)
            {
                current = cloned;
            }
            foreach (Recognized sub in this.subNodes)
            {
                cloned.subNodes.Add(sub.Clone(currentCopied, cloned, ref current));
            }
            return cloned;
        }
        #endregion

    }

    internal class State
    {
        #region Private Fields
        private int position;
        private Node<Node> currentNode;
        private Stack<Node<Node>> parents;
        private bool recognizerMode;
        private Recognized rootReco;
        private Recognized currentReco;
        private Stack<Node<Node>> stackWaitFor;
        private string groupName;
        #endregion

        #region Public Fields
        public bool first;
        #endregion

        #region Public Constructor
        public State(int position, Node<Node> currentNode)
        {
            this.position = position;
            this.currentNode = currentNode;
            this.recognizerMode = false;
            this.rootReco = null;
            this.currentReco = null;
            this.parents = new Stack<Node<Node>>();
            this.stackWaitFor = new Stack<Node<Node>>();
        }
        #endregion

        #region Public Properties
        public int Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Node<Node> CurrentNode
        {
            get { return this.currentNode; }
            set { this.currentNode = value; }
        }

        public bool RecognizerMode
        {
            get { return this.recognizerMode; }
            set { this.recognizerMode = value; }
        }

        public string Value
        {
            get { return this.currentReco.SubNodes[this.currentReco.SubNodes.Count - 1].Value; }
            set { this.currentReco.SubNodes[this.currentReco.SubNodes.Count - 1].Value = value; }
        }

        public Recognized RootRecognized
        {
            get { return this.rootReco; }
        }

        public Node<Node> CurrentWaitFor
        {
            get
            {
                if (this.stackWaitFor.Count > 0)
                    return this.stackWaitFor.Peek();
                else
                    return null;
            }
        }

        public string GroupName
        {
            get
            {
                if (this.stackWaitFor.Count > 0)
                    return this.stackWaitFor.Peek().Object.GroupName;
                else
                    return "";
            }
        }
        #endregion

        #region Public Methods
        public void Push(Node<Node> startNode)
        {
            this.parents.Push(this.currentNode);
            this.currentNode = startNode;
        }

        public void Pop()
        {
            this.currentNode = this.parents.Pop();
        }

        public void AddRecognized(string reco)
        {
            Recognized r = new Recognized(reco);
            if (this.currentReco == null)
            {
                r.Parent = null;
                this.rootReco = r;
                this.currentReco = r;
            }
            else
            {
                this.currentReco.Add(r);
            }
        }

        public void SetRecognized(string reco)
        {
            if (this.currentReco != null && this.currentReco.Value == "multiple")
            {
                this.currentReco.Value = reco;
            }
        }

        public void PushReco()
        {
            Recognized sub = this.currentReco.Push();
            sub.Parent = this.currentReco;
            this.currentReco = sub;
        }

        public void PopReco()
        {
            this.currentReco = this.currentReco.Parent;
        }

        public void CopyReco(State etat)
        {
            this.rootReco = etat.rootReco.Clone(etat.currentReco, null, ref this.currentReco);
        }

        public void PushWaitFor(Node<Node> waitFor)
        {
            this.groupName = waitFor.Object.GroupName;
            this.stackWaitFor.Push(waitFor);
        }

        public Node<Node> PopWaitFor()
        {
            return this.stackWaitFor.Pop();
        }

        public void CopyStackWaitFor(State etat)
        {
            foreach (Node<Node> waitFor in etat.stackWaitFor)
            {
                this.stackWaitFor.Push(waitFor);
            }
        }

        public void ForEachWaitFor(Action<Node<Node>> action)
        {
            try
            {
                foreach (Node<Node> waitFor in this.stackWaitFor)
                {
                    action(waitFor);
                }
            }
            catch (InvalidOperationException) { }
        }
        #endregion
    }

    public class AnyParser
    {
        #region Private Fields
        private string pattern;
        private Stack<State> etats;
        private Dictionary<string, Tree<Node>> groups;
        private string ID;
        private Tree<Node> nodes;
        private string text;
        private List<string> separators;
        private bool ignoreCase;
        #endregion

        #region Public Constructor
        public AnyParser()
        {
            this.etats = new Stack<State>();
            this.groups = new Dictionary<string, Tree<Node>>();
            this.separators = new List<string>();
        }
        #endregion

        #region Public Properties
        public bool IgnoreCase
        {
            get { return this.ignoreCase; }
            set { this.ignoreCase = value; }
        }
        #endregion

        #region Private Methods
        private bool EatSeparators(NodeType type, ref int position)
        {
            bool found = false;
            if (type == NodeType.SeparatorPlus)
            {
                foreach (string sep in this.separators)
                {
                    if ((position + sep.Length) < this.text.Length && this.text.Substring(position, sep.Length) == sep)
                    {
                        found = true;
                        position += sep.Length;
                    }
                }
                if (!found)
                {
                    return false;
                }
            }
            else
            {
                found = true;
            }
            while (found)
            {
                found = false;
                foreach (string sep in this.separators)
                {
                    if ((position+sep.Length) < this.text.Length && this.text.Substring(position, sep.Length) == sep)
                    {
                        found = true;
                        position += sep.Length;
                    }
                }
            }
            return true;
        }

        private void Compose(int position)
        {
            if (position < this.pattern.Length)
            {
                bool stop = false;
                if (this.pattern[position] == '\\')
                {
                    if ((position + 1) < this.pattern.Length && this.pattern[position + 1] == 'S')
                    {
                        if ((position + 2) < this.pattern.Length)
                        {
                            if (this.pattern[position + 2] == '+')
                            {
                                stop = true;
                                bool found = false;
                                foreach (Node<Node> node in this.nodes.Current)
                                {
                                    if (node.Object.Type == NodeType.SeparatorPlus)
                                    {
                                        found = true;
                                        node.Object.IsMultiple = true;
                                        this.nodes.SetCurrent(node);
                                        this.nodes.Push();
                                        this.Compose(position + 3);
                                        this.nodes.Pop();
                                    }
                                }
                                if (!found)
                                {
                                    Node newNode = new Node(this.ID, position + 3, NodeType.SeparatorPlus);
                                    this.nodes.Add(newNode);
                                    this.nodes.Push();
                                    this.Compose(position + 3);
                                    this.nodes.Pop();
                                }
                            }
                            else if (this.pattern[position + 2] == '*')
                            {
                                stop = true;
                                bool found = false;
                                foreach (Node<Node> node in this.nodes.Current)
                                {
                                    if (node.Object.Type == NodeType.SeparatorStar)
                                    {
                                        found = true;
                                        node.Object.IsMultiple = true;
                                        this.nodes.SetCurrent(node);
                                        this.nodes.Push();
                                        this.Compose(position + 3);
                                        this.nodes.Pop();
                                    }
                                }
                                if (!found)
                                {
                                    Node newNode = new Node(this.ID, position + 3, NodeType.SeparatorStar);
                                    this.nodes.Add(newNode);
                                    this.nodes.Push();
                                    this.Compose(position + 3);
                                    this.nodes.Pop();
                                }
                            }
                        }
                    }
                    else if ((position + 1) < this.pattern.Length && this.pattern[position + 1] == 'e')
                    {
                        if ((position + 2) < this.pattern.Length && this.pattern[position + 2] == '(')
                        {
                            Regex reg = new Regex(@"(\(.*\))");
                            Match m = reg.Match(this.pattern.Substring(position + 2));
                            if (m.Success)
                            {
                                stop = true;
                                Node newNode = new Node(this.ID, position + 2 + m.Length, new Regex(this.pattern.Substring(position + 2, m.Length)));
                                this.nodes.Add(newNode);
                                this.nodes.Push();
                                this.Compose(position + 2 + m.Length);
                                this.nodes.Pop();
                            }
                        }
                    }
                    else if ((position + 1) < this.pattern.Length && this.pattern[position + 1] == '<')
                    {
                        int closedChevrons = this.pattern.IndexOf(@"\>", position);
                        if (closedChevrons != -1)
                        {
                            stop = true;
                            //if (this.nodes.Current.Count > 0)
                            //{
                            //    throw new Exception("Impossible de créer une sous-branche si plusieurs possibilités");
                            //}
                            string name = this.pattern.Substring(position + 2, closedChevrons - position - 2);
                            Node newNode = new Node(this.ID, position, name);
                            this.nodes.Add(newNode);
                            this.nodes.Push();
                            this.Compose(closedChevrons + 2);
                            this.nodes.Pop();
                        }
                        else
                        {
                            throw new Exception("Il manque un chevron fermant");
                        }
                    }

                }
                if (!stop)
                {
                    bool found = false;
                    foreach (Node<Node> node in this.nodes.Current)
                    {
                        if (node.Object.Type == NodeType.Character && node.Object.Character == this.pattern[position])
                        {
                            found = true;
                            node.Object.IsMultiple = true;
                            this.nodes.SetCurrent(node);
                            this.nodes.Push();
                            this.Compose(position + 1);
                            this.nodes.Pop();
                        }
                    }
                    if (!found)
                    {
                        Node newNode = new Node(this.ID, position, this.pattern[position]);
                        this.nodes.Add(newNode);
                        this.nodes.Push();
                        this.Compose(position + 1);
                        this.nodes.Pop();
                    }
                }
            }
        }

        private void Extract()
        {
            string word = String.Empty;
            while (this.etats.Count > 0)
            {
                State etat = this.etats.Peek();
                if (etat.RecognizerMode)
                {
                    if (etat.Position < this.text.Length)
                    {
                        if (etat.CurrentNode.Count > 0)
                        {
                            bool found = false;
                            foreach (Node<Node> subNode in etat.CurrentNode)
                            {
                                if (subNode.Object.Type == NodeType.Character && String.Compare(subNode.Object.Character.ToString(), this.text[etat.Position].ToString(), this.ignoreCase) == 0)
                                {
                                    found = true;
                                    State newEtat = new State(etat.Position + 1, subNode);
                                    newEtat.RecognizerMode = false;
                                    newEtat.CopyReco(etat);
                                    newEtat.CopyStackWaitFor(etat);
                                    this.etats.Push(newEtat);
                                    etat.Value += this.text[etat.Position];
                                    ++etat.Position;
                                    Error.SetError(etat);
                                }
                                else if (subNode.Object.Type == NodeType.SeparatorPlus)
                                {
                                    int position = etat.Position;
                                    this.EatSeparators(subNode.Object.Type, ref position);
                                    if (position != etat.Position)
                                    {
                                        found = true;
                                        State newEtat = new State(position, subNode);
                                        newEtat.RecognizerMode = false;
                                        newEtat.CopyReco(etat);
                                        newEtat.CopyStackWaitFor(etat);
                                        this.etats.Push(newEtat);
                                        etat.Position = position;
                                        etat.CurrentNode = subNode;
                                        Error.SetError(etat);
                                    }
                                }
                                else if (subNode.Object.Type == NodeType.SeparatorStar)
                                {
                                    int position = etat.Position;
                                    this.EatSeparators(subNode.Object.Type, ref position);
                                    found = true;
                                    State newEtat = new State(position, subNode);
                                    newEtat.RecognizerMode = false;
                                    newEtat.CopyReco(etat);
                                    newEtat.CopyStackWaitFor(etat);
                                    this.etats.Push(newEtat);
                                    etat.Position = position;
                                    etat.CurrentNode = subNode;
                                    Error.SetError(etat);
                                }
                                else if (subNode.Object.Type == NodeType.RegularExp)
                                {
                                    Regex exp = subNode.Object.RegularExpression;
                                    Match m = exp.Match(this.text.Substring(etat.Position));
                                    if (m.Success)
                                    {
                                        found = true;
                                        State newEtat = new State(etat.Position + m.Groups[1].Value.Length, subNode);
                                        newEtat.RecognizerMode = false;
                                        newEtat.CopyReco(etat);
                                        newEtat.CopyStackWaitFor(etat);
                                        this.etats.Push(newEtat);
                                        etat.Position += m.Groups[1].Value.Length;
                                        etat.Value += m.Groups[1].Value;
                                        etat.CurrentNode = subNode;
                                        Error.SetError(etat);
                                    }
                                }
                                else if (subNode.Object.Type == NodeType.Group)
                                {
                                    throw new NotImplementedException("Insérer un groupe à la suite d'un ? n'est pas implémenté");
                                }
                            }
                            if (!found)
                            {
                                etat.Value += this.text[etat.Position];
                                ++etat.Position;
                                Error.SetError(etat);
                            }
                        }
                        else
                        {
                            // échec
                            this.etats.Pop();
                        }
                    }
                    else
                    {
                        // echec
                        this.etats.Pop();
                    }
                }
                else
                {
                    if (etat.Position < this.text.Length)
                    {
                        bool found = false;
                        foreach (Node<Node> subNode in etat.CurrentNode)
                        {
                            if (!found)
                            {
                                if (subNode.Object.Type == NodeType.Character && subNode.Object.Character == '?')
                                {
                                    Logging.Logs.Send(Logging.LogLevel.NORMAL, Logging.Categories.Program, "a reconnu " + word);
                                    word = String.Empty;
                                    Logging.Logs.Send(Logging.LogLevel.NORMAL, Logging.Categories.Program, "rencontre ?");
                                    found = true;
                                    if (etat.first)
                                    {
                                        if (subNode.Object.IsMultiple)
                                        {
                                            etat.AddRecognized("multiple");
                                        }
                                        else
                                        {
                                            etat.AddRecognized(subNode.Object.ID);
                                        }
                                        etat.PushReco();
                                        etat.first = false;
                                    }
                                    else if (!subNode.Object.IsMultiple)
                                    {
                                        etat.SetRecognized(subNode.Object.ID);
                                    }
                                    etat.CurrentNode = subNode;
                                    etat.AddRecognized("");
                                    etat.RecognizerMode = true;
                                    Error.SetError(etat);
                                    break;
                                }
                                else if (subNode.Object.Type == NodeType.Character && String.Compare(subNode.Object.Character.ToString(), this.text[etat.Position].ToString(), this.ignoreCase) == 0)
                                {
                                    word += this.text[etat.Position];
                                    if (etat.first)
                                    {
                                        if (subNode.Object.IsMultiple)
                                        {
                                            etat.AddRecognized("multiple");
                                        }
                                        else
                                        {
                                            etat.AddRecognized(subNode.Object.ID);
                                        }
                                        etat.PushReco();
                                        etat.first = false;
                                    }
                                    else if (!subNode.Object.IsMultiple)
                                    {
                                        etat.SetRecognized(subNode.Object.ID);
                                    }
                                    found = true;
                                    ++etat.Position;
                                    etat.CurrentNode = subNode;
                                    Error.SetError(etat);
                                    break;
                                }
                                else if (subNode.Object.Type == NodeType.Group)
                                {
                                    Logging.Logs.Send(Logging.LogLevel.NORMAL, Logging.Categories.Program, "a reconnu " + word);
                                    word = String.Empty;
                                    Logging.Logs.Send(Logging.LogLevel.NORMAL, Logging.Categories.Program, "rencontre le groupe " + subNode.Object.GroupName);
                                    found = true;
                                    if (etat.first)
                                    {
                                        if (subNode.Object.IsMultiple)
                                        {
                                            etat.AddRecognized("multiple");
                                        }
                                        else
                                        {
                                            etat.AddRecognized(subNode.Object.ID);
                                        }
                                        etat.PushReco();
                                        etat.first = false;
                                    }
                                    else if (!subNode.Object.IsMultiple)
                                    {
                                        etat.SetRecognized(subNode.Object.ID);
                                    }
                                    etat.AddRecognized(subNode.Object.GroupName);
                                    etat.PushReco();
                                    if (this.groups.ContainsKey(subNode.Object.GroupName))
                                    {
                                        etat.CurrentNode = this.groups[subNode.Object.GroupName].Root;
                                    }
                                    else
                                    {
                                        throw new Exception(subNode.Object.GroupName + " n'existe pas");
                                    }
                                    etat.first = true;
                                    etat.PushWaitFor(subNode);
                                    Error.SetError(etat);
                                }
                                else if (subNode.Object.Type == NodeType.SeparatorPlus)
                                {
                                    Logging.Logs.Send(Logging.LogLevel.NORMAL, Logging.Categories.Program, "a reconnu " + word);
                                    word = String.Empty;
                                    Logging.Logs.Send(Logging.LogLevel.NORMAL, Logging.Categories.Program, "rencontre SeparatorPlus");
                                    found = true;
                                    if (etat.first)
                                    {
                                        if (subNode.Object.IsMultiple)
                                        {
                                            etat.AddRecognized("multiple");
                                        }
                                        else
                                        {
                                            etat.AddRecognized(subNode.Object.ID);
                                        }
                                        etat.PushReco();
                                        etat.first = false;
                                    }
                                    else if (!subNode.Object.IsMultiple)
                                    {
                                        etat.SetRecognized(subNode.Object.ID);
                                    }
                                    int position = etat.Position;
                                    if (!this.EatSeparators(NodeType.SeparatorPlus, ref position))
                                    {
                                        this.etats.Pop();
                                    }
                                    etat.Position = position;
                                    etat.CurrentNode = subNode;
                                    Error.SetError(etat);
                                }
                                else if (subNode.Object.Type == NodeType.SeparatorStar)
                                {
                                    Logging.Logs.Send(Logging.LogLevel.NORMAL, Logging.Categories.Program, "a reconnu " + word);
                                    word = String.Empty;
                                    Logging.Logs.Send(Logging.LogLevel.NORMAL, Logging.Categories.Program, "rencontre SeparatorStar");
                                    found = true;
                                    int position = etat.Position;
                                    this.EatSeparators(NodeType.SeparatorStar, ref position);
                                    etat.Position = position;
                                    etat.CurrentNode = subNode;
                                    Error.SetError(etat);
                                }
                                else if (subNode.Object.Type == NodeType.RegularExp)
                                {
                                    Logging.Logs.Send(Logging.LogLevel.NORMAL, Logging.Categories.Program, "a reconnu " + word);
                                    word = String.Empty;
                                    Logging.Logs.Send(Logging.LogLevel.NORMAL, Logging.Categories.Program, "rencontre expression régulière");
                                    Regex exp = subNode.Object.RegularExpression;
                                    Match m = exp.Match(this.text.Substring(etat.Position));
                                    if (m.Success)
                                    {
                                        found = true;
                                        if (etat.first)
                                        {
                                            if (subNode.Object.IsMultiple)
                                            {
                                                etat.AddRecognized("multiple");
                                            }
                                            else
                                            {
                                                etat.AddRecognized(subNode.Object.ID);
                                            }
                                            etat.PushReco();
                                            etat.first = false;
                                        }
                                        else if (!subNode.Object.IsMultiple)
                                        {
                                            etat.SetRecognized(subNode.Object.ID);
                                        }
                                        etat.Position += m.Groups[1].Value.Length;
                                        etat.AddRecognized(m.Groups[1].Value);
                                        etat.CurrentNode = subNode;
                                        Error.SetError(etat);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        etat.ForEachWaitFor(new Action<Node<Node>>(delegate(Node<Node> waitFor)
                        {
                            if (!found)
                            {
                                if (waitFor != null)
                                {
                                    if (waitFor.Count > 1)
                                    {
                                        throw new NotImplementedException("Plusieurs possibilités après un groupe non implémenté");
                                    }
                                    else if (waitFor.Count == 1)
                                    {
                                        Node<Node> sub = waitFor[0];
                                        if (sub.Object.Type == NodeType.Group)
                                        {
                                            throw new NotImplementedException("Plusieurs groupes successifs non implémenté");
                                        }
                                        else if (sub.Object.Type == NodeType.Character && String.Compare(sub.Object.Character.ToString(), this.text[etat.Position].ToString(), this.ignoreCase) == 0)
                                        {
                                            found = true;
                                            etat.RecognizerMode = false;
                                            etat.PopWaitFor();
                                            if (!etat.first)
                                                etat.PopReco();
                                            else
                                                etat.first = false;
                                            etat.PopReco();
                                            ++etat.Position;
                                            etat.CurrentNode = sub;
                                            Error.SetError(etat);
                                        }
                                        else if (sub.Object.Type == NodeType.SeparatorStar)
                                        {
                                            int position = etat.Position;
                                            this.EatSeparators(sub.Object.Type, ref position);
                                            found = true;
                                            etat.RecognizerMode = false;
                                            etat.PopWaitFor();
                                            if (!etat.first)
                                                etat.PopReco();
                                            else
                                                etat.first = false;
                                            etat.PopReco();
                                            etat.Position = position;
                                            etat.CurrentNode = sub;
                                            Error.SetError(etat);
                                        }
                                        else if (sub.Object.Type == NodeType.SeparatorPlus)
                                        {
                                            int position = etat.Position;
                                            this.EatSeparators(sub.Object.Type, ref position);
                                            if (position != etat.Position)
                                            {
                                                found = true;
                                                etat.RecognizerMode = false;
                                                etat.PopWaitFor();
                                                if (!etat.first)
                                                    etat.PopReco();
                                                else
                                                    etat.first = false;
                                                etat.PopReco();
                                                etat.Position = position;
                                                etat.CurrentNode = sub;
                                                Error.SetError(etat);
                                            }
                                        }
                                        else if (sub.Object.Type == NodeType.RegularExp)
                                        {
                                            Regex exp = sub.Object.RegularExpression;
                                            Match m = exp.Match(this.text.Substring(etat.Position));
                                            if (m.Success)
                                            {
                                                etat.AddRecognized(m.Groups[1].Value);
                                                found = true;
                                                etat.RecognizerMode = false;
                                                etat.PopWaitFor();
                                                if (!etat.first)
                                                    etat.PopReco();
                                                else
                                                    etat.first = false;
                                                etat.PopReco();
                                                etat.Position += m.Groups[1].Value.Length;
                                                etat.CurrentNode = sub;
                                                Error.SetError(etat);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new NotImplementedException("Plus de possibilités après un groupe non implémenté");
                                    }
                                }
                            }
                        }));
                        if (!found)
                        {
                            if (etat.CurrentNode.Count == 0)
                            {
                                // on recommence à chercher sur une autre ligne
                                if (!etat.first)
                                    etat.PopReco();
                                etat.first = true;
                                if (!String.IsNullOrEmpty(etat.GroupName))
                                {
                                    // on est dans une sous-branche
                                    etat.CurrentNode = this.groups[etat.GroupName].Root;
                                }
                                else
                                {
                                    // on est à la racine de la recherche
                                    etat.CurrentNode = this.groups[etat.RootRecognized.Value].Root;
                                }
                                Error.SetError(etat);
                            }
                            else
                            {
                                // échec
                                this.etats.Pop();
                            }
                        }
                    }
                    else
                    {
                        if (etat.CurrentNode.Count == 0)
                        {
                            // good recognition
                            break;
                        }
                        else
                        {
                            // échec
                            this.etats.Pop();
                        }
                    }
                }
            }
        }
        #endregion

        #region Public Methods
        public void AddSeparator(string sep)
        {
            this.separators.Add(sep);
        }

        public void Compose(string name, string ID, string pattern)
        {
            this.ID = ID;
            this.pattern = pattern;
            if (this.groups.ContainsKey(name))
            {
                this.nodes = this.groups[name];
                this.nodes.SetCurrent(this.nodes.Root);
            }
            else
            {
                this.nodes = new Tree<Node>();
                this.groups.Add(name, nodes);
            }
            this.Compose(0);
        }

        public Recognized Parse(string start, string text)
        {
            this.text = text;
            this.etats.Clear();
            if (this.groups.ContainsKey(start))
            {
                State first = new State(0, this.groups[start].Root);
                first.first = true;
                first.AddRecognized(start);
                this.etats.Push(first);
            }
            Error.Start();
            this.Extract();
            if (this.etats.Count > 0)
            {
                return this.etats.Peek().RootRecognized;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
