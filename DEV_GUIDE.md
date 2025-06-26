# 🎮 Vampire Survivors - 개발 워크플로우 가이드

이 문서는 [골드메탈 유튜브 강의](https://youtu.be/YAu4yWU5D5U?si=-QZ6hv3rZ_Ku1FDo)를 따라 진행하면서 효율적인 개발 환경을 구축하는 방법을 안내합니다.

## 📋 자동화된 개발 환경 개요

### ✅ 완료된 자동화 설정
- **develop 브랜치**: 메인 개발 브랜치 설정 완료
- **커밋 메시지 템플릿**: 일관된 커밋 메시지 가이드
- **Pull Request 템플릿**: 체계적인 PR 작성 가이드
- **CodeRabbit 리뷰**: 자동 코드 리뷰 시스템
- **개발 워크플로우 스크립트**: 반복 작업 자동화

## 🚀 빠른 시작 가이드

### 1. 새로운 기능 개발 시작

```powershell
# 1) 새 기능 브랜치 생성
.\scripts\dev-workflow.ps1 -Action feature -FeatureName "player-movement"

# 2) 코드 작성 후 커밋
.\scripts\dev-workflow.ps1 -Action commit

# 3) 브랜치 푸시
.\scripts\dev-workflow.ps1 -Action push

# 4) Pull Request 생성
.\scripts\dev-workflow.ps1 -Action pr
```

### 2. 일반적인 개발 워크플로우

```bash
# develop 브랜치에서 시작
git checkout develop
git pull origin develop

# 새 기능 브랜치 생성
git checkout -b feature/새기능명

# 코드 작성...

# 커밋 (템플릿 사용)
git add .
git commit

# 푸시 및 PR 생성
git push -u origin feature/새기능명
# GitHub에서 PR 생성
```

## 📝 커밋 메시지 가이드

### 커밋 메시지 템플릿 활용

프로젝트에 설정된 `.gitmessage` 템플릿을 사용하여 일관된 커밋 메시지를 작성하세요.

```bash
# 템플릿을 사용한 커밋
git commit

# 또는 직접 메시지 입력
git commit -m "feat(player): 플레이어 이동 시스템 구현"
```

### 커밋 타입별 예시

```bash
# 새로운 기능
feat(player): 플레이어 이동 시스템 구현

# 버그 수정
fix(enemy): 적 AI 경로 찾기 오류 수정

# 코드 리팩토링
refactor(weapon): 무기 시스템 클래스 구조 개선

# 문서 업데이트
docs(readme): 개발 환경 설정 가이드 추가

# 스타일/포맷 수정
style(player): 코드 포매팅 및 변수명 개선
```

## 📋 Pull Request 작성 가이드

### PR 생성 시 자동 적용 요소

`.github/PULL_REQUEST_TEMPLATE.md` 템플릿이 자동으로 적용되어 다음 정보를 포함합니다:

- **변경 사항**: 무엇을 변경했는지
- **테스트**: 어떻게 테스트했는지
- **체크리스트**: 코드 품질 확인 항목
- **CodeRabbit**: 자동 리뷰 상태

### PR 체크리스트

#### 🎯 기능 개발 시
- [ ] Unity 에디터에서 플레이 테스트 완료
- [ ] 기존 기능에 영향 없음 확인
- [ ] 새로운 기능 정상 동작 확인

#### 📝 코드 품질
- [ ] Cursor AI 규칙 준수
- [ ] Unity 코딩 컨벤션 준수
- [ ] XML 문서 주석 추가
- [ ] SerializeField 적절히 사용

#### ⚡ 성능 최적화
- [ ] Update 메서드 최적화
- [ ] GetComponent 호출 최소화
- [ ] 메모리 할당 최적화

## 🤖 CodeRabbit 자동 리뷰

### CodeRabbit 리뷰 프로세스

1. **PR 생성**: Pull Request 생성 시 자동으로 CodeRabbit 리뷰 시작
2. **Unity 특화 검사**: MonoBehaviour, SerializeField 등 Unity 관련 검사
3. **코드 품질 검사**: C# 컨벤션, SOLID 원칙 등 확인
4. **성능 분석**: 메모리, Update 메서드 등 성능 관련 피드백
5. **한국어 리뷰**: 한국어/영어 혼용 리뷰 제공

### CodeRabbit 피드백 대응

```bash
# 피드백 반영 후 커밋
git add .
git commit -m "style(player): CodeRabbit 피드백 반영 - 변수명 개선"
git push
```

## 🔄 브랜치 관리 전략

### 브랜치 구조
```
main
├── develop
    ├── feature/player-movement
    ├── feature/enemy-ai
    ├── feature/weapon-system
    └── feature/ui-health-bar
```

### 브랜치 네이밍 컨벤션
- **feature/기능명**: 새로운 기능 개발
- **fix/버그명**: 버그 수정
- **docs/문서명**: 문서 작업
- **refactor/리팩토링명**: 코드 리팩토링

### 예시
```bash
feature/player-movement       # 플레이어 이동 시스템
feature/enemy-spawning        # 적 스폰 시스템
fix/player-collision-bug      # 플레이어 충돌 버그 수정
docs/api-documentation        # API 문서 작성
refactor/weapon-architecture  # 무기 시스템 아키텍처 개선
```

## 🛠️ 개발 도구 설정

### 1. GitHub CLI 설치 (선택사항)

```powershell
# winget을 통한 설치
winget install GitHub.cli

# 인증
gh auth login
```

### 2. 추천 VS Code 확장 프로그램

Unity 개발에 유용한 확장 프로그램들:
- **C# Dev Kit**: C# 개발 지원
- **Unity Code Snippets**: Unity 코드 스니펫
- **GitLens**: Git 히스토리 및 정보 표시
- **Prettier**: 코드 포매팅

## 📚 골드메탈 강의 진행 가이드

### 강의 진행 시 권장 워크플로우

1. **강의 섹션별 브랜치 생성**
   ```bash
   .\scripts\dev-workflow.ps1 -Action feature -FeatureName "lecture-01-player-setup"
   ```

2. **강의 내용 구현 후 커밋**
   ```bash
   .\scripts\dev-workflow.ps1 -Action commit -Message "feat(player): 1강 - 플레이어 기본 설정"
   ```

3. **섹션 완료 시 PR 생성**
   ```bash
   .\scripts\dev-workflow.ps1 -Action pr
   ```

### 강의별 브랜치 예시
```bash
feature/lecture-01-player-setup      # 1강: 플레이어 설정
feature/lecture-02-player-movement   # 2강: 플레이어 이동
feature/lecture-03-enemy-spawning    # 3강: 적 스폰
feature/lecture-04-collision         # 4강: 충돌 처리
```

## 🎯 코드 품질 유지

### Cursor AI 규칙 자동 적용

- `.cursor/rules/cursorrules.mdc` 파일이 자동으로 적용
- Unity 특화 코딩 컨벤션 가이드
- SOLID 원칙 및 성능 최적화 가이드

### 정기적인 코드 품질 체크

```bash
# develop 브랜치와 동기화
.\scripts\dev-workflow.ps1 -Action sync

# 완료된 브랜치 정리
.\scripts\dev-workflow.ps1 -Action clean
```

## 🚨 주의사항

### 금지 사항
- **main/develop 브랜치에 직접 푸시 금지**
- **대용량 바이너리 파일 커밋 금지** (Git LFS 사용)
- **개인 설정 파일 커밋 금지** (.gitignore로 관리)

### 권장 사항
- **작은 단위로 자주 커밋**
- **의미 있는 커밋 메시지 작성**
- **PR 생성 전 자체 테스트 수행**
- **CodeRabbit 피드백 적극 반영**

## 🔧 문제 해결

### 자주 발생하는 문제들

#### 1. 스크립트 실행 정책 오류
```powershell
# PowerShell 실행 정책 변경
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
```

#### 2. Git 충돌 해결
```bash
# develop과 동기화
git checkout develop
git pull origin develop
git checkout feature/브랜치명
git rebase develop

# 충돌 해결 후
git add .
git rebase --continue
```

#### 3. CodeRabbit 리뷰 누락
- PR이 draft 상태인지 확인
- `.github/coderabbit.yml` 설정 확인
- GitHub App 권한 확인

## 📞 추가 지원

문제가 발생하면:
1. **GitHub Issues**: 버그 리포트 및 기능 요청
2. **Pull Request**: 개선 사항 제안
3. **문서 업데이트**: DEV_GUIDE.md 개선 제안

---

**Happy Coding! 🎮✨**

*이 가이드는 골드메탈의 뱀서라이크 강의를 효율적으로 진행하면서 체계적인 개발 환경을 유지하기 위해 작성되었습니다.* 