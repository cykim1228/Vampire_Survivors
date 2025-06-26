# 🧛 Vampire Survivors - Unity Game Development

Unity 엔진을 사용하여 개발하는 뱀파이어 서바이버즈 스타일 게임 프로젝트입니다.

## 📋 프로젝트 개요 (Project Overview)

이 프로젝트는 Unity 엔진과 Cursor AI를 활용하여 고품질의 액션 생존 게임을 개발하는 것을 목표로 합니다.

### 🎮 게임 특징 (Game Features)
- 무한 스테이지 생존 게임플레이
- 다양한 캐릭터와 무기 시스템
- 업그레이드 및 진화 시스템
- 아름답고 최적화된 2D 그래픽

### 🛠️ 개발 환경 (Development Environment)
- **엔진**: Unity 6000.0.51f1 LTS
- **언어**: C#
- **IDE**: Cursor AI
- **버전 관리**: Git & GitHub
- **CI/CD**: GitHub Actions
- **코드 리뷰**: CodeRabbit

## 🚀 시작하기 (Getting Started)

### 필수 요구사항 (Prerequisites)
- Unity 6000.0.51f1 LTS
- Cursor AI
- Git
- .NET 6.0 이상

### 설치 및 실행 (Installation & Running)

1. 저장소 클론
```bash
git clone https://github.com/cykim1228/Vampire_Survivors.git
cd Vampire_Survivors
```

2. Unity Hub에서 프로젝트 열기
   - Unity Hub를 실행
   - "Open" 버튼 클릭
   - 프로젝트 폴더 선택

3. Package Manager 의존성 확인
   - Unity Editor에서 Window > Package Manager 열기
   - 필요한 패키지들이 자동으로 설치되는지 확인

## 📁 프로젝트 구조 (Project Structure)

```
Assets/
├── Scripts/           # C# 스크립트
│   ├── Player/       # 플레이어 관련 스크립트
│   ├── Enemies/      # 적 관련 스크립트
│   ├── Weapons/      # 무기 시스템 스크립트
│   ├── UI/           # UI 관련 스크립트
│   ├── Managers/     # 게임 매니저들
│   └── Utils/        # 유틸리티 스크립트
├── Prefabs/          # 게임 오브젝트 프리팹
├── Sprites/          # 2D 스프라이트 이미지
├── Audio/            # 오디오 파일들
├── Animations/       # 애니메이션 클립
├── Materials/        # 머티리얼
├── Scenes/           # Unity 씬 파일들
└── Tests/            # 테스트 스크립트
```

## 💻 개발 가이드라인 (Development Guidelines)

### 코딩 컨벤션 (Coding Conventions)
프로젝트의 코딩 컨벤션은 `.cursor/rules/cursorrules.mdc` 파일에 정의되어 있습니다.

주요 규칙:
- **클래스명**: PascalCase (예: `PlayerController`)
- **메서드명**: PascalCase (예: `MovePlayer`)
- **변수명**: camelCase (예: `playerHealth`)
- **프라이빗 필드**: 언더스코어 접두사 (예: `_health`)

### Git 워크플로우 (Git Workflow)
- **main**: 배포 가능한 안정 버전
- **develop**: 개발 중인 기능들의 통합 브랜치
- **feature/기능명**: 새로운 기능 개발 브랜치
- **bugfix/버그명**: 버그 수정 브랜치

### 커밋 메시지 규칙 (Commit Message Convention)
```
타입(scope): 설명

예시:
feat(player): 플레이어 이동 시스템 구현
fix(ui): 체력바 표시 오류 수정
docs(readme): 프로젝트 설명 업데이트
```

## 🤖 코드 품질 관리 (Code Quality Management)

Cursor AI와 CodeRabbit을 활용하여 코드 품질을 관리합니다.

### 코드 품질 도구
- ✅ Cursor AI 코딩 컨벤션 자동 적용
- ✅ CodeRabbit 자동 코드 리뷰
- ✅ Unity 특화 코드 품질 검사
- ✅ 형상관리 기반 협업

## 🤖 CodeRabbit 설정 (CodeRabbit Configuration)

CodeRabbit이 다음 항목들을 자동으로 검토합니다:

### Unity 특화 검토 항목
- MonoBehaviour 사용법
- SerializeField 사용 적절성
- Unity 라이프사이클 메서드 최적화
- 메모리 할당 최적화
- Object Pooling 사용

### 일반 코드 품질
- C# 코딩 컨벤션
- SOLID 원칙 준수
- 에러 핸들링
- 성능 최적화

## 📊 성능 최적화 (Performance Optimization)

### 메모리 관리
- Object Pooling 패턴 사용
- string 대신 StringBuilder 사용
- 불필요한 메모리 할당 최소화

### 렌더링 최적화
- Sprite Atlas 사용
- Batching 최적화
- LOD (Level of Detail) 시스템

## 🧪 테스트 (Testing)

### 유닛 테스트
```bash
# Unity Test Runner를 통한 테스트 실행
Unity Editor > Window > General > Test Runner
```

### 플레이 테스트
- 정기적인 플레이 테스트 세션
- 성능 프로파일링
- 사용자 피드백 수집

## 📝 문서화 (Documentation)

### 코드 문서화
- XML 문서 주석 사용
- 복잡한 로직에 대한 상세 설명
- API 문서 자동 생성

### 게임 디자인 문서
- 게임플레이 메커니즘
- 밸런싱 가이드라인
- 아트 스타일 가이드

## 🤝 기여하기 (Contributing)

1. 이슈 생성 또는 기존 이슈 확인
2. feature 브랜치 생성
3. 변경사항 구현
4. 테스트 작성 및 실행
5. Pull Request 생성
6. CodeRabbit 리뷰 확인 및 피드백 반영
7. 팀 리뷰 후 병합

## 📄 라이선스 (License)

이 프로젝트는 MIT 라이선스 하에 배포됩니다. 자세한 내용은 [LICENSE](LICENSE) 파일을 확인하세요.

## 📞 연락처 (Contact)

프로젝트에 대한 질문이나 제안사항이 있으시면 이슈를 생성해 주세요.

---

**Happy Coding! 🎮✨** 