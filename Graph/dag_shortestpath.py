# 사이클이 없는 유향 그래프의 최단 경로

def dag_shortest_path(graph, start):
    # 위상 정렬 수행
    top_order = topological_sort(graph)
    
    # 거리 초기화
    distances = {node: float('inf') for node in graph}
    distances[start] = 0
    
    # 위상 정렬된 순서대로 경로 업데이트
    for node in top_order:
        if distances[node] != float('inf'):
            for neighbor, weight in graph[node]:
                if distances[neighbor] > distances[node] + weight:
                    distances[neighbor] = distances[node] + weight
    
    return distances
    
    
def dfs(v, visited, stack, graph):
    visited[v] = True
    for neighbor, weight in graph[v]:
        if not visited[neighbor]:
            dfs(neighbor, visited, stack, graph)
    stack.append(v)  # 현재 노드를 스택에 추가

def topological_sort(graph):
    visited = {node: False for node in graph}
    stack = []

    for node in graph:
        if not visited[node]:
            dfs(node, visited, stack, graph)
    
    return stack[::-1]  # 스택을 역순으로 반환하여 위상 정렬 결과 얻기

# 예제 그래프 (인접 리스트 형식)
graph = {
    0: [(1, 2), (3, 6)],
    1: [(0, 2), (2, 3), (3, 8), (4, 5)],
    2: [(1, 3), (4, 7)],
    3: [(0, 6), (1, 8), (4, 9)],
    4: [(1, 5), (2, 7), (3, 9)]
}

# 최단 경로 계산
distances = dag_shortest_path(graph, 1)
print("최단 경로:", distances)