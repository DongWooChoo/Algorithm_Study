def peddle(matrix):
    row = len(matrix) # 행의 갯수
    col = len(matrix[0]) # 열의 갯수
    for i in range(1,col): # 1열은 패스
        for j in range(0,row): #
            if j == 0:
                matrix[j][i] = matrix[j][i] + max(matrix[1][i-1],matrix[2][i-1])
            if j == 1:
                matrix[j][i] = matrix[j][i] + max(matrix[0][i-1],matrix[2][i-1],matrix[0][i-1]+matrix[2][i-1])
            if j == 2:
                matrix[j][i] = matrix[j][i] + max(matrix[0][i-1],matrix[1][i-1])
    for i in range(len(matrix)):
        print(matrix[i])

matrix = [[6,7,12,-5,5],[-8,10,14,9,7],[11,12,7,4,8]]
peddle(matrix)
# 보류
