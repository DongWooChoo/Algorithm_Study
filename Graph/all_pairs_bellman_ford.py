def bellman_ford(graph, r):
    # 그래프의 정점 수 만큼 거리 정보를 무한대로 초기화
    distance = {vertex: float('inf') for vertex in graph}
    # 시작 정점의 거리를 0으로 초기화
    distance[r] = 0

    # 정점 수 - 1 만큼 반복
    for _ in range(len(graph) - 1):
        # 그래프의 모든 간선에 대해 반복
        for u in graph:
            for v, weight in graph[u]:
                # 간선을 따라 갈 때 거리가 더 짧아지는 경우, 거리를 업데이트
                if distance[u] + weight < distance[v]:
                    distance[v] = distance[u] + weight

    # 음의 사이클 존재 여부를 검사하는 부분
    for u in graph:
        for v, weight in graph[u]:
            if distance[u] + weight < distance[v]:
                print("Graph contains negative weight cycle")
                return None

    return distance

def all_pairs_bellman_ford(graph):
    n = len(graph)
    all_distances = []
    for start in range(n):
        dist_from_start = bellman_ford(graph, start)
        all_distances.append(dist_from_start)
    return all_distances

# 예제 그래프
graph = {
    0: [(1, 2), (3, 6)],
    1: [(0, 2), (2, 3), (3, 8), (4, 5)],
    2: [(1, 3), (4, 7)],
    3: [(0, 6), (1, 8), (4, 9)],
    4: [(1, 5), (2, 7), (3, 9)]
}

all_distances = all_pairs_bellman_ford(graph)
for dist in all_distances:
    print(dist)