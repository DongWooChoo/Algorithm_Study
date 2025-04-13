def LCS_num(m,n): #최장 공통 부분 순서의 길이 구하는 함수
    C = [[0 for j in range(len(n) + 1)] for i in range(len(m) + 1)]
    for i in range(1,len(m)+1): #m번 만큼 반복
        for j in range(1,len(n)+1): #n번 만큼 반복
            if m[i-1] == n[j-1] : # 두 문자열이 같다면 이전 값보다 1높게
                C[i][j] = C[i-1][j-1] + 1
            else :
                C[i][j] = max(C[i-1][j],C[i][j-1]) # 좌측값, 위측값들 중 큰 값으로 설정
    return C[len(m)][len(n)] # 최종 공통 부분 순서의 길이를 반환
# 배열의 크기를 글자수 + 1로 하여 -1,-1을 0이 나타나도록 함, for문 역시 1부터 시작하여 len까지 반복하며 해당 문자의 인덱스는 -1 시켜야함

def LCS_str(m,n): #최장 공통부분 순서 구하는 함수
    C = [['' for j in range(len(n) + 1)] for i in range(len(m) + 1)]
    for i in range(1,len(m)+1): #m번 만큼 반복
        for j in range(1,len(n)+1): #n번 만큼 반복
            if m[i-1] == n[j-1] : # 두 문자가 같다면 이전 값에 해당 문자를 추가
                C[i][j] = C[i-1][j-1] + m[i-1]
            else :
                if len(C[i-1][j]) > len(C[i][j-1]) : # 좌측값, 위측값들 중 긴 값으로 설정
                    C[i][j] = C[i-1][j]
                else :
                    C[i][j] = C[i][j-1]
    return C[len(m)][len(n)] # 최종 공통 부분 순서를 반환

print("최장 공통 부분 순서의 길이")
print(LCS_num("ABCD","ABCDA"))
print("최장 공통부분 순서")
print(LCS_str("ABCD","ABCDA"))