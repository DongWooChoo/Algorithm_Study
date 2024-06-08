def dijkstra(graph, r):
    V = len(graph)
    S = set()  # 방문한 정점들
    dist = [float('inf')] * V  # 각 정점까지의 최단 거리
    dist[r] = 0  # 시작 정점까지의 거리는 0
    parent = [None] * V  # 각 정점의 부모 (최단 경로 트리)

    while len(S) < V:
        u = extractMin(V, S, dist)  # 가장 가까운 정점 선택
        if u is None:  # 남은 정점이 없으면 중단
            break
        S.add(u)
        for v, weight in graph[u]:
            if v not in S and dist[u] + weight < dist[v]:  # 더 짧은 경로 발견
                dist[v] = dist[u] + weight
                parent[v] = u

    for i in range(V):
        if i != r and parent[i] is not None:
            print(f"{parent[i]} - {i}, weight: {dist[i]}")
            
def extractMin(G,S,dist): # 집합 G에서 S에 포함되지 않은 점정 줌 costs가 가장 작은 정점 u를 리턴한다.
    min_cost = float('inf')
    min_vertex = None

    for v in range(G):
        if v not in S and dist[v] < min_cost:
            min_cost = dist[v]
            min_vertex = v
    return min_vertex
    
graph = {
    0: [(1, 2), (3, 6)],
    1: [(0, 2), (2, 3), (3, 8), (4, 5)],
    2: [(1, 3), (4, 7)],
    3: [(0, 6), (1, 8), (4, 9)],
    4: [(1, 5), (2, 7), (3, 9)]
}

# 프림 알고리즘 실행 (시작 정점 0)
dijkstra(graph, 0)