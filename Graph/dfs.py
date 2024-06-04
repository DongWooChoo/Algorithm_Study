from collections import deque


    
def DFS(G,s,visited): # G는 그래프, s는 시작 위치
    visited[s] = True
    print(s, end = ' ')
    for node in graph[s]:
        if not visited[node]:
            DFS(G,node,visited)
                
graph = [[1,2,3],[0,2],[0,1,3,4],[0,2,6],[2],[3,6,7],[3,5],[5]]
visited = [False] * (len(graph)+1)
DFS(graph,0,visited)