using LinkedListIntroduction.Lib; 

namespace LinkedListIntroduction.Tests;

[TestClass]
public sealed class BasicLinkedListTests
{

    [TestMethod]
    public void TestEmpty()
    {
        IntegerLinkedList ill = new IntegerLinkedList();
        Assert.AreEqual(0, ill.Count);
    }

    [TestMethod]
    public void TestCount()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(3, ill.Count);
    }

    [TestMethod]
    public void TestSum()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(21, ill.Sum);
    }

    [TestMethod]
    public void TestToStringExplicit()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestPrepend()
    {
        var ill = new IntegerLinkedList(10);
        ill.Prepend(5);
        Assert.AreEqual("{5, 10}", ill.ToString());
    }

    [TestMethod]
    public void TestDeleteItem()
    {
        var ill = new IntegerLinkedList(1);
        ill.Append(2);
        ill.Append(3);
        
        bool found = ill.deleteitem(2);
        bool notFound = ill.deleteitem(99);
        
        Assert.IsTrue(found);
        Assert.IsFalse(notFound);
        Assert.AreEqual("{1, 3}", ill.ToString());
    }

    [TestMethod]
    public void TestInsertAtIndex()
    {
        var ill = new IntegerLinkedList(1);
        ill.Append(3);
        ill.Insert(2, 1);
        Assert.AreEqual("{1, 2, 3}", ill.ToString());
    }

    [TestMethod]
    public void TestJoin()
    {
        var list1 = new IntegerLinkedList(1);
        list1.Append(2);
        var list2 = new IntegerLinkedList(3);
        list2.Append(4);
        
        list1.Join(list2);
        Assert.AreEqual("{1, 2, 3, 4}", list1.ToString());
    }
    [TestMethod]
    public void TestContains()
    {
        var ill = new IntegerLinkedList(10);
        ill.Append(20);
        Assert.IsTrue(ill.contains(10));
        Assert.IsFalse(ill.contains(30));
    }
    [TestMethod]
    public void TestRemoveDuplicates()
    {
        var ill = new IntegerLinkedList(1);
        ill.Append(2);
        ill.Append(1);
        ill.Append(3);
        ill.Append(2);
        
        ill.removeduplicate();
        Assert.AreEqual("{1, 2, 3}", ill.ToString());
    }
    [TestMethod]
    public void TestMerge()
    {
        var list1 = new IntegerLinkedList(1);
        list1.Append(3);
        var list2 = new IntegerLinkedList(2);
        list2.Append(4);
        
        list1.Merge(list2);
        Assert.AreEqual("{1, 2, 3, 4}", list1.ToString());
    }
    [TestMethod]
    public void TestReverse()
    {
        var ill = new IntegerLinkedList(1);
        ill.Append(2);
        ill.Append(3);
        
        ill.reverse();
        Assert.AreEqual("{3, 2, 1}", ill.ToString());
    }
    [TestMethod]
    public void TestSortedIntegerLinkedList()
    {
        var sill = new SortedIntegerLinkedList();
        sill.sortedinsert(20);
        sill.sortedinsert(10);
        sill.sortedinsert(30);
        sill.sortedinsert(15);
        
        Assert.AreEqual("{10, 15, 20, 30}", sill.ToString());
    }
}