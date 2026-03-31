pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build/Test/Publish') {
            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:8.0'
                    args '-u root:root'
                }
            }
            steps {
                sh 'dotnet --info'
                sh 'dotnet restore'
                sh 'dotnet build --no-restore'
                sh 'dotnet test --no-build --logger "trx;LogFileName=test-results.trx"'
                sh 'dotnet publish DemoApp/DemoApp.csproj -c Release -o publish'
            }
            post {
                always {
                    archiveArtifacts artifacts: 'publish/**', allowEmptyArchive: true
                    archiveArtifacts artifacts: '**/*.trx', allowEmptyArchive: true
                }
            }
        }
    }
}