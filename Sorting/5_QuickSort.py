def quickSort(arr,left,right) :
    if(left < right) :
        q = partion(arr,left,right)
        quickSort(arr,left,q-1)
        quickSort(arr,q+1,right)       
    return arr

def partion(arr,left,right) :
    pivot = arr[right]
    low = left
    high = right - 1
    while(low <= high) :
        while(arr[low] <= pivot and low <= high) :
            low += 1
        while(arr[high] >= pivot and low <= high) :
            high -= 1
        if(low < high) :
            arr[low],arr[high] = arr[high],arr[low]
    arr[right], arr[low]= arr[low], arr[right]
    return low
    
arr = [6,15,13,6]
for i in range(len(arr)) :
    print(arr[i] , " ", end = "")
print()
print("오름차순 : " , quickSort(arr,0,len(arr)-1))