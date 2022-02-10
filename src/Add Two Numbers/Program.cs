using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Add_Two_Numbers
{
  //https://leetcode.com/problems/add-two-numbers/
  class Program
  {
    static void Main(string[] args)
    {
      var first1_1 = new ListNode(9);
      var first1_2 = new ListNode(9, first1_1);
      var first1_3 = new ListNode(9, first1_2);
      var first1_4 = new ListNode(9, first1_3);
      var first1_5 = new ListNode(9, first1_4);

      var first2_1 = new ListNode(9);
      var first2_2 = new ListNode(9, first2_1);
      var first2_3 = new ListNode(9, first2_2);

      var solution = new Solution().AddTwoNumbers(first1_5, first2_3);
    }
  }

  public class ListNode
  {
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
      this.val = val;
      this.next = next;
    }
  }

  public class Solution
  {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
      var l1Count = GetCount(l1);
      var l2Count = GetCount(l2);

      if (l1Count > l2Count)
      {
        var current = GetLastNode(l2);

        for (var i = 0; i < l1Count - l2Count; i++)
        {
          current.next = new ListNode(0);
          current = current.next;
        }
      }
      else
      {
        var current = GetLastNode(l1);

        for (var i = 0; i < l2Count - l1Count; i++)
        {
          current.next = new ListNode(0);
          current = current.next;
        }
      }

      var resultNode = new ListNode();
      var currentResultNode = resultNode;

      var l1CurrentNode = l1;
      var l2CurrentNode = l2;

      while (l1CurrentNode != null && l2CurrentNode != null)
      {
        var value = l1CurrentNode.val + l2CurrentNode.val;
        if (value + currentResultNode.val > 9)
        {
          currentResultNode.val = value + currentResultNode.val - 10;
          currentResultNode.next = new ListNode(1);
          currentResultNode = currentResultNode.next;
        }
        else
        {
          currentResultNode.val += value;
          currentResultNode.next = new ListNode(0);
          currentResultNode = currentResultNode.next;
        }

        l1CurrentNode = l1CurrentNode.next;
        l2CurrentNode = l2CurrentNode.next;
      }

      if (currentResultNode.val != 0) 
        return resultNode;
      
      var temp = resultNode;
      while (temp != null)
      {
        if (temp.next == currentResultNode)
        {
          temp.next = null;
          break;
        }

        temp = temp.next;
      }

      return resultNode;
    }

    private static ListNode GetLastNode(ListNode listNode)
    {
      var currentNode = listNode;

      while (currentNode != null)
      {
        if (currentNode.next == null)
        {
          return currentNode;
        }
        
        currentNode = currentNode.next;
      }

      return currentNode;
    }
    
    private static int GetCount(ListNode listNode)
    {
      var res = 0;
      var currentNode = listNode;

      while (currentNode != null)
      {
        res++;
        currentNode = currentNode.next;
      }

      return res;
    }
  }
}