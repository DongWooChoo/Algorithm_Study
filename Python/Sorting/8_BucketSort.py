def insertSort(arr) :
    for i in range(1, len(arr)):
        for j in range(i, 0, -1):
            if(arr[j-1] > arr[j]) :
                arr[j-1],arr[j]=arr[j],arr[j-1]
            else :
                break
    return arr

def bucket_sort(arr):
    n = len(arr)
    output = [[] for _ in range(n)] # 각각이 리스트인 배열
    
    for i in range(n):
        index = int(n * arr[i] / (max(arr) + 1)) # 만약 값이 소수라면 특정 값(배열크기)을 곱하여 정수부분만 추출 => 인덱스가 해당 정수인 곳에 값을 추가
        output[index].append(arr[i]) 
    
    for i in range(n): # 삽입 정렬을 수행
        insertSort(output[i])
    
    
    index = 0
    for i in range(n): # 정렬된 버킷을 다시 원래 배열로 합침
        for j in range(len(output[i])):
            arr[index] = output[i][j]
            index += 1

# 예시 입력 데이터
A = [13, 2, 42, 45 ,23 ,12 ,0.3]

print("Before Bucket Sort:", A)
bucket_sort(A)
print("After Bucket Sort:", A)
