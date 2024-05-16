

def countingSort(arr) : 
    n = len(arr)
    count = [0] * (max(arr) + 1) # 최대값 크기의 배열을 생성
    output = [0] * (n)
    for i in range(0,n) : # 각 배열의 값을 count 인덱스로 개수를 파악
        count[arr[i]] += 1
    for i in range(1, len(count)) : # 누적합으로 만듬 
        count[i] += count[i - 1]
    for i in range(0,n) : 
        output[count[arr[i]] - 1] = arr[i] # 해당 배열의 값에 해당하는 누적합 값을 찾고 누적합 값에 해당하는 위치의 output 배열에 값을 삽입
        count[arr[i]] -= 1 # 해당 위치의 누적합 값을 1 감소
    for i in range(0, n) : 
        arr[i] = output[i]
        
arr = [10,2,5,8,9]
countingSort(arr)
print(arr)