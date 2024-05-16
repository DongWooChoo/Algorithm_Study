def insertSort(arr) :
    for i in range(1, len(arr)):
        for j in range(i, 0, -1):
            if(arr[j-1] > arr[j]) :
                arr[j-1],arr[j]=arr[j],arr[j-1]
            else :
                break
    return arr

arr = [13, 2, 42, 45 ,23 ,12 ,54]

print("기본배열 : " , arr)
print("오름차순 : " , insertSort(arr))