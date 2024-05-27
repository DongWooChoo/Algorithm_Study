V, E = 6, 8
edge = [0, 1, 0, 2, 0, 5, 0, 6, 4, 3, 5, 3, 5, 4, 6, 4]
adj_matrix = [[0]*(V+1) for _ in range(V+1)]
for i in range(E):
		# 2*i와 2*i+1은 edge 리스트에서 간선 정보를 가져오기 위한 인덱스
		num1, num2 = edge[2*i], edge[2*i+1]
		# 각 인덱스에 1을 할당하여 num1과 num2 사이에 간선의 존재 여부를 나타냄
		adj_matrix[num1][num2] = 1
		adj_matrix[num2][num1] = 1

print(adj_matrix )