def max_subarray_sum(array) : #최대 부분 배열 합
    max_sum = array[0] # 최대 합 초기 값 설정
    current_sum = array[0] # 현재 합 초기 값 설정
    for num in array[1:]: #첫번째 부터 끝까지 반복
        current_sum = max(num,current_sum + num) #현재 값과 현재 합에 지금 값을 더한값과 비교하여 더 큰 값으로 설정
        max_sum = max(max_sum, current_sum) # 최대 합과 현재 값과 비교하여 더 큰 값을 최대 합으로 설정
    return max_sum

print("최대 부분 배열 합")
print(max_subarray_sum([1,5,-3,4,9,-20,5,6]))