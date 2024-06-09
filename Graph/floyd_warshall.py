def floyd_warshall(graph):
    # 정점의 수
    n = len(graph)
    
    # 최단 거리 초기화
    distance = [[float('inf')] * n for _ in range(n)]
    
    # 자기 자신으로 가는 거리는 0으로 초기화
    for i in range(n):
        distance[i][i] = 0
    
    # 그래프의 초기 간선 가중치로 최단 거리 테이블 초기화
    for i in range(n):
        for j in range(n):
            if graph[i][j] is not None:
                distance[i][j] = graph[i][j]
    
    # 플로이드-워셜 알고리즘 실행
    for k in range(n):
        for i in range(n):
            for j in range(n):
                if distance[i][j] > distance[i][k] + distance[k][j]:
                    distance[i][j] = distance[i][k] + distance[k][j]
    
    return distance