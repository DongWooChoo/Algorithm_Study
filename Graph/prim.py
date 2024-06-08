def Prim(G,r):
    V = len(G)
    S = set() # 빈집합 생성
    costs = [float('inf')] * V # 각 경로로의 비용은 무제한
    costs[r] = 0 # 시작 경로까지의 비용은 0
    parent = [None] * V
    while (len(S) < V):
        u = extractMin(G,S,costs) #집합 S중에서 가장 값이 적은 정점 u를 리턴
        if u is None : # 모든 정점을 전부 방문한 경우 중단
            break
        S.add(u) 
        for v, weight in graph[u]:
                if v not in S and weight < costs[v]:
                    costs[v] = weight
                    parent[v] = u
    for i in range(1, V):
        if parent[i] is not None:
            print(f"{parent[i]} - {i}, weight: {costs[i]}")
def extractMin(G,S,costs):
    min_cost = float('inf')
    min_vertex = None

    for v in range(len(G)):
        if v not in S and costs[v] < min_cost:
            min_cost = costs[v]
            min_vertex = v
    return min_vertex
    
    
# 그래프 정의 (인접 리스트 형태)
graph = {
    0: [(1, 2), (3, 6)],
    1: [(0, 2), (2, 3), (3, 8), (4, 5)],
    2: [(1, 3), (4, 7)],
    3: [(0, 6), (1, 8), (4, 9)],
    4: [(1, 5), (2, 7), (3, 9)]
}

# 프림 알고리즘 실행 (시작 정점 0)
Prim(graph, 0)