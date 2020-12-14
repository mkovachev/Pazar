pipeline {
  agent any
  stages {
    stage('Verify Branch') {
      steps {
        echo "$GIT_BRANCH"
      }
    }
    stage('Run Unit Tests') {
      steps {
        powershell(script: """ 
          cd Server
          dotnet test
          cd ..
        """)
      }
    }
    stage('Docker Build') {
      steps {
        powershell(script: 'docker-compose build')
        powershell(script: 'docker images -a')
      }
    }
    stage('Run Test Application') {
      steps {
        powershell(script: 'docker-compose up -d')
        powershell(script: 'docker rmi $(docker images -f "dangling=true" -q)')
      }
    }
    stage('Run Integration Tests') {
      steps {
        powershell(script: './Tests/ContainerTests.ps1') 
      }
    }
    stage('Stop Test Application') {
      steps {
        powershell(script: 'docker-compose down') 
        // powershell(script: 'docker volumes prune -f')
      }
      post {
        success {
          echo "Build successfull! You should deploy! :)"
        }
        failure {
          echo "Build failed! You should receive an e-mail! :("
        }
      }
    }
    stage('Push Images') {
      when { branch 'main' }
      steps {
        script {
          docker.withRegistry('https://index.docker.io/v1/', 'Dockerhub') {
            def identity = docker.image("mkovachev/pazar-identity")
            identity.push("1.0.${env.BUILD_ID}")
            identity.push('latest')
            def ads = docker.image("mkovachev/pazar-ads")
            ads.push("1.0.${env.BUILD_ID}")
            ads.push('latest')
            def notifications = docker.image("mkovachev/pazar-notifications")
            notifications.push("1.0.${env.BUILD_ID}")
            notifications.push('latest')
            def statistics = docker.image("mkovachev/pazar-statistics")
            statistics.push("1.0.${env.BUILD_ID}")
            statistics.push('latest')
            def watchdog = docker.image("mkovachev/pazar-watchdog")
            watchdog.push("1.0.${env.BUILD_ID}")
            watchdog.push('latest')
            def client = docker.image("mkovachev/pazar-client")
            client.push("1.0.${env.BUILD_ID}")
            client.push('latest')
          }
        }
      }
    }
  }
}
