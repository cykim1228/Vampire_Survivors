# 🎮 Vampire Survivors - 개발 가이드

이 문서는 [골드메탈 유튜브 강의](https://www.youtube.com/playlist?list=PLO-mt5Iu5TeZF8xMHqtT_DhAPKmjF6i3x)를 따라 진행하면서 GitHub Desktop을 이용한 간단한 개발 환경을 안내합니다.

## 📋 개발 환경 개요

### ✅ 설정 완료된 항목
- **develop 브랜치**: 메인 개발 브랜치 설정 완료
- **Pull Request 템플릿**: 체계적인 PR 작성 가이드
- **CodeRabbit 리뷰**: 자동 코드 리뷰 시스템
- **Cursor AI 규칙**: Unity 코딩 컨벤션 자동 적용

## 🚀 GitHub Desktop 워크플로우

### 1. 기본 개발 흐름

```
1) 코드 수정
   ↓
2) GitHub Desktop에서 Changes 확인
   ↓
3) 커밋 메시지 작성 후 "Commit to develop"
   ↓
4) "Push origin" 클릭
   ↓
5) GitHub 웹에서 Pull Request 생성 (필요시)
```

### 2. 커밋 메시지 작성 가이드

GitHub Desktop에서 커밋할 때 이런 형식으로 작성해주세요:

#### 🎯 기본 형식
```
타입(스코프): 간단한 설명

상세 설명 (선택사항)
```

#### 📝 예시들
```
feat(player): 1강 - 플레이어 이동 시스템 구현

fix(enemy): 적 스폰 위치 오류 수정

docs(readme): 개발 환경 설정 가이드 추가

style(player): 코드 포매팅 및 변수명 개선
```

#### 🏷️ 커밋 타입
- **feat**: 새로운 기능 추가
- **fix**: 버그 수정
- **docs**: 문서 수정
- **style**: 코드 포매팅 (기능 변경 없음)
- **refactor**: 코드 리팩토링
- **test**: 테스트 코드
- **chore**: 빌드 도구, 설정 변경

#### 🎮 스코프 예시
- **player**: 플레이어 관련
- **enemy**: 적 관련
- **weapon**: 무기 시스템
- **ui**: 사용자 인터페이스
- **audio**: 오디오 시스템

### 3. Pull Request 생성

#### 언제 PR을 만들까요?
- **강의 몇 강 완료 시마다** (예: 3-4강마다)
- **큰 기능 완성 시** (예: 플레이어 시스템 완료)
- **버그 수정 완료 시**

#### PR 생성 방법
1. **GitHub Desktop에서 푸시 후**
2. **GitHub 웹사이트로 이동**
3. **"Compare & pull request" 버튼 클릭**
4. **자동으로 템플릿이 적용됨** - 체크리스트 확인 후 작성
5. **"Create pull request" 클릭**
6. **CodeRabbit이 자동으로 코드 리뷰 시작** 🤖

## 📋 Pull Request 체크리스트

PR 생성 시 자동으로 나타나는 템플릿에서 확인할 항목들:

### 🧪 테스트 완료 항목
- [ ] Unity 에디터에서 플레이 테스트 완료
- [ ] 빌드 오류 없음 확인
- [ ] 기존 기능 정상 동작 확인
- [ ] 새로운 기능 정상 동작 확인

### 📝 코드 품질
- [ ] Cursor AI 규칙 준수
- [ ] Unity 코딩 컨벤션 준수
- [ ] 적절한 주석 추가
- [ ] SerializeField 적절히 사용

### ⚡ 성능
- [ ] Update 메서드 최적화
- [ ] GetComponent 호출 최소화
- [ ] 메모리 할당 최적화

## 🤖 CodeRabbit 자동 리뷰

### 리뷰 프로세스
1. **PR 생성** → CodeRabbit 자동 리뷰 시작
2. **Unity 특화 검사**: MonoBehaviour, SerializeField 등
3. **코드 품질 검사**: C# 컨벤션, SOLID 원칙
4. **성능 분석**: 메모리, Update 메서드 최적화
5. **한국어 리뷰**: 이해하기 쉬운 피드백

### 피드백 대응
CodeRabbit 피드백을 받으면:
1. **코드 수정**
2. **GitHub Desktop에서 다시 커밋**
3. **자동으로 PR 업데이트됨**

## 📚 골드메탈 강의 진행 가이드

### 추천 커밋 패턴

#### 강의별 커밋 예시
```
feat(player): 1강 - 플레이어 오브젝트 생성 및 기본 설정
feat(player): 2강 - 플레이어 이동 시스템 구현  
feat(enemy): 3강 - 적 캐릭터 생성 및 기본 AI
feat(weapon): 4강 - 무기 시스템 기초 구현
```

#### 섹션별 PR 생성
```
PR #1: 플레이어 시스템 기초 (1-3강)
PR #2: 적 시스템 구현 (4-6강)  
PR #3: 무기 시스템 구현 (7-9강)
```

### 브랜치 전략 (선택사항)

**간단하게 develop 브랜치에서 작업하거나, 필요시 기능별 브랜치 생성:**

#### develop 브랜치에서 직접 작업 (추천)
```
develop 브랜치에서 모든 작업 → 커밋 → 푸시 → PR 생성
```

#### 기능별 브랜치 (더 체계적)
```bash
# GitHub Desktop에서 "New branch" 클릭
feature/player-system     # 플레이어 관련 기능들
feature/enemy-system      # 적 관련 기능들
feature/weapon-system     # 무기 관련 기능들
```

## 🎯 간단 요약

### 일상적인 개발 흐름
1. **코드 수정** (골드메탈 강의 따라하기)
2. **GitHub Desktop 열기**
3. **Changes 탭에서 수정 사항 확인**
4. **커밋 메시지 작성** (`feat(player): 설명`)
5. **"Commit to develop" 클릭**
6. **"Push origin" 클릭**
7. **몇 강마다 GitHub에서 PR 생성**

### CodeRabbit의 도움
- **자동 코드 리뷰**: PR 생성 시 자동으로 리뷰 시작
- **Unity 특화**: MonoBehaviour, SerializeField 등 Unity 관련 체크
- **한국어 피드백**: 이해하기 쉬운 개선 제안

## 🚨 주의사항

### 금지 사항
- **대용량 파일 커밋 금지** (Git LFS 자동 처리됨)
- **개인 설정 파일 커밋 금지** (.gitignore로 자동 제외)

### 권장 사항
- **작은 단위로 자주 커밋**
- **의미 있는 커밋 메시지 작성**
- **PR 생성 전 Unity에서 테스트**

---
