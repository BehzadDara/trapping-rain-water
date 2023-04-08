#region Problem
/*
Given n non-negative integers representing an elevation map where the width of each bar is 1, 
compute how much water it can trap after raining.

Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. 
In this case, 6 units of rain water (blue section) are being trapped.

Input: height = [4,2,0,3,2,5]
Output: 9

LeetCode link: https://leetcode.com/problems/trapping-rain-water/
*/
#endregion

#region Solution
//Console.WriteLine(Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
//Console.WriteLine(Trap(new int[] { 4, 2, 0, 3, 2, 5 }));
//Console.WriteLine(Trap(new int[] { 5, 4, 1, 2 }));
Console.WriteLine(Trap(new int[] { 1, 7, 8 }));

int Trap(int[] height)
{
    var result = 0;

    var end = 0;
    while (end < height.Length - 1)
    {
        var begin = end;

        while (begin < height.Length - 1 && height[begin] <= height[begin + 1])
            begin++;
        end = begin + 1;

        while (end < height.Length - 1 && height[end] >= height[end + 1])
            end++;

        while (end < height.Length - 1 && height[end] <= height[end + 1])
            end++;

        var tmp = end;
        while (tmp < height.Length - 1)
        {
            tmp++;
            if (height[end] <= height[begin] && height[end] <= height[tmp])
            {
                end = tmp;
            }
        }

        if (end > height.Length - 1)
            break;

        var minHeight = Math.Min(height[begin], height[end]);
        for (int i = begin + 1; i < end; i++)
        {
            if (minHeight - height[i] > 0)
                result += minHeight - height[i];
        }
    }

    return result;
}
#endregion