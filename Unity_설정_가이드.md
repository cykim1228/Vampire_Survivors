# 🎮 Unity에서 Cursor/VS Code 자동완성 설정 가이드

## 🛠️ Unity 에디터 설정

### 1. Unity에서 External Script Editor 설정

1. **Unity 에디터 열기**
2. **Edit → Preferences** (Windows) 또는 **Unity → Preferences** (Mac)
3. **External Tools** 탭 선택
4. **External Script Editor**를 다음 중 하나로 설정:
   - `C:\Users\사용자명\AppData\Local\Programs\cursor\Cursor.exe` (Cursor)
   - 또는 VS Code 경로

### 2. Unity 프로젝트 설정

1. **Edit → Project Settings**
2. **Player** 섹션 선택
3. **Configuration** 에서:
   - **Scripting Backend**: IL2CPP (추천)
   - **Api Compatibility Level**: .NET Framework (또는 .NET Standard 2.1)

### 3. Unity에서 프로젝트 파일 재생성

프로젝트 파일들이 제대로 생성되지 않았을 수 있습니다:

1. **Assets → Open C# Project** 클릭
2. 또는 **Edit → Preferences → External Tools → Regenerate project files** 클릭

## 🔧 문제 해결

### 자동완성이 여전히 안 되는 경우

#### 방법 1: Cursor/VS Code 재시작
1. Cursor 완전 종료
2. Unity 에디터에서 `Assets → Open C# Project`
3. 프로젝트가 다시 열리면서 IntelliSense 로딩 대기

#### 방법 2: 솔루션 파일 다시 로드
1. **Ctrl+Shift+P** (명령 팔레트)
2. **".NET: Reload Projects"** 검색 후 실행
3. 또는 **"Developer: Reload Window"**

#### 방법 3: Unity에서 프로젝트 파일 재생성
```
Unity 에디터에서:
Assets → Open C# Project 클릭
```

#### 방법 4: 수동으로 솔루션 파일 열기
1. Windows 탐색기에서 프로젝트 폴더 열기
2. `Vampire Survivors.sln` 파일을 Cursor로 열기

### 확인 방법

자동완성이 제대로 작동하는지 확인:

1. **Player.cs** 파일 열기
2. `GetComponent` 타이핑 시작
3. 자동완성 리스트에 다음이 보여야 함:
   ```csharp
   GetComponent<T>()
   GetComponentInChildren<T>()
   GetComponentInParent<T>()
   GetComponents<T>()
   ```

## 💡 추가 팁

### IntelliSense 로딩 확인
- VS Code/Cursor 하단 상태 표시줄에서 C# 로딩 상태 확인
- "C# Projects loaded" 메시지가 나타날 때까지 대기

### 네임스페이스 자동 추가
- `using UnityEngine;` 등이 자동으로 추가되는지 확인
- 없다면 파일 상단에 수동 추가:
  ```csharp
  using UnityEngine;
  using System.Collections;
  using System.Collections.Generic;
  ```

### 빠른 테스트 방법
다음 코드를 입력해보세요:
```csharp
public class TestAutoComplete : MonoBehaviour
{
    void Start()
    {
        // 여기서 'GetComponent'를 타이핑하면 자동완성이 나와야 함
        var rb = GetComponent<Rigidbody2D>();
        
        // 'transform'을 타이핑하면 Transform 관련 메서드들이 나와야 함
        transform.position = Vector3.zero;
    }
}
```

## 🎯 최종 체크리스트

- [ ] Unity External Script Editor가 Cursor로 설정됨
- [ ] .vscode/settings.json에 Unity 설정 추가됨
- [ ] C# Dev Kit 확장 프로그램 설치됨
- [ ] 솔루션 파일(.sln)이 존재함
- [ ] Cursor에서 GetComponent 자동완성 작동
- [ ] using 문 자동 추가 작동

모든 항목이 체크되면 Unity 개발 환경이 완벽하게 설정된 것입니다! 🎉 