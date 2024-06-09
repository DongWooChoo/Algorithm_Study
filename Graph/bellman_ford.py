def floyd_warshall_with_adj_list(graph, n):
    # 최단 거리 초기화
    dist = [[float('inf')] * n for _ in range(n)]
    for u in range(n):
        dist[u][u] = 0  # 자기 자신으로의 거리는 0

    # 그래프의 초기 간선 가중치로 최단 거리 테이블 초기화
    for u in graph:
        for v, weight in graph[u]:
            dist[u][v] = weight

    # 플로이드-워셜 알고리즘 실행
    for k in range(n):
        for i in range(n):
            for j in range(n):
                if dist[i][j] > dist[i][k] + dist[k][j]:
                    dist[i][j] = dist[i][k] + dist[k][j]

    return dist

# 예제 그래프 (인접 리스트 형식)
graph = {
    0: [(1, 2), (3, 6)],
    1: [(0, 2), (2, 3), (3, 8), (4, 5)],
    2: [(1, 3), (4, 7)],
    3: [(0, 6), (1, 8), (4, 9)],
    4: [(1, 5), (2, 7), (3, 9)]
}

# 그래프의 노드 수
n = len(graph)

# 플로이드-워셜 알고리즘 실행
distances = floyd_warshall_with_adj_list(graph, n)

# 결과 출력
for i in range(n):
    print(f"정점 {i}부터의 거리: {distances[i]}")
