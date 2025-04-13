def backpack(weights, values, capacity) : #배낭 문제 -> 주어진 가방에 용량을 만족시키며 최대한 가치가 높은 물건들을 넣는 문제
    n = len(weights)
    dp = [[0] * (capacity + 1) for _ in range(n + 1)] # 행은 아이템 인덱스, 열은 용량
    for i in range(1, n + 1): # 각 아이템을 봄
        for w in range(1, capacity + 1): # 용량을 1부터 증가시키면서 최적의 해를 찾음
            if weights[i - 1] > w: # 현재 아이템의 무게가 배낭의 용량보다 크다면
                dp[i][w] = dp[i - 1][w] # 해당 아이템을 넣을 수 없으므로 이전 행의 값을 그대로 가져온다
            else: # 현재 아이템을 배낭에 넣을 수 있다면
                dp[i][w] = max(dp[i - 1][w], values[i - 1] + dp[i - 1][w - weights[i - 1]]) # 현재 아이템을 넣었을 때와 넣지 않았을 때의 최대 가치 중 큰 값을 선택
    return dp[n][capacity]# 배낭에 담긴 아이템들의 최대 가치를 반환

print("배낭 문제")
print(backpack([2, 3, 6, 5],[3, 5, 6, 6],8))