from collections import deque

def BFS(G,s): # G는 그래프, s는 시작 위치
    queue = []
    visited = [False] * (len(G)+1)
    visited[s] = True
    queue.append(s)
    while queue :
        u = queue.pop(0) # 큐에 있는 것을 꺼낸 후 해당 정점과 연결된 것들 중 방문하지 않은 것들을 노드에 추가한다.
        print(u, end = ' ')
        for i in graph[u]:
            if not visited[i] :
                visited[i] = True
                queue.append(i)
                
graph = [[1,2,3],[0,2],[0,1,3,4],[0,2,6],[2],[3,6,7],[3,5],[5]]
BFS(graph,0)