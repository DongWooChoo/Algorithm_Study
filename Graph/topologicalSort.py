def dfs(v, visited, stack, graph):
    visited[v] = True
    for neighbor, weight in graph[v]:
        if not visited[neighbor]:
            dfs(neighbor, visited, stack, graph)
    #stack.append(v)  # 현재 노드를 스택에 추가

def topological_sort(graph):
    visited = {node: False for node in graph}
    stack = []

    for node in graph:
        if not visited[node]:
            dfs(node, visited, stack, graph)
    
    return stack[::-1]  # 스택을 역순으로 반환하여 위상 정렬 결과 얻기

# 제공된 그래프 데이터 (간선에 가중치가 있지만, 위상 정렬에는 무시됨)
graph = {
    0: [(1, 2), (3, 6)],
    1: [(2, 3), (3, 8), (4, 5)],
    2: [(1, 3), (4, 7)],
    3: [(4, 9)],
    4: []
}

order = topological_sort(graph)
print("위상 정렬 결과:", order)