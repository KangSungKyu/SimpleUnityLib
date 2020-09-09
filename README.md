# SimpleUnityLib
내 개인 프로젝트용으로 모아둔것들

UIAction
- ui tween 함수 (컴포넌트)구현, 시퀸스 형식으로 다수의 tween을 관리 가능
- ui로 행동할 수 있는 함수들 구현한 것들(text의 경우 바로 변환하거나 타자입력하듯이 차례대로 변환하거나 등등..)

EventableType
- 설명에도 적었지만 간단하게 value가 변하기 전,후에 대해서 이벤트 처리하는거 클래스로 묶어주고
- EventableType <-> BasicType 간에 암묵적 캐스팅 정도 (어차피 value+event가 붙은거니) 추가함

CSVReader
- 읽어들인 csv파일 string을 파싱합니다.
- 기본적으로 첫번째 줄의 필드유무, 전체 단위 토큰, 줄 단위 토큰을 지정합니다.
