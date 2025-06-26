# 🚀 Unity Game Development 환경 설정 가이드

이 문서는 Unity 게임 개발을 위한 완전한 개발 환경 설정 가이드입니다.

## 📋 목차 (Table of Contents)
1. [기본 설정](#1-기본-설정)
2. [GitHub 저장소 설정](#2-github-저장소-설정)
3. [Cursor AI 설정](#3-cursor-ai-설정)
4. [CodeRabbit 설정](#4-coderabbit-설정)
5. [개발 워크플로우](#5-개발-워크플로우)

## 1. 기본 설정

### 1.1 Unity 설치
1. [Unity Hub](https://unity.com/download) 다운로드 및 설치
2. Unity 6000.0.51f1 LTS 버전 설치
3. Cursor AI 설치 (이미 설치되어 있다면 생략)

### 1.2 Git 설정
```bash
# Git 전역 설정
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"

# Git LFS 초기화 (대용량 파일 관리용)
git lfs install
```

### 1.3 프로젝트 파일 확인
다음 파일들이 생성되었는지 확인하세요:
- ✅ `.gitignore` - Git 무시 파일 설정
- ✅ `.cursor/rules/cursorrules.mdc` - Cursor AI 코딩 규칙 (새로운 형식)
- ✅ `.github/coderabbit.yml` - CodeRabbit 설정 (형상관리 전용)
- ✅ `.gitattributes` - Git LFS 설정
- ✅ `README.md` - 프로젝트 문서
- ✅ `SETUP_GUIDE.md` - 설정 가이드

## 2. GitHub 저장소 설정

### 2.1 저장소 생성
1. GitHub에서 새 저장소 생성 완료: [Vampire_Survivors](https://github.com/cykim1228/Vampire_Survivors)
2. 저장소 이름: `Vampire_Survivors`
3. README 파일 추가하지 않음 (이미 있음)

### 2.2 로컬 저장소 연결
```bash
# 원격 저장소 추가
git remote add origin https://github.com/cykim1228/Vampire_Survivors.git

# 초기 커밋
git add .
git commit -m "feat: 초기 프로젝트 설정 및 개발 환경 구성"

# 메인 브랜치로 푸시
git branch -M main
git push -u origin main

# 개발 브랜치 생성
git checkout -b develop
git push -u origin develop
```

### 2.3 브랜치 보호 규칙 설정
GitHub 저장소 Settings > Branches에서:
1. `main` 브랜치 보호 규칙 추가
2. "Require pull request reviews before merging" 활성화
3. "Require status checks to pass before merging" 활성화

## 3. Cursor AI 설정

### 3.1 Cursor AI 설치 및 설정
1. [Cursor](https://www.cursor.com/) 다운로드 및 설치
2. 프로젝트 폴더에서 Cursor 실행
3. `.cursor/rules/cursorrules.mdc` 파일이 자동으로 적용됨 (Cursor AI 업데이트 반영)

### 3.2 Cursor AI 사용법
```typescript
// Cursor AI 활용 예시
// Ctrl+K: AI 코드 생성
// Ctrl+L: AI 챗
// Tab: AI 자동완성 수락
```

### 3.3 추천 Cursor AI 확장 프로그램
Unity 개발을 위한 확장 프로그램들:
- **C# Dev Kit** - C# 개발 지원
- **Unity Code Snippets** - Unity 코드 스니펫
- **Debugger for Unity** - Unity 디버깅
- **Unity Meta Files Watcher** - .meta 파일 관리

## 4. CodeRabbit 설정

### 4.1 CodeRabbit 계정 설정
1. [CodeRabbit](https://coderabbit.ai/) 회원가입
2. GitHub 계정 연동
3. 저장소 연결 승인

### 4.2 CodeRabbit GitHub App 설치
1. GitHub에서 CodeRabbit 앱 설치
2. 저장소 접근 권한 부여
3. `.github/coderabbit.yml` 설정 파일 확인

### 4.3 CodeRabbit 기능 활용
- **자동 코드 리뷰**: PR 생성 시 자동으로 리뷰 수행
- **Unity 특화 검사**: MonoBehaviour, SerializeField 등 Unity 특화 검사
- **성능 분석**: 메모리 할당, Update 메서드 최적화 등
- **한국어 지원**: 한국어/영어 혼용 리뷰

## 5. 개발 워크플로우

### 5.1 기능 개발 워크플로우
```bash
# 1. 새 기능 브랜치 생성
git checkout develop
git pull origin develop
git checkout -b feature/player-movement

# 2. 코드 작성 (Cursor AI 활용)
# 3. 커밋
git add .
git commit -m "feat(player): 플레이어 이동 시스템 구현"

# 4. 푸시
git push origin feature/player-movement

# 5. Pull Request 생성
# 6. CodeRabbit 리뷰 확인 및 피드백 반영
# 7. 팀 리뷰 후 병합
```

### 5.2 커밋 메시지 컨벤션
```bash
# 타입(스코프): 설명
feat(player): 새로운 플레이어 기능 추가
fix(ui): UI 버그 수정
docs(readme): 문서 업데이트
style(code): 코드 포매팅 수정
refactor(core): 코드 리팩토링
test(unit): 유닛 테스트 추가
chore(deps): 의존성 업데이트
```

### 5.3 코드 리뷰 체크리스트
- [ ] Unity 코딩 컨벤션 준수
- [ ] SerializeField 적절한 사용
- [ ] 메모리 할당 최적화
- [ ] null 체크 및 예외 처리
- [ ] 적절한 주석 포함
- [ ] 테스트 코드 작성

## 🎯 다음 단계

환경 설정이 완료되었다면:

1. **첫 번째 스크립트 작성**: PlayerController 스크립트 작성
2. **CodeRabbit 테스트**: Pull Request 생성 후 자동 리뷰 확인
3. **팀 협업 시작**: 브랜치 전략에 따른 협업 시작

## 🔧 문제 해결

### 자주 발생하는 문제들

#### Unity 프로젝트 열기 오류
```bash
# 해결방법: Unity 버전 불일치 시
# Unity Hub에서 Unity 6000.0.51f1 LTS 설치 확인
# 프로젝트 경로에 한글이나 특수문자가 없는지 확인
```

#### Git LFS 오류
```bash
# Git LFS 재설치
git lfs uninstall
git lfs install
git lfs track "*.png"
git lfs track "*.jpg"
```

#### CodeRabbit 리뷰 누락
- GitHub App 권한 확인
- `.github/coderabbit.yml` 파일 문법 검사
- 저장소 public/private 설정 확인

## 📞 지원

설정 과정에서 문제가 발생하면:
1. GitHub Issues에 문제 보고
2. 팀 Slack 채널에서 문의
3. 문서 업데이트 제안

---

**성공적인 Unity 게임 개발을 위한 환경이 준비되었습니다! 🎮✨** 