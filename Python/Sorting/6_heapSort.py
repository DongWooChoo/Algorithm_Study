
def heapSort(arr) :
    n = len(arr)
    for i in range(n//2 - 1, -1, -1) : # 중간 값(자식이 있는 인덱스)부터 시작하여 상단 인덱스로 올라가면서 힙 정렬 => 힙 구조를 갖춤
        heapify(arr, n, i)
    for i in range(n-1, 0, -1) : # 배열의 가장 큰 값을 맨 뒤로 보내고 힙 크기를 1씩 줄이며 반복 => 정렬된 배열로 바뀜
        arr[i], arr[0] = arr[0], arr[i]
        heapify(arr, i, 0)

def heapify(arr,heap_size,index) :
    largest = index # 최댓값은 일단 현재 위치로 설정 
    left = 2 * index + 1 # 왼쪽 자식의 인덱스
    right = 2 * index + 2 # 오른쪽 자식의 인덱스
    if left < heap_size and arr[left] > arr[largest] : # 왼쪽 자식의 값이 부모보다 크면 largest를 왼쪽 자식 인덱스로
        largest = left
    if right < heap_size and arr[right] > arr[largest] : # 오른쪽 자식의 값이 (부모 혹은 왼쪽 자식)보다 크면 largest를 오른쪽 자식 인덱스로
        largest = right
    if largest != index : # 가장 큰 값의 인덱스 현재 인덱스가 아니라면 힙 정렬을 수행해야함
        arr[index], arr[largest] = arr[largest], arr[index] #현재 인덱스와 가장 큰 값의 인덱스와 교환
        heapify(arr, heap_size, largest) # 아래쪽으로 내려가서 힙 정렬 수행


arr = [16,4,10,14,7,9,3,2,8,1]
heapSort(arr)
print(arr)