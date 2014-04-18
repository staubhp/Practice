using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeQ1
{
    /// <summary>
    /// This is a simple implementation of a singly linked list
    /// </summary>
    class SinglyLinkedList
    {
        public Node headNode; //normally these nodes would be encapsulated, but they need to be exposed for Part 2 to use for traversal
        public Node currentNode;

        private int size = 0;

        public class Node
        {
            public object NodeContent;
            public Node Next;
        }

        public void PrintList()
        {
            Node tempNode = headNode;
            for (int i = 1; i <= Count(); i++)
            {
                Console.WriteLine(tempNode.NodeContent);
                tempNode = tempNode.Next;
            }
        }
        
        public int Count()
        {
            return size;
        }

    

        public Node Add(params object[] content)
        {
            if (content.Length > 1)
            {
                Node myLastNode = new Node();
                foreach (var myContent in content)
                {
                    myLastNode = Add(myContent);
                }
                return myLastNode;
            }
            else
            {
                if (headNode == null)
                {
                    headNode = new Node();
                    headNode.NodeContent = content[0];
                    currentNode = headNode;
                    size++;
                    return headNode;
                }
                else
                {
                    Node myNewNode = new Node();
                    myNewNode.NodeContent = content[0];
                    currentNode.Next = myNewNode;
                    currentNode = myNewNode;
                    size++;
                    return myNewNode;
                }
            }            
        }

  

        public object Get(int position)
        {
            if (position < 0 || position > (Count() - 1)) { return null; }
            object ret = null;

            Node tempNode = headNode;

            for (int i = 1; i < position; i++)
            {
                tempNode = tempNode.Next;
            }

            ret = tempNode.NodeContent;

            return ret;

        }

        public Node GetNode(int position)
        {                     
            Node tempNode = headNode;

            for (int i = 1; i < position; i++)
            {
                tempNode = tempNode.Next;
                if (tempNode == null) { break; }
            }

            return tempNode;
        }

        public bool Delete(int position)
        {
            bool ret = false;
            if (position < 0 || position > (Count() - 1)) { return ret; }

            Node tempNode = headNode;

            //if it's the head node, make head node either next node or null
            if (position == 0)
            {
                headNode = headNode.Next;
                ret = true;
            }
            else
            {
                //work our way to the node preceding the target node
                for (int i = 1; i <= position - 1; i++)
                {
                    tempNode = tempNode.Next;
                }

                //change this node's next to the node that comes after the target node
                tempNode.Next = tempNode.Next.Next;
                ret = true;
            }

            if (ret) { size--; }

            return ret;
        }
    }
}
