def find(parent, u):
    if u != parent[u]:
        parent[u] = find(parent, parent[u])
    return parent[u]

def union(parent, rank, u, v):
    root_u = find(parent, u)
    root_v = find(parent, v)
    if root_u != root_v:
        if rank[root_u] > rank[root_v]:
            parent[root_v] = root_u
        elif rank[root_u] < rank[root_v]:
            parent[root_u] = root_v
        else:
            parent[root_v] = root_u
            rank[root_u] += 1

def kruskal(n, graph):
    parent = list(range(n))
    rank = [0] * n
    mst = []
    
    # 모든 간선을 가중치에 따라 정렬하기 위해 리스트로 변환
    edges = []
    for u in graph:
        for v, weight in graph[u]:
            if u < v:  # 중복 간선 제거
                edges.append((weight, u, v))
    edges.sort()  # 가중치에 따라 간선 정렬

    for weight, u, v in edges:
        if find(parent, u) != find(parent, v):
            union(parent, rank, u, v)
            mst.append((u, v, weight))
            if len(mst) == n - 1:
                break
    return mst

graph = {
    0: [(1, 2), (3, 6)],
    1: [(0, 2), (2, 3), (3, 8), (4, 5)],
    2: [(1, 3), (4, 7)],
    3: [(0, 6), (1, 8), (4, 9)],
    4: [(1, 5), (2, 7), (3, 9)]
}

n = len(graph)  # 정점의 수
mst = kruskal(n, graph)
print("최소 스패닝 트리:", mst)