def matrixMax(matrix):
    row = len(matrix) # 행의 갯수
    col = len(matrix[0]) # 열의 갯수
    for i in range(0,row): 
        for j in range(0,col):
            if i == 0 and j == 0: # 가장 좌측이며 가장 우측인 값인 경우 그대로 패스
                continue
            if i == 0: # 가장 좌측 값일 경우 위측의 값과 합침
                matrix[i][j] = matrix[i][j] + matrix[i][j-1]
                continue
            if j == 0: # 가장 위측 값일 경우 좌측의 값과 합침
                matrix[i][j] = matrix[i][j] + matrix[i-1][j]
                continue
            # 위의 조건에 해당하지 않을 경우 좌측의 값과 위측의 값들 중 큰 값과 합침
            matrix[i][j] = matrix[i][j] + max(matrix[i-1][j], matrix[i][j-1])

    return matrix

def matrixPath(matrix):
    row = len(matrix) # 행의 갯수
    col = len(matrix[0]) # 열의 갯수
    path = [[0 for _ in range(col)] for _ in range(row)] 
    row = row - 1 # 가장 끝의 인덱스는 갯수 - 1
    col = col - 1 # ""
    while row > 0 or col > 0:
        path[row][col] = 1 
        if col == 0 : # 우측을 못가는 경우는 무조건 좌측으로
            row = row - 1
        elif row == 0 : # 좌측으로 못가는 경우는 무조건 우측으로
            col = col - 1
        elif matrix[row-1][col] > matrix[row][col-1]: # 좌측값이 우측값보다 더 큰경우 좌측으로
            row = row - 1
        else :
            col = col -1
    path[0][0] = 1
    return path


matrix = [[6,7,12,5],[5,3,11,18],[7,17,3,3],[8,10,14,9]]
print("기존 행렬")
for i in range(len(matrix)):
    print(matrix[i])
matrix = matrixMax(matrix)
print("수정후 행렬")
for i in range(len(matrix)):
    print(matrix[i])
route = matrixPath(matrix)
print("경로")
for i in range(len(route)):
    print(route[i])