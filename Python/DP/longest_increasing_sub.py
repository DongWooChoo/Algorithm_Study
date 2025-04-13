def LIS_num(array) : #최장 증가 부분 수열의 길이
    n = len(array) # 배열의 길이를 저장
    lis = [1] * n # 모든 요소에서 최소 lis의 값은 1이다
    for i in range(1,n) : #1부터 배열의 길이 만큼 반복
        for j in range(i): #i만큼 반복W
            if array[i] > array[j] and lis[i] < lis[j] + 1: # 현재 값이 이전 값보다 작고, 현재 lis의 값이 이전 lis보다 크지 않은 경우 증가
                lis[i] = lis[j] + 1 #lis를 증가
    return max(lis) #lis의 최대값을 반환

print("최장 증가 부분 수열의 길이")
print(LIS_num([1,5,-3,4,9,-20,5,6]))