using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    public class SortMethods
    {
        private static int[] _array;
        private static int _lastSortedItem;
        public static void DoHeapSort(int[] array)
        {
            _array = array;
            for (int i = 0; i < (_array.Length-1)/2; i++)
            {
                int childIndexLeft = i * 2 + 1;
                int childIndexRight = i * 2 + 2;
                SortNodeUp(i,childIndexLeft);
                SortNodeUp(i,childIndexRight);
            }
            for (int i = _array.Length-1; i >0; i--) 
            {
                
                Swap( 0, i);
                _lastSortedItem = i;
                SortNodeDown( 0, GetIndexOfMaxValue(1, 2));

            }

        }
        private static void Swap(int i1,int i2)
        {
            int temp=_array[i1];
            _array[i1]=_array[i2];
            _array[i2]=temp;
        }
        private static void SortNodeUp(int father, int child)
        {
            if (_array[father] < _array[child])
            {
                Swap( father, child);
                int grandFatherIndex = (father - 1) / 2;
                SortNodeUp( grandFatherIndex, father);
            }  
        }
        private static void SortNodeDown(int current,int child)
        {
            if (_array[current] < _array[child]&&child<_lastSortedItem)
            {
                Swap(current, child);
                int grandSonLeft = child*2+1;
                int grandSonRight=child*2+2;
                if(grandSonLeft<=_lastSortedItem&&grandSonRight<=_lastSortedItem)
                {
                    int maxGrandSon = GetIndexOfMaxValue(grandSonRight, grandSonLeft);
                    SortNodeDown(child, maxGrandSon);
                }

            }
        }
        private static int GetIndexOfMaxValue(int i1,int i2)
        {
            if (_array[i1] >= _array[i2]) return i1;
            else return i2;
            
        }
    }
}
