# 🎮 Vampire Survivors - Development Workflow Automation
# 개발 워크플로우 자동화 스크립트

param(
    [Parameter(Mandatory=$true)]
    [string]$Action,
    
    [Parameter(Mandatory=$false)]
    [string]$FeatureName,
    
    [Parameter(Mandatory=$false)]
    [string]$Message
)

# 색상 출력 함수
function Write-ColorOutput($ForegroundColor) {
    $fc = $host.UI.RawUI.ForegroundColor
    $host.UI.RawUI.ForegroundColor = $ForegroundColor
    if ($args) {
        Write-Output $args
    }
    $host.UI.RawUI.ForegroundColor = $fc
}

# 배너 출력
Write-ColorOutput Green "🎮 Vampire Survivors - Development Workflow"
Write-ColorOutput Green "============================================"

switch ($Action.ToLower()) {
    "feature" {
        if (-not $FeatureName) {
            Write-ColorOutput Red "❌ 오류: 기능 이름을 입력해주세요"
            Write-ColorOutput Yellow "사용법: .\dev-workflow.ps1 -Action feature -FeatureName 기능명"
            exit 1
        }
        
        $branchName = "feature/$FeatureName"
        Write-ColorOutput Yellow "🌿 새로운 기능 브랜치 생성: $branchName"
        
        # develop 브랜치로 이동
        git checkout develop
        git pull origin develop
        
        # 새 기능 브랜치 생성
        git checkout -b $branchName
        
        Write-ColorOutput Green "✅ 기능 브랜치 '$branchName' 생성 완료!"
        Write-ColorOutput Cyan "📝 이제 코드를 작성하고 커밋해주세요."
    }
    
    "commit" {
        Write-ColorOutput Yellow "📝 스마트 커밋 시작..."
        
        # 변경사항 확인
        $status = git status --porcelain
        if (-not $status) {
            Write-ColorOutput Red "❌ 커밋할 변경사항이 없습니다."
            exit 1
        }
        
        # 변경된 파일 표시
        Write-ColorOutput Cyan "📁 변경된 파일들:"
        git status --short
        
        # 모든 변경사항 스테이지
        git add .
        
        # 커밋 메시지 자동 생성 또는 사용자 입력
        if ($Message) {
            git commit -m $Message
        } else {
            # 템플릿 사용하여 커밋
            git commit
        }
        
        Write-ColorOutput Green "✅ 커밋 완료!"
    }
    
    "push" {
        Write-ColorOutput Yellow "🚀 브랜치 푸시 및 PR 준비..."
        
        # 현재 브랜치 이름 가져오기
        $currentBranch = git rev-parse --abbrev-ref HEAD
        
        # develop 브랜치에서는 푸시하지 않음
        if ($currentBranch -eq "develop" -or $currentBranch -eq "main") {
            Write-ColorOutput Red "❌ main/develop 브랜치에서는 직접 푸시할 수 없습니다."
            Write-ColorOutput Yellow "💡 feature 브랜치를 사용해주세요: .\dev-workflow.ps1 -Action feature -FeatureName 기능명"
            exit 1
        }
        
        # 리모트에 푸시
        git push -u origin $currentBranch
        
        Write-ColorOutput Green "✅ 브랜치 푸시 완료!"
        Write-ColorOutput Cyan "🔗 GitHub에서 Pull Request를 생성해주세요:"
        Write-ColorOutput Cyan "   https://github.com/cykim1228/Vampire_Survivors/compare/$currentBranch"
    }
    
    "pr" {
        Write-ColorOutput Yellow "📝 Pull Request 생성 중..."
        
        # GitHub CLI 확인
        $ghExists = Get-Command gh -ErrorAction SilentlyContinue
        if (-not $ghExists) {
            Write-ColorOutput Red "❌ GitHub CLI (gh)가 설치되지 않았습니다."
            Write-ColorOutput Yellow "📥 설치: winget install GitHub.cli"
            Write-ColorOutput Cyan "🔗 수동으로 PR 생성: https://github.com/cykim1228/Vampire_Survivors/pulls"
            exit 1
        }
        
        # 현재 브랜치 이름 가져오기
        $currentBranch = git rev-parse --abbrev-ref HEAD
        
        # PR 제목 생성
        $prTitle = $currentBranch -replace "feature/", "✨ " -replace "fix/", "🐛 " -replace "docs/", "📝 "
        
        # Pull Request 생성
        gh pr create --title $prTitle --base develop --head $currentBranch --fill
        
        Write-ColorOutput Green "✅ Pull Request 생성 완료!"
        Write-ColorOutput Cyan "🤖 CodeRabbit이 자동으로 리뷰를 시작합니다."
    }
    
    "sync" {
        Write-ColorOutput Yellow "🔄 develop 브랜치와 동기화..."
        
        # 현재 브랜치 저장
        $currentBranch = git rev-parse --abbrev-ref HEAD
        
        # develop 업데이트
        git checkout develop
        git pull origin develop
        
        # 원래 브랜치로 돌아가서 rebase
        if ($currentBranch -ne "develop") {
            git checkout $currentBranch
            git rebase develop
        }
        
        Write-ColorOutput Green "✅ 동기화 완료!"
    }
    
    "clean" {
        Write-ColorOutput Yellow "🧹 완료된 브랜치 정리..."
        
        # 머지된 브랜치 확인
        $mergedBranches = git branch --merged develop | Where-Object { $_ -notmatch "(develop|main|\*)" }
        
        if ($mergedBranches) {
            Write-ColorOutput Cyan "🗑️ 삭제할 브랜치들:"
            $mergedBranches | ForEach-Object { Write-ColorOutput Gray "  $_" }
            
            $confirm = Read-Host "정말 삭제하시겠습니까? (y/N)"
            if ($confirm -eq "y" -or $confirm -eq "Y") {
                $mergedBranches | ForEach-Object { git branch -d $_.Trim() }
                Write-ColorOutput Green "✅ 브랜치 정리 완료!"
            }
        } else {
            Write-ColorOutput Green "✅ 정리할 브랜치가 없습니다."
        }
    }
    
    "help" {
        Write-ColorOutput Cyan @"
📚 개발 워크플로우 명령어 가이드

🌿 새 기능 시작:
   .\dev-workflow.ps1 -Action feature -FeatureName "player-movement"

📝 스마트 커밋:
   .\dev-workflow.ps1 -Action commit
   .\dev-workflow.ps1 -Action commit -Message "feat(player): 이동 시스템 구현"

🚀 브랜치 푸시:
   .\dev-workflow.ps1 -Action push

📝 Pull Request 생성:
   .\dev-workflow.ps1 -Action pr

🔄 develop과 동기화:
   .\dev-workflow.ps1 -Action sync

🧹 완료된 브랜치 정리:
   .\dev-workflow.ps1 -Action clean

📚 도움말:
   .\dev-workflow.ps1 -Action help
"@
    }
    
    default {
        Write-ColorOutput Red "❌ 알 수 없는 액션: $Action"
        Write-ColorOutput Yellow "💡 사용 가능한 액션: feature, commit, push, pr, sync, clean, help"
        Write-ColorOutput Cyan "📚 도움말: .\dev-workflow.ps1 -Action help"
    }
} 