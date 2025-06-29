import java.io.*;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        /**
         * 변수 초기화 영역
         */
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder();
        StringTokenizer st;

        /**
         * 데이터 초기 설정 영역
         */
        // 스위치 개수 저장
        int switchCnt = Integer.parseInt(br.readLine());
        // 스위치 상태 정보 저장
        int[] switchList = new int[switchCnt + 1];
        st = new StringTokenizer(br.readLine());
        for(int i = 0; i < switchCnt; i++) {
            switchList[i + 1] = Integer.parseInt(st.nextToken());
        }
        // 학생 수 저장
        int studentCnt = Integer.parseInt(br.readLine());
        // 학생 성별 및 스위치 번호 저장
        int[][] students = new int[studentCnt][2];
        for (int i = 0; i < studentCnt; i++) {
            st = new StringTokenizer(br.readLine());
            students[i][0] = Integer.parseInt(st.nextToken()); // 성별
            students[i][1] = Integer.parseInt(st.nextToken()); // 숫자
        }

        /**
         * 문제 해결 영역
         */
        for(int i = 0; i < studentCnt; i++) {
            int studentGender = students[i][0];
            int switchNum = students[i][1];
            // 남학생의 경우, 자신이 받은 스위치 번호의 배수인 스위치를 전부 토클처리
            if(studentGender == 1) {
                for(int j = switchNum; j <= switchCnt;  j+= switchNum) {
                    switchList[j] ^= 1;
                }
            }
            // 여학생의 경우, 자신이 받은 스위치 번호를 중심으로 좌우가 대칭이면서 가장 많은 스위치를 포함하는 구간을 찾아 전부 토글처리
            else {
                int leftNum = switchNum - 1;
                int rightNum = switchNum + 1;
                switchList[switchNum] ^= 1; // 우선 기준 스위치 토글 처리
                while(leftNum >= 1 && rightNum <= switchCnt && switchList[leftNum] == switchList[rightNum]) { // 좌와 우의 스위치 상태가 동일한 경우 토글 처리
                    switchList[leftNum] ^= 1;
                    switchList[rightNum] ^= 1;
                    leftNum--;
                    rightNum++;
                }
            }
        }

        /**
         * 결과 출력 영역
         */
        for (int i = 1; i <= switchCnt; i++) {
            sb.append(switchList[i]).append(" ");
            if (i % 20 == 0) sb.append("\n");
        }
        System.out.println(sb);
    }
}