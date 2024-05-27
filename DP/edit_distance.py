def edit_distance(str1, str2) : #두 문자열의 최소 편집 거리
    m = len(str1) #첫번째 문자열의 길이
    n = len(str2) #두번째 문자열의 길이
    dp = [[0] * (n + 1) for _ in range(m + 1)] # 2차원의 행렬을 만듬
    for i in range(m + 1): #세로 열을 각 순서대로 
        dp[i][0] = i # 문자를 대입
    for j in range(n + 1): #가로 열에 각 순서대로 
        dp[0][j] = j # 문자를 대입

    for i in range(1, m + 1): #str1의 길이 만큼 반복
        for j in range(1, n + 1): #str의 길이 만큼 반복
            if str1[i - 1] == str2[j - 1]: # 현재 위치의 문자가 동일한 경우
                dp[i][j] = dp[i - 1][j - 1] # 편집이 필요하지 않으므로 대각선(왼쪽 위)의 값을 가져온다
            else: # 현재 위치의 문자가 동일하지 않은 경우
                # 세 가지 작업(삽입, 삭제, 대체) 중 최소값을 선택하고 1을 더한다.
                dp[i][j] = 1 + min(dp[i - 1][j], dp[i][j - 1], dp[i - 1][j - 1])
    return dp[m][n] # 단어 간의 편집 거리를 반환

print("두 문자열의 최소 편집 거리")
print(edit_distance("kitten","sitting"))