def pebble(n, weights):
    # n은 행의 수, weights는 n x 4 매트릭스
    if n == 0:
        return 0
    
    # 동적 프로그래밍 테이블 초기화
    peb = [[0] * 4 for _ in range(n)]

    # 첫 번째 행 초기화
    for p in range(4):
        peb[0][p] = weights[0][p]

    # 두 번째 행부터 마지막 행까지 계산
    for i in range(1, n):
        for p in range(4):
            max_val = float('-inf')
            for q in range(4):
                if q != p:  # 다른 열을 선택해야 함
                    max_val = max(max_val, peb[i-1][q])
            peb[i][p] = max_val + weights[i][p]

    # 마지막 행의 최대 값 반환
    return max(peb[n-1])

# 예제 데이터
weights = [
    [6, 7, 12, -5,5],
    [-8, 10, 14, 9,7],
    [11, 12, 7, 4,8]
]

# 매트릭스의 행의 수
n = len(weights)

# 최대 점수 계산
max_score = pebble(n, weights)
print(f"최고 점수: {max_score}")
