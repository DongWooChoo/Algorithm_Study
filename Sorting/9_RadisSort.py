def radixSort(arr):
    numDigits = len(str(max(arr)))
    n= len(arr)
    output = [0] * n
    for digit in range(1, numDigits + 1): #첫째자리 수부터 가장 큰 자릿수까지
        cnt = [0] * 10 # 10진수 이므로 10칸
        
        for i in range(n): # 배열의 자릿수의 각 값에 해당하는 cnt에 1씩 추가 => digit가 1일땐 1의 자리, 2일땐 10의 자리 ...
            cnt[(arr[i] // (10 ** (digit - 1))) % 10] += 1
            
        start = [0] * 10
        for d in range(1, 10): # 각 자릿수의 시작 위치를 구함.
            start[d] = start[d - 1] + cnt[d - 1]
        
        for i in range(n): # start를 참고하여 자릿수 별로 정렬된 배열을 만듬
            digit_value = (arr[i] // (10 ** (digit - 1))) % 10
            output[start[digit_value]] = arr[i]
            start[digit_value] += 1
        
        for i in range(n): # 각 자릿수 별로 정렬된 배열을 복사
            arr[i] = output[i]

# Example Usage
A = [170, 45, 75]
radixSort(A)
print("Sorted array is:", A)
