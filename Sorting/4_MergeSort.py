def mergeSort(arr,left,right) : 
    if (left < right) :
        mid = (left + right) // 2  # //이게 중요
        mergeSort(arr,left,mid)
        mergeSort(arr,mid+1,right)
        merge(arr,left,right,mid)
    return arr

def merge(arr,left,right,mid) :
    temp = [0] * (right-left+1)
    index = 0
    low = left
    high = mid + 1
    while(low <= mid and high <= right) :
        if(arr[low] <= arr[high]) :
            temp[index] = arr[low]
            low +=1
            index +=1
        else :
            temp[index] = arr[high]
            high +=1
            index +=1
    while(low <= mid) :
        temp[index] = arr[low]
        low +=1
        index +=1
    while(high <= right) :
        temp[index] = arr[high]
        high +=1
        index +=1
    
    for i in range(len(temp)):
        arr[left + i] = temp[i]
    return arr

arr = [13, 2, 42, 45 ,23 ,12 ,54]
print("기본배열 : " , arr)
print("오름차순 : " , mergeSort(arr,0,len(arr)-1))
arr1, arr2, arr3 = [arr] * 3
print(arr1)
print(arr2)