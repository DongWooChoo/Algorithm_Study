def greedy_max_weight(I, S, w):
    # I는 독립 집합인지 확인하는 함수
    def is_independent_set(A):
        return A in I

    A = set()
    
    # S의 원소들을 가중치 기준 내림차순으로 정렬
    sorted_S = sorted(S, key=lambda x: w[x], reverse=True)

    for x in sorted_S:
        if is_independent_set(A | {x}):
            A.add(x)
    
    return A

# 예시를 위한 독립 집합의 정의와 가중치 배열
# 예를 들어, S = {1, 2, 3, 4}이고, I는 {∅, {1}, {2}, {1, 3}, {2, 4}}로 정의된다고 가정
S = {1, 2, 3, 4}
I = [set(), {1}, {2}, {1, 3}, {1, 2, 4}, {1,2}] #{1,2}가 없다면 1추가 -> 2추가 X -> 3추가 -> 4추가 X가 진행되게 되므로 {1,3}이 된다.
w = {1: 4, 2: 3, 3: 2, 4: 1}

# 함수 실행
result = greedy_max_weight(I, S, w)
print("최대 가중치 합을 갖는 독립 집합:", result)
