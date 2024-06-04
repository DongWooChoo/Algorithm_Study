def matrixChain(n, p):
    # 비용을 저장할 2차원 리스트를 초기화합니다.
    m = [[0 for _ in range(n)] for _ in range(n)]
    
    # 행렬이 하나인 경우 비용은 0입니다.
    for i in range(n):
        m[i][i] = 0
    
    # r: 문제의 크기를 결정하는 변수, 문제의 크기 = r + 1
    for r in range(1, n):
        for i in range(1, n - r):
            j = i + r
            m[i][j] = float('inf')
            for k in range(i, j):
                m[i][j] = min(m[i][j], m[i][k] + m[k+1][j] + p[i-1] * p[k] * p[j])

    return m[1][n-1]

# 테스트를 위한 행렬 리스트입니다.
# 예를 들어, 행렬의 크기가 [[2,3],[3,7],[7,9],[9,2]]이라면,
# 행렬의 크기를 나타내는 리스트 p는 [2, 3, 7, 9, 2]가 됩니다.
matrix = [[2,3],[3,7],[7,9],[9,2]]
p = [matrix[0][0]] + [matrix[i][1] for i in range(len(matrix))]
n = len(p)

# 결과 출력
print(matrixChain(n, p))
