import time, random
# 선택 정렬
def selectionSortUP(arr) : ##오름차순
    for i in range(len(arr)-1,0,-1) :
        maxIndex = i
        for j in range(0,i+1) :
            if(arr[maxIndex] < arr[j]) :
                maxIndex = j
        arr[maxIndex],arr[j] = arr[j],arr[maxIndex]
    return arr

# 합병 정렬
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

arr = random.sample(range(100000), 10000)
start_time = time.time() # 시간 측정 시작
selectionSortUP(arr) # 선택 정렬 수행
end_time = time.time() # 시간 측정 종료
execution_time = end_time - start_time
print(f"선택 정렬 소요시간: {execution_time}")
start_time = time.time() # 시간 측정 시작
mergeSort(arr,0,len(arr)-1) # 합병 정렬 수행
end_time = time.time() # 시간 측정 종료
execution_time = end_time - start_time
print(f"병합 정렬 소요시간: {execution_time}")

#1. 성능 측정 방법 설명
#10000개의 랜덤으로 주어진 배열을 정렬하기 위해 선택정렬과 병합정렬을 사용하며, 각 정렬이 수행되는데 소요되는 시간을 time라이브러리를 이용하여 측정한다.
#2. 성능 측정 결과 제시 
#선택 정렬 소요시간: 9.987446784973145
#병합 정렬 소요시간: 0.13021278381347656
#위의 코드를 실행해본 결과이며 병합 정렬이 훨씬 적은 시간이 소요된다는 것을 알 수 있다.
#3. 성능 차이가 많이 발생하는 이유 설명
#선택정렬은 모든 요소들을 순차적으로 비교하고 가장 작은 값을 선택하여 자리를 바꾸는 방식으로 O(n^2)의 시간 복잡도를 가지는 알고리즘입니다.
#한편 합병정렬은 배열을 재귀적으로 반으로 나누고 각각을 정렬한 다음 합치는 방법이기에 O(nlongn)의 시간복잡도를 가지는 알고리즘입니다.
#위의 시간복잡도의 차이로 인해 위와 같은 시간차이가 발생하였습니다.
