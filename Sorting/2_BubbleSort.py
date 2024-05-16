def bubbleSort(arr) :
    for i in range(len(arr) - 1) :
        for j in range(i,len(arr) - i - 1) :
            if(arr[j]>arr[j+1]) :
                arr[j],arr[j+1] = arr[j+1],arr[j]
    return arr

arr = [13, 2, 42, 45 ,23 ,12 ,54]

print("기본배열 : " , arr)
print("오름차순 : " , bubbleSort(arr))