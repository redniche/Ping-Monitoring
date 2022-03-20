<!-- @format -->

Language: [한국어]

<br>

## 소개

인터넷의 특정 네트워크 기기와의 핑테스트를 위해 만들어진 프로그램입니다. 인트라넷 상황에서 내부망을 관제해야할 때 사용하고자 진행했습니다.
**정식 릴리즈되지 않은 코드를 빌드, 사용시 어떠한 법적 책임도 지지 않음을 명시합니다.**

## 기술스택

<table>
    <th>범주</th>    
    <th>스택</th>
    <tr>
        <td>언어</td>
        <td><img src="https://img.shields.io/badge/C%23-007ACC?style=flat&logo=CSharp&logoColor=white"></td>
    </tr>
    <tr>
        <td>프레임워크</td>
        <td><img src="https://img.shields.io/badge/.Net Framework-007ACC?style=flat&logo=DotNet&logoColor=white"></td>
    </tr>
</table>

## 개발 환경

- Framework: .Net Framework 4.7.1
- IDE: Visual Studio 2019(back up)
- Language: C#

---

## 사용법

![실행](/image/초기화면.png)

![실행](/image/실행화면.png)

### 지원기능

#### 네트워크 모니터링

- 망이름 (공백 혹은 Tabs) 1.1.1.1(ip형식)
- 1.1.1.1(ip형식)

과 같이 입력 후 Start 버튼 클릭. Start를 누르면 입력창은 전부 \*로 변합니다.

핑 모니터링 목록은 열과 행으로 구분되는데 줄바꿈으로 열을 추가합니다.

핑상태는 라벨의 색으로 구분합니다.
초록색: 핑 100 이하  
주황색: 핑 200 이하  
빨간색: 핑 200 초과  
보라색: 연결불가

#### 투명도 조절

화면의 투명도를 아래의 스크롤바를 이용해 변경할 수 있습니다.

#### IP 노출 방지

화면에 표시된 IP 주소는 모두 \*로 처리됩니다.
모니터링 정지시에는 비밀번호가 필요합니다. '예찬3'  
3번 틀릴시 프로그램 강제 종료됩니다.

비밀번호 갱신 기능은 필요시 업데이트 예정입니다.
