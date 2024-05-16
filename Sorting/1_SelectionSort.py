def selectionSortDown(arr) : ## 내림차순
    for i in range(0,len(arr)) : #0,1,2,3,4,5,6 ....
        maxIndex = i
        for j in range(i,len(arr)) : 
            if(arr[maxIndex] < arr[j]) :
                maxIndex = j
        arr[maxIndex],arr[i] = arr[i],arr[maxIndex]
    return arr

def selectionSortUP(arr) : ##오름차순
    for i in range(len(arr)-1,0,-1) :
        maxIndex = i
        for j in range(0,i+1) :
            if(arr[maxIndex] < arr[j]) :
                maxIndex = j
        arr[maxIndex],arr[j] = arr[j],arr[maxIndex]
    return arr

def selectionSortUP2(arr) : ##오름차순
    for i in range(len(arr)-1,0,-1) :
        maxIndex = findLargest(arr, i)
        arr[maxIndex],arr[i] = arr[i],arr[maxIndex]
    return arr

def findLargest(arr,last) :
    largest = 0
    for i in range(1,last+1) :
        if(arr[largest] < arr[i]) :
            largest = i
    return largest

arr = [13, 2, 42, 45 ,23 ,12 ,54]

print("기본배열 : " , arr)
print("오름차순 : " , selectionSortUP2(arr))
print("내림차순 : " , selectionSortDown(arr))
print("오름차순 : " , selectionSortUP(arr))
