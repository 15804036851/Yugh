using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practice
{
    /// <summary>
    /// 数组的排序
    /// </summary>
    public class SortPractice
    {
        #region 冒泡排序
        /// <summary>
        /// 冒泡排序
        /// </summary>
        public void ArraySort()
        {
            /* 冒泡排序：将数组元素中相邻两个元素的值进行比较，若升序排列， 则将较小的值放到前面，每一次交换都将最大的数放到最后，
                         依次交换后最终将数组中的元素从小到大排序。
                         循环次数为n(n - 1)/2, 最坏情况比较n(n - 1)/2次，最好情况比较n-1次
            */

            int[] array = { 3, 4, 7, 8, 1, 5, 2, 6, 9, 0 };
            int temp;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    // 升序排列
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;

                        // 不借助中间变量交换
                        //array[j + 1] = array[j + 1] + array[j];
                        //array[j] = array[j + 1] - array[j];
                        //array[j + 1] = array[j + 1] - array[j];
                    }
                }
            }
            Console.WriteLine("排列后的结果为：{0}", string.Join(" ", array));
            Console.ReadKey();

        }
        #endregion

        #region 选择排序
        /// <summary>
        /// 选择排序
        /// </summary>
        public void SelectionSort()
        {
            /* 选择排序：假设长度为n的数组arr，要按照从小到大排序，那么先从n个数字中找到最小值min1，
             *           如果最小值min1的位置不在数组的最左端(也就是min1不等于arr[0])，则将最小值min1和arr[0]交换，
                         接着在剩下的n-1个数字中找到最小值min2，
                         如果最小值min2不等于arr[1]，则交换这两个数字，依次类推，直到数组arr有序排列
            */

            int[] arr = new int[] { 4, 7, 6, 1, 5, 9, 2, 0, 3, 8 };
            int index;
            for (int i = 0; i < arr.Length; i++)
            {
                index = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[index])
                    {
                        index = j;
                    }
                }

                if (index != i)
                {
                    int temp = arr[index];
                    arr[index] = arr[i];
                    arr[i] = temp;
                }
            }
            Console.WriteLine("排列后的结果为：{0}", string.Join(" ", arr));
            Console.ReadKey();
        }
        #endregion

        #region 插入排序
        /// <summary>
        /// 插入排序
        /// </summary>
        public void InsertSort()
        {
            /* 插入排序：基本思想就是将无序序列插入到有序序列中。
                         例如要将数组arr=[4,2,8,0,5,1]排序，可以将第一个元素4看做是一个有序序列，将[2,8,0,5,1]看做一个无序序列。
                         无序序列中2比4小，于是将2插入到4的左边，此时有序序列变成了[2,4]，无序序列变成了[8,0,5,1]。
                         无序序列中8比4大，于是将8插入到4的右边，有序序列变成了[2,4,8],无序序列变成了[0,5,1]。
                         无序序列中0比8小，于是将0插入到8的左边，此时有序序列变成了[0,2,4,8]，无序序列变成了[5,1]。
                         以此类推，最终数组按照从小到大排序。
            */

            int[] arr = new int[] { 4, 7, 6, 1, 5, 9, 2, 0, 3, 8 };
            for (int i = 1; i < arr.Length; i++)
            {
                int j;
                if (arr[i] < arr[i - 1])
                {
                    int temp = arr[i];
                    for (j = i - 1; j >= 0 && temp < arr[j]; j--)
                    {
                        arr[j + 1] = arr[j];
                    }
                    arr[j + 1] = temp;
                }
            }
            Console.WriteLine("排列后的结果为：{0}", string.Join(" ", arr));
            Console.ReadKey();
        }
        #endregion

        #region 希尔排序
        /// <summary>
        /// 希尔排序
        /// </summary>
        public void ShellSort()
        {
            /* 希尔排序：基本思想就是先将待排记录序列分割成为若干子序列分别进行插入排序，待整个序列中的记录"基本有序"时，再对全体记录进行一次直接插入排序。
                         
            */

            int[] arr = new int[] { 4, 7, 6, 1, 5, 9, 2, 0, 3, 8 };

            int increasement = arr.Length;
            int i, j, k;
            do
            {
                // 确定分组的增量
                increasement = increasement / 3 + 1;
                for (i = 0; i < increasement; i++)
                {
                    for (j = i + increasement; j < arr.Length; j += increasement)
                    {
                        if (arr[j] < arr[j - increasement])
                        {
                            int temp = arr[j];
                            for (k = j - increasement; k >= 0 && temp < arr[k]; k -= increasement)
                            {
                                arr[k + increasement] = arr[k];
                            }
                            arr[k + increasement] = temp;
                        }
                    }
                }
            } while (increasement > 1);

            Console.WriteLine("排列后的结果为：{0}", string.Join(" ", arr));
            Console.ReadKey();
        }
        #endregion

        #region 快速排序
        /// <summary>
        /// 快速排序
        /// </summary>
        public void QuickSort()
        {
            /* 快速排序：通过一趟排序将待排记录分割成独立的两部分，其中一部分记录的关键字均比另一部分记录的关键字小，
                         则可分别对这两部分记录继续进行排序，已达到整个序列有序。
                         一趟快速排序的具体过程可描述为：从待排序列中任意选取一个记录(通常选取第一个记录)作为基准值，
                         然后将记录中关键字比它小的记录都安置在它的位置之前，将记录中关键字比它大的记录都安置在它的位置之后。
                         这样，以该基准值为分界线，将待排序列分成的两个子序列。

            一趟快速排序的具体做法为：设置两个指针low和high分别指向待排序列的开始和结尾，
            记录下基准值baseval(待排序列的第一个记录)，然后先从high所指的位置向前搜索直到找到一个小于baseval的记录并互相交换，
            接着从low所指向的位置向后搜索直到找到一个大于baseval的记录并互相交换，重复这两个步骤直到low=high为止。
            */

            int[] arr = new int[] { 4, 7, 6, 1, 5, 9, 2, 0, 3, 8 };

            this.QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine("排列后的结果为：{0}", string.Join(" ", arr));
            Console.ReadKey();
        }

        /// <summary>
        /// 快速排序的递归方法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            int i = start;
            int j = end;
            // 基准数
            int baseval = arr[start];

            while (i < j)
            {
                // 从右向左找比基准数小的数
                while (i < j && arr[j] >= baseval)
                {
                    j--;
                }
                if (i < j)
                {
                    arr[i] = arr[j];
                    i++;
                }
                // 从左向右找比基准数大的数
                while (i < j && arr[i] < baseval)
                {
                    i++;
                }
                if (i < j)
                {
                    arr[j] = arr[i];
                    j--;
                }
            }
            // 把基准数放到i的位置
            arr[i] = baseval;

            // 递归
            QuickSort(arr, start, i - 1);
            QuickSort(arr, i + 1, end);
        }
        #endregion

        #region 归并排序
        /// <summary>
        /// 归并排序
        /// </summary>
        public void MergeSort()
        {
            /* 归并排序：将两个或两个以上的有序序列组合成一个新的有序表。
                         假设初始序列含有n个记录，则可以看成是n个有序的子序列，每个子序列的长度为1，然后两两归并，
                         得到若干个长度为2(或者是1)的有序子序列，再两两归并。如此重复，直到得到一个长度为n的有序序列为止。
                         这种排序方法称为2-路归并排序
            */

            int[] arr = new int[] { 4, 7, 6, 1, 5, 9, 2, 0, 3, 8 };
            int[] temp = new int[arr.Length];
            this.MergeSort(arr, 0, arr.Length - 1, temp);

            Console.WriteLine("排列后的结果为：{0}", string.Join(" ", arr));
            Console.ReadKey();
        }

        /// <summary>
        /// 归并排序的递归方法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        void MergeSort(int[] arr, int start, int end, int[] temp)
        {
            if (start >= end)
                return;

            // 将元素组分成若干个子序列
            int mid = (start + end) / 2;
            MergeSort(arr, start, mid, temp);
            MergeSort(arr, mid + 1, end, temp);

            int length = 0;
            int i_start = start;
            int i_end = mid;
            int j_start = mid + 1;
            int j_end = end;

            // 合并两个子序列放入临时数组
            while (i_start <= i_end && j_start <= j_end)
            {
                if (arr[i_start] < arr[j_start])
                {
                    temp[length] = arr[i_start];
                    length++;
                    i_start++;
                }
                else
                {
                    temp[length] = arr[j_start];
                    length++;
                    j_start++;
                }
            }

            // 将左侧剩余元素放入临时数组
            while (i_start <= i_end)
            {
                temp[length] = arr[i_start];
                length++;
                i_start++;
            }

            // 将右侧剩余元素放入临时数组
            while (j_start <= j_end)
            {
                temp[length] = arr[j_start];
                length++;
                j_start++;
            }

            // 将临时数组里的数据放回原数组
            for (int i = 0; i < length; i++)
            {
                arr[start + i] = temp[i];
            }
        }
        #endregion

        #region 堆排序
        /// <summary>
        /// 堆排序
        /// </summary>
        public void HeapSort()
        {
            /* 堆排序：将待排序列构造成一个大顶堆(或小顶堆)，整个序列的最大值(或最小值)就是堆顶的根结点，
                       将根节点的值和堆数组的末尾元素交换，此时末尾元素就是最大值(或最小值)，
                       然后将剩余的n-1个序列重新构造成一个堆，这样就会得到n个元素中的次大值(或次小值)，
                       如此反复执行，最终得到一个有序序列。
            */

            int[] arr = new int[] { 4, 7, 6, 1, 5, 9, 2, 0, 3, 8 };
            int length = arr.Length;

            // 初始化堆
            // (length / 2 - 1) 是二叉树中最后一个非叶子节点的符号
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                HeapAdjust(arr, i, length);
            }

            // 交换堆顶元素和最后一个元素
            for (int i = length - 1; i >= 0; i--)
            {
                int temp = arr[i];
                arr[i] = arr[0];
                arr[0] = temp;
                HeapAdjust(arr, 0, i);
            }

            Console.WriteLine("排列后的结果为：{0}", string.Join(" ", arr));
            Console.ReadKey();
        }

        /// <summary>
        /// 堆的调整
        /// </summary>
        /// <param name="arr">待调整的数组</param>
        /// <param name="i">待调整的结点下标</param>
        /// <param name="length">数组的长度</param>
        void HeapAdjust(int[] arr, int i, int length)
        {
            // 调整i位置的结点，保存当前结点的下标
            int max = i;
            // 当前结点左右孩子结点的下标
            int lChild = i * 2 + 1;
            int rChild = i * 2 + 2;

            if (lChild < length && arr[lChild] > arr[max])
            {
                max = lChild;
            }
            if (rChild < length && arr[rChild] > arr[max])
            {
                max = rChild;
            }

            if (max != i)
            {
                int temp = arr[i];
                arr[i] = arr[max];
                arr[max] = temp;

                // 递归
                HeapAdjust(arr, max, length);
            }
        }
        #endregion
    }
}
