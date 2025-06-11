기능 소개
1. ATM 서비스 안내
2. 로그인
3. 회원 가입
4. 아이디/패스워드를 통한 ATM 접근 서비스
5. 입금
6. 출금
7. 데이터 관리


   ATM 서비스
   1) 처음 ATM서비스를 시작하면 ID/PW 검사 및 회원가입을 위한 UI가 나옵니다.
   2) 회원 가입에서 ID/PW 그리고 Name을 입력하면 회원가입이 완료됩니다.
   3) ID/PW를 입력하면 ATM 서비스를 이용할 수 있습니다.
   4) Balance는 계좌 잔액입니다.
   5) Cash는 사용자 현금입니다.
   6) Deposite은 입금, Withdraw는 출금 기능입니다.
      
![스크린샷 2025-06-11 104721](https://github.com/user-attachments/assets/27a3154c-192a-49c8-b7c3-b532fdb07386)

   로그인 기능
   1) 데이터 베이스에 저장된 ID/PW(대소문자 일치, 영문 및 숫자만 가능)가 일치해야 ATM 이용이 가능합니다.

![스크린샷 2025-06-11 104732](https://github.com/user-attachments/assets/f9d20aec-a780-40cb-a548-3a5b2a7577e5)

   회원 가입 기능
   1) 회원 가입 버튼을 누르면 회원가입 창이 켜집니다.
   2) ID와 PW는 영문이나 숫자를 입력해야 하지만, Name은 한글도 가능합니다.
   3) ID, PW 단어 수는 제한없이 가능합니다.(한 자리도 가능)
   4) PW와 PW Confirm은 일치해야 합니다.
   5) Sign Up 버튼을 누르면 회원가입이 완료됩니다.

![스크린샷 2025-06-11 104811](https://github.com/user-attachments/assets/7ab640e7-366c-40cc-88a2-4ebaa1c0891f)
![스크린샷 2025-06-11 104837](https://github.com/user-attachments/assets/1fb657da-1618-415b-95dd-905dae41011e)
   아이디/패스워드 검사 기능
   1) 회원가입한 정확한 ID와 PW를 입력해야 ATM 이용이 가능합니다.

![스크린샷 2025-06-11 104854](https://github.com/user-attachments/assets/93f81a0a-e66f-429f-9e32-92b3d462a366)
   입금 기능
   1) 입금 창에서 정해진 금액으로 입금하거나 사용자가 원하는 금액으로 입금하는 기능이 구현되어 있습니다.
   2) 금액이 사용자가 가지고 있는 Cash보다 많으면 오류가 뜨고 입금되지 않습니다.
   3) 뒤로 가기 버튼을 누르면 입금 기능이 비활성화됩니다.

![스크린샷 2025-06-11 104902](https://github.com/user-attachments/assets/576e35e0-2646-4fb0-9a7c-c7713df96e85)
   출금 기능
   1) 출금 창에서 정해진 금액으로 출금하거나 사용자가 원하는 금액으로 출금하는 기능이 구현되어 있습니다.
   2) 금액이 사용자의 계좌 잔액인 Balance보다 많으면 오류가 뜨고 출금되지 않습니다.
   3) 뒤로 가기 버튼을 누르면 출금 기능이 비활성화됩니다.

![스크린샷 2025-06-11 104924](https://github.com/user-attachments/assets/4423180f-8197-4d08-a756-84fb136fd746)
![스크린샷 2025-06-11 104914](https://github.com/user-attachments/assets/f4427b98-ec6a-47bf-a053-282cafbe9087)

   데이터 관리
   1) 처음 ATM서비스를 시작하면 데이터베이스를 불러옵니다.
   2) 회원가입 시 데이터베이스에 사용자의 정보가 저장되며 Cash 10000. balance는 50000이 지급됩니다.
   3) 입출금할 때 사용자의 정보가 데이터베이스에 저장됩니다.

![스크린샷 2025-06-11 104950](https://github.com/user-attachments/assets/2fb60b94-6e02-4a08-b0dd-b976ccd9c96a)
