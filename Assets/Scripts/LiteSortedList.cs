using System;
using System.Collections.Generic;

//C# contains a sortedset which doesn't allow you to insert elements that are the same as one another.
//it also contains a sortedlist, which is *really* more like a sorted hashtable.
//this should be simple enough for our purposes.

public class LiteSortedList<T> {
    IComparer<T> comparison;

    private List<T> data = new List<T>();

    public LiteSortedList(IComparer<T> _comparison){
        comparison = _comparison;
    }

    public LiteSortedList(){
        comparison = Comparer<T>.Default;
    }

    //Adding an item will take O(logN) time due to binary search.
    //This saves us performing a resort.
    public void Add(T item){
        int end = data.Count;
        int start = 0;
        int index = BinarySearch(item,start,end);
        data.Insert(index,item);
    }

    //recursive
    private int BinarySearch(T item, int start, int end){
        int range = end-start;
        if(range == 0){
            return 0;
        }
        bool greaterthanstart = comparison.Compare(item, data[start]) > 0;
        if(range == 1){
            return start + Convert.ToInt32(greaterthanstart);
        }
        bool greaterthanend = comparison.Compare(item, data[end - 1]) > 0;
        if(greaterthanend){
            return end;
        }
        bool greaterthanmiddle = comparison.Compare(item, data[start + range / 2]) > 0;
        if (greaterthanmiddle){
            return BinarySearch(item, start + range / 2, end);
        }
        return BinarySearch(item,start,start + range/2);
    }

    public void Resort(){
        data.Sort(comparison);
        //uses insertion sort (O(N) for already sorted arrs) if partitions < 16
        //else uses heapsort (O(NlogN))
    }

    //removing data doesn't affect our sorted list.
    public void RemoveAt(int index){
        data.RemoveAt(index);
    }

    public void Remove(T item){
        data.Remove(item);
    }

    public T this[int index]{
        get{
            return data[index];
        }
        set{
            RemoveAt(index);
            Add(value);
        }
    }

    public int Count{
        get{
            return data.Count;
        }
    }

}
